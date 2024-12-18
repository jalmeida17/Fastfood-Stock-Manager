using LEARNING_.NET_API_ANGULAR;
using ContosoPizza.Data;

namespace ContosoPizza.Services;

public static class FastfoodStockService
{
    static List<FastfoodStock> Restaurants { get; } = FastfoodStockData.Restaurants;
    static int nextId;

    public static List<FastfoodStock> GetAll() => Restaurants;

    public static FastfoodStock? Get(int id) => Restaurants.FirstOrDefault(p => p.Id == id);

    public static int GetCokeSum() => Restaurants.Sum(c => c.Coke);

    public static void Add(FastfoodStock fastfoodStock)
    {
        nextId = Restaurants.Count + 1;

        if (fastfoodStock.Id == 0 || Restaurants.Any(r => r.Id == fastfoodStock.Id))
        {
            fastfoodStock.Id = nextId++;
        }
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
    public static FastfoodStock CreateOrUpdate(FastfoodStock fastfoodStock)
    {
        var existingStock = Get(fastfoodStock.Id);

        if (existingStock == null)
        {
            Add(fastfoodStock);
        }
        else
        {
            Update(fastfoodStock);
        }
        return fastfoodStock;

    }
}