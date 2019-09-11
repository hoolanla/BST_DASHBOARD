using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace BST_DASHBOARD.Project.Report
{
    public partial class MissingReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            genReport();

        }

        private bool genReport()
        {

            DataTable dtMap = new DataTable("BST");  //*** DataTable Map DataSet.xsd ***//
            DataTable m_dt = (DataTable)Session["REPORT"];

            DataRow dr = null;
            dtMap.Columns.Add(new DataColumn("FirstName", typeof(string)));
            dtMap.Columns.Add(new DataColumn("Company", typeof(string)));
            dtMap.Columns.Add(new DataColumn("PanelTimeOutput", typeof(string)));
            dtMap.Columns.Add(new DataColumn("Dept", typeof(string)));
   
            for (int i = 0; i < (m_dt.Rows.Count); i++)
            {
                dr = dtMap.NewRow();
                dr["FirstName"] = m_dt.Rows[i]["FirstName"];
                dr["Company"] = m_dt.Rows[i]["Company"];
                dr["PanelTimeOutput"] = m_dt.Rows[i]["PanelTimeOutput"];
                dr["Dept"] = m_dt.Rows[i]["Dept"];
     
              
                dtMap.Rows.Add(dr);
            }


            ReportDocument rpt = new ReportDocument();
            rpt.Load(Server.MapPath("~/Report/Missing.rpt"));

            foreach (CrystalDecisions.CrystalReports.Engine.Table crTable in rpt.Database.Tables)
            {
                TableLogOnInfo tableLogOnInfo = crTable.LogOnInfo;
                object connectionInfo = tableLogOnInfo.ConnectionInfo;
                crTable.ApplyLogOnInfo(tableLogOnInfo);
            }
            
            rpt.SetDataSource(dtMap);
            rpt.SetParameterValue("DateTo", Session["DATETO"].ToString());
            rpt.SetParameterValue("DateFrom", Session["DATEFROM"].ToString());
            CRViewer.ReportSource = rpt;
     
           
            return true;
        }
    }
}