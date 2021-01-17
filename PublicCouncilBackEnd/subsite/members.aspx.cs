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
    public partial class WebForm10 : System.Web.UI.Page
    {
        private void GetMembers(string LANG, string PC_ID, bool ISDELETE, bool ISACTIVE)
        {
            SqlDataAdapter getMembers = new SqlDataAdapter();

            switch (LANG)
            {
                case "az":
                    {
                        MEMBERS_EN.DataSource = SQL.SELECT(getMembers);
                        MEMBERS_EN.DataBind();

                        getMembers = new SqlDataAdapter(new SqlCommand(@"SELECT  ROW_NUMBER() OVER(ORDER BY MEMBER_ID DESC) AS '#' ,
                                                                                    MEMBER_ID,
                                                                                    MEMBER_NAME,
                                                                                    MEMBER_SURNAME,
                                                                                    MEMBER_IMAGE

                                                                            FROM PC_MEMBERS
                                                                            WHERE
                                                                            ISDELETE = @ISDELETE AND
                                                                            ISACTIVE = @ISACTIVE AND
                                                                            PC_ID=@PC_ID"));

                        getMembers.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = ISDELETE;
                        getMembers.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = ISDELETE;
                        getMembers.SelectCommand.Parameters.Add("@PC_ID", SqlDbType.Int).Value = PC_ID;

                        MEMBERS_AZ.DataSource = SQL.SELECT(getMembers);
                        MEMBERS_AZ.DataBind();
                       

                        break;
                    }
                case "en":
                    {
                        MEMBERS_AZ.DataSource = SQL.SELECT(getMembers);
                        MEMBERS_AZ.DataBind();

                        getMembers = new SqlDataAdapter(new SqlCommand(@"SELECT  ROW_NUMBER() OVER(ORDER BY MEMBER_ID DESC) AS '#' ,
                                                                                    MEMBER_ID,
                                                                                    MEMBER_NAME_EN,
                                                                                    MEMBER_SURNAME_EN,
                                                                                    MEMBER_IMAGE


                                                                            FROM PC_MEMBERS
                                                                            WHERE
                                                                            ISDELETE = @ISDELETE AND
                                                                            ISACTIVE = @ISACTIVE AND
                                                                            PC_ID=@PC_ID"));

                        getMembers.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = ISDELETE;
                        getMembers.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = ISDELETE;
                        getMembers.SelectCommand.Parameters.Add("@PC_ID", SqlDbType.Int).Value = PC_ID;

                        MEMBERS_EN.DataSource = SQL.SELECT(getMembers);
                        MEMBERS_EN.DataBind();
                        break;
                    }
                default:
                    {
                        MEMBERS_EN.DataSource = SQL.SELECT(getMembers);
                        MEMBERS_EN.DataBind();

                        getMembers = new SqlDataAdapter(new SqlCommand(@"SELECT  ROW_NUMBER() OVER(ORDER BY MEMBER_ID DESC) AS '#' ,
                                                                                    MEMBER_ID,
                                                                                    MEMBER_NAME,
                                                                                    MEMBER_SURNAME,
                                                                                    MEMBER_IMAGE

                                                                            FROM PC_MEMBERS
                                                                            WHERE
                                                                            ISDELETE = @ISDELETE AND
                                                                            ISACTIVE = @ISACTIVE AND
                                                                            PC_ID=@PC_ID"));

                        getMembers.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = ISDELETE;
                        getMembers.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = ISDELETE;
                        getMembers.SelectCommand.Parameters.Add("@PC_ID", SqlDbType.Int).Value = PC_ID;

                        MEMBERS_AZ.DataSource = SQL.SELECT(getMembers);
                        MEMBERS_AZ.DataBind();
                        break;
                    }

            }

            getMembers = null;

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Convert.ToString(Page.RouteData.Values["language"]).ToLower())
            {
                case "az":
                    {
                        pageName.Text = "Üzvlər";

                        break;
                    }
                case "en":
                    {
                        pageName.Text = "Members";
                        break;
                    }
                default:
                    {
                        pageName.Text = "Üzvlər";
                        break;
                    }

            }
          //  GetMembers(Convert.ToString(Page.RouteData.Values["language"]).ToLower(), Session["PC_USER_ID"] as string, false, true);
        }

        protected void MEMBERS_EN_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            if (Convert.ToString(Page.RouteData.Values["language"]).ToLower() == "az")
            {
                MEMBERS_AZ.Visible = true;
                MEMBERS_EN.Visible = false;
                DataPager_AZ.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            }
            else if (Convert.ToString(Page.RouteData.Values["language"]).ToLower() == "en")
            {
                MEMBERS_EN.Visible = true;
                MEMBERS_AZ.Visible = false;
                DataPager_EN.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            }
            GetMembers(Convert.ToString(Page.RouteData.Values["language"]).ToLower(), Session["PC_USER_ID"] as string, false, true);
        }

        protected void MEMBERS_AZ_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            if (Convert.ToString(Page.RouteData.Values["language"]).ToLower() == "az")
            {
                MEMBERS_AZ.Visible = true;
                MEMBERS_EN.Visible = false;
                DataPager_AZ.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            }
            else if (Convert.ToString(Page.RouteData.Values["language"]).ToLower() == "en")
            {
                MEMBERS_AZ.Visible = false;
                MEMBERS_EN.Visible = true;
                DataPager_EN.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            }

            GetMembers(Convert.ToString(Page.RouteData.Values["language"]).ToLower(), Session["PC_USER_ID"] as string, false, true);
        }
    }
}