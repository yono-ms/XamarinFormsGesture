using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFormsGesture
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private bool _IsVisibleFloat;

        public bool IsVisibleFloat
        {
            get { return _IsVisibleFloat; }
            set { _IsVisibleFloat = value; OnPropertyChanged(); }
        }

        private double _TranslationXFloat;

        public double TranslationXFloat
        {
            get { return _TranslationXFloat; }
            set { _TranslationXFloat = value; OnPropertyChanged(); }
        }

        private double _TranslationYFloat;

        public double TranslationYFloat
        {
            get { return _TranslationYFloat; }
            set { _TranslationYFloat = value; OnPropertyChanged(); }
        }

        public Command Command => new Command(() =>
        {
            System.Diagnostics.Debug.WriteLine($"command.");
            IsVisibleFloat = !IsVisibleFloat;
        });

        double savedX;
        double savedY;

        private void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"PanUpdated {e.StatusType} {e.TotalX} {e.TotalY}");

            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    savedX = 0;
                    savedY = 0;
                    break;

                case GestureStatus.Running:
                    double deltaX = e.TotalX - savedX;
                    savedX = e.TotalX;
                    TranslationXFloat += deltaX;

                    double deltaY = e.TotalY - savedY;
                    savedY = e.TotalY;
                    TranslationYFloat += deltaY;

                    break;

                default:
                    break;
            }
        }
    }
}
