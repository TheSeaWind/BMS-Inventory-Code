using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Declarations;
using Declarations.Events;
using Declarations.Media;
using Declarations.Players;
using Implementation;


namespace TPA_Utility
{
    public class VLCVideoPlay
    {
        public bool IsStart = true;
        public string CameraName;
        public string ParkingLineLocation;
        public bool IsLPR = false;
        public IMediaPlayerFactory factory;
        public IVideoPlayer IPCamPlayer;
        public string video_url;
        public string video_path;
        public IDiskPlayer DiskPlayer;
        public System.Windows.Forms.Panel PlayerPanel;        
        public void IPCamPlayStart()
        {
            try
            {
                factory = new MediaPlayerFactory(true);
                IPCamPlayer = factory.CreatePlayer<IVideoPlayer>();
                IMedia media = factory.CreateMedia<IMedia>(video_url);
                IPCamPlayer.Open(media);
                IPCamPlayer.Play();
                IsStart = IPCamPlayer.IsPlaying;
            }
            catch 
            {
                IsStart = false;
            }
            //IPCamPlayer.WindowHandle = PlayerPanel.Handle;
        }

        public void IPImageCapture(string _FileName)
        {
            IPCamPlayer.TakeSnapShot(0, _FileName);
        }
        public void SetHandle( System.Windows.Forms.Panel panel)
        {
            IPCamPlayer.WindowHandle = panel.Handle;
        }

        public void SetHandle(System.Windows.Forms.PictureBox pic)
        {
            IPCamPlayer.WindowHandle = pic.Handle;
        }
        public void IPCamPlayStop()
        {
            IPCamPlayer.Stop();
        }

        public void DiskPlayStart()
        {
            factory = new MediaPlayerFactory(true);
            DiskPlayer = factory.CreatePlayer<IDiskPlayer>();

            IMedia media = factory.CreateMedia<IMediaFromFile>(video_path);
            DiskPlayer.Open(media);
            media.Parse(true);
            DiskPlayer.Play();
        }

        public void DiskPlayStop()
        {
            IPCamPlayer.Stop();
        }  
    }
}
