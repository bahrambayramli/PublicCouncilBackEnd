using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace PublicCouncilBackEnd.manage
{
    public partial class WebForm14 : System.Web.UI.Page
    {


        #region(SQL FUNCTIONS)
        private void GetMember(string MEMBER_ID, bool ISDELETE, string PC_ID)
        {
            SqlDataAdapter getMember = new SqlDataAdapter(new SqlCommand(@"SELECT 
                                                                                 MEMBER_ID       ,
                                                                                 MEMBER_NAME     ,
                                                                                 MEMBER_SURNAME  ,
                                                                                 MEMBER_FNAME    ,
                                                                                 MEMBER_POSITION ,
                                                                                 MEMBER_DETAIL   ,
                                                                                 MEMBER_IMAGE    ,
                                                                                 PC_ID
                                                                            FROM PC_MEMBERS

                                                                            WHERE 
                                                                                  ISDELETE       = @ISDELETE      AND
                                                                                  MEMBER_ID      = @MEMBER_ID     AND
                                                                                  PC_ID          = @PC_ID"));


            getMember.SelectCommand.Parameters.Add("@MEMBER_ID", SqlDbType.Int).Value = MEMBER_ID;
            getMember.SelectCommand.Parameters.Add("@PC_ID", SqlDbType.NVarChar).Value = PC_ID;
            getMember.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = ISDELETE;

            DataTable DT = SQL.SELECT(getMember);

            memberName.Text          = DT.Rows[0]["MEMBER_NAME"].ToString();
            memberSurname.Text       = DT.Rows[0]["MEMBER_SURNAME"].ToString();
            memberFname.Text          = DT.Rows[0]["MEMBER_FNAME"].ToString();
            memberPosition.Text      = DT.Rows[0]["MEMBER_POSITION"].ToString();
            memberDetail.Text        = DT.Rows[0]["MEMBER_DETAIL"].ToString();
            memberImage.ImageUrl     = $"/Images/members/{DT.Rows[0]["MEMBER_IMAGE"].ToString()}";

            
        }

        private void UpdateMember(string MEMBER_ID, string PC_ID)
        {
           
            SqlCommand updateMember = new SqlCommand();

            if (fileMember.HasFile)
            {
                string extension = Path.GetExtension(fileMember.FileName).ToLower();
                if ((extension != ".jpg") &&
                    (extension != ".jpeg") &&
                    (extension != ".bmp") &&
                    (extension != ".png") &&
                    (extension != ".gif") &&
                    (extension != ".tif") &&
                    (extension != ".tiff")) return;

                string memberImageName = Helper.SetName(extension);

                updateMember = new SqlCommand(@"UPDATE PC_MEMBERS  SET  
						                                                 MEMBER_NAME        = @MEMBER_NAME         ,
                                                                         MEMBER_SURNAME     = @MEMBER_SURNAME      ,
                                                                         MEMBER_FNAME       = @MEMBER_FNAME        ,
                                                                         MEMBER_POSITION    = @MEMBER_POSITION     ,
                                                                         MEMBER_DETAIL      = @MEMBER_DETAIL       ,
                                                                         MEMBER_IMAGE       = @MEMBER_IMAGE        
					                                                WHERE 
                                                                 
                                                                    MEMBER_ID      = @MEMBER_ID     AND
                                                                    PC_ID          = @PC_ID
                                                                  ");
                updateMember.Parameters.Add("@MEMBER_ID", SqlDbType.Int).Value               = MEMBER_ID;
                updateMember.Parameters.Add("@PC_ID", SqlDbType.NVarChar).Value              = PC_ID;
                updateMember.Parameters.Add("@MEMBER_NAME", SqlDbType.NVarChar).Value        = memberName.Text;
                updateMember.Parameters.Add("@MEMBER_SURNAME", SqlDbType.NVarChar).Value     = memberSurname.Text;
                updateMember.Parameters.Add("@MEMBER_FNAME", SqlDbType.NVarChar).Value       = memberFname.Text;
                updateMember.Parameters.Add("@MEMBER_POSITION", SqlDbType.NVarChar).Value    = memberPosition.Text;
                updateMember.Parameters.Add("@MEMBER_DETAIL", SqlDbType.NVarChar).Value      = memberDetail.Text;
                updateMember.Parameters.Add("@MEMBER_IMAGE", SqlDbType.NVarChar).Value       = memberImageName;



                fileMember.SaveAs(Server.MapPath("/Images/members/" + memberImageName));

            }
            else
            {
                updateMember = new SqlCommand(@"UPDATE PC_MEMBERS  SET     
                                                                         MEMBER_NAME        = @MEMBER_NAME       ,
                                                                         MEMBER_SURNAME     = @MEMBER_SURNAME    ,
                                                                         MEMBER_FNAME       = @MEMBER_FNAME      ,
                                                                         MEMBER_POSITION    = @MEMBER_POSITION   ,
                                                                         MEMBER_DETAIL      = @MEMBER_DETAIL     
					                                                     WHERE 
                                                                 
                                                                         MEMBER_ID          = @MEMBER_ID     AND
                                                                         PC_ID              = @PC_ID
                                                                             ");

                updateMember.Parameters.Add("@MEMBER_ID", SqlDbType.Int).Value              = MEMBER_ID;
                updateMember.Parameters.Add("@PC_ID", SqlDbType.NVarChar).Value             = PC_ID;
                updateMember.Parameters.Add("@MEMBER_NAME", SqlDbType.NVarChar).Value       = memberName.Text;
                updateMember.Parameters.Add("@MEMBER_SURNAME", SqlDbType.NVarChar).Value    = memberSurname.Text;
                updateMember.Parameters.Add("@MEMBER_FNAME", SqlDbType.NVarChar).Value      = memberFname.Text;
                updateMember.Parameters.Add("@MEMBER_POSITION", SqlDbType.NVarChar).Value   = memberPosition.Text;
                updateMember.Parameters.Add("@MEMBER_DETAIL", SqlDbType.NVarChar).Value     = memberDetail.Text;
               
            }

            SQL.COMMAND(updateMember);

            updateMember = null;
        }

        private void InsertMember(string PC_ID)
        {
            //string logoSerial = Helper.MakeSerial();



            if (fileMember.HasFile)
            {

                string extension = Path.GetExtension(fileMember.FileName).ToLower();
                if ((extension != ".jpg") &&
                    (extension != ".jpeg") &&
                    (extension != ".bmp") &&
                    (extension != ".png") &&
                    (extension != ".gif") &&
                    (extension != ".tif") &&
                    (extension != ".tiff")) return;

            
                    string memberImageName = Helper.SetName(extension);

                    SqlCommand insertMember = new SqlCommand(@"INSERT INTO PC_MEMBERS
                                                                                    (
						                                                            MEMBER_NAME       ,
                                                                                    MEMBER_SURNAME    ,
                                                                                    MEMBER_FNAME      ,
                                                                                    MEMBER_POSITION   ,
                                                                                    MEMBER_DETAIL     ,
                                                                                    MEMBER_IMAGE      ,
                                                                                    PC_ID             ,
                                                                                    ISDELETE          ,
                                                                                    ISACTIVE
	                                                                                )
                                                                              VALUES
                                                                                    (
	                                                                            	 @MEMBER_NAME       ,
                                                                                     @MEMBER_SURNAME    ,
                                                                                     @MEMBER_FNAME      ,
                                                                                     @MEMBER_POSITION   ,
                                                                                     @MEMBER_DETAIL     ,
                                                                                     @MEMBER_IMAGE      ,
                                                                                     @PC_ID             ,
                                                                                     @ISDELETE          ,
                                                                                     @ISACTIVE
	                                                                            	)
                                                                                    ");

                    insertMember.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                    insertMember.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                    insertMember.Parameters.Add("@MEMBER_NAME", SqlDbType.NVarChar).Value       = memberName.Text;
                    insertMember.Parameters.Add("@MEMBER_SURNAME", SqlDbType.NVarChar).Value    = memberSurname.Text;
                    insertMember.Parameters.Add("@MEMBER_FNAME", SqlDbType.NVarChar).Value      = memberFname.Text;
                    insertMember.Parameters.Add("@MEMBER_POSITION", SqlDbType.NVarChar).Value   = memberPosition.Text;
                    insertMember.Parameters.Add("@MEMBER_DETAIL", SqlDbType.NVarChar).Value     = memberDetail.Text;
                    insertMember.Parameters.Add("@MEMBER_IMAGE", SqlDbType.NVarChar).Value      = memberImageName;
                    insertMember.Parameters.Add("@PC_ID", SqlDbType.Int).Value = PC_ID;

                    SQL.COMMAND(insertMember);

                   fileMember.SaveAs(Server.MapPath("/Images/members/" + memberImageName));

            }



        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["MEMBER"] as string == "SELECTED")
                {
                    try
                    {
                        GetMember(Session["MEMBER_ID"] as string, false, Session["PC_ID"] as string);
                    }
                    catch (Exception ex)
                    {
                         Log.LogCreator(Server.MapPath("~/Logs/logs.txt"), ex.Message);
                    }

                    try
                    {
                        btnConfirm.Text = "Dəyiş";
                        btnConfirm.CssClass = "btn btn-warning";
                    }
                    catch (Exception ex)
                    {
                         Log.LogCreator(Server.MapPath("~/Logs/logs.txt"), ex.Message);
                    }
                }
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (Session["MEMBER"] as string == "SELECTED")
            {
                UpdateMember(Session["MEMBER_ID"] as string, Session["PC_ID"] as string);
            }
            else
            {
                InsertMember(Session["PC_ID"] as string);
            }



            Session["MEMBER"] = null;
            Session["MEMBER_ID"] = null;

            Response.Redirect("/manage/members");
        }
    }
}