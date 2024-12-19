using LEARNING_.NET_API_ANGULAR;
using LEARNING_.NET_API_ANGULAR.Models;

namespace ContosoPizza.Data;

public static class FastfoodStockData
{
    private static IServiceProvider _provider;

    // Méthode pour initialiser les données à partir du DbContext
    public static void Initialize(IServiceProvider provider)
    {
        _provider = provider;
    }

    public static List<FastfoodStock> GetAll()
    {
        using (var scope = _provider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
            var Data = context.FastfoodStocksDbSet.ToList();
            return Data;
        }
    }

    public static bool Delete(int id)
    {
        using (var scope = _provider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

            var stock = context.FastfoodStocksDbSet.FirstOrDefault(s => s.Id == id);
            if (stock != null)
            {
                context.FastfoodStocksDbSet.Remove(stock);

                int affectedRows = context.SaveChanges();
                return affectedRows > 0;
            }

            return false;
        }
    }
   
    public static bool Create(FastfoodStock stock)
    {
        using (var scope = _provider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

            if (stock != null)
            {
                context.FastfoodStocksDbSet.Add(stock);

                int affectedRows = context.SaveChanges();
                return affectedRows > 0;
            }

            return false;
        }
    }

    public static bool Update(FastfoodStock stock)
    {
        using (var scope = _provider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

            if (stock != null)
            {
                context.FastfoodStocksDbSet.Update(stock);

                int affectedRows = context.SaveChanges();
                return affectedRows > 0;
            }

            return false;
        }
    }

    public static FastfoodStock GetById(int id)
    {

        using (var scope = _provider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
            var data = context.FastfoodStocksDbSet.First(f => f.Id == id);
            return data;
        }
    }
}
