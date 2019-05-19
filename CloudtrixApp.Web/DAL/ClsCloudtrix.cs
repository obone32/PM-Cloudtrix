using PharmaApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Data.Common;
using System.Web;
using System.Data.Entity.Infrastructure;

namespace PharmaApp.Web.DAL
{
    public class ClsCloudtrix
    {
        #region Local Variable
        ConString CN = new ConString();
        public SqlTransaction Tras { get; set; }
        public SqlConnection Conn { get; set; }

        #endregion

        public int RoleMaster_Add(CloudtrixModel _objModel)
        {
            int blnResult = 0;
            SqlCommand cmd = ClsAppDatabase.GetSPName("RoleMaster_Add");
            ClsAppDatabase.AddOutParameter(cmd, "@pRoleID", SqlDbType.Int);
            ClsAppDatabase.AddInParameter(cmd, "@pRoleName", SqlDbType.VarChar, _objModel.RoleName);
            ClsAppDatabase.AddInParameter(cmd, "@pRoleDesc", SqlDbType.VarChar, _objModel.RoleDesc);
            cmd.Transaction = Tras;
            int Row = cmd.ExecuteNonQuery();
            blnResult = Convert.ToInt16(cmd.Parameters["@pRoleID"].Value);
            cmd.Parameters.Clear();
            cmd.Dispose();
            return blnResult;
        }

        public int RoleMaster_Update(CloudtrixModel _objModel)
        {
            int blnResult = 0;
            SqlCommand cmd = ClsAppDatabase.GetSPName("RoleMaster_Update");
            ClsAppDatabase.AddInParameter(cmd, "@pRoleID", SqlDbType.Int, _objModel.RoleID);
            ClsAppDatabase.AddInParameter(cmd, "@pRoleName", SqlDbType.VarChar, _objModel.RoleName);
            ClsAppDatabase.AddInParameter(cmd, "@pRoleDesc", SqlDbType.VarChar, _objModel.RoleDesc);
            ClsAppDatabase.AddInParameter(cmd, "@pIsDelete", SqlDbType.Bit, _objModel.IsDelete);
            cmd.Transaction = Tras;
            int Row = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cmd.Dispose();
            return blnResult;
        }

