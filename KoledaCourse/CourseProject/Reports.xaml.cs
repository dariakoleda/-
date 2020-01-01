using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            try
            {
                if (comboBoxReports.SelectedItem == null)
                    throw new Exception("Выберите отчёт!");
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
                var table = connector.GetTableByName(tableName);
                ReportDataSource reportDataSource = new ReportDataSource(dataSourceName, table);
                reportViewerMain.LocalReport.DataSources.Add(reportDataSource);
                reportViewerMain.LocalReport.ReportEmbeddedResource = $"CourseProject.{reportName}.rdlc";
                reportViewerMain.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonShowReport_Click(object sender, RoutedEventArgs e)
        {
            reportViewerMain.Reset();
            FillReportViewer();
        }
    }
}
