using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RDLC_ReportWithParameters_1_6_2017
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.reportViewer.RefreshReport();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            //string f = dtFromDate.Value.Date.ToShortDateString
           using( NorthwindEntities db = new NorthwindEntities()){
               //GetOrdersReport_ResultBindingSource
               GetOrdersReport_ResultBindingSource.DataSource = db.GetOrdersReport(dtFromDate.Value, dtToDate.Value).ToList();
               Microsoft.Reporting.WinForms.ReportParameter[] rParams = new Microsoft.Reporting.WinForms.ReportParameter[]{
                   new Microsoft.Reporting.WinForms.ReportParameter("fromDate",dtFromDate.Value.Date.ToShortDateString()),
                   new Microsoft.Reporting.WinForms.ReportParameter("toDate",    dtToDate.Value.Date.ToShortDateString())
               };
               reportViewer.LocalReport.SetParameters(rParams);
               reportViewer.RefreshReport();
            }
        }
    }
}
