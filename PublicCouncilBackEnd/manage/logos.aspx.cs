using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace PublicCouncilBackEnd.manage
{
    public partial class WebForm4 : System.Web.UI.Page
    {

        #region(SQL FUNCTIONS)
        private void GetLogos(string USER_ID, bool ISDELETE, GridView GRID)
        {
            SqlDataAdapter getLogos = new SqlDataAdapter(new SqlCommand(@"SELECT  ROW_NUMBER() OVER(ORDER BY DATA_ID DESC) AS '#' ,
                                                                                  DATA_ID,
                                                                                  LOGO_SERIAL,
                                                                                  USER_ID,
                                                                                  ISDELETE,
                                                                                  ISACTIVE,
                                                                                  LOGO_TITLE,
                                                                                  LOGO_IMG
                                                                                  
                                                                            FROM PC_SITELOGOS

                                                                            WHERE ISDELETE     = @ISDELETE AND
                                                                                  USER_ID      = @USER_ID"));
            getLogos.SelectCommand.Parameters.Add("@USER_ID", SqlDbType.Int).Value = USER_ID;
            getLogos.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = ISDELETE;

            GRID.DataSource = SQL.SELECT(getLogos);
            GRID.DataBind();

        }

        public void DeleteLogo(string ID)
        {
            SqlCommand deletenews = new SqlCommand(@"Update PC_SITELOGOS SET ISDELETE=@ISDELETE WHERE DATA_ID = @DATA_ID");
            deletenews.Parameters.Add("@DATA_ID", SqlDbType.Int).Value = ID;
            deletenews.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = true;
            SQL.COMMAND(deletenews);
            GetLogos(Session["USER_ID"] as string, false, LogoList);

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["LOGO"] = null;
                GetLogos(Session["USER_ID"] as string, false, LogoList);
            }
        }

        protected void new_logo_Click(object sender, EventArgs e)
        {
            Session["LOGO"] = null;
            Response.Redirect("/manage/logodetail");
        }

        protected void delete_logo_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
                string id = LogoList.Rows[rowIndex].Cells[1].Text;
                DeleteLogo(id);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        #region(LogoList)

        protected void LogoList_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Pager) { return; }
            try { e.Row.Cells[1].Visible = false; } catch { }
            try { e.Row.Cells[2].Visible = false; } catch { }
            try { e.Row.Cells[3].Visible = false; } catch { }
        }

        protected void LogoList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LogoList.PageIndex = e.NewPageIndex;
            GetLogos(Session["USR_SERIAL"] as string, false, LogoList);
        }

        protected void LogoList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["LOGO"] = "SELECTED";
            Session["LOGO_ID"] = LogoList.SelectedRow.Cells[1].Text;
            Response.Redirect("/manage/logodetail");
        }

        #endregion

    }
}