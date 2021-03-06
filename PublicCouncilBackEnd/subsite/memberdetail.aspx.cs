﻿using System;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace PublicCouncilBackEnd.subsite
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        #region(SQL FUNCTIONS)
        private string GetPcId(string PC_NAME)
        {
            SqlDataAdapter getPcId = new SqlDataAdapter(new SqlCommand(@"SELECT USER_ID FROM PC_USERS WHERE USER_PCDOMAIN = @USER_PCDOMAIN"));

            getPcId.SelectCommand.Parameters.Add("@USER_PCDOMAIN", SqlDbType.NVarChar).Value = PC_NAME;

            return SQL.SELECT(getPcId).Rows[0]["USER_ID"].ToString();

        }

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

                                                      MEMBER_NAME_AZ       , 
                                                      MEMBER_SURNAME_AZ    , 
                                                      MEMBER_IMAGE         ,
                                                      MEMBER_POSITION_AZ   ,
                                                      MEMBER_DETAIL_AZ

                                                      FROM PC_MEMBERS 

                                                      WHERE PC_ID = @PC_ID AND 
                                                      MEMBER_ID   = @MEMBER_ID"));

                        getMember.SelectCommand.Parameters.Add("@PC_ID", SqlDbType.Int).Value = PC_ID;
                        getMember.SelectCommand.Parameters.Add("@MEMBER_ID", SqlDbType.Int).Value = MEMBER_ID;
                        dt = SQL.SELECT(getMember);

                        memberImage.ImageUrl = $"~/images/members/{dt.Rows[0]["MEMBER_IMAGE"].ToString()}";
                        memberPosition.Text = $"{dt.Rows[0]["MEMBER_POSITION_AZ"].ToString()}";
                        memberNameSurname.Text = $"{dt.Rows[0]["MEMBER_NAME_AZ"].ToString()} {dt.Rows[0]["MEMBER_SURNAME_AZ"].ToString()}";
                        memberDetail.Text = $"{dt.Rows[0]["MEMBER_DETAIL_AZ"].ToString()}";
                        break;
                    }
                case "en":
                    {
                        getMember = new SqlDataAdapter(
                                    new SqlCommand(@"SELECT 

                                                      MEMBER_NAME_EN       , 
                                                      MEMBER_SURNAME_EN    , 
                                                      MEMBER_IMAGE         ,
                                                      MEMBER_POSITION_EN   ,
                                                      MEMBER_DETAIL_EN

                                                      FROM PC_MEMBERS 

                                                      WHERE PC_ID = @PC_ID AND 
                                                      MEMBER_ID   = @MEMBER_ID"));

                        getMember.SelectCommand.Parameters.Add("@PC_ID", SqlDbType.Int).Value = PC_ID;
                        getMember.SelectCommand.Parameters.Add("@MEMBER_ID", SqlDbType.Int).Value = MEMBER_ID;
                        dt = SQL.SELECT(getMember);

                        memberImage.ImageUrl = $"~/images/members/{dt.Rows[0]["MEMBER_IMAGE"].ToString()}";
                        memberPosition.Text = $"{dt.Rows[0]["MEMBER_POSITION_EN"].ToString()}";
                        memberNameSurname.Text = $"{dt.Rows[0]["MEMBER_NAME_EN"].ToString()} {dt.Rows[0]["MEMBER_SURNAME_EN"].ToString()}";
                        memberDetail.Text = $"{dt.Rows[0]["MEMBER_DETAIL_EN"].ToString()}";
                        break;
                    }
                default:
                    {
                        getMember = new SqlDataAdapter(
                                    new SqlCommand(@"SELECT 

                                                      MEMBER_NAME_AZ       , 
                                                      MEMBER_SURNAME_AZ    , 
                                                      MEMBER_IMAGE         ,
                                                      MEMBER_POSITION_AZ   ,
                                                      MEMBER_DETAIL_AZ

                                                      FROM PC_MEMBERS 

                                                      WHERE PC_ID = @PC_ID AND 
                                                      MEMBER_ID   = @MEMBER_ID"));

                        getMember.SelectCommand.Parameters.Add("@PC_ID", SqlDbType.Int).Value = PC_ID;
                        getMember.SelectCommand.Parameters.Add("@MEMBER_ID", SqlDbType.Int).Value = MEMBER_ID;
                        dt = SQL.SELECT(getMember);

                        memberImage.ImageUrl = $"~/images/members/{dt.Rows[0]["MEMBER_IMAGE"].ToString()}";
                        memberPosition.Text = $"{dt.Rows[0]["MEMBER_POSITION_AZ"].ToString()}";
                        memberNameSurname.Text = $"{dt.Rows[0]["MEMBER_NAME_AZ"].ToString()} {dt.Rows[0]["MEMBER_SURNAME_AZ"].ToString()}";
                        memberDetail.Text = $"{dt.Rows[0]["MEMBER_DETAIL_AZ"].ToString()}";
                        break;
                    }
            }

            getMember = null;
            dt = null;
        }
        #endregion

        protected private void RunMemberDetail(string LANG, string PC_NAME, string MEMBER_ID)
        {
            //GetMemberInfo
            try
            {
                GetMemberInfo(LANG, MEMBER_ID, GetPcId(PC_NAME));
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: subsute >> memberdetail.aspx page >> GetMemberInfo method, Log:{ex.Message}");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //RunMemberDetail
            try
            {
                RunMemberDetail(Convert.ToString(Page.RouteData.Values["language"]).ToLower(), Convert.ToString(Page.RouteData.Values["publiccouncil"]).ToLower(), Page.RouteData.Values["memberid"] as string);
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: subsute memberdetail.aspx page >> RunMemberDetail method, Log:{ex.Message}");
            }

        }
    }
}