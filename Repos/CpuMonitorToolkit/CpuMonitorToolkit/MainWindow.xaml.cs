using System.Windows;
using CpuMonitorToolkit.ViewModel;

namespace CpuMonitorToolkit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.Left = SystemParameters.WorkArea.Width / 2;
            this.Top = SystemParameters.WorkArea.Height / 2;

            Closed += (s, e) => App.Current.Shutdown();
        }

        private void LayoutRoot_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            base.DragMove();
        }
    }
}