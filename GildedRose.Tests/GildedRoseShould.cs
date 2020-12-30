using Xunit;
using System;
using System.IO;
using System.Text;
using GildedRose;

namespace GildedRose.Tests
{
    public class MatchPastRunValues
    {
        [Fact]
        public void validateUpdateQuality()
        {
            var content = new string(File.ReadAllText("GildedRoseUpdate30Days.txt"));
            Assert.Equal(content, updateQuality());
        }

        public string updateQuality()
        {
            StringBuilder output = new StringBuilder();
            Item[] items =
            {
                new Item("+5 Dexterity Vest", 10, 20),
                new Item("Aged Brie", 2, 0),
                new Item("Elixir of the Mongoose", 5, 7),
                new Item("Sulfuras, Hand of Ragnaros", 0, 80),
                new Item("Sulfuras, Hand of Ragnaros", -1, 80),
                new Item("Backstage passes to a TAFKAL80ETC concert", 15, 20),
                new Item("Backstage passes to a TAFKAL80ETC concert", 10, 49),
                new Item("Backstage passes to a TAFKAL80ETC concert", 5, 49),
                new Item("Backstage passes to a TAFKAL80ETC concert", 5, 48)
            };

            GildedRose app = new GildedRose(items);

            var days = 30;

            for (var i = 0; i < days; i++)
            {
                output.Append("-------- day " + i + " --------\n");
                output.Append("Name, SellIn, Quality\n");

                foreach (var item in app.Items)
                {
                    output.Append(item.ToString());
                    output.Append("\n");
                }

                output.Append("\n");
                app.updateQuality();
            }

            return output.ToString();
        }
    }
}
