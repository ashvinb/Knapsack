using System.Globalization;
using System.Text;

namespace com.mobiquity.packer.Packer
{
    public class Packer
    {
        /// <summary>
        /// Packs the items in the bag and returns the indexes of the selected items
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string? Pack(string filePath)
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                // Read each line and parse the data
                foreach (string line in lines)
                {
                    string[] parts = line.Trim().Split(':');
                    int weight = int.Parse(parts[0].Trim());

                    // Read items
                    List<Item> items = new List<Item>();
                    foreach (string itemStr in parts[1].Split(' '))
                    {
                        if (itemStr == "") continue;
                        string[] itemParts = itemStr.Trim('(', ')').Split(',');
                        items.Add(new Item(int.Parse(itemParts[0]), double.Parse(itemParts[1], CultureInfo.InvariantCulture), int.Parse(itemParts[2].Trim('€'))));
                    }

                    List<Bag> bagList = new List<Bag>();
                    Bag bag = new Bag();
                    bag.Weight = weight;
                    bag.Items = items;
                    bagList.Add(bag);

                    //Validate bag
                    BagInputValidator bagInputValidator = new BagInputValidator();  
                    var isValidBag = bagInputValidator.Validate(bag);

                    // If bag is valid, find the most valuable items that can be carried in the bag
                    if (isValidBag)
                    {
                        List<Item> selectedItems = Knapsack(weight, items);

                        StringBuilder stringBuilder = new StringBuilder();

                        if (selectedItems.Count > 0)
                        {
                            stringBuilder.Append(string.Join(",", selectedItems.Select(x => x.Index)));
                        }
                        else
                        {
                            stringBuilder.Append("-");
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Knapsack algorithm to find the most valuable items that can be carried in a bag
        /// </summary>
        /// <param name="maxWeight"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public static List<Item> Knapsack(int maxWeight, List<Item> items)
        {
            int numItems = items.Count;

            // Initialize dp matrix
            int[,] dp = new int[numItems + 1, maxWeight + 1];

            // Sort items by cost/weight ratio
            for (int i = 1; i <= numItems; i++)
            {
                Item item = items[i - 1];

                for (int j = 0; j <= maxWeight; j++)
                {
                    if (item.Weight > j)
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - (int)item.Weight] + item.Cost);
                    }
                }
            }

            // Backtrack to find items selected
            List<Item> selectedItems = new List<Item>();
            int w = maxWeight;
            for (int i = numItems; i > 0 && w > 0; i--)
            {
                if (dp[i, w] != dp[i - 1, w])
                {
                    Item item = items[i - 1];
                    selectedItems.Add(item);
                    w -= (int)item.Weight;
                }
            }
            selectedItems.Reverse();

            return selectedItems;
        }

        

    }

}