using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace PublicCouncilBackEnd
{
    public class SQLFUNC
    {
        public static void GetSectionsData(string lang, string category, string operation, ListView LS_AZ, ListView LS_EN)
        {
            SqlDataAdapter getdata = new SqlDataAdapter();
            switch (lang)
            {
                case "az":
                    {
                        LS_EN.DataSourceID = null;
                        LS_EN.DataBind();

                        getdata = new SqlDataAdapter(new SqlCommand(@"SELECT  DATA_ID, NEWS_SEOAZ, NEWS_SITECATEGORYAZ , NEWS_AZ_TITLE, NEWS_IMG, NEWS_DATE ," + operation + @" FROM DATA_NEWS 

                                                                                                                WHERE
                                                                                                                      ISACTIVE            = @ISACTIVE                AND 
                                                                                                                      ISDELETE            = @ISDELETE                AND 
                                                                                                                      NEWS_AZ_VIEW        = @NEWS_AZ_VIEW            AND
                                                                                                                      NEWS_CATEGORY       = @NEWS_CATEGORY          
                                                                                                                     

                                                                                                                ORDER BY NEWS_DATE DESC  "));

                        getdata.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                        getdata.SelectCommand.Parameters.Add("@NEWS_AZ_VIEW", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@NEWS_CATEGORY", SqlDbType.NVarChar).Value = category;


                        LS_AZ.DataSource = SQL.SELECT(getdata);
                        LS_AZ.DataBind();

                        getdata = null;
                        break;
                    }
                case "en":
                    {
                        LS_EN.DataSourceID = null;
                        LS_EN.DataBind();

                        getdata = new SqlDataAdapter(new SqlCommand(@"SELECT DATA_ID,  NEWS_SEOEN, NEWS_SITECATEGORYEN, NEWS_EN_TITLE, NEWS_IMG, NEWS_DATE , " + operation + @" FROM DATA_NEWS 

                                                                                                                WHERE
                                                                                                                      ISACTIVE            = @ISACTIVE                AND 
                                                                                                                      ISDELETE            = @ISDELETE                AND 
                                                                                                                      NEWS_EN_VIEW        = @NEWS_EN_VIEW            AND
                                                                                                                      NEWS_CATEGORY       = @NEWS_CATEGORY           

                                                                                                                ORDER BY NEWS_DATE DESC  "));

                        getdata.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                        getdata.SelectCommand.Parameters.Add("@NEWS_EN_VIEW", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@NEWS_CATEGORY", SqlDbType.NVarChar).Value = category;

                        LS_AZ.DataSource = SQL.SELECT(getdata);
                        LS_AZ.DataBind();

                        getdata = null;
                        break;
                    }

                default:
                    {
                        LS_EN.DataSourceID = null;
                        LS_EN.DataBind();

                        getdata = new SqlDataAdapter(new SqlCommand(@"SELECT DATA_ID,  NEWS_SEOAZ, NEWS_SITECATEGORYAZ, NEWS_AZ_TITLE, NEWS_IMG, NEWS_DATE , " + operation + @" FROM DATA_NEWS 

                                                                                                                WHERE
                                                                                                                      ISACTIVE            = @ISACTIVE                AND 
                                                                                                                      ISDELETE            = @ISDELETE                AND 
                                                                                                                      NEWS_AZ_VIEW        = @NEWS_AZ_VIEW            AND
                                                                                                                      NEWS_CATEGORY       = @NEWS_CATEGORY           

                                                                                                                ORDER BY NEWS_DATE DESC  "));

                        getdata.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                        getdata.SelectCommand.Parameters.Add("@NEWS_AZ_VIEW", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@NEWS_CATEGORY", SqlDbType.NVarChar).Value = category;

                        LS_AZ.DataSource = SQL.SELECT(getdata);
                        LS_AZ.DataBind();

                        getdata = null;
                        break;
                    }
            }
        }
        public static void GetSectionsData(string lang, string category, string subcategory, string operation, ListView LS_AZ, ListView LS_EN) 
        {
            SqlDataAdapter getdata = new SqlDataAdapter();
            switch (lang)
            {
                case "az":
                    {
                        LS_EN.DataSourceID = null;
                        LS_EN.DataBind();
                        if (string.IsNullOrEmpty(subcategory))
                        {
                            getdata = new SqlDataAdapter(new SqlCommand(@"SELECT  DATA_ID,  NEWS_SEOAZ, NEWS_SITECATEGORYAZ, NEWS_AZ_TITLE, NEWS_IMG, NEWS_DATE, " + operation + @" FROM DATA_NEWS 

                                                                                                                WHERE
                                                                                                                      ISACTIVE            = @ISACTIVE                AND 
                                                                                                                      ISDELETE            = @ISDELETE                AND 
                                                                                                                      NEWS_AZ_VIEW        = @NEWS_AZ_VIEW            AND
                                                                                                                      NEWS_CATEGORY       = @NEWS_CATEGORY          
                                                                                                                    

                                                                                                                     ORDER BY NEWS_DATE DESC  "));
                        }
                        else
                        {
                            getdata = new SqlDataAdapter(new SqlCommand(@"SELECT  DATA_ID, NEWS_SEOAZ, NEWS_SITECATEGORYAZ, NEWS_AZ_TITLE, NEWS_IMG, NEWS_DATE, " + operation + @" FROM DATA_NEWS 

                                                                                                                WHERE
                                                                                                                      ISACTIVE            = @ISACTIVE                AND 
                                                                                                                      ISDELETE            = @ISDELETE                AND 
                                                                                                                      NEWS_AZ_VIEW        = @NEWS_AZ_VIEW            AND
                                                                                                                      NEWS_CATEGORY       = @NEWS_CATEGORY           AND
                                                                                                                      NEWS_SUBCATEGORY    = @NEWS_SUBCATEGORY

                                                                                                                ORDER BY NEWS_DATE DESC  "));
                            getdata.SelectCommand.Parameters.Add("@NEWS_SUBCATEGORY", SqlDbType.NVarChar).Value = subcategory;
                        }


                        getdata.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                        getdata.SelectCommand.Parameters.Add("@NEWS_AZ_VIEW", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@NEWS_CATEGORY", SqlDbType.NVarChar).Value = category;
                      

                        LS_AZ.DataSource = SQL.SELECT(getdata);
                        LS_AZ.DataBind();

                        getdata = null;
                        break;
                    }
                case "en":
                    {
                        LS_EN.DataSourceID = null;
                        LS_EN.DataBind();

                        if (string.IsNullOrEmpty(subcategory))
                        {
                            getdata = new SqlDataAdapter(new SqlCommand(@"SELECT  DATA_ID,  NEWS_SEOEN, NEWS_SITECATEGORYEN, NEWS_E_TITLE, NEWS_IMG, NEWS_DATE, " + operation + @" FROM DATA_NEWS 

                                                                                                                WHERE
                                                                                                                      ISACTIVE            = @ISACTIVE                AND 
                                                                                                                      ISDELETE            = @ISDELETE                AND 
                                                                                                                      NEWS_EN_VIEW        = @NEWS_EN_VIEW            AND
                                                                                                                      NEWS_CATEGORY       = @NEWS_CATEGORY          
                                                                                                                    

                                                                                                                     ORDER BY NEWS_DATE DESC  "));
                        }
                        else
                        {
                            getdata = new SqlDataAdapter(new SqlCommand(@"SELECT  DATA_ID, NEWS_SEOEN, NEWS_SITECATEGORYEN, NEWS_EN_TITLE, NEWS_IMG, NEWS_DATE, " + operation + @" FROM DATA_NEWS 

                                                                                                                WHERE
                                                                                                                      ISACTIVE            = @ISACTIVE                AND 
                                                                                                                      ISDELETE            = @ISDELETE                AND 
                                                                                                                      NEWS_EN_VIEW        = @NEWS_EN_VIEW            AND
                                                                                                                      NEWS_CATEGORY       = @NEWS_CATEGORY           AND
                                                                                                                      NEWS_SUBCATEGORY    = @NEWS_SUBCATEGORY

                                                                                                                ORDER BY NEWS_DATE DESC  "));
                            getdata.SelectCommand.Parameters.Add("@NEWS_SUBCATEGORY", SqlDbType.NVarChar).Value = subcategory;
                        }

                        getdata.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                        getdata.SelectCommand.Parameters.Add("@NEWS_EN_VIEW", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@NEWS_CATEGORY", SqlDbType.NVarChar).Value = category;
                        getdata.SelectCommand.Parameters.Add("@NEWS_SUBCATEGORY", SqlDbType.NVarChar).Value = subcategory;

                        LS_AZ.DataSource = SQL.SELECT(getdata);
                        LS_AZ.DataBind();

                        getdata = null;
                        break;
                    }

                default:
                    {
                        {
                            LS_EN.DataSourceID = null;
                            LS_EN.DataBind();
                            if (string.IsNullOrEmpty(subcategory))
                            {
                                getdata = new SqlDataAdapter(new SqlCommand(@"SELECT  DATA_ID, NEWS_SEOAZ, NEWS_SITECATEGORYAZ , NEWS_AZ_TITLE, NEWS_IMG, NEWS_DATE, " + operation + @" FROM DATA_NEWS 

                                                                                                                WHERE
                                                                                                                      ISACTIVE            = @ISACTIVE                AND 
                                                                                                                      ISDELETE            = @ISDELETE                AND 
                                                                                                                      NEWS_AZ_VIEW        = @NEWS_AZ_VIEW            AND
                                                                                                                      NEWS_CATEGORY       = @NEWS_CATEGORY          
                                                                                                                    

                                                                                                                     ORDER BY NEWS_DATE DESC  "));
                            }
                            else
                            {
                                getdata = new SqlDataAdapter(new SqlCommand(@"SELECT  DATA_ID, NEWS_SEOAZ, NEWS_SITECATEGORYAZ , NEWS_AZ_TITLE, NEWS_IMG, NEWS_DATE, " + operation + @" FROM DATA_NEWS 

                                                                                                                WHERE
                                                                                                                      ISACTIVE            = @ISACTIVE                AND 
                                                                                                                      ISDELETE            = @ISDELETE                AND 
                                                                                                                      NEWS_AZ_VIEW        = @NEWS_AZ_VIEW            AND
                                                                                                                      NEWS_CATEGORY       = @NEWS_CATEGORY           AND
                                                                                                                      NEWS_SUBCATEGORY    = @NEWS_SUBCATEGORY

                                                                                                                ORDER BY NEWS_DATE DESC  "));
                                getdata.SelectCommand.Parameters.Add("@NEWS_SUBCATEGORY", SqlDbType.NVarChar).Value = subcategory;
                            }


                            getdata.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                            getdata.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                            getdata.SelectCommand.Parameters.Add("@NEWS_AZ_VIEW", SqlDbType.Bit).Value = true;
                            getdata.SelectCommand.Parameters.Add("@NEWS_CATEGORY", SqlDbType.NVarChar).Value = category;


                            LS_AZ.DataSource = SQL.SELECT(getdata);
                            LS_AZ.DataBind();

                            getdata = null;
                            break;
                        }
                    }
            }
        }
        public static void GetSectionsData(string lang, string category, string subcategory, string operation, string count, ListView LS_AZ, ListView LS_EN)
        {
            SqlDataAdapter getdata = new SqlDataAdapter();
            switch (lang)
            {
                case "az":
                    {
                        LS_EN.DataSourceID = null;
                        LS_EN.DataBind();
                        if (string.IsNullOrEmpty(subcategory))
                        {
                            getdata = new SqlDataAdapter(new SqlCommand(@"SELECT TOP " + count+ @"  DATA_ID,  NEWS_SEOAZ, NEWS_SITECATEGORYAZ, NEWS_AZ_TITLE, NEWS_IMG, NEWS_DATE, " + operation + @" FROM DATA_NEWS 

                                                                                                                WHERE
                                                                                                                      ISACTIVE            = @ISACTIVE                AND 
                                                                                                                      ISDELETE            = @ISDELETE                AND 
                                                                                                                      NEWS_AZ_VIEW        = @NEWS_AZ_VIEW            AND
                                                                                                                      NEWS_CATEGORY       = @NEWS_CATEGORY          
                                                                                                                    

                                                                                                                     ORDER BY NEWS_DATE DESC  "));
                        }
                        else
                        {
                            getdata = new SqlDataAdapter(new SqlCommand(@"SELECT TOP " + count + @" DATA_ID, NEWS_SEOAZ, NEWS_SITECATEGORYAZ, NEWS_AZ_TITLE, NEWS_IMG, NEWS_DATE, " + operation + @" FROM DATA_NEWS 

                                                                                                                WHERE
                                                                                                                      ISACTIVE            = @ISACTIVE                AND 
                                                                                                                      ISDELETE            = @ISDELETE                AND 
                                                                                                                      NEWS_AZ_VIEW        = @NEWS_AZ_VIEW            AND
                                                                                                                      NEWS_CATEGORY       = @NEWS_CATEGORY           AND
                                                                                                                      NEWS_SUBCATEGORY    = @NEWS_SUBCATEGORY

                                                                                                                ORDER BY NEWS_DATE DESC  "));
                            getdata.SelectCommand.Parameters.Add("@NEWS_SUBCATEGORY", SqlDbType.NVarChar).Value = subcategory;
                        }


                        getdata.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                        getdata.SelectCommand.Parameters.Add("@NEWS_AZ_VIEW", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@NEWS_CATEGORY", SqlDbType.NVarChar).Value = category;


                        LS_AZ.DataSource = SQL.SELECT(getdata);
                        LS_AZ.DataBind();

                        getdata = null;
                        break;
                    }
                case "en":
                    {
                        LS_EN.DataSourceID = null;
                        LS_EN.DataBind();

                        if (string.IsNullOrEmpty(subcategory))
                        {
                            getdata = new SqlDataAdapter(new SqlCommand(@"SELECT TOP " + count + @" DATA_ID,  NEWS_SEOEN, NEWS_SITECATEGORYEN, NEWS_E_TITLE, NEWS_IMG, NEWS_DATE, " + operation + @" FROM DATA_NEWS 

                                                                                                                WHERE
                                                                                                                      ISACTIVE            = @ISACTIVE                AND 
                                                                                                                      ISDELETE            = @ISDELETE                AND 
                                                                                                                      NEWS_EN_VIEW        = @NEWS_EN_VIEW            AND
                                                                                                                      NEWS_CATEGORY       = @NEWS_CATEGORY          
                                                                                                                    

                                                                                                                     ORDER BY NEWS_DATE DESC  "));
                        }
                        else
                        {
                            getdata = new SqlDataAdapter(new SqlCommand(@"SELECT TOP " + count + @" DATA_ID, NEWS_SEOEN, NEWS_SITECATEGORYEN, NEWS_EN_TITLE, NEWS_IMG, NEWS_DATE, " + operation + @" FROM DATA_NEWS 

                                                                                                                WHERE
                                                                                                                      ISACTIVE            = @ISACTIVE                AND 
                                                                                                                      ISDELETE            = @ISDELETE                AND 
                                                                                                                      NEWS_EN_VIEW        = @NEWS_EN_VIEW            AND
                                                                                                                      NEWS_CATEGORY       = @NEWS_CATEGORY           AND
                                                                                                                      NEWS_SUBCATEGORY    = @NEWS_SUBCATEGORY

                                                                                                                ORDER BY NEWS_DATE DESC  "));
                            getdata.SelectCommand.Parameters.Add("@NEWS_SUBCATEGORY", SqlDbType.NVarChar).Value = subcategory;
                        }

                        getdata.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                        getdata.SelectCommand.Parameters.Add("@NEWS_EN_VIEW", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@NEWS_CATEGORY", SqlDbType.NVarChar).Value = category;
                        getdata.SelectCommand.Parameters.Add("@NEWS_SUBCATEGORY", SqlDbType.NVarChar).Value = subcategory;

                        LS_AZ.DataSource = SQL.SELECT(getdata);
                        LS_AZ.DataBind();

                        getdata = null;
                        break;
                    }

                default:
                    {
                        {
                            LS_EN.DataSourceID = null;
                            LS_EN.DataBind();
                            if (string.IsNullOrEmpty(subcategory))
                            {
                                getdata = new SqlDataAdapter(new SqlCommand(@"SELECT TOP " + count + @" DATA_ID, NEWS_SEOAZ, NEWS_SITECATEGORYAZ , NEWS_AZ_TITLE, NEWS_IMG, NEWS_DATE, " + operation + @" FROM DATA_NEWS 

                                                                                                                WHERE
                                                                                                                      ISACTIVE            = @ISACTIVE                AND 
                                                                                                                      ISDELETE            = @ISDELETE                AND 
                                                                                                                      NEWS_AZ_VIEW        = @NEWS_AZ_VIEW            AND
                                                                                                                      NEWS_CATEGORY       = @NEWS_CATEGORY          
                                                                                                                    

                                                                                                                     ORDER BY NEWS_DATE DESC  "));
                            }
                            else
                            {
                                getdata = new SqlDataAdapter(new SqlCommand(@"SELECT TOP " + count + @" DATA_ID, NEWS_SEOAZ, NEWS_SITECATEGORYAZ , NEWS_AZ_TITLE, NEWS_IMG, NEWS_DATE, " + operation + @" FROM DATA_NEWS 

                                                                                                                WHERE
                                                                                                                      ISACTIVE            = @ISACTIVE                AND 
                                                                                                                      ISDELETE            = @ISDELETE                AND 
                                                                                                                      NEWS_AZ_VIEW        = @NEWS_AZ_VIEW            AND
                                                                                                                      NEWS_CATEGORY       = @NEWS_CATEGORY           AND
                                                                                                                      NEWS_SUBCATEGORY    = @NEWS_SUBCATEGORY

                                                                                                                ORDER BY NEWS_DATE DESC  "));
                                getdata.SelectCommand.Parameters.Add("@NEWS_SUBCATEGORY", SqlDbType.NVarChar).Value = subcategory;
                            }


                            getdata.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                            getdata.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                            getdata.SelectCommand.Parameters.Add("@NEWS_AZ_VIEW", SqlDbType.Bit).Value = true;
                            getdata.SelectCommand.Parameters.Add("@NEWS_CATEGORY", SqlDbType.NVarChar).Value = category;


                            LS_AZ.DataSource = SQL.SELECT(getdata);
                            LS_AZ.DataBind();

                            getdata = null;
                            break;
                        }
                    }
            }
        }
    }
}