using System.Threading.Tasks;

namespace Instagram.Common.Commands
{
    public interface ICommandHandler<in T> where T : ICommand
    {
         Task HandleAsync(T command);
    }
}