using MinVagtPlanDK.ViewModels;
using MinVagtPlanDK.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MinVagtPlanDK
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ShiftDetailPage), typeof(ShiftDetailPage));
            Routing.RegisterRoute(nameof(CompanyDetailPage), typeof(CompanyDetailPage));
            Routing.RegisterRoute(nameof(ForgotPasswordPage), typeof(ForgotPasswordPage));
        }

    }
}
