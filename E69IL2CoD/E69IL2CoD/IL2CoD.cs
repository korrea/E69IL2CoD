using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E69IL2CoD
{
    public class IL2CoD : SimulatorClass
    {
        private MemoryMappedFile IL2CoDFile;
        private MemoryMappedViewAccessor FileMapView;

        public IL2CoD(TelemetryInfo Telemetry)
        {
            this.telemetryData = Telemetry;
        }

        public override bool StartUp()
        {
            try
            {
                this.IL2CoDFile = MemoryMappedFile.OpenExisting("CLODDeviceLink");
                this.FileMapView = this.IL2CoDFile.CreateViewAccessor();

                this.telemetryData.IsInitialized = true;

                return true;
            }
            catch (Exception)
            {
                this.telemetryData.Clear();
                return false;
            }
        }

        public override bool GetData()
        {
            try
            {
                if (this.FileMapView != null)
                {
                    double pitch = this.FileMapView.ReadDouble((((int)E69IL2CoD.IL2CoDData.ParameterTypes.Z_Orientation * 10) + 1) * sizeof(double));
                    double roll = this.FileMapView.ReadDouble((((int)E69IL2CoD.IL2CoDData.ParameterTypes.Z_Orientation * 10) + 2) * sizeof(double));
                    double yaw = this.FileMapView.ReadDouble((((int)E69IL2CoD.IL2CoDData.ParameterTypes.Z_Orientation * 10) + 0) * sizeof(double));

                    this.telemetryData.Pitch = (float)pitch;
                    this.telemetryData.Roll = (float)roll;
                    this.telemetryData.Yaw = (float)yaw;

                    this.telemetryData.IsOnFlight = true;
                }
                else
                {
                    this.telemetryData.IsOnFlight = false;
                }

                return true;
            }
            catch (Exception)
            {
                this.telemetryData.Clear();
                return false;
            }


        }
        public override void ShutDown()
        {
            if (this.FileMapView != null)
            {
                this.FileMapView.Flush();
                this.FileMapView.Dispose();
            }
            if (this.IL2CoDFile != null)
            {
                this.IL2CoDFile.Dispose();
            }
            this.IL2CoDFile = null;
            this.FileMapView = null;
            this.telemetryData.Clear();
        }
    }
}
