using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class aademployee : System.Web.UI.Page
{
    SqlCommand objcom;
    SqlConnection objcon;
    protected void Page_Load(object sender, EventArgs e)
    {
        string constr = @"data source=.; initial catalog=demo; integrated security=SSPI";
        objcon = new SqlConnection(constr);
    }

  
    protected void btnsave_Click(object sender, EventArgs e)
    {
        objcom = new SqlCommand("insert into employee(employeeid,name,address,phone)values('" + txtemployeeid.Text + "','" + txtname.Text + "','" + txtaddress.Text + "','" + txtphone.Text + "')", objcon);
        objcon.Open();
        objcom.ExecuteNonQuery();
        objcon.Close();
        lblmessageshow.Text = "One record Inserted";
        txtemployeeid.Text = "";
        txtname.Text = ""; 
        txtaddress.Text = "";
        txtphone.Text = "";
    }
}