using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

class Program
{
    static void Main()
    {

        /*// Sample input
        string input = @"81 : (1,53.38,€45) (2,88.62,€98) (3,78.48,€3) (4,72.30,€76) (5,30.18,€9) (6,46.34,€48)
 8 : (1,15.3,€34)
 75 : (1,85.31,€29) (2,14.55,€74) (3,3.98,€16) (4,26.24,€55) (5,63.69,€52) (6,76.25,€75) (7,60.02,€74) (8,93.18,€35) (9,89.95,€78)
 56 : (1,90.72,€13) (2,33.80,€40) (3,43.15,€10) (4,37.97,€16) (5,46.81,€36) (6,48.77,€79) (7,81.80,€45) (8,19.36,€79) (9,6.76,€64)";

        //string input = @"81 : (1,53.38,€45) (2,88.62,€98) (3,78.48,€3) (4,72.30,€76) (5,30.18,€9) (6,46.34,€48)";

        string[] lines = input.Split('\n');

        foreach (string line in lines)
        {
            string[] parts = line.Trim().Split(':');
            int maxWeight = int.Parse(parts[0].Trim());

            List<Item> items = new List<Item>();
            foreach (string itemStr in parts[1].Split(' '))
            {
                if (itemStr == "") continue;
                string[] itemParts = itemStr.Trim('(', ')').Split(',');
                items.Add(new Item(int.Parse(itemParts[0]), double.Parse(itemParts[1], CultureInfo.InvariantCulture), int.Parse(itemParts[2].Trim('€'))));
            }

            List<Item> selectedItems = Knapsack(maxWeight, items);

            if (selectedItems.Count > 0)
            {
                Console.WriteLine(string.Join(",", selectedItems.Select(x => x.Index)));
            }
            else
            {
                Console.WriteLine("-");
            }
        }


        static List<Item> Knapsack(int maxWeight, List<Item> items)
        {
            int numItems = items.Count;

            // Initialize dp matrix
            int[,] dp = new int[numItems + 1, maxWeight + 1];

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

    public static void ReadFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);


            foreach (string line in lines)
            {
                string[] parts = line.Trim().Split(':');
                int weight = int.Parse(parts[0].Trim());

                List<Bag> bagList = new List<Bag>();
                List<Item> items = new List<Item>();
                foreach (string itemStr in parts[1].Split(' '))
                {
                    if (itemStr == "") continue;
                    string[] itemParts = itemStr.Trim('(', ')').Split(',');
                    items.Add(new Item(int.Parse(itemParts[0]), double.Parse(itemParts[1], CultureInfo.InvariantCulture), int.Parse(itemParts[2].Trim('€'))));
                }

                Bag bag = new Bag();
                bag.Weight = weight;
                bag.Items = items;

                bagList.Add(bag);

                List<Item> selectedItems = Knapsack(weight, items);

                if (selectedItems.Count > 0)
                {
                    Console.WriteLine(string.Join(",", selectedItems.Select(x => x.Index)));
                }
                else
                {
                    Console.WriteLine("-");
                }
            }


            static List<Item> Knapsack(int maxWeight, List<Item> items)
            {
                int numItems = items.Count;

                // Initialize dp matrix
                int[,] dp = new int[numItems + 1, maxWeight + 1];

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
        else
        {
            Console.WriteLine("File does not exist.");
        }
    }
*/
    }

}

/*class Item
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

class Bag
{
    public  List<Item>? Items { get; set; }
    public int Weight { get; set; }
}*/




