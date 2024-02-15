using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Assigncomplain : System.Web.UI.Page
{
    SqlConnection objcon;
    SqlCommand objcom;
    int i;
    protected void Page_Load(object sender, EventArgs e)
    {
        string constr = @"data source=.; initial catalog=demo;integrated security=SSPI";
         objcon = new SqlConnection(constr);
         ddldd.Items.Clear();
         ddlmm.Items.Clear();
         ddlyy.Items.Clear();
         ddlday.Items.Clear();
         ddlmonth.Items.Clear();
         ddlyear.Items.Clear();

        for (i = 1; i <= 31; i++)
        {
            ddldd.Items.Add(i.ToString());
            ddlday.Items.Add(i.ToString());
        }

        for (i = 1; i <= 12; i++)
        {
            ddlmm.Items.Add(i.ToString());
            ddlmonth.Items.Add(i.ToString());

        }

        for (i = 2000; i <= 2023; i++)
        {
            ddlyy.Items.Add(i.ToString());
            ddlyear.Items.Add(i.ToString());
        }

    }
    protected void btnsave_Click(object sender, EventArgs e)
    {   
          string date1 = ddldd.Text + "-" + ddlmm.Text + "-" + ddlyy.Text;
          string date2 = ddlday.Text + "-" + ddlmonth.Text + "-" + ddlyear.Text;
          objcom = new SqlCommand("insert into assigncomplain(employeedid,complainno,assignmendate,expectedresolutiondate)values('" + ddlemployeeid.Text + "','" + ddlcomplainno.Text + "','" + date1 + "','" + date2 + "')", objcon);
          objcon.Open();
          objcom.ExecuteNonQuery();
          objcon.Close();
          lblmessageshow.Text = "Assigned a complain...";
        
        

    }



    protected void btnfillcomplno_Click(object sender, EventArgs e)
    {
        ddlcomplainno.Items.Clear();
        SqlDataAdapter objadapt = new SqlDataAdapter("select * from complain", objcon);
        DataTable objdt = new DataTable();
        objadapt.Fill(objdt);
        foreach (DataRow dr in objdt.Rows)
        {
            ddlcomplainno.Items.Add(dr["complainno"].ToString());
        }
    }
    protected void btnfillid_Click(object sender, EventArgs e)
    {
        ddlemployeeid.Items.Clear();
        SqlDataAdapter objadapt = new SqlDataAdapter("select * from employee", objcon);
        DataTable objdt = new DataTable();
        objadapt.Fill(objdt);
        foreach (DataRow dr in objdt.Rows)
        {
            ddlemployeeid.Items.Add(dr["employeeid"].ToString());
        }
    }
}