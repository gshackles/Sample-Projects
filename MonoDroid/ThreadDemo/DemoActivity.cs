using Android.App;
using Android.OS;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadDemo
{
    [Activity(Label = "Thread Demo", MainLauncher = true)]
    public class DemoActivity : Activity
    {
        private LoginService _loginService;
        private ProgressDialog _progressDialog;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            _loginService = new LoginService();
            _progressDialog = new ProgressDialog(this) { Indeterminate = true };
            _progressDialog.SetTitle("Login In Progress");
            _progressDialog.SetMessage("Please wait...");

            loginSynchronously();
            //loginWithThread();
            //loginWithJavaThread();
            //loginWithThreadPool();
            //loginWithAsyncTask();
            //loginWithTaskLibrary();
        }

        private void loginSynchronously()
        {
            _progressDialog.Show();

            _loginService.Login("greg");

            onSuccessfulLogin();
        }

        private void loginWithThread()
        {
            _progressDialog.Show();

            new Thread(new ThreadStart(() =>
            {
                _loginService.Login("greg");

                RunOnUiThread(() => onSuccessfulLogin());
            })).Start();
        }

        private void loginWithJavaThread()
        {
            _progressDialog.Show();

            new Java.Lang.Thread(() =>
            {
                _loginService.Login("greg");

                RunOnUiThread(() => onSuccessfulLogin());
            }).Start();
        }

        private void loginWithThreadPool()
        {
            _progressDialog.Show();

            ThreadPool.QueueUserWorkItem(state =>
            {
                _loginService.Login("greg");

                RunOnUiThread(() => onSuccessfulLogin());
            });
        }

        private void loginWithAsyncTask()
        {
            new LoginTask(this, _loginService).Execute("greg");
        }

        private void loginWithTaskLibrary()
        {
            _progressDialog.Show();

            Task.Factory
                .StartNew(() => 
                    _loginService.Login("greg")
                )
                .ContinueWith(task => 
                    RunOnUiThread(() => 
                        onSuccessfulLogin()
                    )
                );
        }

        private void onSuccessfulLogin()
        {
            _progressDialog.Hide();

            new AlertDialog.Builder(this)
                .SetTitle("Login Successful")
                .SetMessage("Great success!")
                .Show();
        }
    }
}