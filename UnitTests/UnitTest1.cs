using Xunit;
using FluentAssertions;
using com.mobiquity.packer.Packer;

public class KnapsackTests
{
    [Fact]
    public void Knapsack_ReturnsEmptyList_WhenMaxWeightIsZero()
    {
        // Arrange
        int maxWeight = 0;
        List<Item> items = new List<Item>()
        {
            new Item(1, 10, 20),
            new Item(2, 30, 40),
            new Item(3, 50, 60)
        };

        // Act
        List<Item> result = Packer.Knapsack(maxWeight, items);

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public void Knapsack_ReturnsEmptyList_WhenItemsListIsEmpty()
    {
        // Arrange
        int maxWeight = 50;
        List<Item> items = new List<Item>();

        // Act
        List<Item> result = Packer.Knapsack(maxWeight, items);

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public void Knapsack_SelectsCorrectItems_WhenAllItemsCanBeSelected()
    {
        // Arrange
        int maxWeight = 100;
        List<Item> items = new List<Item>()
        {
            new Item(1, 10, 20),
            new Item(2, 30, 40),
            new Item(3, 50, 60)
        };

        // Act
        List<Item> result = Packer.Knapsack(maxWeight, items);

        // Assert
        result.Should().BeEquivalentTo(items);
    }

    [Fact]
    public void Knapsack_SelectsCorrectItems_WhenSomeItemsCanBeSelected()
    {
        // Arrange
        int maxWeight = 50;
        List<Item> items = new List<Item>()
        {
            new Item(1, 10, 20),
            new Item(2, 30, 40),
            new Item(3, 50, 60)
        };

        // Act
        List<Item> result = Packer.Knapsack(maxWeight, items);

        // Assert
        result.Should().HaveCount(2)
            .And.Contain(items[1])
            .And.Contain(items[0]);
    }

    [Fact]
    public void Knapsack_SelectsNoItems_WhenMaxWeightIsLessThanAnyItemWeight()
    {
        // Arrange
        int maxWeight = 5;
        List<Item> items = new List<Item>()
        {
            new Item(1, 10, 20),
            new Item(2, 30, 40),
            new Item(3, 50, 60)
        };

        // Act
        List<Item> result = Packer.Knapsack(maxWeight, items);

        // Assert
        result.Should().BeEmpty();
    }
}
