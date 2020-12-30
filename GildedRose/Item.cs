namespace GildedRose
{
    public class Item
    {
        public string Name;
        public int Quality;
        public int SellIn;

        public Item(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public new string ToString()
        {
            return Name + ", " + SellIn + ", " + Quality;
        }
    }
}
