using Microsoft.EntityFrameworkCore;

namespace LEARNING_.NET_API_ANGULAR.Models
{
    // Ce fichier permet de "connecter" le code avec la BDD mysql
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {

            
        }

        // La table qui va être dans la bdd
        public DbSet<FastfoodStock> FastfoodStocksDbSet { get; set; }
    }


}
