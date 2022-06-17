using MinVagtPlanDK.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MinVagtPlanDK.Views
{
    public partial class CompanyDetailPage : ContentPage
    {
        public CompanyDetailPage()
        {
            InitializeComponent();
            BindingContext = new CompanyDetailViewModel();
        }
    }
}