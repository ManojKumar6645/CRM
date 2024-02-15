using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Complain : System.Web.UI.Page
{
    int i;
    SqlConnection objcon;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        string constr = @"data source=.;initial catalog=demo;integrated security=SSPI";
        objcon = new SqlConnection(constr);
        lblmessageshow.Text = Session["username"].ToString();

        for (i = 1; i <= 31; i++)
        {
            ddldd.Items.Add(i.ToString());
        }

        for (i = 1; i <= 12; i++)
        {
            ddlmm.Items.Add(i.ToString());
        }

        for (i = 2000; i <= 2023; i++)
        {
            ddlyy.Items.Add(i.ToString());
        }
        ddlcomplaintype.Items.Add("Employee Satisfaction");
        ddlcomplaintype.Items.Add("Delay Salary");
        ddlcomplaintype.Items.Add("Customer Satisfaction");
        ddlcomplaintype.Items.Add("Resign letter");
       
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string date = ddldd.Text + "-" + ddlmm.Text + "-" + ddlyy.Text;
        string status = "Not completed";
        SqlCommand objcom = new SqlCommand("insert into complain(dateofcomplain,problem,complaintype,username,complainno,status)values('" + date + "','" + txtproblem.Text + "','" +ddlcomplaintype.Text + "','"+lblmessageshow.Text+"','"+txtcomplainno.Text+"','"+status.ToString()+"')", objcon);
        objcon.Open();
        objcom.ExecuteNonQuery();
        objcon.Close();
        lblmessage.Text = "Complain has been submited";
        txtproblem.Text = "";
    }
    protected void ddldd_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlcomplaintype_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}