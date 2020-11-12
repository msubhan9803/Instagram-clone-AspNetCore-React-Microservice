using System.Threading.Tasks;

namespace Instagram.Common.Mongo
{
    public interface IDatabaseInitializer
    {
        Task InitializeAsync();
    }
}