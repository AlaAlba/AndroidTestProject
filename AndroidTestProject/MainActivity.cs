using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System;

namespace AndroidTestProject
{
    [Activity(Label = "AndroidTestProject", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        /// <summary>
        /// トースト表示用
        /// </summary>
        private Toast t = null;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="bundle"></param>
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            Button btn = (Button)FindViewById(Resource.Id.button1);
            btn.Click += Btn_Click;
        }

        /// <summary>
        /// ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Click(object sender, EventArgs e)
        {
            try{
                if (t != null){
                    t.Cancel();
                }

                t = Toast.MakeText(this, "Hello,Xamarin.Android", ToastLength.Long);

                t.Show();
            }
            catch(Exception ex){
                Console.Write("例外発生" + ex.ToString());
            }
        }
    }
}

