using CpuMonitorToolkit.Utility;
using GalaSoft.MvvmLight;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace CpuMonitorToolkit.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {

        [DllImport("kernel32")]
        public static extern void GetSystemDirectory(StringBuilder SysDir, int count);
        [DllImport("kernel32")]
        public static extern void GetSystemInfo(ref CPU_INFO cpuinfo);
        [DllImport("kernel32")]
        public static extern void GlobalMemoryStatus(ref MEMORY_INFO meminfo);
        [DllImport("kernel32")]
        public static extern void GetSystemTime(ref SYSTEMTIME_INFO stinfo);
        public static PerformanceCounter _cpuNT;


        private string cpu;

        /// <summary>
        /// cpu使用率
        /// </summary>
        public string Cpu
        {
            get
            {
                return cpu;
            }

            set
            {
                cpu = value;
                RaisePropertyChanged(() => Cpu);
            }
        }


        private string memory;

        /// <summary>
        /// 内存
        /// </summary>
        public string Memor
        {
            get
            {
                return memory;
            }

            set
            {
                memory = value;
                RaisePropertyChanged(() => Memor);
            }
        }



        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            Thread thread = new Thread(new ThreadStart(StartMonitor));
            //调用Start方法执行线程
            thread.Start();
        }

        private void StartMonitor()
        {
            Memor = "0";
            Cpu = "0";
            _cpuNT = new PerformanceCounter("Processor", "% Processor Time", "_Total");

            MEMORY_INFO MemInfo;
            MemInfo = new MEMORY_INFO();
            while (true)
            {
                GlobalMemoryStatus(ref MemInfo);

                Memor = MemInfo.dwMemoryLoad.ToString("0") + "%";

                Cpu = _cpuNT.NextValue().ToString("0") + "%";

                System.Threading.Thread.Sleep(2000);
            }
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}