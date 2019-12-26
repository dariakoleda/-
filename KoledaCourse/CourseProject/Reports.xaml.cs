using Microsoft.Reporting.WinForms;
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

namespace CourseProject
{
    /// <summary>
    /// Логика взаимодействия для Reports.xaml
    /// </summary>
    public partial class Reports : Window
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void FillReportViewer()
        {
            string reportName = "";
            string dataSourceName = "";
            string tableName = "";
            switch (comboBoxReports.SelectedIndex)
            {
                case 0:
                    {
                        reportName = "ReportTopics";
                        dataSourceName = "DSTopics";
                        tableName = "Topics";
                        break;
                    }
            }
            Connector connector = new Connector();
            var table = connector.GetTableByType(typeof(Topics));
            ReportDataSource reportDataSource = new ReportDataSource(dataSourceName, table);
            reportViewerMain.LocalReport.DataSources.Add(reportDataSource);
            reportViewerMain.LocalReport.ReportEmbeddedResource = $"CourseProject.{reportName}.rdlc";
            reportViewerMain.RefreshReport();
        }

        private void buttonShowReport_Click(object sender, RoutedEventArgs e)
        {
            reportViewerMain.Reset();
            FillReportViewer();
        }
    }
}
