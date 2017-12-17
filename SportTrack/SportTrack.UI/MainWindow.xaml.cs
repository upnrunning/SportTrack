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
using System.Net;

namespace SportTrack.UI
{
    
    public partial class MainWindow : Window
    {
        string projectRootDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        Repository r = new Repository();
        

        
        public MainWindow()
        {
            
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            LoadingGif.Source = new Uri(projectRootDirectory + @"\..\loading.gif");
            Sponsor.Source = new BitmapImage(new Uri(projectRootDirectory + @"\..\3NWzq6NI58Y.jpg"));
            Sponsor2.Source = new BitmapImage(new Uri(projectRootDirectory + @"\..\qFGrsz8RhOQ.jpg"));

            LoadNews("nhl news");
            }

        public async void LoadNews(string sport)
        {
            BingRepository b = new BingRepository();
            try
            {
                await b.GetBingDataAsync(sport + " news");
                if (Repository.SearchResults.Count == 0) throw new Exception("Trouble connecting to the server. Try again later");
                LoadingGif.Stop();
                LoadingGif.Visibility = Visibility.Collapsed;
                loadingTextBlock.Visibility = Visibility.Collapsed;
                News.Children.Clear();
                for (int i = 0; i < Repository.SearchResults.Count; i++)
                {
                    A.ShowGridLines = false;
                    Hyperlink linkNews = new Hyperlink
                    {
                        NavigateUri = new Uri(Repository.SearchResults[i].Url)
                    };
                    Image image = new Image
                    {
                        Source = new BitmapImage(new Uri(projectRootDirectory + @"\..\3NWzq6NI58Y.jpg")),
                        Height = 48,
                        Width = 48,
                        VerticalAlignment = VerticalAlignment.Top,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Margin = new Thickness(5)
                    };
                    TextBlock linkTextBlock = new TextBlock
                    {
                        VerticalAlignment = VerticalAlignment.Top,
                        Width = 120,
                        Height = 38,
                        Margin = new Thickness(55, 5, 5, 5)
                    };
                    linkNews.Inlines.Add(Repository.SearchResults[i].Url);
                    linkTextBlock.Inlines.Add(linkNews);
                    linkTextBlock.MaxWidth = 120;
                    linkTextBlock.PreviewMouseDown += (s, e) => { TextBlock chosenLink = s as TextBlock; Hyperlink link = chosenLink.Inlines.FirstInline as Hyperlink; Browser aa = new Browser(link.NavigateUri); aa.Show(); };
                    TextBlock desciptionTextBlock = new TextBlock
                    {
                        Name = "tb" + i.ToString(),
                        Text = Repository.SearchResults[i].Description,
                        VerticalAlignment = VerticalAlignment.Center,
                        Height = 100,
                        TextWrapping = TextWrapping.Wrap,
                        Margin = new Thickness(5, 30, 5, 0)
                    };
                    News.Children.Add(desciptionTextBlock);
                    Grid.SetRow(desciptionTextBlock, i / 5);
                    Grid.SetColumn(desciptionTextBlock, i % 5);
                    News.Children.Add(linkTextBlock);
                    Grid.SetColumn(linkTextBlock, i % 5);
                    Grid.SetRow(linkTextBlock, i / 5);
                    News.Children.Add(image);
                    Grid.SetRow(image, i / 5);
                    Grid.SetColumn(image, i % 5);

                }
            }

            catch (Exception e)
            {
                News.Children.Clear();
                MessageBox.Show(e.Message);
            }
            

        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateNewTask create = new CreateNewTask();
            create.Show();
            //Random rnd = new Random();
            //Grid DynamicGrid = new Grid
            //{
            //    Name = "aaaaname"
            //};
            //// Create Columns
            //ColumnDefinition gridCol1 = new ColumnDefinition();
            //ColumnDefinition gridCol2 = new ColumnDefinition();
            //ColumnDefinition gridCol3 = new ColumnDefinition();
            //ColumnDefinition gridCol4 = new ColumnDefinition();
            //gridCol1.Width = new GridLength(325);
            //gridCol2.Width = new GridLength(98);
            //gridCol3.Width = new GridLength(51);
            //gridCol4.Width = new GridLength(49);
            //DynamicGrid.ColumnDefinitions.Add(gridCol1);
            //DynamicGrid.ColumnDefinitions.Add(gridCol2);
            //DynamicGrid.ColumnDefinitions.Add(gridCol3);
            //DynamicGrid.ColumnDefinitions.Add(gridCol4);
            //// Create Rows
            //RowDefinition gridRow1 = new RowDefinition();
            //RowDefinition gridRow2 = new RowDefinition();
            //RowDefinition gridRow3 = new RowDefinition();
            //RowDefinition gridRow4 = new RowDefinition();
            //RowDefinition gridRow5 = new RowDefinition();
            //gridRow1.Height = new GridLength(20);
            //gridRow2.Height = new GridLength(20);
            //gridRow3.Height = new GridLength(20);
            //gridRow4.Height = new GridLength(20);
            //gridRow5.Height = new GridLength(20);

            //DynamicGrid.RowDefinitions.Add(gridRow1);
            //DynamicGrid.RowDefinitions.Add(gridRow2);
            //DynamicGrid.RowDefinitions.Add(gridRow3);
            //DynamicGrid.RowDefinitions.Add(gridRow4);
            //DynamicGrid.RowDefinitions.Add(gridRow5);

            //TextBlock DynamicTextBlock = new TextBlock
            //{
            //    Background = new SolidColorBrush(Colors.White),
            //    Text = "Test"
            //};
            //TextBlock DynamicTextBlock2 = new TextBlock
            //{
            //    Background = new SolidColorBrush(Colors.AntiqueWhite),
            //    Text = "Test"

            //};
            //TextBlock DynamicTextBlock3 = new TextBlock
            //{
            //    Background = new SolidColorBrush(Colors.AntiqueWhite),
            //    Text = "TIME LEFT:",
            //    TextAlignment = TextAlignment.Center,
            //    FontSize = 19,
            //    Margin = new Thickness(5, 5, 5, 5)
            //};
            //Label DynamicLabel = new Label
            //{
            //    Background = new SolidColorBrush(Colors.Azure),
            //    Content = rnd.Next(40),
            //    VerticalContentAlignment = VerticalAlignment.Center,
            //    HorizontalContentAlignment = HorizontalAlignment.Right
            //};
            //TextBlock DynamicTextBlock4 = new TextBlock
            //{
            //    Background = new SolidColorBrush(Colors.AntiqueWhite),
            //    Text = "ДНЯ",
            //    TextAlignment = TextAlignment.Left,
            //    VerticalAlignment = VerticalAlignment.Center
            //};
            //ProgressBar DynamicProgressBar = new ProgressBar
            //{
            //    Minimum = 0,
            //    Maximum = 100,
            //    Value = rnd.Next(101)
            //};
            //Button DynamicButton = new Button
            //{
            //    Margin = new Thickness(0, 5, 5, 5),
            //    Content = "Edit"
            //};
            //Button DynamicButtonDelete = new Button
            //{
            //    Margin = new Thickness(5),
            //    Content = "Delete",
            //    Background = new SolidColorBrush(Colors.Red)
            //};

            //B.Children.Add(DynamicGrid);
            //DynamicGrid.Children.Add(DynamicTextBlock);
            //Grid.SetRow(DynamicTextBlock, 0);
            //Grid.SetColumn(DynamicTextBlock, 0);
            //Grid.SetRowSpan(DynamicTextBlock, 2);
            //DynamicGrid.Children.Add(DynamicTextBlock2);
            //Grid.SetRow(DynamicTextBlock2, 2);
            //Grid.SetColumn(DynamicTextBlock2, 0);
            //Grid.SetRowSpan(DynamicTextBlock2, 3);
            //DynamicGrid.Children.Add(DynamicTextBlock3);
            //Grid.SetColumn(DynamicTextBlock3, 1);
            //Grid.SetRow(DynamicTextBlock3, 0);
            //Grid.SetRowSpan(DynamicTextBlock3, 2);
            //DynamicGrid.Children.Add(DynamicLabel);
            //Grid.SetColumn(DynamicLabel, 2);
            //Grid.SetRowSpan(DynamicLabel, 2);
            //DynamicGrid.Children.Add(DynamicTextBlock4);
            //Grid.SetColumn(DynamicTextBlock4, 3);
            //Grid.SetRowSpan(DynamicTextBlock4, 2);
            //DynamicGrid.Children.Add(DynamicProgressBar);
            //Grid.SetColumn(DynamicProgressBar, 1);
            //Grid.SetColumnSpan(DynamicProgressBar, 3);
            //Grid.SetRow(DynamicProgressBar, 2);
            //DynamicGrid.Children.Add(DynamicButton);
            //Grid.SetColumn(DynamicButton, 1);
            //Grid.SetRow(DynamicButton, 3);
            //Grid.SetRowSpan(DynamicButton, 2);
            //DynamicGrid.Children.Add(DynamicButtonDelete);
            //Grid.SetRow(DynamicButtonDelete, 3);
            //Grid.SetRowSpan(DynamicButtonDelete, 2);
            //Grid.SetColumn(DynamicButtonDelete, 2);
            //Grid.SetColumnSpan(DynamicButtonDelete, 2);

        }

        private void RadioButton_SportChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            RadioButton _selectedSport = sender as RadioButton;
            string sport = _selectedSport.Content.ToString();
            
            LoadingGif.Visibility = Visibility.Visible;
            LoadingGif.Play();
            loadingTextBlock.Visibility = Visibility.Visible;
            LoadNews(sport);
        }

        private void LoadingGif_MediaEnded(object sender, RoutedEventArgs e)
        {
            LoadingGif.Position = new TimeSpan(0, 0, 3);
            LoadingGif.Play();
        }
    } 
}
