using AllEnum;
using PokemonGo.RocketAPI.GeneratedCode;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGo_UWP.Entities
{
    public class InventoryPokemonWrapper
    {
        private readonly PokemonData _data;
        public InventoryPokemonWrapper(PokemonData data)
        {
            _data = data;
        }

        #region Wrapped Properties

        public ulong Id => _data.Id;
        public PokemonId PokemonId => _data.PokemonId;

        public int StaminaPercentage => (int)(_data.Stamina / (double)_data.StaminaMax) * 100;

        public int Stamina => _data.Stamina;
        public int StaminaMax => _data.StaminaMax;

        public int Cp => _data.Cp;

        public ulong Date => _data.CreationTimeMs;

        public string Weight => _data.WeightKg.ToString("0.00 kg", CultureInfo.InvariantCulture);

        public string Height => _data.HeightM.ToString("0.00 m", CultureInfo.InvariantCulture);

        #endregion
    }
}
