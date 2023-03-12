using com.mobiquity.packer.APIException;
using com.mobiquity.packer.Packer;

public class BagInputValidator
{
    private const int MaxBagWeight = 100;
    private const int MaxNumItems = 15;
    private const int MaxItemWeight = 100;
    private const int MaxItemCost = 100;

    public bool Validate(Bag bag)
    {
        var errorMessage = "";

        // Check bag weight
        if (bag.Weight <= 0 || bag.Weight > MaxBagWeight)
        {
            errorMessage = "Bag weight must be between 1 and 100.";
            throw new APIException(errorMessage);
        }

        // Check number of items
        if (bag.Items == null || bag.Items.Count == 0)
        {
            errorMessage = "Bag must contain at least one item.";
            throw new APIException(errorMessage);
        }
        if (bag.Items.Count > MaxNumItems)
        {
            errorMessage = $"Bag can contain at most {MaxNumItems} items.";
            throw new APIException(errorMessage);
        }

        // Check each item
        foreach (var item in bag.Items)
        {
            if (item.Weight <= 0 || item.Weight > MaxItemWeight)
            {
                errorMessage = "Item weight must be between 1 and 100.";
                throw new APIException(errorMessage);
            }
            if (item.Cost < 0 || item.Cost > MaxItemCost)
            {
                errorMessage = "Item cost must be between 0 and 100.";
                throw new APIException(errorMessage);
            }
        }

        return true;
    }
}