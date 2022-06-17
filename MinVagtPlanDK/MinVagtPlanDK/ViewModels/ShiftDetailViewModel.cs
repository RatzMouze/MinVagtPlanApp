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
    [QueryProperty(nameof(ShiftId), nameof(ShiftId))]
    public class ShiftDetailViewModel : BaseViewModel
    {
        private string shiftId;
        private Shift shift;

        public Shift _Shift
        {
            get => shift;
            set => SetProperty(ref shift, value);
        }

        public string ShiftId
        {
            get
            {
                return shiftId;
            }
            set
            {
                shiftId = value;
                LoadShift(value);
            }
        }

        public async void LoadShift(string _shiftId)
        {
            try
            {
                string apiCallString = "https://api.minsmartevagtplan.dk/api/shifts/single/" + _shiftId;
                var shiftsJSONString = apiCallString.WithHeader("Accept", "application/json").WithHeader("Content-Type", "application/json").WithHeader("Authorization", Authenticator.GetAuthKey()).GetStringAsync().Result;
                var result = JsonConvert.DeserializeObject<SingleShiftResult>(shiftsJSONString);

                _Shift = result.data;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
