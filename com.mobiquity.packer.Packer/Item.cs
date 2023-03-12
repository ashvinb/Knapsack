namespace com.mobiquity.packer.Packer
{
    public class Item
    {
        public int Index { get; }
        public double Weight { get; }
        public int Cost { get; }

        public Item(int index, double weight, int cost)
        {
            Index = index;
            Weight = weight;
            Cost = cost;
        }
    }

}