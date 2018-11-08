using System.Collections.Generic;
using System.Configuration;

namespace ClientMarketWatch
{
    /// <summary>
    ///     A class used to manage subscription to one or more Market Watch sources for price updates.
    /// </summary>
    public class MaretWatchSourcesSection : ConfigurationSection
    {
        [ConfigurationProperty("Sources")]
        [ConfigurationCollection(typeof(List<MarketWatchSource>),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public MarketWatchSourceCollection Sources
        {
            get => (MarketWatchSourceCollection) this[nameof(Sources)];
            set => this[nameof(Sources)] = value;
        }
    }

    public class MarketWatchSourceCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new MarketWatchSource();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MarketWatchSource) element).Name;
        }
    }

    public class MarketWatchSource : ConfigurationElement
    {
        [ConfigurationProperty("Name", IsKey = true)]
        public string Name
        {
            get => (string) this[nameof(Name)];
            set => this[nameof(Name)] = value;
        }

        [ConfigurationProperty("Endpoint")]
        public string Endpoint
        {
            get => (string) this[nameof(Endpoint)];
            set => this[nameof(Endpoint)] = value;
        }
    }
}