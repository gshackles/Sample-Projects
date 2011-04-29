using System.Threading;

namespace ThreadDemo
{
    public class LoginService
    {
        public void Login(string username)
        {
            Thread.Sleep(10000);
        }
    }
}