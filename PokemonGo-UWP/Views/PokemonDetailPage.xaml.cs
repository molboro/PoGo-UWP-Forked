using PokemonGo_UWP.Entities;
using PokemonGo_UWP.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Template10.Common;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace PokemonGo_UWP.Views
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class PokemonDetailPage : Page
    {
        public PokemonDetailPage()
        {
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string id = "";
            id = Template10.Services.SerializationService.SerializationService.Json.Deserialize<string>(e.Parameter.ToString());
            if (!string.IsNullOrEmpty(id))
            {
                DataContext = GameClient.InventoryPokemons.FirstOrDefault(p => p.Id.ToString() == id);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BootStrapper.Current.NavigationService.GoBack();
        }
    }
}
