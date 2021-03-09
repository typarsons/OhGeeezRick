using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JSONRickAndMorty
{
    /// <summary>
    /// Interaction logic for ShowCharacterWindow.xaml
    /// </summary>
    public partial class ShowCharacterWindow : Window
    {
        public ShowCharacterWindow()
        {
            InitializeComponent();
        }
        public void SetUpWindow(Character character)
        {
            imgChar.Source = new BitmapImage(new Uri(character.image));  
        }
    }
}
