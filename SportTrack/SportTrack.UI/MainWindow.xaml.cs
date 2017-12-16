using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SportTrack.Logic;
using System.IO;
using System.Threading;

namespace SportTrack.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string c;
        BingRepository b = new BingRepository();
        public MainWindow()
        {
            c = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            SportsFeedRepository sp = new SportsFeedRepository();
            //BingRepository b = new BingRepository();
            InitializeComponent();
            Repository r = new Repository();
            //sp.SportsFeedGetDataAsync("nba", 2017, "playoff", new DateTime(2017, 04, 22), null);
            //b.GetBingDataAsync("nba news");string c = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            LoadingGif.Source = new Uri(c + @"\..\loading.gif");
            Sponsor.Source = new BitmapImage(new Uri(c + @"\..\3NWzq6NI58Y.jpg"));
            Sponsor2.Source = new BitmapImage(new Uri(c + @"\..\qFGrsz8RhOQ.jpg"));
            LoadNews();
            }

        public async void LoadNews()
        {
            await b.GetBingDataAsync("NBA news");
            LoadingGif.Stop();
            LoadingGif.Visibility = Visibility.Collapsed;
            loadingTextBlock.Visibility = Visibility.Collapsed;
            for (int i = 0; i < Repository.SearchResults.Count; i++)
            {
                A.ShowGridLines = false;
                Hyperlink a = new Hyperlink();
                a.NavigateUri = new Uri(Repository.SearchResults[i].Url);
                Image image = new Image();
                image.Source = new BitmapImage(new Uri(c + @"\..\3NWzq6NI58Y.jpg"));
                image.Height = 48;
                image.Width = 48;
                image.VerticalAlignment = VerticalAlignment.Top;
                image.HorizontalAlignment = HorizontalAlignment.Left;
                image.Margin = new Thickness(5);
                TextBlock btn = new TextBlock();
                btn.VerticalAlignment = VerticalAlignment.Top;
                btn.Width = 120;
                btn.Height = 38;
                btn.Margin = new Thickness(55, 5, 5, 5);
                a.Inlines.Add(Repository.SearchResults[i].Url);
                btn.Inlines.Add(a);
                btn.MaxWidth = 120;
                btn.PreviewMouseDown += (s, e) => { TextBlock but = s as TextBlock; Hyperlink link = but.Inlines.FirstInline as Hyperlink; Browser aa = new Browser(link.NavigateUri); aa.Show(); };
                TextBlock tb = new TextBlock();
                tb.Name = "tb" + i.ToString();
                tb.Text = Repository.SearchResults[i].Description;
                tb.VerticalAlignment = VerticalAlignment.Center;
                tb.Height = 100;
                tb.TextWrapping = TextWrapping.Wrap;
                tb.Margin = new Thickness(5, 30, 5, 0);
                News.Children.Add(tb);
                Grid.SetRow(tb, i / 5);
                Grid.SetColumn(tb, i % 5);
                News.Children.Add(btn);
                Grid.SetColumn(btn, i % 5);
                Grid.SetRow(btn, i / 5);
                News.Children.Add(image);
                Grid.SetRow(image, i / 5);
                Grid.SetColumn(image, i % 5);

            }

        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            Grid DynamicGrid = new Grid
            {
                Name = "aaaaname"
            };
            // Create Columns
            ColumnDefinition gridCol1 = new ColumnDefinition();
            ColumnDefinition gridCol2 = new ColumnDefinition();
            ColumnDefinition gridCol3 = new ColumnDefinition();
            ColumnDefinition gridCol4 = new ColumnDefinition();
            gridCol1.Width = new GridLength(325);
            gridCol2.Width = new GridLength(98);
            gridCol3.Width = new GridLength(51);
            gridCol4.Width = new GridLength(49);
            DynamicGrid.ColumnDefinitions.Add(gridCol1);
            DynamicGrid.ColumnDefinitions.Add(gridCol2);
            DynamicGrid.ColumnDefinitions.Add(gridCol3);
            DynamicGrid.ColumnDefinitions.Add(gridCol4);
            // Create Rows
            RowDefinition gridRow1 = new RowDefinition();
            RowDefinition gridRow2 = new RowDefinition();
            RowDefinition gridRow3 = new RowDefinition();
            RowDefinition gridRow4 = new RowDefinition();
            RowDefinition gridRow5 = new RowDefinition();
            gridRow1.Height = new GridLength(20);
            gridRow2.Height = new GridLength(20);
            gridRow3.Height = new GridLength(20);
            gridRow4.Height = new GridLength(20);
            gridRow5.Height = new GridLength(20);

            DynamicGrid.RowDefinitions.Add(gridRow1);
            DynamicGrid.RowDefinitions.Add(gridRow2);
            DynamicGrid.RowDefinitions.Add(gridRow3);
            DynamicGrid.RowDefinitions.Add(gridRow4);
            DynamicGrid.RowDefinitions.Add(gridRow5);

            TextBlock DynamicTextBlock = new TextBlock
            {
                Background = new SolidColorBrush(Colors.White),
                Text = "Test"
            };
            TextBlock DynamicTextBlock2 = new TextBlock
            {
                Background = new SolidColorBrush(Colors.AntiqueWhite),
                Text = "Test"

            };
            TextBlock DynamicTextBlock3 = new TextBlock
            {
                Background = new SolidColorBrush(Colors.AntiqueWhite),
                Text = "TIME LEFT:",
                TextAlignment = TextAlignment.Center,
                FontSize = 19,
                Margin = new Thickness(5, 5, 5, 5)
            };
            Label DynamicLabel = new Label
            {
                Background = new SolidColorBrush(Colors.Azure),
                Content = rnd.Next(40),
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Right
            };
            TextBlock DynamicTextBlock4 = new TextBlock
            {
                Background = new SolidColorBrush(Colors.AntiqueWhite),
                Text = "ДНЯ",
                TextAlignment = TextAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };
            ProgressBar DynamicProgressBar = new ProgressBar
            {
                Minimum = 0,
                Maximum = 100,
                Value = rnd.Next(101)
            };
            Button DynamicButton = new Button
            {
                Margin = new Thickness(0, 5, 5, 5),
                Content = "Edit"
            };
            Button DynamicButtonDelete = new Button
            {
                Margin = new Thickness(5),
                Content = "Delete",
                Background = new SolidColorBrush(Colors.Red)
            };

            B.Children.Add(DynamicGrid);
            DynamicGrid.Children.Add(DynamicTextBlock);
            Grid.SetRow(DynamicTextBlock, 0);
            Grid.SetColumn(DynamicTextBlock, 0);
            Grid.SetRowSpan(DynamicTextBlock, 2);
            DynamicGrid.Children.Add(DynamicTextBlock2);
            Grid.SetRow(DynamicTextBlock2, 2);
            Grid.SetColumn(DynamicTextBlock2, 0);
            Grid.SetRowSpan(DynamicTextBlock2, 3);
            DynamicGrid.Children.Add(DynamicTextBlock3);
            Grid.SetColumn(DynamicTextBlock3, 1);
            Grid.SetRow(DynamicTextBlock3, 0);
            Grid.SetRowSpan(DynamicTextBlock3, 2);
            DynamicGrid.Children.Add(DynamicLabel);
            Grid.SetColumn(DynamicLabel, 2);
            Grid.SetRowSpan(DynamicLabel, 2);
            DynamicGrid.Children.Add(DynamicTextBlock4);
            Grid.SetColumn(DynamicTextBlock4, 3);
            Grid.SetRowSpan(DynamicTextBlock4, 2);
            DynamicGrid.Children.Add(DynamicProgressBar);
            Grid.SetColumn(DynamicProgressBar, 1);
            Grid.SetColumnSpan(DynamicProgressBar, 3);
            Grid.SetRow(DynamicProgressBar, 2);
            DynamicGrid.Children.Add(DynamicButton);
            Grid.SetColumn(DynamicButton, 1);
            Grid.SetRow(DynamicButton, 3);
            Grid.SetRowSpan(DynamicButton, 2);
            DynamicGrid.Children.Add(DynamicButtonDelete);
            Grid.SetRow(DynamicButtonDelete, 3);
            Grid.SetRowSpan(DynamicButtonDelete, 2);
            Grid.SetColumn(DynamicButtonDelete, 2);
            Grid.SetColumnSpan(DynamicButtonDelete, 2);

        }

        private void RadioButton_SportChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            RadioButton ikikkk = sender as RadioButton;
            string sport = ikikkk.Content.ToString();
            
            
        }

        private void LoadingGif_MediaEnded(object sender, RoutedEventArgs e)
        {
            LoadingGif.Position = new TimeSpan(0, 0, 3);
            LoadingGif.Play();
        }
    } 
}
