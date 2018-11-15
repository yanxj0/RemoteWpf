using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Management;

namespace RemoteWpf
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            getRemoteCon();
        }

        public void getRemoteCon()
        {
            ConnectionOptions options = new ConnectionOptions();
            //设定用于WMI连接操作的用户名 
            options.Username = "administrator";
            //设定用户的口令
            options.Password = "dist@2017";
            ManagementScope scope = new ManagementScope("\\\\192.168.200.113\\root\\cimv2", options);
            scope.Connect();
            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_Process");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
            ManagementObjectCollection queryCollection = searcher.Get();
            foreach (ManagementObject m in queryCollection)
            {
                // Display the remote computer information
                MessageBox.Show("Process Name : " + m["Name"]);
                MessageBox.Show("User Name : " + m["ProcessID"]);
                MessageBox.Show("ProcessID : " + m["ParentProcessID"]);
            }
            
        }

    }
}
