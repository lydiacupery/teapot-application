using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Reactive.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static TeapotApplication.State;

namespace TeapotApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IViewFor<MainWindowViewModel>, INotifyPropertyChanged
    {


        public static readonly DependencyProperty ViewModelProperty =
    DependencyProperty.Register("ViewModel", typeof(MainWindowViewModel), typeof(MainWindow), new PropertyMetadata(null));
        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            ViewModel = viewModel;

            var whistlingImage = new BitmapImage(new Uri("Assets/TeapotSteaming.png", UriKind.Relative));
            var notWhistlingImage = new BitmapImage(new Uri("Assets/TeapotBoring.png", UriKind.Relative));
            var boilingImage = new BitmapImage(new Uri("Assets/TeapotCrazyDay.png", UriKind.Relative));

            var whistlingImageGreen = new BitmapImage(new Uri("Assets/TeapotSteamingGreen.png", UriKind.Relative));
            var notWhistlingImageGreen = new BitmapImage(new Uri("Assets/TeapotBoringGreen.png", UriKind.Relative));
            var boilingImageGreen = new BitmapImage(new Uri("Assets/TeapotCrazyDayGreen.png", UriKind.Relative));

            this.WhenActivated(d =>
            {
                d(this.OneWayBind(ViewModel, vm => vm.CheckWhistlingCommand, v => v.Whistling.Command));
                d(this.OneWayBind(ViewModel, vm => vm.CheckNotWhistlingCommand, v => v.NotWhistling.Command));
                d(this.OneWayBind(ViewModel, vm => vm.CheckBoilingOverCommand, v => v.BoilingOver.Command));

                d(this.OneWayBind(ViewModel, vm => vm.CheckWhistlingCommand2, v => v.Whistling2.Command));
                d(this.OneWayBind(ViewModel, vm => vm.CheckNotWhistlingCommand2, v => v.NotWhistling2.Command));
                d(this.OneWayBind(ViewModel, vm => vm.CheckBoilingOverCommand2, v => v.BoilingOver2.Command));

                d(this.OneWayBind(ViewModel, vm => vm.TeapotCurrentState, v => v.Whistling.IsChecked, (teapotState) => teapotState == TeapotState.Whistling ));
                d(this.OneWayBind(ViewModel, vm => vm.TeapotCurrentState, v => v.NotWhistling.IsChecked, (teapotState) => teapotState == TeapotState.NotWhistling ));
                d(this.OneWayBind(ViewModel, vm => vm.TeapotCurrentState, v => v.BoilingOver.IsChecked, (teapotState) => teapotState == TeapotState.BoilingOver ));
                d(this.OneWayBind(ViewModel, vm => vm.TeapotCurrentState, v => v.TeapotImage.Source, (teapotState) => teapotState == TeapotState.BoilingOver ? boilingImage  :  (teapotState == TeapotState.Whistling ? whistlingImage : notWhistlingImage)));

                d(this.OneWayBind(ViewModel, vm => vm.TeapotCurrentState2, v => v.Whistling2.IsChecked, (teapotState) => teapotState == TeapotState.Whistling ));
                d(this.OneWayBind(ViewModel, vm => vm.TeapotCurrentState2, v => v.NotWhistling2.IsChecked, (teapotState) => teapotState == TeapotState.NotWhistling ));
                d(this.OneWayBind(ViewModel, vm => vm.TeapotCurrentState2, v => v.BoilingOver2.IsChecked, (teapotState) => teapotState == TeapotState.BoilingOver ));
                d(this.OneWayBind(ViewModel, vm => vm.TeapotCurrentState2, v => v.TeapotImage2.Source, (teapotState) => teapotState == TeapotState.BoilingOver ? boilingImageGreen  :  (teapotState == TeapotState.Whistling ? whistlingImageGreen : notWhistlingImageGreen)));

                d(this.OneWayBind(ViewModel, vm => vm.TeapotMessage , v => v.TeapotMessage.Text));
            });

        }

        public MainWindow() { }



        public MainWindowViewModel ViewModel
        {
            get { return (MainWindowViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (MainWindowViewModel)value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
