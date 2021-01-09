using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace PublicCouncilBackEnd.manage
{
    public partial class WebForm9 : System.Web.UI.Page
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

        #region( CRUD  FUNCTIONS)
        private void GetPartners(string PARTNER_ID)
        {
            SqlDataAdapter getPartners = new SqlDataAdapter(new SqlCommand(@"SELECT 
                                                                            ROW_NUMBER() OVER(ORDER BY DATA_ID DESC) AS '#' ,
	                                                                        DATA_ID,
                                                                            SPONSOR_TITLE,
                                                                            SPONSOR_IMG,
                                                                            SPONSOR_LINK
                                                                          
                                                                        FROM PC_SPONSORS WHERE 
                                                                             ISDELETE = @ISDELETE AND
                                                                             ISACTIVE = @ISACTIVE AND
                                                                             DATA_ID  = @DATA_ID"));

            getPartners.SelectCommand.Parameters.Add("@DATA_ID", SqlDbType.Int).Value = PARTNER_ID;
            getPartners.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
            getPartners.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;

            DataTable DT = new DataTable();

            DT = SQL.SELECT(getPartners);

            sponsorname.Text = DT.Rows[0]["SPONSOR_TITLE"].ToString();
            sponsorLink.Text = DT.Rows[0]["SPONSOR_LINK"].ToString();
            sponsorImage.ImageUrl = $"~/Images/{DT.Rows[0]["SPONSOR_IMG"].ToString()}";

        }

        private void InsertSponsor()
        {
            string picName = Helper.SetName(".jpg");
            SqlCommand insertSponsor = new SqlCommand(@"INSERT INTO PC_SPONSORS
                                                                                (
                                                                                 SPONSOR_TITLE,
                                                                                 SPONSOR_LINK,
                                                                                 SPONSOR_IMG,
                                                                                 ISDELETE,
                                                                                 ISACTIVE
                                                                                )
                                                                                VALUES
                                                                                (                                                                               
                                                                                 @SPONSOR_TITLE,
                                                                                 @SPONSOR_LINK,
                                                                                 @SPONSOR_IMG,
                                                                                 @ISDELETE,
                                                                                 @ISACTIVE
                                                                                )");

            insertSponsor.Parameters.Add("@SPONSOR_TITLE", SqlDbType.NVarChar).Value = sponsorname.Text;
            insertSponsor.Parameters.Add("@SPONSOR_LINK", SqlDbType.NVarChar).Value = sponsorLink.Text;
            insertSponsor.Parameters.Add("@SPONSOR_IMG", SqlDbType.NVarChar).Value = picName;
            insertSponsor.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
            insertSponsor.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
            SQL.COMMAND(insertSponsor);
            MadeImage(sponsorFile, picName, 460, 280);
            Session["SPONSOR"] = null;


        }

        private void UpdateSponsor(string SPONSORSID)
        {
            SqlCommand update = new SqlCommand(@"UPDATE PC_SPONSORS SET
                                                                                 SPONSOR_TITLE = @SPONSOR_TITLE,
                                                                                 SPONSOR_LINK  = @SPONSOR_LINK,
                                                                                 SPONSOR_IMG   = @SPONSOR_IMG,
                                                                                 ISDELETE       = @ISDELETE,
                                                                                 ISACTIVE       = @ISACTIVE 
                                                                                                            WHERE DATA_ID=@DATA_ID");

            update.Parameters.Add("@DATA_ID", SqlDbType.Int).Value = SPONSORSID;

            update.Parameters.Add("@SPONSOR_TITLE", SqlDbType.NVarChar).Value = sponsorname.Text;
            update.Parameters.Add("@SPONSOR_LINK", SqlDbType.NVarChar).Value = sponsorLink.Text;

            if (sponsorFile.HasFile)
            {
                string picName = Helper.SetName(".jpg");
                update.Parameters.Add("@SPONSOR_IMG", SqlDbType.NVarChar).Value = picName;
                MadeImage(sponsorFile, picName, 460, 280);
            }
            else
            {
                string mainImageName = sponsorImage.ImageUrl.ToString().Replace("/", "").Replace("Images", "").Replace("~", "");

                update.Parameters.Add("@SPONSOR_IMG", SqlDbType.NVarChar).Value = mainImageName;
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
                if (Session["SPONSOR"] as string == "SELECTED")
                {
                    GetPartners(Session["SPONSOR_ID"] as string);
                    sponsorConfirm.Text = "Dəyiş";
                }
                else
                {
                    UpdateSponsor(Session["SPONSOR_ID"] as string);
                    sponsorConfirm.Text = "Təsdiq et";
                }
            }
        }

        protected void sponsordetail_back_Click(object sender, EventArgs e)
        {
            Session["SPONSOR"] = null;
            Session["SPONSOR_ID"] = null;
            Response.Redirect("/manage/sponsors");
        }

        protected void sponsorConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["SPONSOR"] as string == "SELECTED")
                {

                    UpdateSponsor(Session["SPONSOR_ID"] as string);
                }
                else
                {
                    InsertSponsor();
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }

            Session["SPONSOR"] = null;
            Session["SPONSOR_ID"] = null;
            Response.Redirect("/manage/sponsors");
        }
    }
}