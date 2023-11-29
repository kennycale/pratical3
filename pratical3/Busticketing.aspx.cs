using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pratical3
{
    public partial class BusTicketing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                if (IsPostBack == false) //You can also type as - if (!IsPostBack)
                {
                    Label1.Text = "You are accessing this page on " +
                    DateTime.Now.ToString();
                }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void calDepartDt_SelectionChanged(object sender, EventArgs e)
        {
            textDepartDt.Text = calDepartDt.SelectedDate.ToShortDateString();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void ddlTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlTo.SelectedIndex != ddlFrom.SelectedIndex)
            {
                //error
                lblError.Text = "Sorry, we do not provide service from " + ddlFrom.SelectedItem.Text + " to " + ddlTo.SelectedItem.Text + ".";
                return; //terminate when execution here
            }
            else
            {
                lblError.Text = String.Empty;
            }

            //calculate Price
            float price = 0.00f;
            int adult, child;
            adult = Convert.ToInt16(txtadult.Text);
            child = Convert.ToInt16(txtChild.Text);

            if (ddlFrom.SelectedIndex == 1 && ddlTo.SelectedIndex ==1)
            {
                //from duta to butterworth
                price = adult * 34.00f + child * 25.50f;
            }

            //putra to seremban
            if (ddlFrom.SelectedIndex ==2 && ddlTo.SelectedIndex==2)
            {
                price = adult * 6.00f + child * 4.30f;
            }

            //Display output
            txtPrice.Text = price.ToString("C2"); //Myr
        }

        protected void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtCancel_Click(object sender, EventArgs e)
        {
            txtadult.Text = string.Empty;
            txtChild.Text = string.Empty;
            ddlFrom.SelectedIndex = 0;
            ddlTo.SelectedIndex = 0;
            textDepartDt.Text = string.Empty;
            txtPrice.Text = string.Empty;
        }
    }
}