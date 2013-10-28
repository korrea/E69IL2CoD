using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E69IL2CoD
{
    public abstract class SimulatorClass
    {
        public TelemetryInfo telemetryData { get; set; }
        public abstract bool StartUp();
        public abstract bool GetData();
        public abstract void ShutDown();
    }
}
