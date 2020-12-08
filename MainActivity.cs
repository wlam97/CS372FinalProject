/*
 

CS372 - Tanzina Akter

Decemeber 2nd, 2020
 
Title:
Pepe Clicker


Tony Trinh       200367523
Prajna Chakma    200361931
Wilson Lam       200367497
 
 */


using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System.Drawing;
using Android.Content;
using Android.Media;

namespace CONSTRAINTLAYOUTTEST
{
    [Activity(Label = "PepeClicker", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        int clicks = 0;
        ImageButton pepeimagebutton;
        TextView pepetextview;
        Button storebutton;
        string color;
        MediaPlayer shanty;
        protected override void OnCreate(Bundle savedInstanceState) //function called oncreation
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            shanty = MediaPlayer.Create(this, Resource.Raw.shanty2); //music will play
            shanty.Start();
            clicks = GetClicks();                                   // receiving clicks if values are changed within store
            color = GetColor();                                     //this will recognize if a color is bought in the store and update it
            pepeimagebutton = FindViewById<ImageButton>(Resource.Id.pepeimagebutton);
            pepetextview = FindViewById<TextView>(Resource.Id.pepetextview);
            pepeimagebutton.Click += pepeimagebutton_click;
            storebutton = FindViewById<Button>(Resource.Id.storebutton);
            storebutton.Click += storebutton_click;


        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent? data)
        {
            if (requestCode == 1)           //receives data from store and passes it back to the main game
            {
                if (resultCode == Result.Ok)
                {
                    clicks = data.GetIntExtra("clicksback", clicks);
                    color = data.GetStringExtra("color");
                    pepetextview.Text = clicks.ToString() + " PEPES";       //reupdating currency to match game to store

                    if (color == "orange")
                    {
                        pepeimagebutton.SetImageResource(Resource.Drawable.orange);         //if "color" is bought, it is set to that color
                    }
                    if (color == "yellow")
                    {
                        pepeimagebutton.SetImageResource(Resource.Drawable.yellow);
                    }
                    if (color == "green")
                    {
                        pepeimagebutton.SetImageResource(Resource.Drawable.green);
                    }
                    if (color == "blue")
                    {
                        pepeimagebutton.SetImageResource(Resource.Drawable.blue);
                    }
                    if (color == "violet")
                    {
                        pepeimagebutton.SetImageResource(Resource.Drawable.rainbow);
                    }
                }
            }
        }

        int GetClicks()
        {
            return Intent.GetIntExtra("clicksback", clicks);        //functions to receive clicks
        }

        void storebutton_click(object sender, System.EventArgs e)
        {
            Intent nextActivity = new Intent(this, typeof(StoreActivity));          //function to send clicks/currency and start store activity
            nextActivity.PutExtra("clicks", clicks);
            StartActivityForResult(nextActivity, 1);
        }

        string GetColor()
        {
            return Intent.GetStringExtra("color" ?? "Not received"); //receives color
        }

        void pepeimagebutton_click(object sender, System.EventArgs e) //increments on click
        {
            clicks++;
            pepetextview.Text = clicks.ToString() + " PEPES";

        }
    }

}