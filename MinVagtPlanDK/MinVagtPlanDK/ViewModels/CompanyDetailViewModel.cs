using Flurl.Http;
using MinVagtPlanDK.Models;
using MinVagtPlanDK.Services;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MinVagtPlanDK.ViewModels
{
    [QueryProperty(nameof(CompanyId), nameof(CompanyId))]
    public class CompanyDetailViewModel : BaseViewModel
    {
        private string companyId;
        private Company company;

        public Company _Company
        {
            get => company;
            set => SetProperty(ref company, value);
        }

        public string CompanyId
        {
            get
            {
                return companyId;
            }
            set
            {
                companyId = value;
                LoadCompany(value);
            }
        }

        public async void LoadCompany(string _companyId)
        {
            try
            {
                string apiCallString = "https://api.minsmartevagtplan.dk/api/companies/single/" + _companyId;
                var shiftsJSONString = apiCallString.WithHeader("Accept", "application/json").WithHeader("Content-Type", "application/json").WithHeader("Authorization", Authenticator.GetAuthKey()).GetStringAsync().Result;
                var result = JsonConvert.DeserializeObject<SingleCompanyResult>(shiftsJSONString);

                _Company = result.data;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
