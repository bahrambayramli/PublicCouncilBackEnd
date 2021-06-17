using System;
using System.Web;
using Ionic.Zip;
using System.IO;
using System.Text;
using System.Web.UI;
using System.IO.Compression;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Configuration;


namespace PublicCouncilBackEnd.manage
{
    public partial class WebForm17 : System.Web.UI.Page
    {
        #region(HELPER FUNCTIONS)
        private void ArchivSite(string ARCHIVE_NAME)
        {
            Response.Clear();
            Response.BufferOutput   = false;
            Response.ContentType    = "application/zip";
            Response.AddHeader("content-disposition", $"attachment; filename={ARCHIVE_NAME}");

            using (ZipFile zip = new ZipFile())
            {
                zip.Password            = ConfigurationManager.AppSettings["SQLPASSWORD"].ToString();
                zip.CompressionLevel    = (Ionic.Zlib.CompressionLevel)CompressionLevel.NoCompression;
                zip.AddSelectedFiles("*", Server.MapPath("~/images/"), "images", true);
                zip.AddFiles(Directory.GetFiles(Server.MapPath("~/uploads/")), "uploads");
                zip.AddFiles(Directory.GetFiles(Server.MapPath("~/logs/")), "logs");
                zip.Save(Server.MapPath($"~/pcsiteacrch/{ARCHIVE_NAME}"));
            }
        }

        private void ArchivDB(string DB_ARCHIVE_NAME)
        {
            var script = new StringBuilder();

            Server server = new Server(
                                new ServerConnection(
                                    new Microsoft.Data.SqlClient.SqlConnection($"Data Source={ConfigurationManager.AppSettings["SQLSERVER"]}; Initial Catalog={ConfigurationManager.AppSettings["SQLCATALOG"]}; USER ID={ConfigurationManager.AppSettings["SQLUSER"]}; Password={ConfigurationManager.AppSettings["SQLPASSWORD"]};")));
            Database database = server.Databases[ConfigurationManager.AppSettings["SQLCATALOG"]];
            ScriptingOptions options = new ScriptingOptions
            {
                ScriptData          = true,
                ScriptSchema        = true,
                ScriptDrops         = false,
                Indexes             = true,
                IncludeHeaders      = true
            };

            foreach (Microsoft.SqlServer.Management.Smo.Table table in database.Tables)
            {
                foreach (var statement in table.EnumScript(options))
                {
                    script.Append(statement);
                    script.Append(Environment.NewLine);
                }
            }

            File.WriteAllText(Server.MapPath("~/pcsiteacrch/") + DB_ARCHIVE_NAME, script.ToString());
        }

        private string MakeNameForArchive()
        {
            return Guid.NewGuid().ToString().Replace("-", "") +
                                                DateTime.Now.Day.ToString() +
                                                DateTime.Now.Month.ToString() +
                                                DateTime.Now.Year.ToString() +
                                                DateTime.Now.Minute.ToString();
        }
        #endregion

