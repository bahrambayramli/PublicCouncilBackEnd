using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace PublicCouncilBackEnd.subsite
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        #region(HELPER FUNCTIONS)
        private void ChangeLanguage(string LANG)
        {
            switch (LANG)
            {
                case "az":
                    {
                        pageName.Text = "Üzvlər";
                        pcActivityPeriod.Text = $"Üzvlərin fəaliyyət dövrü {Session["PC_ACTIVITY_PERIOD"] as string}";
                        break;
                    }
                case "en":
                    {
                        pageName.Text = "Members";
                        pcActivityPeriod.Text = $"Period of activity of members { Session["PC_ACTIVITY_PERIOD"] as string}";
                        break;
                    }
                default:
                    {
                        pageName.Text = "Üzvlər";
                        pcActivityPeriod.Text = $"Üzvlərin fəaliyyət dövrü {Session["PC_ACTIVITY_PERIOD"] as string}";
                        break;
                    }

            }
        }
        #endregion

        #region(SQL FUNCTIONS)
        private string GetPcId(string PC_NAME)
        {
            SqlDataAdapter getPcId = new SqlDataAdapter(new SqlCommand(@"SELECT USER_ID FROM PC_USERS WHERE USER_PCDOMAIN = @USER_PCDOMAIN"));

            getPcId.SelectCommand.Parameters.Add("@USER_PCDOMAIN", SqlDbType.NVarChar).Value = PC_NAME;

            return SQL.SELECT(getPcId).Rows[0]["USER_ID"].ToString();

        }

        private void GetMembers(string LANG, string PC_ID, bool ISDELETE, GridView GRID)
        {
          
            SqlDataAdapter getMembers;
            DataTable dt;
            switch (LANG)
            {
                case "az":
                    {
                        getMembers = new SqlDataAdapter(new SqlCommand(@"SELECT ROW_NUMBER() OVER(ORDER BY MEMBER_ORDER_NUMBER ASC) AS '#' ,

                                                                                
                                                                                  MEMBER_NAME_AZ     AS 'Ad',
                                                                                  MEMBER_SURNAME_AZ  AS 'Soyad',
                                                                                  MEMBER_POSITION_AZ AS 'Vəzifə'

                                                                            FROM PC_MEMBERS

																			LEFT JOIN PC_USERS
																			ON PC_MEMBERS.PC_ID = PC_USERS.USER_ID

																			WHERE 
                                                                                  PC_USERS.USER_ID      = @PC_USER_ID AND
                                                                                  PC_MEMBERS.ISDELETE   = 'FALSE'"));

                        getMembers.SelectCommand.Parameters.Add("@PC_USER_ID", SqlDbType.Int).Value    = PC_ID;
                        dt = SQL.SELECT(getMembers);
                        GRID.DataSource = dt;
                        GRID.DataBind();
                        break;
                    }
                case "en":
                    {
                        getMembers = new SqlDataAdapter(new SqlCommand(@"SELECT ROW_NUMBER() OVER(ORDER BY MEMBER_ORDER_NUMBER ASC) AS '#' ,

                                                                                
                                                                                  MEMBER_NAME_EN     AS 'Name',
                                                                                  MEMBER_SURNAME_EN  AS 'Surname',
                                                                                  MEMBER_POSITION_EN AS 'Position'

                                                                            FROM PC_MEMBERS

																			LEFT JOIN PC_USERS
																			ON PC_MEMBERS.PC_ID = PC_USERS.USER_ID

																			WHERE 
                                                                                  PC_USERS.USER_ID      = @PC_USER_ID AND
                                                                                  PC_MEMBERS.ISDELETE   = 'FALSE'"));

                        getMembers.SelectCommand.Parameters.Add("@PC_USER_ID", SqlDbType.Int).Value = PC_ID;
                        dt = SQL.SELECT(getMembers);
                        GRID.DataSource = dt;
                        GRID.DataBind();
                        break;
                    }
                default:
                    {
                        getMembers = new SqlDataAdapter(new SqlCommand(@"SELECT ROW_NUMBER() OVER(ORDER BY MEMBER_ORDER_NUMBER ASC) AS '#' ,

                                                                                
                                                                                  MEMBER_NAME_AZ     AS 'Ad',
                                                                                  MEMBER_SURNAME_AZ  AS 'Soyad',
                                                                                  MEMBER_POSITION_AZ AS 'Vəzifə'

                                                                            FROM PC_MEMBERS

																			LEFT JOIN PC_USERS
																			ON PC_MEMBERS.PC_ID = PC_USERS.USER_ID

																			WHERE 
                                                                                  PC_USERS.USER_ID      = @PC_USER_ID AND
                                                                                  PC_MEMBERS.ISDELETE   = 'FALSE'"));

                        getMembers.SelectCommand.Parameters.Add("@PC_USER_ID", SqlDbType.Int).Value = PC_ID;
                        dt = SQL.SELECT(getMembers);
                        GRID.DataSource = dt;
                        GRID.DataBind();
                        break;
                    }
            }

           
        }

        private void GetMembers(string LANG, string PC_ID, bool ISDELETE, bool ISACTIVE,ListView LSV_AZ, ListView LSV_EN)
        {
            SqlDataAdapter getMembers = new SqlDataAdapter();

            switch (LANG)
            {
                case "az":
                    {
                        LSV_EN.DataSource = null;
                        LSV_EN.DataBind();

                        getMembers = new SqlDataAdapter(new SqlCommand(@"SELECT 
                                                                                    MEMBER_ID,
                                                                                    MEMBER_NAME_AZ,
                                                                                    MEMBER_SURNAME_AZ,
                                                                                    MEMBER_IMAGE,
                                                                                    MEMBER_POSITION_AZ,
																					USER_PCDOMAIN

                                                                            FROM PC_MEMBERS
																			LEFT JOIN PC_USERS
																			ON PC_MEMBERS.PC_ID = PC_USERS.USER_ID
                                                                            WHERE
                                                                            PC_MEMBERS.ISDELETE = @ISDELETE AND
                                                                            PC_MEMBERS.ISACTIVE = @ISACTIVE AND
                                                                            PC_ID=@PC_ID ORDER BY MEMBER_ORDER_NUMBER"));

                        getMembers.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = ISDELETE;
                        getMembers.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = ISACTIVE;
                        getMembers.SelectCommand.Parameters.Add("@PC_ID", SqlDbType.Int).Value = PC_ID;

                        LSV_AZ.DataSource = SQL.SELECT(getMembers);
                        LSV_AZ.DataBind();


                        break;
                    }
                case "en":
                    {
                        LSV_AZ.DataSource = null;
                        LSV_AZ.DataBind();

                        getMembers = new SqlDataAdapter(new SqlCommand(@"SELECT 
                                                                                    MEMBER_ID,
                                                                                    MEMBER_NAME_EN,
                                                                                    MEMBER_SURNAME_EN,
                                                                                    MEMBER_IMAGE,
                                                                                    MEMBER_POSITION_EN,
																					USER_PCDOMAIN

                                                                            FROM PC_MEMBERS
																			LEFT JOIN PC_USERS
																			ON PC_MEMBERS.PC_ID = PC_USERS.USER_ID
                                                                            WHERE
                                                                            ISDELETE = @ISDELETE AND
                                                                            ISACTIVE = @ISACTIVE AND
                                                                            PC_ID=@PC_ID ORDER BY MEMBER_ORDER_NUMBER"));

                        getMembers.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = ISDELETE;
                        getMembers.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = ISACTIVE;
                        getMembers.SelectCommand.Parameters.Add("@PC_ID", SqlDbType.Int).Value = PC_ID;

                        LSV_EN.DataSource = SQL.SELECT(getMembers);
                        LSV_EN.DataBind();
                        break;
                    }
                default:
                    {
                        LSV_EN.DataSource = null;
                        LSV_EN.DataBind();

                        getMembers = new SqlDataAdapter(new SqlCommand(@"SELECT 
                                                                                    MEMBER_ID,
                                                                                    MEMBER_NAME_AZ,
                                                                                    MEMBER_SURNAME_AZ,
                                                                                    MEMBER_IMAGE,
                                                                                    MEMBER_POSITION_AZ,
																					USER_PCDOMAIN

                                                                            FROM PC_MEMBERS
																			LEFT JOIN PC_USERS
																			ON PC_MEMBERS.PC_ID = PC_USERS.USER_ID
                                                                            WHERE
                                                                            ISDELETE = @ISDELETE AND
                                                                            ISACTIVE = @ISACTIVE AND
                                                                            PC_ID=@PC_ID ORDER BY MEMBER_ORDER_NUMBER"));

                        getMembers.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = ISDELETE;
                        getMembers.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = ISACTIVE;
                        getMembers.SelectCommand.Parameters.Add("@PC_ID", SqlDbType.Int).Value = PC_ID;

                        LSV_AZ.DataSource = SQL.SELECT(getMembers);
                        LSV_AZ.DataBind();


                        break;
                    }

            }

            getMembers = null;

        }
        #endregion

        #region(MEMBERS LIST GRIDVIEW EVENTS)
        protected void MEMBERS_AZ_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager_AZ.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);


            GetMembers(Convert.ToString(Page.RouteData.Values["language"]).ToLower(), Session["PC_USER_ID"] as string, false, true, MEMBERS_AZ, MEMBERS_EN);

        }

        protected void MEMBERS_EN_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager_EN.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            GetMembers(Convert.ToString(Page.RouteData.Values["language"]).ToLower(), Session["PC_USER_ID"] as string, false, true, MEMBERS_AZ, MEMBERS_EN);

        }

        protected void MemberList_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Width = new Unit("20px");
            e.Row.Cells[1].Width = new Unit("200px");
            e.Row.Cells[2].Width = new Unit("200px");
        }
        #endregion

        protected private void RunMembers(string LANG,string PC_NAME)
        {
            try
            {
                ChangeLanguage(LANG);
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "log.txt")), $"Log created:{DateTime.Now}, Log page is: subsite >> members.aspx page >> ChangeLanguage, Log:{ex.Message}");
            }

            try
            {
                GetMembers(Convert.ToString(Page.RouteData.Values["language"]).ToLower(), GetPcId(PC_NAME), false, MemberList);
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "log.txt")), $"Log created:{DateTime.Now}, Log page is: subsite >> members.aspx page >> GetMembers, Log:{ex.Message}");
            }

            try
            {
                GetMembers(Convert.ToString(Page.RouteData.Values["language"]).ToLower(), GetPcId(PC_NAME), false, true, MEMBERS_AZ, MEMBERS_EN);
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "log.txt")), $"Log created:{DateTime.Now}, Log page is: subsite >> members.aspx page >> GetMembers, Log:{ex.Message}");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                RunMembers(Convert.ToString(Page.RouteData.Values["language"]).ToLower(),Convert.ToString(Page.RouteData.Values["publiccouncil"]).ToLower());
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "log.txt")), $"Log created:{DateTime.Now}, Log page is: subsite >> members.aspx page >> RunMembers, Log:{ex.Message}");
            }
        }

    }
}