using ContosoPizza.Data;
using LEARNING_.NET_API_ANGULAR;

namespace ContosoPizza.Services;

public static class FastfoodStockService
{
    static int nextId;

    public static List<FastfoodStock> GetAll() => FastfoodStockData.GetAll();
    public static FastfoodStock? Get(int id) => FastfoodStockData.GetById(id);
    public static bool Add(FastfoodStock fastfoodStock)
    {
        nextId = GetAll().Count + 1;

        if (fastfoodStock.Id == 0 || GetAll().Any(r => r.Id == fastfoodStock.Id))
        {
            fastfoodStock.Id = nextId++;
        }
        return FastfoodStockData.Create(fastfoodStock);
    }

    public static bool Delete(int id)
    {
        var fastfoodStock = Get(id);
        if(fastfoodStock is null)
            return false;

        return FastfoodStockData.Delete(id);
    }

    public static bool Update(FastfoodStock fastfoodStock)
    {
        var index = GetAll().FindIndex(p => p.Id == fastfoodStock.Id);
        if(index == -1)
            return false;
        
        return FastfoodStockData.Update(fastfoodStock);
    }


    public static int GetCokeSum() => GetAll().Sum(c => c.Coke);
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