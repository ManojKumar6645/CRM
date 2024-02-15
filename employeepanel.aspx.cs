using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class employeepanel : System.Web.UI.Page
{
    SqlConnection objcon;
    int i;
    protected void Page_Load(object sender, EventArgs e)
    {
        string constr = @"data source=.; initial catalog= demo; integrated security=SSPI";
        objcon = new SqlConnection(constr);
        ddldd.Items.Clear();
        ddlmm.Items.Clear();
        ddlyy.Items.Clear();
        ddlstatus.Items.Clear();
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
        ddlstatus.Items.Add("Completed");
        ddlstatus.Items.Add(" Not Completed");

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (ddlstatus.Text == "Completed")
        {

            SqlCommand objcom1 = new SqlCommand("update complain set status ='" + ddlstatus.Text + "' where complainno ='" + ddlcomplainno.Text + "'", objcon);
            objcon.Open();
            objcom1.ExecuteNonQuery();
            objcon.Close();

        }
        else
        {
            string date = ddldd.Text + "-" + ddlmm.Text + "-" + ddlyy.Text;
            SqlCommand objcom = new SqlCommand("insert into complainstatus(complainno,status,dateofupdate)values('" + ddlcomplainno.Text + "','" + ddlstatus.Text + "','" + date + "')", objcon);
            objcon.Open();
            objcom.ExecuteNonQuery();
            objcon.Close();
           
            

            }
        lblmessage.Text = "One Complain Updated ";
    }
    protected void btncompnfill_Click(object sender, EventArgs e)
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
}