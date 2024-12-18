using LEARNING_.NET_API_ANGULAR;
using LEARNING_.NET_API_ANGULAR.Models;

namespace ContosoPizza.Data;

public static class FastfoodStockData
{
    public static List<FastfoodStock> Restaurants { get; private set; } = new();

    // Méthode pour initialiser les données à partir du DbContext
    public static void Initialize(ApplicationContext context)
    {
        Restaurants = context.FastfoodStocksDbSet.ToList();
    }
}
