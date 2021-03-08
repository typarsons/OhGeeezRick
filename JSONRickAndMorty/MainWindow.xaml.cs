using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace JSONRickAndMorty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

           string url = "https://rickandmortyapi.com/api/character";

            //using (var client = new HttpClient())
            //{
            //    string jsonData = client.GetStringAsync(url).Result;

            //    RickAndMortyAPI api = JsonConvert.DeserializeObject<RickAndMortyAPI>(jsonData);

            //    foreach (var character in api.results)
            //    {
            //        lstCharacters.Items.Add(character);
            //    }
            //}
            using (var client = new HttpClient())
            {
                string jsonData = client.GetStringAsync(url).Result;

                RickAndMortyAPI api = JsonConvert.DeserializeObject<RickAndMortyAPI>(jsonData);

                //foreach (var character in api.results)
                //{
                //    lstCharacters.Items.Add(character);
                //}

                string urlNext = api.info.next;

                string jsonData2 = client.GetStringAsync(urlNext).Result;

                RickAndMortyAPI api2 = JsonConvert.DeserializeObject<RickAndMortyAPI>(jsonData2);

                foreach (var character in api.results)
                {
                    lstCharacters.Items.Add(character);

                }
                


            }
        }
        private void lstCharacters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCharacter = (Character)lstCharacters.SelectedItem;
            imgCharacter.Source = new BitmapImage(new Uri(selectedCharacter.image));
        }
    }
}
