using Android.App;
using Android.Content;
using Android.OS;

namespace ThreadDemo
{
    public class LoginTask : AsyncTask
    {
        private ProgressDialog _progressDialog;
        private LoginService _loginService;
        private Context _context;

        public LoginTask(Context context, LoginService loginService)
        {
            _context = context;
            _loginService = loginService;
        }

        protected override void OnPreExecute()
        {
            base.OnPreExecute();

            _progressDialog = ProgressDialog.Show(_context, "Login In Progress", "Please wait...");
        }

        protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
        {
            _loginService.Login(@params[0].ToString());

            return true;
        }

        protected override void OnPostExecute(Java.Lang.Object result)
        {
            base.OnPostExecute(result);

            _progressDialog.Hide();

            new AlertDialog.Builder(_context)
                .SetTitle("Login Successful")
                .SetMessage("Great success!")
                .Show();
        }
    }
}