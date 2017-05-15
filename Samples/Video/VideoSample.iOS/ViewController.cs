using System;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions.Enums;
using Plugin.MediaManager.Abstractions.Implementations;
using UIKit;

namespace MediaSample.iOS
{
    public partial class ViewController : UIViewController
    {
        VideoSurface _videoSurface;

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            _videoSurface = new VideoSurface();
            VideoView.Add(_videoSurface);
            CrossMediaManager.Current.VideoPlayer.RenderSurface = _videoSurface;
            CrossMediaManager.Current.PlayingChanged += (sender, e) => ProgressView.Progress = (float)e.Progress;
        }

        public override void ViewDidLayoutSubviews()
        {
            _videoSurface.Frame = VideoView.Frame;
            base.ViewDidLayoutSubviews();
        }

        partial void PlayButton_TouchUpInside(UIButton sender)
        {
			//	Videos

			//270p: https://12-lvl3-pdl.vimeocdn.com/01/4788/4/123942907/352609692.mp4?expires=1494851227&token=05e93dd1c79575c6a4ed1
			//720p: https://12-lvl3-pdl.vimeocdn.com/01/4788/4/123942907/352609691.mp4?expires=1494851227&token=00c65ae10f7f5754ecf74
			//360p: https://12-lvl3-pdl.vimeocdn.com/01/4788/4/123942907/352609677.mp4?expires=1494851227&token=0dcec5787ed6386c9e8f8
			//Subtitles
			//		en : https://vimeo.com/texttrack/2815054.vtt?token=59199d6f_0x817c6771b8c8d6b133dca1b8c6d246260c70797f
			//es: https://vimeo.com/texttrack/2815057.vtt?token=59199d6f_0xb9f1cb9865e7c2a605ec6ac23e7902aa7197f989
			//fr: https://vimeo.com/texttrack/2815046.vtt?token=59199d6f_0x79ee6450b749fa3ec3d282eed071752141dd43a8


			var video = new MediaFile() {
                Url = "https://12-lvl3-pdl.vimeocdn.com/01/4788/4/123942907/352609692.mp4?expires=1494868193&token=099622a901a57ad812d77",
				Type = MediaFileType.Video,
            };
            CrossMediaManager.Current.Play(video);
        }
    }
}

