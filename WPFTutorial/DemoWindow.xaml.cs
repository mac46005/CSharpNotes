using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WPFTutorial
{
    /// <summary>
    /// Interaction logic for DemoWindow.xaml
    /// </summary>
    public partial class DemoWindow : Window
    {
        public int secondsCount = 0;
        public DemoWindow()
        {
            InitializeComponent();
            DispatcherTimer disTmr = new DispatcherTimer();
            disTmr.Tick += new EventHandler(disTmr_Tick);
            disTmr.Interval = new TimeSpan(0, 0, 1);
            disTmr.Start();
        }
        public void disTmr_Tick(object obj,EventArgs e)
        {
            secondsCount++;
            secondsBlock.Text = $"{secondsCount} Seconds";
        }

    }
}
