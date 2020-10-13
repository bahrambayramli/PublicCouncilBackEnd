using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace PublicCouncilBackEnd.manage
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        #region(SQL FUNCTIONS)

        private void GetPCOUNCIL(string USER_ID)
        {
            SqlDataAdapter getPC = 
                new SqlDataAdapter(
                    new SqlCommand(@"SELECT 
                                                                               ISACTIVE,
                                                                               USER_MEMBERSHIP,
                                                                               USER_MEMBERSHIP_TYPE,
                                                                               USER_LOGIN,
                                                                               USER_PASSWORD,
                                                                               USER_SERIAL,
                                                                               USER_PCDOMAIN,
                                                                               USER_NAME,
                                                                               USER_SURNAME,
                                                                               USER_MOBILE,
                                                                               PC_NAME,
                                                                               PC_TELEPHONE,
                                                                               PC_EMAIL,
                                                                               PC_WEBADDRESS,
                                                                               PC_COUNTRY,
                                                                               PC_CITY,
                                                                               CREATED_DATE,
                                                                               PC_CATEGORY

                                                                               FROM PC_USERS

                                                                               WHERE 
                                                                                USER_ID      = @USER_ID "));

            getPC.SelectCommand.Parameters.Add("@USER_ID", SqlDbType.Int).Value = USER_ID;

            DataTable pc = SQL.SELECT(getPC);

            if (pc.Rows[0]["ISACTIVE"].ToString().ToLower() == "false")
            {
                inputISACTIVE.Items.FindByValue("0").Selected = true;
            }
            else
            {
                inputISACTIVE.Items.FindByValue("1").Selected = true;
            }

        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            
            GetPCOUNCIL(Session["PC_ID"] as string);
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {

        }
    }
}