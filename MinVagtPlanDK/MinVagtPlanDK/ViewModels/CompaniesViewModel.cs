using System;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using System.Linq;
using Xamarin.Forms;
using Flurl.Http;
using MinVagtPlanDK.Services;
using MinVagtPlanDK.Models;
using MinVagtPlanDK.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Newtonsoft.Json;

namespace MinVagtPlanDK.ViewModels
{
    public class CompaniesViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Company> AllCompanies { get; set; }
        public AsyncCommand<Company> ItemTapped { get; }

        public CompaniesViewModel()
        {
            Title = "Arbejdsgivere";

            AllCompanies = new ObservableRangeCollection<Company>();
            ItemTapped = new AsyncCommand<Company>(OnCompanySelected);

            LoadCompanies();
        }

        void LoadCompanies()
        {
            IsBusy = true;

            try
            {
                var shiftsJSONString = "https://api.minsmartevagtplan.dk/api/companies/get-all".WithHeader("Accept", "application/json").WithHeader("Content-Type", "application/json").WithHeader("Authorization", Authenticator.GetAuthKey()).GetStringAsync().Result;
                var result = JsonConvert.DeserializeObject<AllCompaniesResult>(shiftsJSONString);
                AllCompanies.AddRange(result.data);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task OnCompanySelected(Company company)
        {
            if (company == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            Shell.Current.GoToAsync($"{nameof(CompanyDetailPage)}?{nameof(CompanyDetailViewModel.CompanyId)}={company.id}");
        }
    }
}
