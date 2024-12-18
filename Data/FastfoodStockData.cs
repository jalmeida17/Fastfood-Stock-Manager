using LEARNING_.NET_API_ANGULAR;

namespace ContosoPizza.Data;

public static class FastfoodStockData
{
    public static List<FastfoodStock> Restaurants { get; } = new List<FastfoodStock>
    {
        new FastfoodStock
        {
            Id = 1,
            Name = "Classic Italian",
            Location = "Rome",
            LastRestock = DateTime.Now,
            Bread = 100,
            Cheese = 50,
            Meat = 120,
            Lettuce = 80,
            Tomato = 100,
            Onion = 50,
            Pickle = 30,
            Ketchup = 200,
            Mustard = 150,
            Mayonnaise = 130,
            Potato = 300,
            Water = 500,
            Coke = 400
        },
        new FastfoodStock
        {
            Id = 2,
            Name = "Jojo's",
            Location = "Milan",
            LastRestock = DateTime.Now,
            Bread = 80,
            Cheese = 60,
            Meat = 10,
            Lettuce = 100,
            Tomato = 90,
            Onion = 60,
            Pickle = 40,
            Ketchup = 250,
            Mustard = 180,
            Mayonnaise = 150,
            Potato = 200,
            Water = 400,
            Coke = 350
        },
        new FastfoodStock
        {
            Id = 3,
            Name = "Burger Bliss",
            Location = "Paris",
            LastRestock = DateTime.Now,
            Bread = 120,
            Cheese = 70,
            Meat = 150,
            Lettuce = 60,
            Tomato = 70,
            Onion = 40,
            Pickle = 35,
            Ketchup = 300,
            Mustard = 200,
            Mayonnaise = 180,
            Potato = 350,
            Water = 600,
            Coke = 450
        },
        new FastfoodStock
        {
            Id = 4,
            Name = "Snack Haven",
            Location = "Berlin",
            LastRestock = DateTime.Now,
            Bread = 90,
            Cheese = 40,
            Meat = 80,
            Lettuce = 50,
            Tomato = 60,
            Onion = 30,
            Pickle = 20,
            Ketchup = 180,
            Mustard = 120,
            Mayonnaise = 100,
            Potato = 250,
            Water = 450,
            Coke = 300
        },
        new FastfoodStock
        {
            Id = 5,
            Name = "Grill & Chill",
            Location = "Barcelona",
            LastRestock = DateTime.Now,
            Bread = 110,
            Cheese = 65,
            Meat = 140,
            Lettuce = 70,
            Tomato = 85,
            Onion = 45,
            Pickle = 25,
            Ketchup = 220,
            Mustard = 160,
            Mayonnaise = 140,
            Potato = 270,
            Water = 520,
            Coke = 410
        }
    };
}
