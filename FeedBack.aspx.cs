using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FeedBack : System.Web.UI.Page
{
    SqlConnection objcon;
    int i;
   
    
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
    }
   
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        
    }
    protected void btnsubmit_Click1(object sender, EventArgs e)
    {
        string date = ddldd.Text + "-" + ddlmm.Text + "-" + ddlyy.Text;
        SqlCommand objcom = new SqlCommand("insert into feedback(username,date,feedback)values('" + lblmessageshow.Text + "','" + date + "','" + txtfeedback.Text + "')", objcon);
        objcon.Open();
        objcom.ExecuteNonQuery();
        objcon.Close();
        lblmessagebox.Text = "one feedback registered";
        
    }
}