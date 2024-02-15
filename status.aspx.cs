using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

public partial class status : System.Web.UI.Page
{
    SqlConnection objcon;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        string constr = @"data source=.;initial catalog=demo;integrated security =SSPI;";
        objcon = new SqlConnection(constr);


       SqlDataAdapter objadapt1 = new SqlDataAdapter("select * from  complain ", objcon);
        DataTable objdt1 = new DataTable();
        objadapt1.Fill(objdt1);
        ddlcomplain.DataSource = objdt1;
        ddlcomplain.DataValueField = "complainno";
        ddlcomplain.DataTextField = "complainno";
        ddlcomplain.DataBind();
          
       

    }
    protected void ddlcomplain_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void btnfill_Click(object sender, EventArgs e)
    {
       /*ddlcomplain.Items.Clear();
        SqlDataAdapter objadapt = new SqlDataAdapter("select * from complain", objcon);
        DataTable objdt = new DataTable();
        objadapt.Fill(objdt);
        foreach (DataRow dr in objdt.Rows)
        {
            ddlcomplain.Items.Add(dr["complainno"].ToString());
        }*/
    }
    protected void btnshow_Click(object sender, EventArgs e)
    {
        SqlDataAdapter objadapt2= new SqlDataAdapter("select * from complain where complainno='"+ddlcomplain.Text+"'", objcon);
        DataTable objdt2= new DataTable();
        objadapt2.Fill(objdt2);
        GridView1.DataSource = objdt2;

        GridView1.DataBind();
        

        
    }
}