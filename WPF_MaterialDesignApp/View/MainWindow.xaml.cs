using Microsoft.Expression.Interactivity.Layout;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace WPF_MaterialDesignApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private bool isLeftPanelOpen;
        private Border border;
        private AdornerContainer adornerContainer;

        private void HideLeftPaneButtonClick(object sender, RoutedEventArgs e)
        {
            this.HideLeftPanel();
        }

        private void OpenLeftPaneButtonClick(object sender, RoutedEventArgs e)
        {
            Storyboard showPanelAnimation = this.LeftPane.Resources["showLeftPanel"] as Storyboard;
            showPanelAnimation.Begin(this.LeftPane);
            //(this.MainScreen.Resources["LessOpacity"] as Storyboard).Begin();
            
            var adornerLayer = AdornerLayer.GetAdornerLayer(this.MainScreen);
            if (adornerLayer == null)
                return;

            if (this.adornerContainer == null)
            {
                border = new Border
                {
                    Background = new SolidColorBrush(Colors.Black),
                    Opacity = 0.0
                };
                this.adornerContainer = new AdornerContainer(this.MainScreen) { Child = border };
            }
            adornerLayer.Add(this.adornerContainer);

            var animation = new DoubleAnimation
            {
                To = 0.5,
                Duration = TimeSpan.FromSeconds(0.3)
            };
            this.border.BeginAnimation(OpacityProperty, animation);
            this.isLeftPanelOpen = true;
        }

        private void MainScreenMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.isLeftPanelOpen)
                this.HideLeftPanel();
        }

        private void HideLeftPanel()
        {
            Storyboard hidePanelAnimation = this.LeftPane.Resources["hideLeftPanel"] as Storyboard;
            hidePanelAnimation.Begin(this.LeftPane);
            this.OpenLeftPaneButton.IsChecked = false;

            var animation = new DoubleAnimation
            {
                To = 0.0,
                Duration = TimeSpan.FromSeconds(0.3)
            };
            this.border.BeginAnimation(OpacityProperty, animation);

            var adornerLayer = AdornerLayer.GetAdornerLayer(this.MainScreen);
            if (this.adornerContainer != null)
            {
                adornerLayer.Remove(this.adornerContainer);
                this.adornerContainer = null;
                this.border = null;
            }
            //(this.MainScreen.Resources["MoreOpacity"] as Storyboard).Begin();
            this.isLeftPanelOpen = false;
        }

        private void GoToLightThemeClick(object sender, RoutedEventArgs e)
        {
            this.ApplyTheme("View/Sources/Themes/Default.xaml", "View/Sources/Themes/Light.xaml");
            this.HideLeftPanel();
        }

        private void GoToDefaultThemeClick(object sender, RoutedEventArgs e)
        {
            this.ApplyTheme("View/Sources/Themes/Light.xaml", "View/Sources/Themes/Default.xaml");
            this.HideLeftPanel();
        }

        private void ApplyTheme(string currentThemeUri, string newThemeUri)
        {
            var existingTheme = Application.Current.Resources.MergedDictionaries.SingleOrDefault
                (d => d.Source != null && d.Source.OriginalString == currentThemeUri);

            if (existingTheme == null)
                return;

            var newTheme = new ResourceDictionary();
            newTheme.Source = new Uri(newThemeUri, UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Remove(existingTheme);
            Application.Current.Resources.MergedDictionaries.Add(newTheme);
        }
    }
}
