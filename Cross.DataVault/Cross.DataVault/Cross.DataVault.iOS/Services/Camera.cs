using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using Cross.DataVault.Services.DependencyServices;

namespace Cross.DataVault.iOS.Services
{
    public class Camera : ICamera
    {
        public void TakePhoto()
        {


        }

        public CameraPacket TakePhoto_WithResult()
        {
            return null;
        }

        public void TakeVideo()
        {


        }

        public CameraPacket TakeVideo_WithResult()
        {
            return null;

        }
    }
}