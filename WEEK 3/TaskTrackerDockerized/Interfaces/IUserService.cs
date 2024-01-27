using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using TaskTracker.Models;

namespace TaskTracker.Interfaces
{
    public interface IUserService
    {
        string Login(string username, string password);
        User Register(User user);
    }
}
