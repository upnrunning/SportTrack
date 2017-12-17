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
using SportTrack.Logic.Model;
using System.Collections.ObjectModel;

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
            LoadNews("nhl news"); // NHL news and standings are loaded by default
            LoadStandings("nhl", "2017 Regular");
            }
        

        public async void LoadStandings(string sport, string season)
        {
            
            string[] seasonInfo = season.Split(new char[] { ' ' }, 2);
            SportsFeedRepository sportsFeed = new SportsFeedRepository();
            await sportsFeed.SportsFeedGetDataAsync(sport, Convert.ToInt32(seasonInfo[0]), seasonInfo[1].ToLower());
            StandingsListView.ItemsSource = null;

            StandingsListView.ItemsSource = Repository.OverallStandings;
            
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

                    if (Repository.SearchResults[i].Image.ThumbNail.ContentUrl == null)
                    { Repository.SearchResults[i].Image.ThumbNail.ContentUrl = projectRootDirectory + @"\..\default.png"; }
                        Image image = new Image
                    {
                        
                        Source = new BitmapImage(new Uri(Repository.SearchResults[i].Image.ThumbNail.ContentUrl)),
                        Height = 32,
                        Width = 32,
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
                    linkNews.Inlines.Add("Open link");
                    linkTextBlock.Inlines.Add(linkNews);
                    linkTextBlock.MaxWidth = 120;
                    linkTextBlock.PreviewMouseDown += (s, e) => { TextBlock chosenLink = s as TextBlock; Hyperlink link = chosenLink.Inlines.FirstInline as Hyperlink;
                                                                  Browser openLinkBrowser = new Browser(link.NavigateUri); openLinkBrowser.Show(); openLinkBrowser.Topmost = true; };
                    TextBlock desciptionTextBlock = new TextBlock
                    {
                        Name = "tb" + i.ToString(),
                        Text = Repository.SearchResults[i].Description,
                        VerticalAlignment = VerticalAlignment.Center,
                        Height = 100,
                        TextWrapping = TextWrapping.Wrap,
                        Margin = new Thickness(5, 30, 5, 0),
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

        }

        private void RadioButton_SportChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            RadioButton _selectedSport = sender as RadioButton;
            string sport = _selectedSport.Content.ToString();
            
            LoadingGif.Visibility = Visibility.Visible;
            LoadingGif.Play();
            loadingTextBlock.Visibility = Visibility.Visible;

            
            var selected = seasonComboBox.SelectedItem as TextBlock;
            string season = selected.Text;
            LoadNews(sport);
            LoadStandings(sport, season);
        }

        private void LoadingGif_MediaEnded(object sender, RoutedEventArgs e)
        {
            LoadingGif.Position = new TimeSpan(0, 0, 3);
            LoadingGif.Play();
        }

        private void seasonComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox box = sender as ComboBox;
            var selected = box.SelectedItem as TextBlock;
            string season = selected.Text;
            string sport = "";
            if (RadioMLB != null && RadioNBA != null && RadioNHL != null && RadioNFL != null)
            {
                if (RadioNHL.IsChecked == true) sport = "nhl";
                else if (RadioNFL.IsChecked == true) sport = "nfl";
                else if (RadioNBA.IsChecked == true) sport = "nba";
                else if (RadioMLB.IsChecked == true) sport = "mlb";
                LoadStandings(sport, season);
            }
        }
    } 
}
