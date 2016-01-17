using System;
namespace JN_WELD_Service
{
    interface IDevices
    {
        void changeset(ref System.Data.DataRow row, string WeldDevice);
        System.Data.DataTable GetDrives();
        System.Data.DataTable GetDrivesChannelInfos();
        int testEqumsChannelparams(System.Data.DataRow row, string WeldDevice);
    }
}
