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
using System.Diagnostics;

namespace PublicCouncilBackEnd.manage
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        public void MadeImage(FileUpload fl, string imgName, int width, int height)
        {

            //gave the sizes
            int W = width;      //Widht
            int H = height;    //Height


            //check the image extrension type  ---------------------------------------------------
            string extension = Path.GetExtension(fl.FileName).ToLower();
            if ((extension != ".jpg") &&
                (extension != ".jpeg") &&
                (extension != ".bmp") &&
                (extension != ".png") &&
                (extension != ".gif") &&
                (extension != ".tif") &&
                (extension != ".tiff")) return;



            //  ------------------------------------------
            System.Drawing.Image orginal = System.Drawing.Image.FromStream(fl.PostedFile.InputStream);
            //int newH = (orginal.Height * W) / orginal.Width;
            //if (newH > H) { W = (W * H) / newH; newH = H; }
            //H = newH;

            //chnaged the converted image size ----------------------------------
            Bitmap NeticeImage = new Bitmap(orginal, W, H);
            NeticeImage.Save(Server.MapPath("/Images/" + imgName), System.Drawing.Imaging.ImageFormat.Jpeg);//Jpeg formatina kecirdirem
            NeticeImage.Dispose();
        }

        #region(SQL FUNCTIONS)
        private void GetPartners(string PARTNER_ID)
        {
            SqlDataAdapter getPartners = new SqlDataAdapter(new SqlCommand(@"SELECT 
                                                                            ROW_NUMBER() OVER(ORDER BY DATA_ID DESC) AS '#' ,
	                                                                        DATA_ID,
                                                                            PARTNERS_TITLE,
                                                                            PARTNERS_IMG,
                                                                            PARTNERS_LINK
                                                                          
                                                                        FROM PC_PARTNERS WHERE 
                                                                             ISDELETE = @ISDELETE AND
                                                                             ISACTIVE = @ISACTIVE AND
                                                                             DATA_ID  = @DATA_ID"));

            getPartners.SelectCommand.Parameters.Add("@DATA_ID", SqlDbType.Int).Value = PARTNER_ID;
            getPartners.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
            getPartners.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;

            DataTable DT = new DataTable();

            DT = SQL.SELECT(getPartners);

            partnername.Text = DT.Rows[0]["PARTNERS_TITLE"].ToString();
            partnerLink.Text = DT.Rows[0]["PARTNERS_LINK"].ToString();
            partnerImage.ImageUrl = $"~/Images/{DT.Rows[0]["PARTNERS_IMG"].ToString()}";

        }

        private void InsertPartner()
        {
            string picName = Helper.SetName(".jpg");
            SqlCommand insertPartner = new SqlCommand(@"INSERT INTO PC_PARTNERS
                                                                                (
                                                                                 PARTNERS_TITLE,
                                                                                 PARTNERS_LINK,
                                                                                 PARTNERS_IMG,
                                                                                 ISDELETE,
                                                                                 ISACTIVE
                                                                                )
                                                                                VALUES
                                                                                (                                                                               
                                                                                 @PARTNERS_TITLE,
                                                                                 @PARTNERS_LINK,
                                                                                 @PARTNERS_IMG,
                                                                                 @ISDELETE,
                                                                                 @ISACTIVE
                                                                                )");

            insertPartner.Parameters.Add("@PARTNERS_TITLE", SqlDbType.NVarChar).Value = partnername.Text;
            insertPartner.Parameters.Add("@PARTNERS_LINK", SqlDbType.NVarChar).Value = partnerLink.Text;
            insertPartner.Parameters.Add("@PARTNERS_IMG", SqlDbType.NVarChar).Value = picName;
            insertPartner.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
            insertPartner.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
            SQL.COMMAND(insertPartner);
            MadeImage(partnerFile, picName, 140, 70);
            Session["PARTNER"] = null;
           

        }

        private void UpdatePartner(string PARTNERSID)
        {
            SqlCommand update = new SqlCommand(@"UPDATE PC_PARTNERS SET
                                                                                 PARTNERS_TITLE = @PARTNES_TITLE,
                                                                                 PARTNERS_LINK  = @PARTNERS_LINK,
                                                                                 PARTNERS_IMG   = @PARTNERS_IMG,
                                                                                 ISDELETE       = @ISDELETE,
                                                                                 ISACTIVE       = @ISACTIVE 
                                                                                                            WHERE DATA_ID=@DATA_ID");

            update.Parameters.Add("@DATA_ID", SqlDbType.Int).Value = PARTNERSID;

            update.Parameters.Add("@PARTNES_TITLE", SqlDbType.NVarChar).Value = partnername.Text;
            update.Parameters.Add("@PARTNERS_LINK", SqlDbType.NVarChar).Value = partnerLink.Text;

            if (partnerFile.HasFile)
            {
                string picName = Helper.SetName(".jpg");
                update.Parameters.Add("@PARTNERS_IMG", SqlDbType.NVarChar).Value = picName;
                MadeImage(partnerFile, picName, 140, 70);
            }
            else
            {
                string mainImageName = partnerImage.ImageUrl.ToString().Replace("/", "").Replace("Images", "").Replace("~", "");

                update.Parameters.Add("@PARTNERS_IMG", SqlDbType.NVarChar).Value = mainImageName;
            }

            update.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
            update.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;

            SQL.COMMAND(update);

            

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["PARTNER"] as string == "SELECTED")
                {
                    GetPartners(Session["PARTNER_ID"] as string);
                    partnerConfirm.Text = "Dəyiş";
                }
                else
                {
                    UpdatePartner(Session["PARTNER_ID"] as string);
                    partnerConfirm.Text = "Təsdiq et";
                }
            }
        }

        protected void partnerConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["PARTNER"] as string == "SELECTED")
                {

                    UpdatePartner(Session["PARTNER_ID"] as string);
                }
                else 
                {
                    InsertPartner();
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }

            Session["PARTNER"] = null;
            Session["PARTNER_ID"] = null;
            Response.Redirect("/manage/partners");
        }

        protected void partnerdetail_back_Click(object sender, EventArgs e)
        {
            Session["PARTNER"] = null;
            Session["PARTNER_ID"] = null;
            Response.Redirect("/manage/partners");
        }

        #region(PartnersList)

        #endregion
    }
}