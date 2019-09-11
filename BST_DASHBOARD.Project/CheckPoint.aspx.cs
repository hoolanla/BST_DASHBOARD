using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

namespace BST_DASHBOARD.Project
{
    public partial class CheckPoint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            if (Session["Admin"] == null)
            {
                Response.Redirect("Authorize.aspx");
            }


            if (!IsPostBack)
            {
                string AddHour = ConfigurationManager.AppSettings["AddMinutes"];
                RadDateTimePicker1.SelectedDate = DateTime.Now.AddMinutes(Int32.Parse(AddHour));
                RadDateTimePicker2.SelectedDate = DateTime.Now.AddMinutes(0);
                ButtonReport.Visible = false;
            }
            else
            {

                initData();


            }
         
        }

        private void initData()
        {

            MODEL.Criteria criteria = new MODEL.Criteria();
            BLL.Data _BLL = new BLL.Data();

            criteria.dateFrom = DateTime.Parse(RadDateTimePicker1.SelectedDate.ToString()).ToString("dd/MM/yyyy HH:mm:ss ");
            criteria.dateTo = DateTime.Parse(RadDateTimePicker2.SelectedDate.ToString()).ToString("dd/MM/yyyy HH:mm:ss ");
            Session["DATETO"] = criteria.dateTo;
            Session["DATEFROM"] = criteria.dateFrom;

            DataTable dt;

            dt = _BLL.getDataCheckPoint(criteria);



            foreach (DataRow dr in dt.Rows) // search whole table
            {
              
                    dr["panelTimeOutput"] = _BLL.panelDTOutput(dr["panelTime"].ToString()); //change the name
                    if (dr["Company"].ToString() == "")
                    {
                        dr["Company"] = "NA";
                    }
               
            }


            ButtonReport.Visible = true;


            Session["REPORT"] = dt;
            RadGrid1.DataSource = dt;
            RadGrid1.DataBind();
        }

        protected void SubmitLinkButton_Click(object sender, EventArgs e)
        {

            initData();


        }

      

        protected void SubmitButtonReport_Click(object sender, EventArgs e)
        {

            Response.Redirect("Report/CheckPointReport.aspx");
        }
    }
}