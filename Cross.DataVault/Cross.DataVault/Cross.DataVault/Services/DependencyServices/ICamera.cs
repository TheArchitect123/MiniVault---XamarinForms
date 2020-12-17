using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cross.DataVault.Services.DependencyServices
{
    public interface ICamera
    {
        void TakePhoto();
        CameraPacket TakePhoto_WithResult();

        void TakeVideo();
        CameraPacket TakeVideo_WithResult();
    }
}
