using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

namespace PublicCouncilBackEnd.manage
{
    public partial class WebForm14 : System.Web.UI.Page
    {

        #region(Image Maker)

        public void MadeImageAndSave(FileUpload fl, string imgName, string imageDirectory, int width, int height)
        {

            //SET THE SIZES
            int W = width;      //Widht
            int H = height;    //Height


            //CHECK THE EXTENSION TYPES ---------------------------------------------------
            string extension = Path.GetExtension(fl.FileName).ToLower();
            if ((extension != ".jpg") &&
                (extension != ".jpeg") &&
                (extension != ".bmp") &&
                (extension != ".png") &&
                (extension != ".gif") &&
                (extension != ".tif") &&
                (extension != ".tiff")) return;



            //SET THE IMAGE SIZE ------------------------------------------
            System.Drawing.Image orginal = System.Drawing.Image.FromStream(fl.PostedFile.InputStream);
            //int newH = (orginal.Height * W) / orginal.Width;
            //if (newH > H) { W = (W * H) / newH; newH = H; }
            //H = newH;
          
            //CHNAGE THE FINAL IMAGE SIZE ----------------------------------
            Bitmap finalImage = new Bitmap(orginal, W, H);
            finalImage.Save(Server.MapPath(imageDirectory + imgName), System.Drawing.Imaging.ImageFormat.Jpeg);//convert to jpeg format
            finalImage.Dispose();
        }

        #endregion

