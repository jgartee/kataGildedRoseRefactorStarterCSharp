using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;
using ApprovalTests;
using ApprovalTests.Reporters;

using GildedRose;
using System.Text;

namespace GildedRose.Tests
{
    public class GildedRoseApprovals
    {
        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public void Test1()
        {
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

            var gr = new GildedRose(items);
            var output = new StringBuilder();
            var itemList = items.ToList();

            for(var i = 0 ; i < 30 ; i++){
                gr.updateQuality();
                itemList.ForEach(item => output.Append("\n" + item.ToString()));

            }

            Approvals.Verify(output.ToString());

        }
    }
}
