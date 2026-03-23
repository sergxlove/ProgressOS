using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProgressOS.Application.Abstractions;
using ProgressOS.Application.Services;
using ProgressOS.Core.Abstractions;
using ProgressOS.Core.Services;
using ProgressOS.DataAccess.Sqlite;
using ProgressOS.DataAccess.Sqlite.Abstractions;
using ProgressOS.DataAccess.Sqlite.Repositories;
using ProgressOS.Enums;
using ProgressOS.Pages;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        private NotesPage _notesPage;
        private VariablePage _currentPage;
        private Button? _activeButton;
        private ServiceProvider _provider;
        public MainWindow()
        {
            InitializeComponent();
            _goalsDayPages = new GoalsDayPages();
            _goalsYearPages = new GoalsYearPage();
            _mainPage = new MainPages();
            _settingPage = new SettingsPage();
            _notesPage = new NotesPage();
            ServiceCollection serviceCollection = new();
            serviceCollection.AddDbContext<ProgressOSDbContext>(opt =>
                opt.UseSqlite("Data Source=D:\\projects\\projects\\ProgressOS\\data.db"));
            serviceCollection.AddScoped<IGoalsDayRepository, GoalsDayRepository>();
            serviceCollection.AddScoped<IGoalsYearRepository, GoalsYearRepository>();
            serviceCollection.AddScoped<INotesRepository, NotesRepository>();
            serviceCollection.AddScoped<IUsersRepository, UsersRepository>();
            serviceCollection.AddScoped<IGoalsDayService, GoalsDayService>();
            serviceCollection.AddScoped<IGoalsYearService, GoalsYearService>();
            serviceCollection.AddScoped<INotesService, NotesService>();
            serviceCollection.AddScoped<IUsersService, UsersService>();
            serviceCollection.AddScoped<IEncryptionService, EncryptionService>();
            serviceCollection.AddScoped<IPasswordHasherService, PasswordHasherService>();
            _provider = serviceCollection.BuildServiceProvider();
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

        private void NavigateNotes_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button button)
            {
                _currentPage = VariablePage.Notes;
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
                case VariablePage.Notes:
                    PageControl.Content = _notesPage;
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