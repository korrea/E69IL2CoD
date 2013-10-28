using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E69IL2CoD
{
    public class TelemetryExtract
    {
        public bool RunCore { get; set; }

        private TelemetryInfo telemetryInfo;
        private IL2CoD il2codData;
        private SimulatorClass actualSim;
        private object changeSim;
        private int delay;

        public TelemetryExtract(TelemetryInfo TelemetryInfo)
        {
            this.telemetryInfo = TelemetryInfo;
            this.il2codData = new IL2CoD(this.telemetryInfo);
            this.RunCore = true;
            this.delay = 20;
            
            this.changeSim = new object();
            this.actualSim = this.il2codData;

            Task.Factory.StartNew(() => this.readDataSimulator(), TaskCreationOptions.LongRunning);
        }

        private void readDataSimulator()
        {
            while (this.RunCore)
            {
                try
                {
                    lock (this.changeSim)
                    {
                        this.getDataSimulator();
                    }
                }
                catch (Exception ex)
                {
                }
                Thread.Sleep(this.delay);
            }

        }

        private void getDataSimulator()
        {
            try
            {
                if (!this.actualSim.telemetryData.IsInitialized)
                {
                    this.actualSim.StartUp();

                    if (this.delay != 1000)
                    {
                        this.delay = 1000;
                    }
                }
                else
                {
                    if (this.delay != 20)
                    {
                        this.delay = 20;
                    }
                    this.actualSim.GetData();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
