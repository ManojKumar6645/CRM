using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registration : System.Web.UI.Page
{
    SqlConnection objcon;
    protected void Page_Load(object sender, EventArgs e)
    {
        string constr = @"data source=.;initial catalog=demo;integrated security=SSPI";
        objcon = new SqlConnection(constr);
        
        
        SqlDataAdapter objadapt1 = new SqlDataAdapter("select * from  country ", objcon);
        DataTable objdt1= new DataTable();
        objadapt1 .Fill(objdt1);
        ddlcountry.DataSource = objdt1;
        ddlcountry.DataValueField = "name";
        ddlcountry.DataTextField = "name";
        ddlcountry.DataBind();
        string countryid = objdt1.Rows[0]["countryid"].ToString();
        if(ddlcountry.SelectedIndexChanged==-1)
        {
        SqlDataAdapter objadapt2 = new SqlDataAdapter("select * from  state where countryid='"+countryid+"'", objcon);
        DataTable objdt2 = new DataTable();
        objadapt2.Fill(objdt2);
        ddlstate.DataSource = objdt2;
        ddlstate.DataValueField = "name";
        ddlstate.DataTextField = "name";
        ddlstate.DataBind();
        string stateid = objdt2.Rows[0]["stateid"].ToString();

        SqlDataAdapter objadapt3 = new SqlDataAdapter("select * from  city where stateid='" + stateid + "'", objcon);
        DataTable objdt3 = new DataTable();
        objadapt3.Fill(objdt3);
        ddlcity.DataSource = objdt3;
        ddlcity.DataValueField = "name";
        ddlcity.DataTextField = "name";
        ddlcity.DataBind();


        
    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void Btnstate_Click(object sender, EventArgs e)
    {

     /*   ddlstate.Items.Clear();
        SqlDataAdapter objadapt = new SqlDataAdapter("select * from country where name='" + ddlcountry.Text + "'", objcon);
        DataTable objdt = new DataTable();
        objadapt.Fill(objdt);

        string countryid;
        countryid = objdt.Rows[0]["countryid"].ToString();

        SqlDataAdapter objadapt1 = new SqlDataAdapter("select * from state where countryid='" + countryid + "'", objcon);
        DataTable objdt1 = new DataTable();
        objadapt1.Fill(objdt1);

        foreach (DataRow dr in objdt1.Rows)
        {

            ddlstate.Items.Add(dr["name"].ToString());
        }*/
    }
    string gender;
    protected void btnregister_Click(object sender, EventArgs e)
    {
        if (rbtnmale.Checked == true)
        {
            gender = "male";
        }
        else
        {
            gender = "female";
        }
        if (txtpassword.Text != txtconfirmpassword.Text)
        {
            lblmessagebox.Text = "password not match";

        }
       
        
            
                                    else
                                    {
                                        if (CheckBox1.Checked == true)
                                        {


                                           /* byte[] store = ASCIIEncoding.ASCII.GetBytes(txtpassword.Text);
                                            string password = Convert.ToBase64String(store);*/


                                            SqlCommand objcom = new SqlCommand("insert into register(username,phone,gender,country,state,city,pincode)values('" + txtusername.Text + "','" + txtphone.Text + "','" + gender + "','" + ddlcountry.Text + "','" + ddlstate.Text + "','" + ddlcity.Text + "','" + txtpincode.Text + "')", objcon);
                                            objcon.Open();
                                            objcom.ExecuteNonQuery();
                                            objcon.Close();

                                            string usertype;
                                            usertype = "user";
                                            SqlCommand objcom1 = new SqlCommand("insert into login(username,password,usertype)values('" + txtusername.Text + "','" +txtpassword.Text + "','" + usertype + "')", objcon);
                                            objcon.Open();
                                            objcom1.ExecuteNonQuery();
                                            objcon.Close();
                                            lblmessagebox.Text = "one record registerd";
                                        }
                                        else
                                        {
                                            lblmessagebox.Text = "Please read term and conditions";
                                        }
                                        txtusername.Text = "";
                                        txtpassword.Text = "";
                                        txtconfirmpassword.Text = "";
                                        txtphone.Text = "";
                                        ddlcity.Text = "";
                                        ddlcountry.Text = "";
                                        ddlstate.Text = "";
                                        txtpincode.Text = "";
           
                                        txtusername.Focus();
                                    }
                                }
    protected void btncheckavailability_Click(object sender, EventArgs e)
    {
        SqlDataAdapter objadapt = new SqlDataAdapter("select * from register where username='" + txtusername.Text + "'", objcon);
        DataTable objdt = new DataTable();
        objadapt.Fill(objdt);
        if (objdt.Rows.Count > 0)
        {
            lblmessagebox.Text = "User Name Not Available";
        }
        else
        {
            lblmessagebox.Text = "User Name Available";
        }
    }
    protected void btncountry_Click(object sender, EventArgs e)
    {

     /*   ddlcountry.Items.Clear();
        SqlDataAdapter objadapt = new SqlDataAdapter("select * from country", objcon);
        DataTable objdt = new DataTable();
        objadapt.Fill(objdt);
        foreach (DataRow dr in objdt.Rows)
        {
            ddlcountry.Items.Add(dr["name"].ToString());
        }*/

    }
    protected void btncity_Click(object sender, EventArgs e)
    {
       /* ddlcity.Items.Clear();
        SqlDataAdapter objadapt = new SqlDataAdapter("select * from state where name='" + ddlstate.Text + "'", objcon);
        DataTable objdt = new DataTable();
        objadapt.Fill(objdt);

        string stateid;
        stateid = objdt.Rows[0]["stateid"].ToString();




        SqlDataAdapter objadapt3 = new SqlDataAdapter("select * from city where stateid='" + stateid + "'", objcon);
        DataTable objdt3 = new DataTable();
        objadapt3.Fill(objdt3);

        foreach (DataRow dr in objdt3.Rows)
        {

            ddlcity.Items.Add(dr["name"].ToString());
        }*/
       

    }
    protected void btnstate_Click(object sender, EventArgs e)
    {
        ddlstate.Items.Clear();
        SqlDataAdapter objadapt = new SqlDataAdapter("select * from country where name='" + ddlcountry.Text + "'", objcon);
        DataTable objdt = new DataTable();
        objadapt.Fill(objdt);

        string countryid;
        countryid = objdt.Rows[0]["countryid"].ToString();

        SqlDataAdapter objadapt1 = new SqlDataAdapter("select * from state where countryid='" + countryid + "'", objcon);
        DataTable objdt1 = new DataTable();
        objadapt1.Fill(objdt1);

        foreach (DataRow dr in objdt1.Rows)
        {

            ddlstate.Items.Add(dr["name"].ToString());
        }
    }
    protected void txtusername_TextChanged(object sender, EventArgs e)
    {

    }
}
                        
                    
                
            
        
   
