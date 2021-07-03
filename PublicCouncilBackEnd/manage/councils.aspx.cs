using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace PublicCouncilBackEnd.manage
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        #region(SQL FUNCTIONS)

        private void GETPCOUNCILS(string PC_ID)
        {
            string newValue = string.Empty;
            if(!string.IsNullOrEmpty(PC_ID))
            {
                newValue = "AND USER_ID = @PC_ID";
            }

            SqlDataAdapter getPC = new SqlDataAdapter(new SqlCommand(@"SELECT 
                                                                              ROW_NUMBER() OVER(ORDER BY CREATED_DATE DESC) AS '#' ,
                                                                              USER_ID,
                                                                              USER_SERIAL,
                                                                              USER_NAME,
                                                                              USER_SURNAME,
                                                                              PC_NAME,
                                                                              USER_MEMBERSHIP,
                                                                              USER_MEMBERSHIP_TYPE,
                                                                              USER_PCDOMAIN
                                                                        FROM  PC_USERS
                                                                        WHERE USER_LOGIN != @USER_LOGIN AND
                                                                              ISDELETE    = @ISDELETE   AND
                                                                              1=1  "      + newValue));

            getPC.SelectCommand.Parameters.Add("@USER_LOGIN", SqlDbType.NVarChar).Value = "admin";
            getPC.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
            if (!string.IsNullOrEmpty(PC_ID))
            {
                getPC.SelectCommand.Parameters.Add("@PC_ID", SqlDbType.Int).Value = PC_ID;
            }
            PCLists.DataSource = SQL.SELECT(getPC);
            PCLists.DataBind();
        }

        private void DeleteData(string PC_ID)
        {
            SqlCommand deletePC = new SqlCommand(@"Update PC_USERS SET ISDELETE=@ISDELETE,ISACTIVE=@ISACTIVE WHERE USER_ID = @USER_ID");
            deletePC.Parameters.Add("@USER_ID", SqlDbType.Int).Value = PC_ID;
            deletePC.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = false;
            deletePC.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = true;
            SQL.COMMAND(deletePC);
            GETPCOUNCILS(Session["PC_ID"] as string);

        }

        private void GetDeletedPC()
        {
            SqlDataAdapter getPC = new SqlDataAdapter(new SqlCommand(@"SELECT 
                                                                              ROW_NUMBER() OVER(ORDER BY CREATED_DATE DESC) AS '#'  ,
                                                                              USER_ID                                               ,
                                                                              USER_SERIAL                                           ,
                                                                              USER_NAME                                             ,
                                                                              USER_SURNAME                                          ,
                                                                              PC_NAME                                               ,
                                                                              USER_MEMBERSHIP                                       ,
                                                                              USER_MEMBERSHIP_TYPE                                  ,
                                                                              USER_PCDOMAIN

                                                                        FROM  PC_USERS
                                                                        WHERE 
                                                                                ISDELETE    = @ISDELETE  
                                                                               
                                                                           "));

            getPC.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = true;

            PC_DELETED.DataSource = SQL.SELECT(getPC);
            PC_DELETED.DataBind();
        }

        private void RestoreDeletedPc(string PC_ID)
        {
            SqlCommand restorePc = new SqlCommand(@"UPDATE PC_USERS 
                                                                  SET 
                                                                        ISDELETE = @ISDELETE,
                                                                        ISACTIVE = @ISACTIVE 
                                                                  WHERE 
                                                                        USER_ID = @USER_ID");

            restorePc.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value   = true;
            restorePc.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value   = false;
            restorePc.Parameters.Add("@USER_ID", SqlDbType.Int).Value    = PC_ID;

            SQL.COMMAND(restorePc);
        }

        #endregion

        #region(PC LIST GRIDVIEW EVENT'S)
        protected void PCLists_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Pager) { return; }

            try { e.Row.Cells[1].Visible = false; } catch { }
            try { e.Row.Cells[2].Visible = false; } catch { }
            try { e.Row.Cells[7].Visible = false; } catch { }
            if (Session["USER_MEMBERSHIP_TYPE"] as string != "admin")
            {
                try { e.Row.Cells[9].Visible = false; } catch { }
            }
        }

        protected void PCLists_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PCLists.PageIndex = e.NewPageIndex;
            if (Session["USER_MEMBERSHIP_TYPE"] as string == "admin")
            {
                GETPCOUNCILS("");
            }
            else
            {
                GETPCOUNCILS(Session["USER_ID"] as string);
            }
        }

        protected void PCLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["PC"] = "SELECTED";
            Session["PC_ID"] = PCLists.SelectedRow.Cells[1].Text;
            Session["PC_SERIAL"] = PCLists.SelectedRow.Cells[2].Text;
            Response.Redirect("/manage/councildetail");
        }

        protected void delete_pc_Click(object sender, EventArgs e)
        {
            //int rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            try
            {
                string id = PCLists.Rows[((GridViewRow)((Control)sender).NamingContainer).RowIndex].Cells[1].Text;
                DeleteData(id);
            }
            catch (Exception ex)
            {
                Log.LogCreator(
                    Server.MapPath(Path.Combine("~/Logs", "logs.txt")),
                    $"Log created:{DateTime.Now}, Log page is: Admin Master >> councils.aspx >> DeleteData method, Log:{ex.Message}"
                    );
            }
        }
        #endregion

        #region(DELETED PC LIST EVENT'S)
        protected void PC_DELETED_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Pager) { return; }
            try { e.Row.Cells[1].Visible = false; } catch { }
            try { e.Row.Cells[2].Visible = false; } catch { }
            try { e.Row.Cells[7].Visible = false; } catch { }
        }

        protected void PC_DELETED_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PC_DELETED.PageIndex = e.NewPageIndex;

            //GetDeletedPC
            try
            {
                GetDeletedPC();
            }
            catch (Exception ex)
            {
                Log.LogCreator(
                    Server.MapPath(Path.Combine("~/Logs", "logs.txt")),
                    $"Log created:{DateTime.Now}, Log page is: Admin Master >> councils.aspx >> GetDeletedPC method, Log:{ex.Message}"
                    );
            }
        }

        protected void PC_DELETED_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["PC"]           = "SELECTED";
            Session["PC_ID"]        = PC_DELETED.SelectedRow.Cells[1].Text;
            Session["PC_SERIAL"]    = PC_DELETED.SelectedRow.Cells[2].Text;
            Response.Redirect("/manage/councildetail");
        }

        protected void restore_pc_Click(object sender, EventArgs e)
        {
            //RestoreDeletedPc
            try
            {
                string id = PC_DELETED.Rows[((GridViewRow)((Control)sender).NamingContainer).RowIndex].Cells[1].Text;
                RestoreDeletedPc(id);
            }
            catch (Exception ex)
            {
                Log.LogCreator(
                    Server.MapPath(Path.Combine("~/Logs", "logs.txt")),
                    $"Log created:{DateTime.Now}, Log page is: Admin Master >> councils.aspx >> RestoreDeletedPc method, Log:{ex.Message}"
                    );
            }

            //GetDeletedPC
            try
            {
                GetDeletedPC();
            }
            catch (Exception ex)
            {
                Log.LogCreator(
                    Server.MapPath(Path.Combine("~/Logs", "logs.txt")),
                    $"Log created:{DateTime.Now}, Log page is: Admin Master >> councils.aspx >> GetDeletedPC method, Log:{ex.Message}"
                    );
            }
        }
        #endregion

        protected void new_pc_Click(object sender, EventArgs e)
        {
            Session["PC"]           = null;
            Session["PC_ID"]        = null;
            Response.Redirect("/manage/councildetail");
        }

        private protected void RunCouncils(string MEMBERSHIP_TYPE, string USER_ID)
        {
            if (!IsPostBack)
            {
                switch (MEMBERSHIP_TYPE)
                {
                    case "admin":
                        {
                            //GETPCOUNCILS
                            try
                            {
                                GETPCOUNCILS("");
                            }
                            catch (Exception ex)
                            {
                                Log.LogCreator(
                                    Server.MapPath(Path.Combine("~/Logs", "logs.txt")),
                                    $"Log created:{DateTime.Now}, Log page is: Admin Master >> councils.aspx >> GETPCOUNCILS method, Log:{ex.Message}"
                                    );
                            }

                            //GetDeletedPC
                            try
                            {
                                GetDeletedPC();
                            }
                            catch (Exception ex)
                            {
                                Log.LogCreator(
                                    Server.MapPath(Path.Combine("~/Logs", "logs.txt")),
                                    $"Log created:{DateTime.Now}, Log page is: Admin Master >> councils.aspx >> GetDeletedPC method, Log:{ex.Message}"
                                    );
                            }

                            break;
                        }
                    default:
                        {
                            new_pc.Visible = false;
                            new_pc.Enabled = false;

                            pcDeleted.Visible = false;
                            pcDeleted.Enabled = false;

                            //GETPCOUNCILS
                            try
                            {
                                GETPCOUNCILS(USER_ID);
                            }
                            catch (Exception ex)
                            {
                                Log.LogCreator(
                                    Server.MapPath(Path.Combine("~/Logs", "logs.txt")),
                                    $"Log created:{DateTime.Now}, Log page is: Admin Master >> councils.aspx >> GETPCOUNCILS method, Log:{ex.Message}"
                                    );
                            }

                            break;
                        }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //RunCouncils
            try
            {
                RunCouncils(
                    Convert.ToString(Session["USER_MEMBERSHIP_TYPE"]).ToLower(),
                    Convert.ToString(Session["USER_ID"])
                    );
            }
            catch (Exception ex)
            {
                Log.LogCreator(
                    Server.MapPath(Path.Combine("~/Logs", "logs.txt")),
                    $"Log created:{DateTime.Now}, Log page is: Admin Master >> councils.aspx >> RunCouncils method, Log:{ex.Message}"
                    );
            }
        }
    }
}