using PokemonGo.RocketAPI.GeneratedCode;
using PokemonGo_UWP.Entities;
using PokemonGo_UWP.Utils;
using PokemonGo_UWP.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Common;
using Template10.Mvvm;
using Template10.Utils;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Template10.Services.NavigationService;

namespace PokemonGo_UWP.ViewModels
{
    public class InventoryPokemonViewModel : ViewModelBase
    {

        #region Bindable Game Vars
        private IReadOnlyCollection<InventoryPokemonWrapper> _inventoryPokemons = new List<InventoryPokemonWrapper>();

        /// <summary>
        ///     Stores the current pokemons in "inventory"
        /// </summary>
        public IReadOnlyCollection<InventoryPokemonWrapper> InventoryPokemons { get { return _inventoryPokemons; } set { Set(ref _inventoryPokemons, value); } }

        public DelegateCommand SortByCpCommand { get; set; }
        public DelegateCommand SortByNumberCommand { get; set; }
        public DelegateCommand SortByNameCommand { get; set; }
        public DelegateCommand SortByDateCommand { get; set; }

        #endregion

        #region SharedLogic

        private DelegateCommand _returnToGameScreen;

        /// <summary>
        ///     Going back to map page
        /// </summary>
        public DelegateCommand ReturnToGameScreen => _returnToGameScreen ?? (
            _returnToGameScreen = new DelegateCommand(() =>
            {
                NavigationService.Navigate(typeof(GameMapPage));
            }, () => true)
            );
        #endregion

        public InventoryPokemonViewModel() : base()
        {
            SortByCpCommand = new DelegateCommand(SortByCp);
            SortByNumberCommand = new DelegateCommand(SortByNumber);
            SortByNameCommand = new DelegateCommand(SortByName);
            SortByDateCommand = new DelegateCommand(SortByDate);
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            await base.OnNavigatedToAsync(parameter, mode, state);
            InventoryPokemons = GameClient.InventoryPokemons.ToList();
        }

        public override Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            return base.OnNavigatingFromAsync(args);
        }

        public void SortByCp()
        {
            InventoryPokemons = InventoryPokemons.OrderByDescending(d => d.Cp).ToList();
        }

        public void SortByNumber()
        {
            InventoryPokemons = InventoryPokemons.OrderBy(d => d.PokemonId).ToList();
        }
        public void SortByName()
        {
            InventoryPokemons = InventoryPokemons.OrderBy(d => d.PokemonId.ToString()).ToList();
        }

        public void SortByDate()
        {
            InventoryPokemons = InventoryPokemons.OrderByDescending(d => d.Date).ToList();
        }

        public void ItemClick(object sender, ItemClickEventArgs args)
        {
            var clickedItem = args.ClickedItem as InventoryPokemonWrapper;
            if (clickedItem != null)
            {
                //Parameter needs to be a string, ulong is too big for serialization
                BootStrapper.Current.NavigationService.Navigate(typeof(PokemonDetailPage), clickedItem.Id.ToString());
            }
        }
    }
}

