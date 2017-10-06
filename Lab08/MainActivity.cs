using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab08
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            /*
            var ViewGroup = (Android.Views.ViewGroup)Window.DecorView.FindViewById(Android.Resource.Id.Content);
            var MainLayout = ViewGroup.GetChildAt(0) as LinearLayout;
            var HeaderImage = new ImageView(this);
            HeaderImage.SetImageResource(Resource.Drawable.Xamarin_Diplomado_30);

            MainLayout.AddView(HeaderImage);
            var UserNameTextView = new TextView(this);
            UserNameTextView.Text = GetString(Resource.String.UserName);
            MainLayout.AddView(UserNameTextView);
            */
            Validate();
        }
        private async void Validate()
        {
            var nombre = FindViewById<TextView>(Resource.Id.Nombre);
            var status = FindViewById<TextView>(Resource.Id.Estatus);
            var token = FindViewById<TextView>(Resource.Id.Codigo);

            var ServiceClient = new SALLab08.ServiceClient();

            string StudentEmail = "shadowghost-1996@hotmail.com";
            string Password = "santuario1";

            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);
            var Result = await ServiceClient.ValidateAsync(StudentEmail, Password, myDevice);
            nombre.Text= $"{Result.Fullname}";
            status.Text= $"{Result.Status}";
            token.Text= $"{Result.Token}";
            //menssage.Text = $"{Result.Status}\n{Result.Fullname}\n{Result.Token}";

        }
    }
}

