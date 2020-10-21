using System.Threading.Tasks;

namespace Instagram.Common.Mongo
{
    public interface IDatabaseSeeder
    {
         Task SeedAsync();
    }
}