        public List<CloudtrixModel> RoleMaster_ListAll(CloudtrixModel _objModel)
        {
            DbCommand cmd = ClsEntityAppDatabase.GetSPName("RoleMaster_ListAll");
            ClsEntityAppDatabase.AddInParameter(cmd, "@pRoleID", SqlDbType.Int, _objModel.RoleID);
            try
            {
                using (var dataReader = cmd.ExecuteReader())
                {
                    return ((IObjectContextAdapter)CN).ObjectContext.Translate<CloudtrixModel>(dataReader as DbDataReader).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
            }
        }

        public List<CloudtrixModel> MenuRights_ListAll(CloudtrixModel _objModel)
        {
            DbCommand cmd = ClsEntityAppDatabase.GetSPName("MenuRights_ListAll");
            ClsEntityAppDatabase.AddInParameter(cmd, "@pMenuRightsID", SqlDbType.Int, _objModel.MenuRightsID);
            ClsEntityAppDatabase.AddInParameter(cmd, "@pMenuID", SqlDbType.Int, _objModel.MenuID);
            ClsEntityAppDatabase.AddInParameter(cmd, "@pRoleID", SqlDbType.Int, _objModel.RoleID);
            try
            {
                using (var dataReader = cmd.ExecuteReader())
                {
                    return ((IObjectContextAdapter)CN).ObjectContext.Translate<CloudtrixModel>(dataReader as DbDataReader).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
            }
        }

        public List<CloudtrixModel> MenuRoleRights_ListAll(CloudtrixModel _objModel)
        {
            DbCommand cmd = ClsEntityAppDatabase.GetSPName("MenuRoleRights_ListAll");
            ClsEntityAppDatabase.AddInParameter(cmd, "@pRoleIDs", SqlDbType.VarChar, _objModel.RoleIDs);
            ClsEntityAppDatabase.AddInParameter(cmd, "@pMenuID", SqlDbType.Int, _objModel.MenuID);
            ClsEntityAppDatabase.AddInParameter(cmd, "@pParentMenuID", SqlDbType.Int, _objModel.ParentMenuID);
            try
            {
                using (var dataReader = cmd.ExecuteReader())
                {
                    return ((IObjectContextAdapter)CN).ObjectContext.Translate<CloudtrixModel>(dataReader as DbDataReader).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
            }
        }

        public int MenuRights_Add(CloudtrixModel _objModel)
        {
            int blnResult = 0;
            SqlCommand cmd = ClsAppDatabase.GetSPName("MenuRights_Add");
            ClsAppDatabase.AddOutParameter(cmd, "@pMenuRightsID", SqlDbType.Int);
            ClsAppDatabase.AddInParameter(cmd, "@pMenuID", SqlDbType.Int, _objModel.MenuID);
            ClsAppDatabase.AddInParameter(cmd, "@pRoleID", SqlDbType.Int, _objModel.RoleID);
            ClsAppDatabase.AddInParameter(cmd, "@pIsAdd", SqlDbType.Bit, _objModel.IsAdd);
            ClsAppDatabase.AddInParameter(cmd, "@pIsUpdate", SqlDbType.Bit, _objModel.IsUpdate);
            ClsAppDatabase.AddInParameter(cmd, "@pIsDelete", SqlDbType.Bit, _objModel.IsDelete);
            ClsAppDatabase.AddInParameter(cmd, "@pIsView", SqlDbType.Bit, _objModel.IsView);
            cmd.Transaction = Tras;
            int Row = cmd.ExecuteNonQuery();
            blnResult = Convert.ToInt16(cmd.Parameters["@pMenuRightsID"].Value);
            cmd.Parameters.Clear();
            cmd.Dispose();
            return blnResult;
        }

        public int MenuRights_Update(CloudtrixModel _objModel)
        {
            int blnResult = 0;
            SqlCommand cmd = ClsAppDatabase.GetSPName("MenuRights_Update");
            ClsAppDatabase.AddInParameter(cmd, "@pMenuRightsID", SqlDbType.Int, _objModel.MenuRightsID);
            ClsAppDatabase.AddInParameter(cmd, "@pMenuID", SqlDbType.Int, _objModel.MenuID);
            ClsAppDatabase.AddInParameter(cmd, "@pRoleID", SqlDbType.Int, _objModel.RoleID);
            ClsAppDatabase.AddInParameter(cmd, "@pIsAdd", SqlDbType.Bit, _objModel.IsAdd);
            ClsAppDatabase.AddInParameter(cmd, "@pIsUpdate", SqlDbType.Bit, _objModel.IsUpdate);
            ClsAppDatabase.AddInParameter(cmd, "@pIsDelete", SqlDbType.Bit, _objModel.IsDelete);
            ClsAppDatabase.AddInParameter(cmd, "@pIsView", SqlDbType.Bit, _objModel.IsView);
            cmd.Transaction = Tras;
            int Row = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cmd.Dispose();
            return blnResult;
        }

        public List<CloudtrixModel> Employee_Verify(CloudtrixModel _objModel)
        {
            DbCommand cmd = ClsEntityAppDatabase.GetSPName("Employee_Verify");
            ClsEntityAppDatabase.AddInParameter(cmd, "@pEmployeeEmail", SqlDbType.VarChar, _objModel.EmployeeEmail);
            ClsEntityAppDatabase.AddInParameter(cmd, "@pPassword", SqlDbType.VarChar, _objModel.Password);
            try
            {
                using (var dataReader = cmd.ExecuteReader())
                {
                    return ((IObjectContextAdapter)CN).ObjectContext.Translate<CloudtrixModel>(dataReader as DbDataReader).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
            }
        }

        public int LoginHistory_Add(CloudtrixModel _objModel)
        {
            int blnResult = 0;
            SqlCommand cmd = ClsAppDatabase.GetSPName("LoginHistory_Add");
            ClsAppDatabase.AddOutParameter(cmd, "@pLoginHistoryID", SqlDbType.Int);
            ClsAppDatabase.AddInParameter(cmd, "@pEmailID", SqlDbType.VarChar, _objModel.EmailID);
            ClsAppDatabase.AddInParameter(cmd, "@pPassword", SqlDbType.VarChar, _objModel.Password);
            ClsAppDatabase.AddInParameter(cmd, "@pLoginIP", SqlDbType.VarChar, _objModel.LoginIP);
            cmd.Transaction = Tras;
            int Row = cmd.ExecuteNonQuery();
            blnResult = Convert.ToInt16(cmd.Parameters["@pLoginHistoryID"].Value);
            cmd.Parameters.Clear();
            cmd.Dispose();
            return blnResult;
        }

        public int LoginHistory_Update(CloudtrixModel _objModel)
        {
            int blnResult = 0;
            SqlCommand cmd = ClsAppDatabase.GetSPName("LoginHistory_Update");
            ClsAppDatabase.AddInParameter(cmd, "@pLoginHistoryID", SqlDbType.Int,_objModel.LoginHistoryID);
            ClsAppDatabase.AddInParameter(cmd, "@pEmpID", SqlDbType.Int, _objModel.EmpID);
            ClsAppDatabase.AddInParameter(cmd, "@pIsSuccess", SqlDbType.Bit, _objModel.IsSuccess);
            ClsAppDatabase.AddInParameter(cmd, "@pMessage", SqlDbType.VarChar, _objModel.Message);
            cmd.Transaction = Tras;
            int Row = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cmd.Dispose();
            return blnResult;
        }

        public List<CloudtrixModel> StateMaster_ListAll(CloudtrixModel _objModel)
        {
            if(_objModel.StateName == null) { _objModel.StateName = ""; }
            DbCommand cmd = ClsEntityAppDatabase.GetSPName("StateMaster_ListAll");
            ClsEntityAppDatabase.AddInParameter(cmd, "@pStateID", SqlDbType.Int, _objModel.StateID);
            ClsEntityAppDatabase.AddInParameter(cmd, "@pStateName", SqlDbType.VarChar, _objModel.StateName);
            try
            {
                using (var dataReader = cmd.ExecuteReader())
                {
                    return ((IObjectContextAdapter)CN).ObjectContext.Translate<CloudtrixModel>(dataReader as DbDataReader).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
            }
        }
        
    }
}