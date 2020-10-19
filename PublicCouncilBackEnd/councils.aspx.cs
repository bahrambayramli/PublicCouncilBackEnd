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
    public partial class WebForm12 : System.Web.UI.Page
    {

        private void GetPCList(string LANGUAGE,string PC_DIRECTORY,bool ISDELETE,bool ISACTIVE , ListView LSV_AZ,ListView LSV_EN)
        {
            SqlDataAdapter getpcList = new SqlDataAdapter();

            switch (LANGUAGE)
            {
                case "az":
                    {
                        LSV_EN.DataSource = null;
                        LSV_EN.DataBind();
                        getpcList = new SqlDataAdapter(new SqlCommand(@"SELECT USER_PCDOMAIN ,PC_NAME,PC_CATEGORY FROM PC_USERS 
                                                                                        WHERE
                                                                                                    ISDELETE     = @ISDELETE       AND
                                                                                                    ISACTIVE     = @ISACTIVE       AND
                                                                                                    PC_CATEGORY  = @PC_CATEGORY    AND
                                                                                                    USER_LOGIN   !='admin'  
                                                                                                    ORDER BY CREATED_DATE DESC"));

                        getpcList.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = ISDELETE;
                        getpcList.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = ISACTIVE;
                        getpcList.SelectCommand.Parameters.Add("@PC_CATEGORY", SqlDbType.NVarChar).Value = PC_DIRECTORY;

                        LSV_AZ.DataSource = SQL.SELECT(getpcList);
                        LSV_AZ.DataBind();


                        break;
                    }

                #region(en)
                //case "en":
                //    {
                //        LSV_EN.DataSource = null;
                //        LSV_EN.DataBind();
                //        getpcList = new SqlDataAdapter(new SqlCommand(@"SELECT USER_PCDOMAIN ,PC_NAME,PC_CATEGORY FROM PC_USERS 
                //                                                                        WHERE
                //                                                                                    ISDELETE     = @ISDELETE       AND
                //                                                                                    ISACTIVE     = @ISACTIVE       AND
                //                                                                                    PC_CATEGORY  = @PC_CATEGORY    
                //                                                                                    ORDER BY CREATED_DATE DESC"));

                //        getpcList.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = true;
                //        getpcList.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = false;
                //        getpcList.SelectCommand.Parameters.Add("@PC_CATEGORY", SqlDbType.NVarChar).Value = PC_DIRECTORY;

                //        LSV_AZ.DataSource = SQL.SELECT(getpcList);
                //        LSV_AZ.DataBind();
                //        break;
                //    }
                #endregion

                default:
                    {
                        LSV_EN.DataSource = null;
                        LSV_EN.DataBind();
                        getpcList = new SqlDataAdapter(new SqlCommand(@"SELECT USER_PCDOMAIN ,PC_NAME,PC_CATEGORY FROM PC_USERS 
                                                                                        WHERE
                                                                                                    ISDELETE     = @ISDELETE       AND
                                                                                                    ISACTIVE     = @ISACTIVE       AND
                                                                                                    PC_CATEGORY  = @PC_CATEGORY    AND
                                                                                                    USER_LOGIN   !='admin'  
                                                                                                    ORDER BY CREATED_DATE DESC"));

                        getpcList.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = ISDELETE;
                        getpcList.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = ISACTIVE;
                        getpcList.SelectCommand.Parameters.Add("@PC_CATEGORY", SqlDbType.NVarChar).Value = PC_DIRECTORY;

                        LSV_AZ.DataSource = SQL.SELECT(getpcList);
                        LSV_AZ.DataBind();
                        break;
                    }
            }
        }

        private void GetPCList(string LANGUAGE, bool ISDELETE, bool ISACTIVE, ListView LSV_AZ, ListView LSV_EN)
        {
            SqlDataAdapter getpcList = new SqlDataAdapter();

            switch (LANGUAGE)
            {
                case "az":
                    {
                        LSV_EN.DataSource = null;
                        LSV_EN.DataBind();
                        getpcList = new SqlDataAdapter(new SqlCommand(@"SELECT USER_PCDOMAIN ,PC_NAME,PC_CATEGORY FROM PC_USERS 
                                                                                        WHERE
                                                                                                    ISDELETE     = @ISDELETE       AND
                                                                                                    ISACTIVE     = @ISACTIVE      AND
                                                                                                    USER_LOGIN   !='admin'   
                                                                                                       
                                                                                                    ORDER BY CREATED_DATE DESC"));

                        getpcList.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = ISDELETE;
                        getpcList.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = ISACTIVE;

                        LSV_AZ.DataSource = SQL.SELECT(getpcList);
                        LSV_AZ.DataBind();


                        break;
                    }

                #region(en)
                //case "en":
                //    {
                //        LSV_EN.DataSource = null;
                //        LSV_EN.DataBind();
                //        getpcList = new SqlDataAdapter(new SqlCommand(@"SELECT USER_PCDOMAIN ,PC_NAME,PC_CATEGORY FROM PC_USERS 
                //                                                                        WHERE
                //                                                                                    ISDELETE     = @ISDELETE       AND
                //                                                                                    ISACTIVE     = @ISACTIVE       AND
                //                                                                                    PC_CATEGORY  = @PC_CATEGORY    
                //                                                                                    ORDER BY CREATED_DATE DESC"));

                //        getpcList.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = true;
                //        getpcList.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = false;
                //        getpcList.SelectCommand.Parameters.Add("@PC_CATEGORY", SqlDbType.NVarChar).Value = PC_DIRECTORY;

                //        LSV_AZ.DataSource = SQL.SELECT(getpcList);
                //        LSV_AZ.DataBind();
                //        break;
                //    }
                #endregion

                default:
                    {
                        LSV_EN.DataSource = null;
                        LSV_EN.DataBind();
                        getpcList = new SqlDataAdapter(new SqlCommand(@"SELECT USER_PCDOMAIN ,PC_NAME,PC_CATEGORY FROM PC_USERS 
                                                                                        WHERE
                                                                                                    ISDELETE     = @ISDELETE       AND
                                                                                                    ISACTIVE     = @ISACTIVE       AND
                                                                                                    USER_LOGIN   !='admin'  
                                                                                                    ORDER BY CREATED_DATE DESC"));

                        getpcList.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = ISDELETE;
                        getpcList.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = ISACTIVE;

                        LSV_AZ.DataSource = SQL.SELECT(getpcList);
                        LSV_AZ.DataBind();


                        break;
                    }
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Convert.ToString(Page.RouteData.Values["language"]).ToLower())
            {
                case "az":
                    {
                        pcTitle.Text = "İctimai şuralar";
                        pcucep.Text = "Mərkəzi icra hakimiyyət yanında ictimai şuralar";
                        pcucep.NavigateUrl = "/councils/pcucep/az";
                        pculealsgb.Text = "Yerli icra hakimiyyəti və yerli özünü idarəetmə orqanları yanında ictimai şuralar";
                        pculealsgb.NavigateUrl = "/councils/pculealsgb/az";
                        other.Text = "Digər";
                        other.NavigateUrl = "/councils/other/az";
                        break;
                    }
                case "en":
                    {
                        pcTitle.Text = "Public councils";
                        pcucep.Text = "Public councils under the central executive power";
                        pcucep.NavigateUrl = "/councils/pcucep/en";
                        pculealsgb.Text = "Public councils under local executive authorities and local self-government bodies";
                        pculealsgb.NavigateUrl = "/councils/pculealsgb/en";
                        other.Text = "Other";
                        other.NavigateUrl = "/councils/other/en";
                        break;
                    }
                default:
                    {
                        pcTitle.Text = "İctimai şuralar";
                        pcucep.Text = "Mərkəzi icra hakimiyyət yanında ictimai şuralar";
                        pcucep.NavigateUrl = "/councils/pcucep/az";
                        pculealsgb.Text = "Yerli icra hakimiyyəti və yerli özünüidarəetmə orqanları yanında ictimai şuralar";
                        pculealsgb.NavigateUrl = "/councils/pculealsgb/az";
                        other.Text = "Digər";
                        other.NavigateUrl = "/councils/other/az";
                        break;
                    }
            }

            if (string.IsNullOrEmpty(Page.RouteData.Values["directory"] as string))
            {
                GetPCList(Convert.ToString(Page.RouteData.Values["language"]).ToLower(),false,true,PCLIST_AZ,PCLIST_EN);

            }
            else
            {
                GetPCList(Convert.ToString(Page.RouteData.Values["language"]).ToLower(),Page.RouteData.Values["directory"] as string, false, true, PCLIST_AZ, PCLIST_EN);

            }
        }


        protected void POSTLIST_AZ_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            if (Convert.ToString(Page.RouteData.Values["language"]).ToLower() == "az")
            {
                PCLIST_AZ.Visible = true;
                PCLIST_EN.Visible = false;
                DataPager_AZ.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            }
            else if (Convert.ToString(Page.RouteData.Values["language"]).ToLower() == "en")
            {
                PCLIST_EN.Visible = true;
                PCLIST_AZ.Visible = false;
                DataPager_EN.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            }
            if (string.IsNullOrEmpty(Page.RouteData.Values["directory"] as string))
            {
                GetPCList(Convert.ToString(Page.RouteData.Values["language"]).ToLower(), false, true, PCLIST_AZ, PCLIST_EN);

            }
            else
            {
                GetPCList(Convert.ToString(Page.RouteData.Values["language"]).ToLower(), Page.RouteData.Values["directory"] as string, false, true, PCLIST_AZ, PCLIST_EN);

            }
        }

        protected void POSTLIST_EN_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            if (Convert.ToString(Page.RouteData.Values["language"]).ToLower() == "az")
            {
                PCLIST_AZ.Visible = true;
                PCLIST_EN.Visible = false;
                DataPager_AZ.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            }
            else if (Convert.ToString(Page.RouteData.Values["language"]).ToLower() == "en")
            {
                PCLIST_AZ.Visible = false;
                PCLIST_EN.Visible = true;
                DataPager_EN.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            }

            if (string.IsNullOrEmpty(Page.RouteData.Values["directory"] as string))
            {
                GetPCList(Convert.ToString(Page.RouteData.Values["language"]).ToLower(), false, true, PCLIST_AZ, PCLIST_EN);

            }
            else
            {
                GetPCList(Convert.ToString(Page.RouteData.Values["language"]).ToLower(), Page.RouteData.Values["directory"] as string, false, true, PCLIST_AZ, PCLIST_EN);

            }


        }
    }
}