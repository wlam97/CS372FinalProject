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
    [Activity(Label = "PepeClicker Store")]
    public class StoreActivity : AppCompatActivity
    {
        int clicks = 0;
        int clickstostring = 0;
        ImageButton orange;
        ImageButton yellow;
        ImageButton green;
        ImageButton blue;
        ImageButton violet;
        TextView currencyclick;
        string color;
        MediaPlayer SellPepe;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.content_main);
            Button backtopepe = FindViewById<Button>(Resource.Id.backtopepe);           
            SellPepe = MediaPlayer.Create(this, Resource.Raw.SellCoins);            //variable to play music on successful purchase
            clicks = GetClicks();                                                   //getting clicks from main
            clickstostring = clicks;                                                //duping variables to get our clicks to a string
            currencyclick = FindViewById<TextView>(Resource.Id.currencyclick);      //updating currency in shop to show as string
            currencyclick.Text = clickstostring.ToString() + " PEPES";

            orange = FindViewById<ImageButton>(Resource.Id.storebutton1); //one of the store functions for purchasing a color
            orange.Click += orangebutton_click;

            yellow = FindViewById<ImageButton>(Resource.Id.storebutton2);
            yellow.Click += yellowbutton_click;

            green = FindViewById<ImageButton>(Resource.Id.storebutton3);
            green.Click += greenbutton_click;

            blue = FindViewById<ImageButton>(Resource.Id.storebutton4);
            blue.Click += bluebutton_click;

            violet = FindViewById<ImageButton>(Resource.Id.storebutton5);
            violet.Click += violetbutton_click;


            backtopepe.Click += backtopepe_click;                           //function to go back to the game from the store


        }

        void orangebutton_click(object sender, System.EventArgs e)          //if orange is clicked, pepe will be orange and currency will be subtracted + music play
        {
            if (clicks >= 25)
            {
                clicks = clicks - 25;
                clickstostring = clicks;
                currencyclick.Text = clickstostring.ToString() + " PEPES";
                color = "orange";
                SellPepe.Start();
            }
        }

        void yellowbutton_click(object sender, System.EventArgs e)
        {
            if (clicks >= 25)
            {
                clicks = clicks - 25;
                clickstostring = clicks;
                currencyclick.Text = clickstostring.ToString() + " PEPES";
                color = "yellow";
                SellPepe.Start();
            }
        }

        void greenbutton_click(object sender, System.EventArgs e)
        {
            if (clicks >= 25)
            {
                clicks = clicks - 25;
                clickstostring = clicks;
                currencyclick.Text = clickstostring.ToString() + " PEPES";
                color = "green";
                SellPepe.Start();
            }
        }

        void bluebutton_click(object sender, System.EventArgs e)
        {
            if (clicks >= 25)
            {
                clicks = clicks - 25;
                clickstostring = clicks;
                currencyclick.Text = clickstostring.ToString() + " PEPES";
                color = "blue";
                SellPepe.Start();
            }
        }

        void violetbutton_click(object sender, System.EventArgs e)
        {
            if (clicks >= 25)
            {
                clicks = clicks - 25;
                clickstostring = clicks;
                currencyclick.Text = clickstostring.ToString() + " PEPES";
                color = "violet";
                SellPepe.Start();
            }
        }



        int GetClicks()
        {
            return Intent.GetIntExtra("clicks", clicks);                    //getting clicks from main game
        }

        void backtopepe_click(object sender, System.EventArgs e)                //sending color and clicks back to main game and finishes the activity
        {
            Intent back = new Intent();
            back.PutExtra("clicksback", clicks);
            back.PutExtra("color", color);
            SetResult(Result.Ok, back);
            Finish();
        }
    }
}