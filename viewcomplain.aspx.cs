using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class viewcomplain : System.Web.UI.Page
{
    SqlConnection objcon;
    protected void Page_Load(object sender, EventArgs e)
    {
        string constr = @"data source=.;initial catalog=Demo; integrated security=SSPI";
        objcon = new SqlConnection(constr);
    }
     
    string done;
    string done1;
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (rbtnviewall.Checked == true)
        {

            SqlDataAdapter objadapt = new SqlDataAdapter("select* from complain ", objcon);
            DataTable objdt = new DataTable();
            objadapt.Fill(objdt);
            GridView1.DataSource = objdt;
            GridView1.DataBind();
        }
        else
        {
            if (rbtncompleted.Checked == true)
            {
                done = "Completed";
                SqlDataAdapter objadapt1 = new SqlDataAdapter("select * from complain where status='" + done.ToString() + "'", objcon);
                DataTable objdt1 = new DataTable();
                objadapt1.Fill(objdt1);
                GridView1.DataSource = objdt1;
                GridView1.DataBind();
            }
            else
            {
                if (rbtnuncompleted.Checked == true)
                {
                    done1 = "Not completed";
                    SqlDataAdapter objadapt2 = new SqlDataAdapter("select * from complain where status='" + done1.ToString() + "'", objcon);
                    DataTable objdt2 = new DataTable();
                    objadapt2.Fill(objdt2);
                    GridView1.DataSource = objdt2;
                    GridView1.DataBind();
                }
                else 
                {
                    lblmessageshow.Text = "Please select any option.....";
                }
            }

        }
    }
    protected void rbtncompleted_CheckedChanged(object sender, EventArgs e)
    {

    }
}