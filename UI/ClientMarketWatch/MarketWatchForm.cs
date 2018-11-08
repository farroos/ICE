using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace ClientMarketWatch
{
    public partial class MarketWatchForm : Form
    {
        private BindingSource bindingSource;
        private readonly List<MarketWatchSymbol> symbolList = new List<MarketWatchSymbol>();

        public MarketWatchForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var marketWatchSourcesSection =
                ConfigurationManager.GetSection("MaretWatchSourceSection") as MaretWatchSourcesSection;
            if (marketWatchSourcesSection != null)
                foreach (MarketWatchSource source in marketWatchSourcesSection.Sources)
                {
                    var client = new Client(source.Name, source.Endpoint, PriceChange);
                    client.Load();
                }

            bindingSource = new BindingSource {DataSource = symbolList};
            dataGridView1.DataSource = bindingSource;
        }

        private void PriceChange(string source, string symbol, decimal price)
        {
            var temp = symbolList.FirstOrDefault(s => s.Name == $"{source}/{symbol}");

            if (temp != null)
                temp.Price = price;
            else
                symbolList.Add(
                    new MarketWatchSymbol
                    {
                        Name = $"{source}/{symbol}",
                        Price = price
                    });

            bindingSource = new BindingSource {DataSource = symbolList};
            dataGridView1.DataSource = bindingSource;
        }
    }
}