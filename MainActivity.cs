using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace KJToCalorieConverter
{
    [Activity(Label = "My Calorie Counter", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private EditText kjInput;
        private TextView calorieOutput;
        private Button calculateButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            kjInput = FindViewById<EditText>(Resource.Id.kjInput);
            calorieOutput = FindViewById<TextView>(Resource.Id.calorieOutput);
            calculateButton = FindViewById<Button>(Resource.Id.calculateButton);

            calculateButton.Click += CalculateButton_Click;
        }

        private void CalculateButton_Click(object sender, System.EventArgs e)
        {
            if (double.TryParse(kjInput.Text, out double kjAmount))
            {
                double calorieAmount = kjAmount * 0.239006;

                calorieOutput.Text = $"{calorieAmount:N2} calories";
            }
            else
            {
                calorieOutput.Text = "Invalid kj amount";
            }
        }
    }
}