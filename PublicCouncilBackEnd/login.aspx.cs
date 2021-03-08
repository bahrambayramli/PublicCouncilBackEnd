using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace PublicCouncilBackEnd
{
    public partial class WebForm10 : System.Web.UI.Page
    {


        public void AccountLogin(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password)) 
            {
                _errorMessage.Text = "<p class='text-warning text-center'>Xanalar boş ola bilməz</p>";
                return;
            } 

            SqlDataAdapter checkAccount = new SqlDataAdapter(new SqlCommand(@"
                                                                                SELECT	USER_ID,
                                                                                        USER_MEMBERSHIP,
                                                                                        USER_MEMBERSHIP_TYPE,
                                                                                        USER_SERIAL,
                                                                                        USER_NAME,
                                                                                        USER_SURNAME,
                                                                                        USER_PCDOMAIN

                                                                                 FROM   PC_USERS

                                                                                 WHERE	
                                                                                        USER_LOGIN     = @USER_LOGIN      AND
                                                                                        USER_PASSWORD  = @USER_PASSWORD   AND
                                                                                        ISDELETE      = @ISDELETE         AND
                                                                                        ISACTIVE      = @ISACTIVE
                                                                                		 "));

            checkAccount.SelectCommand.Parameters.Add("@USER_LOGIN", SqlDbType.NVarChar).Value = login;
            checkAccount.SelectCommand.Parameters.Add("@USER_PASSWORD", SqlDbType.NVarChar).Value = Crypto.MD5crypt(password);
            checkAccount.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
            checkAccount.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;


            DataTable dt = SQL.SELECT(checkAccount);

            if (dt.Rows.Count > 0)
            {
                Session["ISLOGIN"]                      = "USERISEXIST";
                Session["USER_ID"]                      = dt.Rows[0]["USER_ID"].ToString();

                Session["USER_PCDOMAIN"]                = dt.Rows[0]["USER_PCDOMAIN"].ToString();

                Session["USER_SERIAL"]                  = dt.Rows[0]["USER_SERIAL"].ToString();

                Session["USER_NAME"]                    = dt.Rows[0]["USER_NAME"].ToString();
                Session["USER_SURNAME"]                 = dt.Rows[0]["USER_SURNAME"].ToString();
               
                Session["USER_MEMBERSHIP"]              = dt.Rows[0]["USER_MEMBERSHIP"].ToString();
                Session["USER_MEMBERSHIP_TYPE"]         = dt.Rows[0]["USER_MEMBERSHIP_TYPE"].ToString();
                Session["POST_AUTHOR"]                  = dt.Rows[0]["USER_PCDOMAIN"].ToString();

                Response.Redirect("/manage/dashboard");
            }
            else
            {
                _errorMessage.Text = "<p class='text-warning text-center'>İstifadəçi adı və yaxud şifrə yalnışdır</p>";
                return;
            }


        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            AccountLogin(inputLogin.Text,inputPassword.Text);
        }
    }
}