        #region(SQL FUNCTIONS)
        #region(SITE)
        private void GetSiteAchives()
        {
            SqlDataAdapter getArchives = new SqlDataAdapter(new SqlCommand(@"SELECT ROW_NUMBER() OVER(ORDER BY CREATED_DATE DESC) AS '#' ,
	                                                                                         ARCHIVE_ID		    ,
                                                                                             ARCHIVE_NAME		,
                                                                                             CREATED_DATE       ,
                                                                                             ZIP_LINK

                                                                                        FROM PC_SITE_ARCHIVE

                                                                                        WHERE ISDELETE = @ISDELETE AND
                                                                                              ISACTIVE = @ISACTIVE

                                                                                        "));

            getArchives.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
            getArchives.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;

            SiteArchivesList.DataSource = SQL.SELECT(getArchives);
            SiteArchivesList.DataBind();

        }

        private void InsertArchive(string ARCHIVE_NAME)
        {
            SqlCommand insertArchive = new SqlCommand(@"INSERT INTO PC_SITE_ARCHIVE
                                                                (
                                                                    ISDELETE            ,
                                                                    ISACTIVE            ,
                                                                    ARCHIVE_NAME        ,
                                                                    CREATED_DATE        ,
                                                                    ZIP_LINK
                                                                )
                                                            VALUES
                                                                (
                                                                    @ISDELETE           ,
                                                                    @ISACTIVE           ,
                                                                    @ARCHIVE_NAME       ,
                                                                    @CREATED_DATE       ,
                                                                    @ZIP_LINK
                                                                )");


            insertArchive.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
            insertArchive.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
            insertArchive.Parameters.Add("@ARCHIVE_NAME", SqlDbType.NVarChar).Value = ARCHIVE_NAME;
            insertArchive.Parameters.Add("@CREATED_DATE", SqlDbType.DateTime).Value = DateTime.UtcNow;
            insertArchive.Parameters.Add("@ZIP_LINK", SqlDbType.NVarChar).Value = $"/pcsiteacrch/{ARCHIVE_NAME}";

            SQL.COMMAND(insertArchive);
        }

        private void DeleteSiteArchive(string ARCHIVE_ID)
        {
            SqlCommand deleteAchive = new SqlCommand(@"UPDATE PC_SITE_ARCHIVE SET ISDELETE=@ISDELETE,ISACTIVE=@ISACTIVE WHERE ARCHIVE_ID = @ARCHIVE_ID");
            deleteAchive.Parameters.Add("@ARCHIVE_ID", SqlDbType.Int).Value = ARCHIVE_ID;
            deleteAchive.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = false;
            deleteAchive.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = true;
            SQL.COMMAND(deleteAchive);
        }
        #endregion

        #region(DB)
        private void GetDBAchives()
        {
            SqlDataAdapter getArchives = new SqlDataAdapter(new SqlCommand(@"SELECT ROW_NUMBER() OVER(ORDER BY CREATED_DATE DESC) AS '#' ,
	                                                                                         DB_ID		        ,
                                                                                             DB_NAME		    ,
                                                                                             CREATED_DATE       ,
                                                                                             ZIP_LINK

                                                                                        FROM PC_DB_ARCHIVE

                                                                                        WHERE ISDELETE = @ISDELETE AND
                                                                                              ISACTIVE = @ISACTIVE

                                                                                        "));

            getArchives.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
            getArchives.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;

            DBArchiveList.DataSource = SQL.SELECT(getArchives);
            DBArchiveList.DataBind();

        }

        private void InsertDBArchive(string ARCHIVE_NAME)
        {
            SqlCommand insertArchive = new SqlCommand(@"INSERT INTO PC_DB_ARCHIVE
                                                                (
                                                                    ISDELETE            ,
                                                                    ISACTIVE            ,
                                                                    DB_NAME             ,
                                                                    CREATED_DATE        ,
                                                                    ZIP_LINK
                                                                )
                                                            VALUES
                                                                (
                                                                    @ISDELETE           ,
                                                                    @ISACTIVE           ,
                                                                    @DB_NAME            ,
                                                                    @CREATED_DATE       ,
                                                                    @ZIP_LINK
                                                                )");


            insertArchive.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
            insertArchive.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
            insertArchive.Parameters.Add("@DB_NAME", SqlDbType.NVarChar).Value = ARCHIVE_NAME;
            insertArchive.Parameters.Add("@CREATED_DATE", SqlDbType.DateTime).Value = DateTime.UtcNow;
            insertArchive.Parameters.Add("@ZIP_LINK", SqlDbType.NVarChar).Value = $"/pcsiteacrch/{ARCHIVE_NAME}";

            SQL.COMMAND(insertArchive);
        }

        private void DeleteDBArchive(string DB_ID)
        {
            SqlCommand deleteAchive = new SqlCommand(@"UPDATE PC_DB_ARCHIVE SET ISDELETE=@ISDELETE,ISACTIVE=@ISACTIVE WHERE DB_ID = @DB_ID");
            deleteAchive.Parameters.Add("@DB_ID", SqlDbType.Int).Value = DB_ID;
            deleteAchive.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = false;
            deleteAchive.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = true;
            SQL.COMMAND(deleteAchive);
        }
        #endregion
        #endregion

        #region(SITE ARCHIVES GRID VIEW EVENST)
        protected void SiteArchivesList_RowCreated(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Pager) { return; }

            try { e.Row.Cells[1].Visible = false; } catch { }
        }

        protected void SiteArchivesList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SiteArchivesList.PageIndex = e.NewPageIndex;
            //GetSiteArchives
            try
            {
                GetSiteAchives();
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: Main Master >> archiv.aspx >> GetSiteAchives method, Log:{ex.Message}");
            }
        }

        protected void delete_archive_Click(object sender, EventArgs e)
        {
            //Delete Archive
            try
            {
                int rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
                string id = SiteArchivesList.Rows[rowIndex].Cells[1].Text;
                DeleteSiteArchive(id);
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: Main Master >> archiv.aspx >> Delete Archive method, Log:{ex.Message}");
            }

            try
            {
                GetSiteAchives();
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: Main Master >> archiv.aspx >> GetSiteAchives method, Log:{ex.Message}");
            }

        }
        #endregion

        #region(DB GRID VIEW EVENTS)
        protected void DBArchiveList_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Pager) { return; }

            try { e.Row.Cells[1].Visible = false; } catch { }
        }

        protected void DBArchiveList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DBArchiveList.PageIndex = e.NewPageIndex;
            //GetDBAchives
            try
            {
                GetDBAchives();
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: Main Master >> archiv.aspx >> GetDBAchives method, Log:{ex.Message}");
            }
        }

        protected void delete_db_archive_Click(object sender, EventArgs e)
        {
            //Delete Archive
            try
            {
                int rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
                string id = DBArchiveList.Rows[rowIndex].Cells[1].Text;
                DeleteDBArchive(id);
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: Main Master >> archiv.aspx >> Delete Archive method, Log:{ex.Message}");
            }

            try
            {
                GetDBAchives();
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: Main Master >> archiv.aspx >> GetDBAchives method, Log:{ex.Message}");
            }
        }
        #endregion

        #region(GET AND ARCHIVE BUTTONS)
        #region(SITE BUTTONS)
        protected void hosting_back_up_Click(object sender, EventArgs e)
        {
            hosting_back_up.Enabled = false;

            string archive_name = $"backup-pc-{MakeNameForArchive()}.zip";

            //InsertArchive
            try
            {
                InsertArchive(archive_name);
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: Manage Master >> archiv.aspx >> InsertArchive method , Log:{ex.Message}");
            }

            try
            {
                ArchivSite(archive_name);
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: Manage Master >> archiv.aspx >> Zip Archiv , Log:{ex.Message}");
            }

            backup_status.Text = "<p class='h4 text-success my-2'>Arxiv edildi.</p>";

            hosting_back_up.Enabled = true;

            try
            {
                GetSiteAchives();
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: Manage Master >> archiv.aspx >> GetSiteAchives method , Log:{ex.Message}");
            }

        }

        protected void get_archives_Click(object sender, EventArgs e)
        {
            try
            {
                GetSiteAchives();
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: Main Master >> archiv.aspx >> GetSiteAchives method, Log:{ex.Message}");
            }
        }
        #endregion

        #region(DB BUTTONS)
        protected void get_dbs_Click(object sender, EventArgs e)
        {
            try
            {
                GetDBAchives();
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: Main Master >> archiv.aspx >> GetDBAchives method, Log:{ex.Message}");
            }
        }

        protected void hoisting_db_backup_Click(object sender, EventArgs e)
        {
            hoisting_db_backup.Enabled = false;
            db_status.Text = "<p class='h4 text-warnign my-2'>Prosses başlanılıb zəhmət olmasa gözləyin.</p>";

            string archive_name = $"backup-db-{MakeNameForArchive()}.zip";

            InsertDBArchive(archive_name);

            try
            {
                ArchivDB(archive_name);
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: Manage Master >> archiv.aspx >> DB Archiv , Log:{ex.Message}");
            }

            db_status.Text = "<p class='h4 text-success my-2'>Arxiv edildi.</p>";

            hoisting_db_backup.Enabled = true;

            try
            {
                GetDBAchives();
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: Main Master >> archiv.aspx >> GetDBAchives method, Log:{ex.Message}");
            }

        }
        #endregion
        #endregion

        private void RunArchive()
        {
            if (Session["USER_MEMBERSHIP_TYPE"] as string != "admin")
            {
                Response.Redirect("/manage/dashboard");
            }
            //GetSiteArchives
            try
            {
                GetSiteAchives();
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: Main Master >> archiv.aspx >> GetSiteAchives method, Log:{ex.Message}");
            }

            try
            {
                GetDBAchives();
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: Main Master >> archiv.aspx >> GetSiteAchives method, Log:{ex.Message}");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                RunArchive();
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: Main Master >> archiv.aspx >> RunArchive method, Log:{ex.Message}");
            }
        }
    }
}