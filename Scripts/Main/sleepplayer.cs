using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Media;
using Java.IO;
using System.Threading;
using static Android.Widget.SeekBar;
using Android.Hardware;

namespace Twinkle.Scripts.Main
{
    class sleepplayer:Fragment , ISensorEventListener
    {
        MediaPlayer mp = null;

        SensorManager sensorManager; 
        AudioRecord ar = null;
        int minSize;

        double ax, ay, az;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View v = inflater.Inflate(Resource.Layout.sleepplayer, container, false);

            ImageView playpause = v.FindViewById<ImageView>(Resource.Id.imageView2);
            SeekBar playerBar = v.FindViewById<SeekBar>(Resource.Id.seekBar1);

            Android.Net.Uri URI = Android.Net.Uri.Parse(
                Activity.GetExternalFilesDir(null).ListFiles()
                    .Where(w=>w.Path.Contains(".mp3"))
                    .Select(s=>s.Path)
                    .ToList()[0]);

            sensorManager = (SensorManager) Context.GetSystemService(Context.SensorService);
            sensorManager.RegisterListener(this, sensorManager.GetDefaultSensor(SensorType.Accelerometer), SensorDelay.Normal);

            mp = new MediaPlayer();
             mp.SetDataSource(Context, URI);
             mp.Prepare();

             playerBar.Max = mp.Duration / 1000;

             playerBar.ProgressChanged += (object sender, ProgressChangedEventArgs e) => { 
                 if (e.FromUser && mp!=null)
                 {
                     mp.SeekTo(playerBar.Progress*1000);
                 }
             };
             new Thread(()=> {
                 while (true)
                 {
                     Activity.RunOnUiThread(() => {
                         if (mp != null && (string)playpause.Tag == "1")
                         {
                             int seekCurrentPos = mp.CurrentPosition / 1000;
                             playerBar.Progress = seekCurrentPos;
                         }
                     });

                     Thread.Sleep(1000);
                 }
             }).Start();

             playpause.Click += (object sender,EventArgs e) => {
                 if ((string)playpause.Tag == "0")
                 {
                     playpause.SetImageResource(Resource.Drawable.pausebtn);
                     playpause.Tag = "1";

                     mp.Start();
                 } else
                 {
                     playpause.SetImageResource(Resource.Drawable.playbtn);
                     playpause.Tag = "0";

                     mp.Pause();
                 }
             };

            return v;
        }
        public void start()
        {
            minSize = AudioRecord.GetMinBufferSize(8000,ChannelIn.Mono, Android.Media.Encoding.Pcm16bit);
            ar = new AudioRecord(AudioSource.Mic, 8000,ChannelIn.Mono, Android.Media.Encoding.Pcm16bit, minSize);
            ar.StartRecording();
        }
        public void stop()
        {
            if (ar != null)
            {
                ar.Stop();
            }
        }
        public void getmic()
        {
            short[] buffer = new short[minSize];
            ar.Read(buffer, 0, minSize);
            int max = 0;
            foreach (short s in buffer)
            {
                
            }
        }

        public void OnSensorChanged(SensorEvent e)
        { 
            if (e.Sensor.Type==SensorType.Accelerometer)
            {
                ax=e.Values [0];
                ay=e.Values [1];
                az=e.Values [2];
            }
        }

        public void OnAccuracyChanged(Sensor sensor, [GeneratedEnum] SensorStatus accuracy)
        {
        }
    }
}