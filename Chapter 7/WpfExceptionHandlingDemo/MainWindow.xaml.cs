using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace WpfExceptionHandlingDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ExceptionManager exceptionManager;
        FileStream fileStream;

        public MainWindow()
        {
            InitializeComponent();
            InitializeExceptionManager();
        }

        /// <summary>
        /// Initialize the ExceptionManger.
        /// </summary>
        private void InitializeExceptionManager()
        {
            LogWriterFactory logWriterFactory = new LogWriterFactory();
            Logger.SetLogWriter(logWriterFactory.Create());

            ExceptionPolicyFactory exceptionFactory = new ExceptionPolicyFactory();
            exceptionManager = exceptionFactory.CreateManager();
        }

        /// <summary>
        /// Open the FileStream.
        /// </summary>
        /// <param name="filename">The filename to open the FileStream on.</param>
        private void OpenFile(string filename) => exceptionManager.Process(() => fileStream = File.Open(filename, FileMode.Open, FileAccess.Read), "FilePolicy");

        /// <summary>
        /// Get the next byte from the file.
        /// </summary>
        /// <returns>The next byte in the file.</returns>
        private int GetFileByte()
        {
            int fileByte = 0;
            exceptionManager.Process(() => fileByte = fileStream.ReadByte(), "FilePolicy");
            return fileByte;
        }

        private void FileNotFoundExceptionButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFile("myfakefile.txt");
            }
            catch (Exception ex)
            {
                HandleMyException("FileNotFoundExceptionButton_Click", ex);
            }
        }

        /// <summary>
        /// Add the exception information to the ExcpetionOutputTextBox.
        /// </summary>
        /// <param name="exceptionPrefix"></param>
        /// <param name="ex"></param>
        private void HandleMyException(string exceptionPrefix, Exception ex)
        {
            string exceptionDetails = $"{exceptionPrefix} Excpetion: {ex.Message} {System.Environment.NewLine}";
            if (ex.InnerException != null) exceptionDetails += $"{exceptionPrefix} Excpetion: {ex.InnerException.Message} {System.Environment.NewLine}";
            ExceptionOutputTextBox.Text += exceptionDetails;
        }

        private void NullReferenceExceptionButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int fileByte = GetFileByte();
                MessageBox.Show(fileByte.ToString());
            }
            catch (Exception ex)
            {
                HandleMyException("NullReferenceExceptionButton_Click", ex);
            }
        }
    }
}