        #region(SQL CRUD FUNCTIONS)
        private void GetMember(string MEMBER_ID, bool ISDELETE, string PC_ID)
        {
            SqlDataAdapter getMember = new SqlDataAdapter(new SqlCommand(@"SELECT 
                                                                                 MEMBER_ID           ,
                                                                                 MEMBER_NAME         ,
                                                                                 MEMBER_SURNAME      ,
                                                                                 MEMBER_FNAME        ,
                                                                                 MEMBER_POSITION     ,
                                                                                 MEMBER_DETAIL       ,
                                                                                 MEMBER_IMAGE        ,
                                                                                 MEMBER_ORDER_NUMBER ,
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
            memberFname.Text         = DT.Rows[0]["MEMBER_FNAME"].ToString();
            memberPosition.Text      = DT.Rows[0]["MEMBER_POSITION"].ToString();
            memberDetail.Text        = DT.Rows[0]["MEMBER_DETAIL"].ToString();
            memberOrderNumber.Text   = DT.Rows[0]["MEMBER_ORDER_NUMBER"].ToString();
            memberImage.ImageUrl     = $"/Images/members/{DT.Rows[0]["MEMBER_IMAGE"].ToString()}";

            
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
						                                                            MEMBER_NAME         ,
                                                                                    MEMBER_SURNAME      ,
                                                                                    MEMBER_FNAME        ,
                                                                                    MEMBER_POSITION     ,
                                                                                    MEMBER_DETAIL       ,
                                                                                    MEMBER_IMAGE        ,
                                                                                    MEMBER_ORDER_NUMBER ,
                                                                                    PC_ID               ,
                                                                                    ISDELETE            ,
                                                                                    ISACTIVE            ,
	                                                                                )
                                                                              VALUES
                                                                                    (
	                                                                            	 @MEMBER_NAME         ,
                                                                                     @MEMBER_SURNAME      ,
                                                                                     @MEMBER_FNAME        ,
                                                                                     @MEMBER_POSITION     ,
                                                                                     @MEMBER_DETAIL       ,
                                                                                     @MEMBER_IMAGE        ,
                                                                                     @MEMBER_ORDER_NUMBER ,
                                                                                     @PC_ID               ,
                                                                                     @ISDELETE            ,
                                                                                     @ISACTIVE
	                                                                            	)
                                                                                    ");

                insertMember.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                insertMember.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                insertMember.Parameters.Add("@MEMBER_NAME", SqlDbType.NVarChar).Value = memberName.Text;
                insertMember.Parameters.Add("@MEMBER_SURNAME", SqlDbType.NVarChar).Value = memberSurname.Text;
                insertMember.Parameters.Add("@MEMBER_FNAME", SqlDbType.NVarChar).Value = memberFname.Text;
                insertMember.Parameters.Add("@MEMBER_POSITION", SqlDbType.NVarChar).Value = memberPosition.Text;
                insertMember.Parameters.Add("@MEMBER_DETAIL", SqlDbType.NVarChar).Value = memberDetail.Text;
                insertMember.Parameters.Add("@MEMBER_IMAGE", SqlDbType.NVarChar).Value = memberImageName;
                insertMember.Parameters.Add("@MEMBER_ORDER_NUMBER", SqlDbType.Int).Value = memberOrderNumber.Text;
                insertMember.Parameters.Add("@PC_ID", SqlDbType.Int).Value = PC_ID;

                SQL.COMMAND(insertMember);

                MadeImageAndSave(fileMember, memberImageName, "~/images/members/", 900, 600);

            }

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
						                                                 MEMBER_NAME         = @MEMBER_NAME         ,
                                                                         MEMBER_SURNAME      = @MEMBER_SURNAME      ,
                                                                         MEMBER_FNAME        = @MEMBER_FNAME        ,
                                                                         MEMBER_POSITION     = @MEMBER_POSITION     ,
                                                                         MEMBER_DETAIL       = @MEMBER_DETAIL       ,
                                                                         MEMBER_IMAGE        = @MEMBER_IMAGE        ,
                                                                         MEMBER_ORDER_NUMBER = @MEMBER_ORDER_NUMBER 
					                                                WHERE 
                                                                 
                                                                    MEMBER_ID      = @MEMBER_ID     AND
                                                                    PC_ID          = @PC_ID
                                                                  ");
                updateMember.Parameters.Add("@MEMBER_ID", SqlDbType.Int).Value                 = MEMBER_ID;
                updateMember.Parameters.Add("@PC_ID", SqlDbType.NVarChar).Value                = PC_ID;
                updateMember.Parameters.Add("@MEMBER_NAME", SqlDbType.NVarChar).Value          = memberName.Text;
                updateMember.Parameters.Add("@MEMBER_SURNAME", SqlDbType.NVarChar).Value       = memberSurname.Text;
                updateMember.Parameters.Add("@MEMBER_FNAME", SqlDbType.NVarChar).Value         = memberFname.Text;
                updateMember.Parameters.Add("@MEMBER_POSITION", SqlDbType.NVarChar).Value      = memberPosition.Text;
                updateMember.Parameters.Add("@MEMBER_DETAIL", SqlDbType.NVarChar).Value        = memberDetail.Text;
                updateMember.Parameters.Add("@MEMBER_IMAGE", SqlDbType.NVarChar).Value         = memberImageName;
                updateMember.Parameters.Add("@MEMBER_ORDER_NUMBER", SqlDbType.Int).Value       = memberOrderNumber.Text;



                MadeImageAndSave(fileMember, memberImageName, "~/images/members/", 900, 600);
            }
            else
            {
                updateMember = new SqlCommand(@"UPDATE PC_MEMBERS  SET     
                                                                         MEMBER_NAME         = @MEMBER_NAME          ,
                                                                         MEMBER_SURNAME      = @MEMBER_SURNAME       ,
                                                                         MEMBER_FNAME        = @MEMBER_FNAME         ,
                                                                         MEMBER_POSITION     = @MEMBER_POSITION      ,
                                                                         MEMBER_DETAIL       = @MEMBER_DETAIL        ,
                                                                         MEMBER_ORDER_NUMBER = @MEMBER_ORDER_NUMBER 

					                                                     WHERE 
                                                                 
                                                                         MEMBER_ID          = @MEMBER_ID     AND
                                                                         PC_ID              = @PC_ID
                                                                             ");

                updateMember.Parameters.Add("@MEMBER_ID", SqlDbType.Int).Value                    = MEMBER_ID;
                updateMember.Parameters.Add("@PC_ID", SqlDbType.NVarChar).Value                   = PC_ID;
                updateMember.Parameters.Add("@MEMBER_NAME", SqlDbType.NVarChar).Value             = memberName.Text;
                updateMember.Parameters.Add("@MEMBER_SURNAME", SqlDbType.NVarChar).Value          = memberSurname.Text;
                updateMember.Parameters.Add("@MEMBER_FNAME", SqlDbType.NVarChar).Value            = memberFname.Text;
                updateMember.Parameters.Add("@MEMBER_POSITION", SqlDbType.NVarChar).Value         = memberPosition.Text;
                updateMember.Parameters.Add("@MEMBER_DETAIL", SqlDbType.NVarChar).Value           = memberDetail.Text;
                updateMember.Parameters.Add("@MEMBER_ORDER_NUMBER", SqlDbType.Int).Value          = memberOrderNumber.Text;


            }

            SQL.COMMAND(updateMember);

            updateMember = null;
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["MEMBER"] as string == "SELECTED")
                {
                    try{ GetMember(Session["MEMBER_ID"] as string, false, Session["PC_ID"] as string); }

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

        protected void back_Click(object sender, EventArgs e)
        {
            Session["MEMBER"] = null;
            Session["MEMBER_ID"] = null;

            Response.Redirect("/manage/members");
        }
    }
}