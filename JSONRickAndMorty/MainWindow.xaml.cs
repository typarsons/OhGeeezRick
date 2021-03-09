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

        //Tyler Parsons
        //MIS 3033
        //(P) JSON - Finish Rick & Morty
        public MainWindow()
        {
            InitializeComponent();

              int i = 1;

              using (var client = new HttpClient())

            { while (i < 34)
                {
                    i = i + 1;

                    string url = "https://rickandmortyapi.com/api/character/?page=" + Convert.ToString(i);

                    string jsonData = client.GetStringAsync(url).Result;

                    RickAndMortyAPI api = JsonConvert.DeserializeObject<RickAndMortyAPI>(jsonData);

                    foreach (var character in api.results)
                    {
                        lstCharacters.Items.Add(character);
                    }
                }                // while this works, you need to use next
                        //prof did this problem in class 3/9, much cleaner solution done correctly using next
            }
        }
        private void lstCharacters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var selectedCharacter = (Character)lstCharacters.SelectedItem;

            ShowCharacterWindow wnd = new ShowCharacterWindow();

            //imgCharacter.Source = new BitmapImage(new Uri(selectedCharacter.image));

            wnd.SetUpWindow(selectedCharacter);

            wnd.ShowDialog();

            }
        }
    }
