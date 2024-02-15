using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    SqlConnection objcon;
    protected void Page_Load(object sender, EventArgs e)
    {
        string constr = @"data source=.;initial catalog=demo;integrated security=SSPI";
         objcon = new SqlConnection(constr);
         lblmessagebox.Visible = false;

    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
       

    }
    protected void btngo_Click(object sender, EventArgs e)
    {

        SqlDataAdapter objadapt = new SqlDataAdapter("select * from login where username='" + txtusername.Text + "' and password='"+txtpassword.Text+"'", objcon);
        DataTable objdt = new DataTable();
        objadapt.Fill(objdt);
        if (objdt.Rows.Count > 0)
        {


            if (objdt.Rows[0]["usertype"].ToString() == "admin")
            {

                
                Session["username"] = txtusername.Text;
                Response.Redirect("adminpanel.aspx");
            }
           
            else
            {

                if (objdt.Rows[0]["usertype"].ToString() == "user")
                {


                    Session["username"] = txtusername.Text;
                    Response.Redirect("userpanel.aspx");
                }
                else
                {
                    if (objdt.Rows[0]["usertype"].ToString() == "employee")
                    {
                        Response.Redirect("employeepanel.aspx");
                    }

                }
            }
        }
        else 
        {
            lblmessagebox.Visible = true;
            lblmessagebox.Text = "Incorrect Password ";
            txtpassword.Text = "";
           
            txtpassword.Focus();
        
        }
    }
    protected void lnkbtnforgetpass_Click(object sender, EventArgs e)
    {
        Response.Redirect("Forget_password.aspx");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Forget_password.aspx");
    }
}