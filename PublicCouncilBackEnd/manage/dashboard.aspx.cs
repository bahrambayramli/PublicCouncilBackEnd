using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace PublicCouncilBackEnd.manage
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private void GetPostsCount(string POST_AUTHOR)
        {
            SqlDataAdapter pcpostCount = new SqlDataAdapter();

            if (Session["USER_MEMBERSHIP_TYPE"] as string == "admin" && Session["POST_AUTHOR"]as String=="admin")
            {
                pcpostCount = new SqlDataAdapter(new SqlCommand(@"SELECT COUNT(*) AS 'COUNT' FROM PC_POSTS 
                                                                              WHERE ISDELETE = 'FALSE' AND ISACTIVE='TRUE'"));
            }
            else
            {
                pcpostCount = new SqlDataAdapter(new SqlCommand(@"SELECT COUNT(*) AS 'COUNT' FROM PC_POSTS 
                                                                              WHERE ISDELETE    = 'FALSE' AND
                                                                                    ISACTIVE    = 'TRUE'  AND
                                                                                    POST_AUTHOR =  @POST_AUTHOR"));

                pcpostCount.SelectCommand.Parameters.Add("@POST_AUTHOR", SqlDbType.NVarChar).Value = POST_AUTHOR;
            }
            postCount.Text = SQL.SELECT(pcpostCount).Rows[0]["COUNT"].ToString();


        }

        private void GetPostAuthorsCount()
        {
            SqlDataAdapter authorCount = 
                new SqlDataAdapter(
                    new SqlCommand(@"SELECT COUNT(*) AS 'COUNT' 
                                                            FROM PC_USERS 
                                                                 WHERE ISDELETE='FALSE' AND 
                                                                       ISACTIVE='TRUE'  
                                                                      "));

           
            pcCount.Text = SQL.SELECT(authorCount).Rows[0]["COUNT"].ToString();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
             GetPostsCount(Session["POST_AUTHOR"] as string);
            if(Session["USER_MEMBERSHIP_TYPE"] as String == "user")
            {
                PCCOUNT_PANEL.Visible = false;
            }
            else
            {
                GetPostAuthorsCount();

            }
        }
    }
}