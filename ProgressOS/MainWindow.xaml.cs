using ProgressOS.Enums;
using ProgressOS.Pages;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgressOS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GoalsDayPages _goalsDayPages;
        private GoalsYearPage _goalsYearPages;
        private MainPages _mainPage;
        private SettingsPage _settingPage;
        private VariablePage _currentPage;
        private Button? _activeButton;
        public MainWindow()
        {
            InitializeComponent();
            _goalsDayPages = new GoalsDayPages();
            _goalsYearPages = new GoalsYearPage();
            _mainPage = new MainPages();
            _settingPage = new SettingsPage();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = this.WindowState == WindowState.Normal ?
                WindowState.Maximized : WindowState.Normal;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void NavigateMain_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button button)
            {
                _currentPage = VariablePage.Main;
                NavigateToPage();
                SetActiveButton(button);
            }
        }

        private void NavigateDaysGoals_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button button)
            {
                _currentPage = VariablePage.GoalsDays;
                NavigateToPage();
                SetActiveButton(button);
            }
        }

        private void NavigateYearsGoals_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button button)
            {
                _currentPage = VariablePage.GoalsYear;
                NavigateToPage();
                SetActiveButton(button);
            }
        }

        private void NavigateSettings_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button button)
            {
                _currentPage = VariablePage.Settings;
                NavigateToPage();
                SetActiveButton(button);
            }
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void NavigateToPage()
        {
            switch(_currentPage)
            {
                case VariablePage.Main:
                    PageControl.Content = _mainPage; 
                    break;
                case VariablePage.GoalsDays:
                    PageControl.Content = _goalsDayPages;
                    break;
                case VariablePage.GoalsYear:
                    PageControl.Content = _goalsYearPages;
                    break;
                case VariablePage.Settings:
                    PageControl.Content = _settingPage;
                    break;
                default:
                    PageControl.Content = _mainPage;
                    break;
            }
        }

        private void SetActiveButton(Button activeButton)
        {
            if (_activeButton != null)
            {
                _activeButton.Style = (Style)FindResource("NavButtonStyle");
            }
            activeButton.Style = (Style)FindResource("ActiveNavButtonStyle");
            _activeButton = activeButton;
        }
    }
}