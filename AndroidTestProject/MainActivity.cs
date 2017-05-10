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

            RadioGroup rg = (RadioGroup)FindViewById(Resource.Id.radioGroup1);
            rg.CheckedChange += Rg_CheckedChange;
        }


        /// <summary>
        /// ボタンクリックイベントでトースト表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Click(object sender, EventArgs e)
        {
            try{
                //トースト表示中なら表示を一旦キャンセルする（連打対応）
                if (t != null){
                    t.Cancel();
                }

                //トースト表示
                t = Toast.MakeText(this, "Hello,Xamarin.Android", ToastLength.Long);

                t.Show();
            }
            catch(Exception ex){
                Console.Write("例外発生" + ex.ToString());
            }
        }

        /// <summary>
        /// ラジオグループ内のチェックが変更されたときのイベントでトースト表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rg_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            //選択されたラジオグループのオブジェクトを取得
            RadioGroup rg = (RadioGroup)sender;
            
            //チェックされたラジオボタンのid値を取得
            int rbId = rg.CheckedRadioButtonId;

            //チェックされたラジオボタンを取得
            RadioButton rb = (RadioButton)FindViewById(rbId);
            
            //チェックされたラジオボタンのid名を取得（String.xmlで記載したid名を取得）
            String rbResoueceIdName = Resources.GetResourceEntryName(rbId);

            try
            {
                //トースト表示中なら表示を一旦キャンセルする（連打対応）
                if (t != null)
                {
                    t.Cancel();
                }

                //トースト表示
                t = Toast.MakeText(this, "CheckedText: " + rb.Text.ToString() 
                    + ",\r\n ID名: " + rbResoueceIdName.ToString() 
                    + ",\r\n ID値: " + rb.Id.ToString() , ToastLength.Long);

                t.Show();
            }
            catch (Exception ex)
            {
                Console.Write("例外発生" + ex.ToString());
            }
        }
    }
}

