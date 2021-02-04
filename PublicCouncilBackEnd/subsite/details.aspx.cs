using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace PublicCouncilBackEnd.subsite
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        public string GetViewCount(string POST_ID)
        {
            SqlDataAdapter getcount = new SqlDataAdapter(new SqlCommand("SELECT POST_VIEWCOUNT FROM PC_POSTS WHERE DATA_ID=@DATA_ID"));
            getcount.SelectCommand.Parameters.Add("@DATA_ID", SqlDbType.Int).Value = POST_ID;

            return SQL.SELECT(getcount).Rows[0]["POST_VIEWCOUNT"].ToString();

        }
        private void CountViewUpdate(string POST_ID)
        {
            SqlCommand countview = new SqlCommand(@"UPDATE  PC_POSTS SET POST_VIEWCOUNT=@POST_VIEWCOUNT WHERE DATA_ID=@DATA_ID");
            countview.Parameters.Add("@POST_VIEWCOUNT", SqlDbType.Int).Value = int.Parse(GetViewCount(Page.RouteData.Values["postid"] as string)) + new Random().Next(9, 15);
            countview.Parameters.Add("@DATA_ID", SqlDbType.Int).Value = POST_ID;
            SQL.COMMAND(countview);
        }
        private void GetPost(string lang, string ID,string POST_AUTHOR)
        {

            CountViewUpdate(Page.RouteData.Values["postid"] as string);
            SqlDataAdapter getdata;
            DataTable DT;
            switch (lang)
            {
                case "az":
                    {


                        getdata = new SqlDataAdapter(new SqlCommand(@"SELECT DATA_ID, POST_SERIAL, POST_AZ_TITLE, POST_SEOAZ, POST_SITECATEGORYAZ, POST_AZ_TOPIC, POST_IMG, POST_DATE ,POST_VIEWCOUNT  FROM PC_POSTS 

                                                                                                                WHERE ISACTIVE     = @ISACTIVE                AND 
                                                                                                                      ISDELETE     = @ISDELETE                AND 
                                                                                                                      POST_AZ_VIEW = @POST_AZ_VIEW            AND   
                                                                                                                      POST_AUTHOR = @POST_AUTHOR              AND
                                                                                                                      DATA_ID=@DATA_ID"));
                        getdata.SelectCommand.Parameters.Add("@DATA_ID", SqlDbType.Int).Value = ID;
                        getdata.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                        getdata.SelectCommand.Parameters.Add("@POST_AZ_VIEW", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@POST_AUTHOR", SqlDbType.NVarChar).Value = POST_AUTHOR;


                        DT = SQL.SELECT(getdata);

                        if (DT.Rows[0]["POST_SITECATEGORYAZ"].ToString().ToLower() == "qanunvericilik")
                        {
                            postImage.Visible = false;
                            postCategory.Visible = false;
                            postDateLink.Visible = false;
                            postViewLink.Visible = false;
                        }


                        Page.Title = DT.Rows[0]["POST_SEOAZ"].ToString();
                        postTitle.Text = DT.Rows[0]["POST_AZ_TITLE"].ToString();
                        postDate.Text = DT.Rows[0]["POST_DATE"].ToString().Substring(0, DT.Rows[0]["POST_DATE"].ToString().Length - 3).Replace("/", ".");

                        postImage.ImageUrl = $"/images/original/{ DT.Rows[0]["POST_IMG"].ToString()}";
                        postAbout.Text = DT.Rows[0]["POST_AZ_TOPIC"].ToString();
                        postCategory.Text = DT.Rows[0]["POST_SITECATEGORYAZ"].ToString();
                        postView.Text = DT.Rows[0]["POST_VIEWCOUNT"].ToString();
                        GetPostImages(DT.Rows[0]["POST_SERIAL"].ToString());
                        GetPostVideos(DT.Rows[0]["POST_SERIAL"].ToString());
                        GetDocs(DT.Rows[0]["POST_SERIAL"].ToString());

                        break;
                    }
                case "en":
                    {

                        getdata = new SqlDataAdapter(new SqlCommand(@"SELECT DATA_ID, POST_SERIAL, POST_EN_TITLE, POST_SEOEN, POST_SITECATEGORYEN, POST_EN_TOPIC, POST_IMG, POST_DATE ,POST_VIEWCOUNT  FROM PC_POSTS 

                                                                                                                WHERE ISACTIVE     = @ISACTIVE                AND 
                                                                                                                      ISDELETE     = @ISDELETE                AND 
                                                                                                                      POST_EN_VIEW = @POST_EN_VIEW             AND   
                                                                                                                      POST_AUTHOR = @POST_AUTHOR              AND
                                                                                                                      DATA_ID=@DATA_ID"));
                        getdata.SelectCommand.Parameters.Add("@DATA_ID", SqlDbType.Int).Value = ID;
                        getdata.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                        getdata.SelectCommand.Parameters.Add("@POST_EN_VIEW", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@POST_AUTHOR", SqlDbType.NVarChar).Value = POST_AUTHOR;


                        DT = SQL.SELECT(getdata);



                        Page.Title = DT.Rows[0]["POST_SEOEN"].ToString();
                        postTitle.Text = DT.Rows[0]["POST_EN_TITLE"].ToString();
                        postDate.Text = DT.Rows[0]["POST_DATE"].ToString().Substring(0, DT.Rows[0]["POST_DATE"].ToString().Length - 3).Replace("/", ".");

                        postImage.ImageUrl = $"/images/original/{ DT.Rows[0]["POST_IMG"].ToString()}";
                        postAbout.Text = DT.Rows[0]["POST_EN_TOPIC"].ToString();
                        postCategory.Text = DT.Rows[0]["POST_SITECATEGORYEN"].ToString();
                        postView.Text = DT.Rows[0]["POST_VIEWCOUNT"].ToString();
                        GetPostImages(DT.Rows[0]["POST_SERIAL"].ToString());
                        GetPostVideos(DT.Rows[0]["POST_SERIAL"].ToString());
                        GetDocs(DT.Rows[0]["POST_SERIAL"].ToString());

                        break;
                    }
                default:
                    {




                        getdata = new SqlDataAdapter(new SqlCommand(@"SELECT DATA_ID, POST_SERIAL, POST_AZ_TITLE, POST_SEOAZ, POST_SITECATEGORYAZ, POST_AZ_TOPIC, POST_IMG, POST_DATE,POST_VIEWCOUNT  FROM DATA_POST 

                                                                                                                WHERE ISACTIVE     = @ISACTIVE                AND 
                                                                                                                      ISDELETE     = @ISDELETE                AND 
                                                                                                                      POST_AZ_VIEW = @POST_AZ_VIEW             AND   
                                                                                                                      POST_AUTHOR = @POST_AUTHOR              AND
                                                                                                                      DATA_ID=@DATA_ID"));
                        getdata.SelectCommand.Parameters.Add("@DATA_ID", SqlDbType.Int).Value = ID;
                        getdata.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                        getdata.SelectCommand.Parameters.Add("@POST_AZ_VIEW", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@POST_AUTHOR", SqlDbType.NVarChar).Value = POST_AUTHOR;


                        DT = SQL.SELECT(getdata);

                        Page.Title = DT.Rows[0]["POST_AZ_TITLE"].ToString();
                        postTitle.Text = DT.Rows[0]["POST_AZ_TITLE"].ToString();
                        postDate.Text = DT.Rows[0]["POST_DATE"].ToString()
                                        .Substring(0, DT.Rows[0]["POST_DATE"].ToString().Length - 3).Replace("/", ".");

                        postImage.ImageUrl = $"/images/original/{ DT.Rows[0]["POST_IMG"].ToString()}";
                        postAbout.Text = DT.Rows[0]["POST_AZ_TOPIC"].ToString();
                        postCategory.Text = DT.Rows[0]["POST_SITECATEGORYAZ"].ToString();
                        postView.Text = DT.Rows[0]["POST_VIEWCOUNT"].ToString();
                        GetPostImages(DT.Rows[0]["POST_SERIAL"].ToString());
                        GetPostVideos(DT.Rows[0]["POST_SERIAL"].ToString());
                        GetDocs(DT.Rows[0]["POST_SERIAL"].ToString());

                        break;
                    }
            }

            getdata = null;
            DT = null;

        }

        private void GetPostImages(string POSTSERIAL)
        {
            SqlDataAdapter getimages = new SqlDataAdapter(new SqlCommand(@"SELECT POST_IMG_NAME
                                                                                            FROM PC_IMGGALERY
                                                                                                 WHERE POST_SERIAL = @POST_SERIAL AND ISDELETE='FALSE' AND ISACTIVE='TRUE'"));
            getimages.SelectCommand.Parameters.Add("@POST_SERIAL", SqlDbType.NVarChar).Value = POSTSERIAL;

            if (Convert.ToString(Page.RouteData.Values["LANGUAGE"]).ToLower() == "az")
            {
                POST_IMGGALERYEN.DataSource = null;
                POST_IMGGALERYEN.DataBind();
                POST_IMGGALERYAZ.DataSource = SQL.SELECT(getimages);
                POST_IMGGALERYAZ.DataBind();
            }
            else if (Convert.ToString(Page.RouteData.Values["LANGUAGE"]).ToLower() == "en")
            {
                POST_IMGGALERYAZ.DataSource = null;
                POST_IMGGALERYAZ.DataBind();
                POST_IMGGALERYEN.DataSource = SQL.SELECT(getimages);
                POST_IMGGALERYEN.DataBind();
            }
            else
            {
                POST_IMGGALERYEN.DataSource = null;
                POST_IMGGALERYEN.DataBind();
                POST_IMGGALERYAZ.DataSource = SQL.SELECT(getimages);
                POST_IMGGALERYAZ.DataBind();
            }

        }
        private void GetPostVideos(string POSTERIAL)
        {
            SqlDataAdapter getvideos = new SqlDataAdapter(new SqlCommand(@"SELECT POST_VIDEO_FRAME FROM PC_VIDEOGALERY WHERE POST_SERIAL=@POST_SERIAL"));
            getvideos.SelectCommand.Parameters.AddWithValue("@POST_SERIAL", POSTERIAL);
            if (Convert.ToString(Page.RouteData.Values["LANGUAGE"]).ToLower() == "az")
            {
                POST_VIDEOGALERYEN.DataSource = null;
                POST_VIDEOGALERYEN.DataBind();
                POST_VIDEOGALERYAZ.DataSource = SQL.SELECT(getvideos);
                POST_VIDEOGALERYAZ.DataBind();
            }
            else if (Convert.ToString(Page.RouteData.Values["LANGUAGE"]).ToLower() == "en")
            {
                POST_VIDEOGALERYAZ.DataSource = null;
                POST_VIDEOGALERYAZ.DataBind();
                POST_VIDEOGALERYEN.DataSource = SQL.SELECT(getvideos);
                POST_VIDEOGALERYEN.DataBind();
            }
            else
            {
                POST_VIDEOGALERYEN.DataSource = null;
                POST_VIDEOGALERYEN.DataBind();
                POST_VIDEOGALERYAZ.DataSource = SQL.SELECT(getvideos);
                POST_VIDEOGALERYAZ.DataBind();
            }
        }
        private void GetDocs(string POST_SERIAL)
        {
            SqlDataAdapter getdocs = new SqlDataAdapter(new SqlCommand(@"SELECT
                                                                    	    DOC_NAME,
                                                                            DOC_DEFAULTNAME
                                                                      FROM  PC_POSTDOCS
                                                                      WHERE 
                                                                            ISDELETE=@ISDELETE       AND
                                                                            ISACTIVE=@ISACTIVE       AND
                                                                            POST_SERIAL=@POST_SERIAL AND 
                                                                    		USER_ID=@USER_ID"));

            getdocs.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
            getdocs.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
            getdocs.SelectCommand.Parameters.Add("@POST_SERIAL", SqlDbType.NVarChar).Value = POST_SERIAL;
            getdocs.SelectCommand.Parameters.Add("@USER_ID", SqlDbType.Int).Value = 1;


            if (Convert.ToString(Page.RouteData.Values["LANGUAGE"]).ToLower() == "az")
            {
                POST_DOCUMENTSEN.DataSource = null;
                POST_DOCUMENTSEN.DataBind();
                POST_DOCUMENTSAZ.DataSource = SQL.SELECT(getdocs);
                POST_DOCUMENTSAZ.DataBind();
            }
            else if (Convert.ToString(Page.RouteData.Values["LANGUAGE"]).ToLower() == "en")
            {
                POST_DOCUMENTSAZ.DataSource = null;
                POST_DOCUMENTSAZ.DataBind();
                POST_DOCUMENTSEN.DataSource = SQL.SELECT(getdocs);
                POST_DOCUMENTSEN.DataBind();
            }
            else
            {
                POST_DOCUMENTSEN.DataSource = null;
                POST_DOCUMENTSEN.DataBind();
                POST_DOCUMENTSAZ.DataSource = SQL.SELECT(getdocs);
                POST_DOCUMENTSAZ.DataBind();
            }



        }

        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {
                GetPost(Convert.ToString(Page.RouteData.Values["language"]).ToLower(), Page.RouteData.Values["postid"] as string, Page.RouteData.Values["publiccouncil"] as string);

                if (Convert.ToString(Page.RouteData.Values["language"]).ToLower() == "az")
                {

                    shareName.Text = "<span class='h5 text-default'>Paylaş</span>";
                }
                else if (Convert.ToString(Page.RouteData.Values["language"]).ToLower() == "en")
                {

                    shareName.Text = "<span class='h5 text-default'>Share</span>";
                }
                else
                {
                    shareName.Text = "<span class='h5 text-default'>Paylaş</span>";
                }
            }
            catch
            {
                
            }


            HtmlMeta ogUrl = new HtmlMeta { Name = "og:url", Content = "http://ictimaishura.az/details/" + RouteData.Values["postid"] as string };
            HtmlMeta ogType = new HtmlMeta { Name = "og:type", Content = "article" };
            HtmlMeta ogTitle = new HtmlMeta { Name = "og:title", Content = Page.Title };
            HtmlMeta ogDescription = new HtmlMeta { Name = "og:description", Content = Page.Title };
            HtmlMeta ogImage = new HtmlMeta { Name = "og:image", Content = "http://ictimaishura.az" + postImage.ImageUrl.ToString() };


            Header.Controls.Add(ogUrl);
            Header.Controls.Add(ogType);
            Header.Controls.Add(ogTitle);
            Header.Controls.Add(ogDescription);
            Header.Controls.Add(ogImage);
        }
    }
}