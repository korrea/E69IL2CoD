using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E69IL2CoD
{
    public sealed class TelemetryInfo
    {
        public enum typeGame
        {
            IL2CoD
        }
        private typeGame gameSelected;
        public bool IsInitialized { get; set; }
        public bool IsOnFlight { get; set; }
        public float Glateral { get; set; }
        public float Glongitudinal { get; set; }
        public float Gvertical { get; set; }

        public float Pitch { get; set; }
        public float PitchRate { get; set; }
        public float Roll { get; set; }
        public float RollRate { get; set; }
        public float Yaw { get; set; }
        public float YawLast { get; set; }
        public float YawRate { get; set; }

        public TelemetryInfo()
        {
            this.Clear();
        }
        
        public void Clear()
        {
            this.IsInitialized = false;
            this.IsOnFlight = false;

            this.Glateral = 0;
            this.Glongitudinal = 0;
            this.Gvertical = 0;

            this.Pitch = 0;
            this.PitchRate = 0;
            this.Roll = 0;
            this.RollRate = 0;
            this.Yaw = 0;
            this.YawRate = 0;
            this.YawLast = 0;
            this.YawRate = 0;
        }
    }
}
