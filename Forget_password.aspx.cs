using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forget_password : System.Web.UI.Page
{
    SqlConnection objcon;
    protected void Page_Load(object sender, EventArgs e)
    {
        string constr = @"data source=.;initial catalog=demo;integrated security=SSPI";
        objcon = new SqlConnection(constr);
         txtpassword.Enabled=false;
        txtconfirmpassword.Enabled=false;
            btnsubmitt.Enabled=false;
        lblmessagebox.Enabled=false;
    }
    protected void btncheckavailability_Click(object sender, EventArgs e)
    {
        SqlDataAdapter objadapt= new SqlDataAdapter ("select * from login where username='"+txtusername.Text+"'",objcon);
        DataTable objdt= new DataTable ();
        objadapt.Fill(objdt);
        if (objdt.Rows.Count > 0)
        {
            txtpassword.Enabled = true;
            txtconfirmpassword.Enabled = true;
            btnsubmitt.Enabled = true;
        }
        else
        {
            lblmessagebox.Text = "The User Name Not Found";
        }
    }
    protected void btnsubmitt_Click(object sender, EventArgs e)
    {
        if (txtpassword.Text == txtconfirmpassword.Text)
        {
            SqlCommand objcomm = new SqlCommand("update login set password='" + txtpassword.Text + "' where username='" + txtusername.Text + "'", objcon);
            objcon.Open();
            objcomm.ExecuteNonQuery();
            objcon.Close();
            txtpassword.Text = "";
            txtconfirmpassword.Text = "";
            txtusername.Text = "";
            lblmessagebox.Text = "The Password Has Been Changed";
            txtpassword.Text = "";
            txtusername.Text = "";
            txtconfirmpassword.Text = "";
            txtusername.Focus();
            

        }
        else
        {
            lblmessagebox.Text = "check your password again";
            txtpassword.Text = "";
            txtconfirmpassword.Text = "";
            txtpassword.Focus();
            txtpassword.Enabled = true;
            txtconfirmpassword.Enabled = true;
            btnsubmitt.Enabled = true;
           
        }
    }
}