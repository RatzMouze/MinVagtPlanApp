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
    public class ScheduleViewModel : BaseViewModel
    {
        private int lastMonthCounter = 0;
        private int nextMonthCounter = 0;

        public ObservableRangeCollection<Shift> AllShifts { get; set; }
        public ObservableRangeCollection<Grouping<string, Shift>> ShiftGroups { get; }
        public AsyncCommand LoadPreviousMonthCommand { get; }
        public AsyncCommand LoadNextMonthCommand { get; }
        public AsyncCommand<Shift> ItemTapped { get; }
        public AsyncCommand LogoutCommand { get; }

        public ScheduleViewModel()
        {
            Title = "Skema";

            AllShifts = new ObservableRangeCollection<Shift>();
            ShiftGroups = new ObservableRangeCollection<Grouping<string, Shift>>();

            LoadPreviousMonthCommand = new AsyncCommand(LoadPreviousMonth);
            LoadNextMonthCommand = new AsyncCommand(LoadNextMonth);
            ItemTapped = new AsyncCommand<Shift>(OnShiftSelected);
            LogoutCommand = new AsyncCommand(Logout);

            LoadSchedule();
        }

        void LoadSchedule()
        {
            IsBusy = true;

            try
            {
                var shiftsJSONString = "https://api.minsmartevagtplan.dk/api/shifts/get-all".WithHeader("Accept", "application/json").WithHeader("Content-Type", "application/json").WithHeader("Authorization", Authenticator.GetAuthKey()).GetStringAsync().Result;
                var result = JsonConvert.DeserializeObject<AllShiftsResult>(shiftsJSONString);
                AllShifts.AddRange(result.data);

                foreach (Shift shift in AllShifts)
                {
                    shift.groupingString = shift.start_time.ToString("MMMM yyyy");
                }

                string groupingString = DateTime.Now.ToString("MMMM yyyy");
                ShiftGroups.Add(new Grouping<string, Shift>(groupingString, AllShifts.Where(s => groupingString == s.groupingString)));
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

        async Task LoadPreviousMonth()
        {
            IsBusy = true;

            lastMonthCounter--;

            string groupingString = DateTime.Now.AddMonths(lastMonthCounter).ToString("MMMM yyyy");
            ShiftGroups.Insert(0, new Grouping<string, Shift>(groupingString, AllShifts.Where(s => groupingString == s.groupingString)));
            OnPropertyChanged();
            IsBusy = false;
        }

        async Task LoadNextMonth()
        {
            IsBusy = true;

            nextMonthCounter++;

            string groupingString = DateTime.Now.AddMonths(nextMonthCounter).ToString("MMMM yyyy");
            ShiftGroups.Add(new Grouping<string, Shift>(groupingString, AllShifts.Where(s => groupingString == s.groupingString)));
            OnPropertyChanged();
            IsBusy = false;
        }

        async Task OnShiftSelected(Shift shift)
        {
            if (shift == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            Shell.Current.GoToAsync($"{nameof(ShiftDetailPage)}?{nameof(ShiftDetailViewModel.ShiftId)}={shift.id}");
        }

        async Task Logout()
        {
            Authenticator.RemoveAuthKey();
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}