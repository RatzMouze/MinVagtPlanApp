using MinVagtPlanDK.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MinVagtPlanDK.Views
{
    public partial class ShiftDetailPage : ContentPage
    {
        public ShiftDetailPage()
        {
            InitializeComponent();
            BindingContext = new ShiftDetailViewModel();
        }
    }
}