using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

public partial class adminpanel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*string constr = @"data source=.;initial catalog=demo;integrated security =SSPI";
        SqlConnection objcon = new SqlConnection(constr);
        SqlDataAdapter objadapt= new SqlDataAdapter ("select * from register where usemame='"+Session["username"].ToString()+"'",objcon );
        DataTable objdt= new DataTable ();
        objadapt.Fill(objdt);*/

        lblmessageshow.Text = "Welcome....." + Session["username"].ToString();

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("ademployee.aspx");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Assigncomplain.aspx");
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewcomplain.aspx");
    }
}