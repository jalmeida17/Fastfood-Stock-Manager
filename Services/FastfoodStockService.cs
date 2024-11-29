using LEARNING_.NET_API_ANGULAR;

namespace ContosoPizza.Services;

public static class FastfoodStockService
{
    static List<FastfoodStock> Restaurants { get; }
    static int nextId = 3;
    static FastfoodStockService()
    {
        Restaurants = new List<FastfoodStock>
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
                }
        };
    }

    public static List<FastfoodStock> GetAll() => Restaurants;

    public static FastfoodStock? Get(int id) => Restaurants.FirstOrDefault(p => p.Id == id);

    public static void Add(FastfoodStock fastfoodStock)
    {
        fastfoodStock.Id = nextId++;
        Restaurants.Add(fastfoodStock);
    }

    public static void Delete(int id)
    {
        var fastfoodStock = Get(id);
        if(fastfoodStock is null)
            return;

        Restaurants.Remove(fastfoodStock);
    }

    public static void Update(FastfoodStock fastfoodStock)
    {
        var index = Restaurants.FindIndex(p => p.Id == fastfoodStock.Id);
        if(index == -1)
            return;

        Restaurants[index] = fastfoodStock;
    }
}