using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userpanel : System.Web.UI.Page
{
    string tempname;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblmessageshow.Text = "Welcome..... " + Session["username"].ToString();
        tempname = Session["username"].ToString();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session["username"] = tempname;
        Response.Redirect("complain.aspx");
    }
    protected void linkbtnfeedback_Click(object sender, EventArgs e)
    {
        Session["username"] = tempname;
        Response.Redirect("FeedBack.aspx");
    }
    protected void LinkButton1_Click1(object sender, EventArgs e)
    {
        Response.Redirect("status.aspx");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {

    }
}