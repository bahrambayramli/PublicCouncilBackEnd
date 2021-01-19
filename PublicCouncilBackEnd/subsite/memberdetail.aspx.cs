using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace PublicCouncilBackEnd.subsite
{
    public partial class WebForm11 : System.Web.UI.Page
    {

        private void GetMemberInfo(string LANG, string MEMBER_ID, string PC_ID)
        {
            SqlDataAdapter getMember;
            DataTable dt;
            switch (LANG)
            {
                case "az":
                    {
                        getMember = new SqlDataAdapter(
                                    new SqlCommand(@"SELECT 

                                                      MEMBER_NAME       , 
                                                      MEMBER_SURNAME    , 
                                                      MEMBER_IMAGE      ,
                                                      MEMBER_POSITION   ,
                                                      MEMBER_DETAIL

                                                      FROM PC_MEMBERS 

                                                      WHERE PC_ID = @PC_ID AND 
                                                      MEMBER_ID   = @MEMBER_ID"));

                        getMember.SelectCommand.Parameters.Add("@PC_ID", SqlDbType.Int).Value = PC_ID;
                        getMember.SelectCommand.Parameters.Add("@MEMBER_ID", SqlDbType.Int).Value = MEMBER_ID;
                        dt = SQL.SELECT(getMember);

                        memberImage.ImageUrl   = $"~/images/members/{dt.Rows[0]["MEMBER_IMAGE"].ToString()}";
                        memberNameSurname.Text = $"<p class'h2 m-0'>{dt.Rows[0]["MEMBER_NAME"].ToString()} {dt.Rows[0]["MEMBER_SURNAME"].ToString()}</p>";
                        memberDetail.Text      = $"{dt.Rows[0]["MEMBER_DETAIL"].ToString()}";
                        break;
                    }
                case "en":
                    {
                        break;
                    }
                default:
                    {
                        getMember = new SqlDataAdapter(
                                    new SqlCommand(@"SELECT 

                                                      MEMBER_NAME       , 
                                                      MEMBER_SURNAME    , 
                                                      MEMBER_IMAGE      ,
                                                      MEMBER_POSITION   ,
                                                      MEMBER_DETAIL

                                                      FROM PC_MEMBERS 

                                                      WHERE
                                                      PC_ID       = @PC_ID AND 
                                                      MEMBER_ID   = @MEMBER_ID"));

                        getMember.SelectCommand.Parameters.Add("@PC_ID", SqlDbType.Int).Value = PC_ID;
                        getMember.SelectCommand.Parameters.Add("@MEMBER_ID", SqlDbType.Int).Value = MEMBER_ID;
                        dt = SQL.SELECT(getMember);

                        memberImage.ImageUrl = $"~/images/members/{dt.Rows[0]["MEMBER_IMAGE"].ToString()}";
                        memberNameSurname.Text = $"<p class'h2 m-0'>{dt.Rows[0]["MEMBER_NAME"].ToString()} {dt.Rows[0]["MEMBER_SURNAME"].ToString()}</p>";
                        memberDetail.Text = $"{dt.Rows[0]["MEMBER_DETAIL"].ToString()}";
                        break;
                    }
            }

            getMember = null;
            dt = null;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            GetMemberInfo(Convert.ToString(Page.RouteData.Values["language"]).ToLower(), Page.RouteData.Values["memberid"] as string, Session["PC_USER_ID"] as string);
        }
    }
}