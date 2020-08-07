//===============================================================================
// This file is based on the Microsoft Data Access Application Block for .NET
// For more information please go to 
// http://msdn.microsoft.com/library/en-us/dnbda/html/daab-rm.asp
//===============================================================================

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Reflection;


    /// <summary>
    /// The SqlHelper class is intended to encapsulate high performance, 
    /// scalable best practices for common uses of SqlClient.
    /// </summary>
    public abstract class SQL
    {

        public static readonly string ConnectionStringProfile = ConfigurationManager.ConnectionStrings["Database"].ToString();

        // Hashtable to store cached parameters
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        /// Execute a SqlCommand (that returns no resultset) against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a SqlConnection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
                return val;
            }
        }

        public static int ExecuteSql(string connectionString, string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                            connection.Dispose();
                        }
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                            connection.Dispose();
                        }
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// 执行插入更新语句并返回ID
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="SQLString"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public static int ExecuteReturnID(string connectionString, string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = Convert.ToInt32(cmd.ExecuteScalar());
                        cmd.Parameters.Clear();
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                            connection.Dispose();
                        }
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                            connection.Dispose();
                        }
                        throw e;
                    }
                }
            }
        }

        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {


                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }

            //if (conn.State == ConnectionState.Open)
            //{
            //    conn.Close();
            //    conn.Dispose();
            //}
        }

        /// <summary>
        /// Execute a SqlCommand (that returns no resultset) against an existing database connection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="conn">an existing database connection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }
            return val;
        }

        /// <summary>
        /// Execute a SqlCommand (that returns no resultset) using an existing SQL Transaction 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="trans">an existing sql transaction</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            if (trans.Connection.State == ConnectionState.Open)
            {
                trans.Connection.Close();
                trans.Connection.Dispose();
            }
            return val;
        }

        /// <summary>
        /// Execute a SqlCommand that returns a resultset against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a SqlConnection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>A SqlDataReader containing the results</returns>
        public static SqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);

            // we use a try/catch here because if the method throws an exception we want to 
            // close the connection throw code, because no datareader will exist, hence the 
            // commandBehaviour.CloseConnection will not work
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
                throw;
            }
        }

        /// <summary>
        /// Execute a SqlCommand that returns the first column of the first record against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a SqlConnection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>
        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
                return val;
            }
        }

        /// <summary>
        /// Execute a SqlCommand that returns the first column of the first record against an existing database connection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="conn">an existing database connection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>
        public static object ExecuteScalar(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }
            return val;
        }

        /// <summary>
        /// add parameter array to the cache
        /// </summary>
        /// <param name="cacheKey">Key to the parameter cache</param>
        /// <param name="cmdParms">an array of SqlParamters to be cached</param>
        public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }

        /// <summary>
        /// Retrieve cached parameters
        /// </summary>
        /// <param name="cacheKey">key used to lookup parameters</param>
        /// <returns>Cached SqlParamters array</returns>
        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];

            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }

        /// <summary>
        /// Prepare a command for execution
        /// </summary>
        /// <param name="cmd">SqlCommand object</param>
        /// <param name="conn">SqlConnection object</param>
        /// <param name="trans">SqlTransaction object</param>
        /// <param name="cmdType">Cmd type e.g. stored procedure or text</param>
        /// <param name="cmdText">Command text, e.g. Select * from Products</param>
        /// <param name="cmdParms">SqlParameters to use in the command</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
               conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
            //if (conn.State == ConnectionState.Open)
            //{
            //    conn.Close();
            //    conn.Dispose();
            //}
        }

        /// <summary>
        /// 对在连接字符串中指定的数据库执行一条可以返回一个表的SQL语句
        /// 传给SQL语句的parameters为可选项
        /// </summary>
        /// <remarks>
        /// 例如:  
        ///  DataTable dt = ExecuteDataTable(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">一条正确的用于连接数据库的连接字符串</param>
        /// <param name="cmdType">指定执行的SQL的类型(存储过程, 文本, 等等.)</param>
        /// <param name="cmdText">一个存储过程名称或一条SQL语句</param>
        /// <param name="commandParameters">一组用于执行命令的参数</param>
        /// <returns>一个包含结果的DataTable</returns>
        public static DataTable ExecuteDataTable(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
                {
                    DataTable val = new DataTable();
                    sqlDataAdapter.Fill(val);
                    cmd.Parameters.Clear();

                    if (val == null || val.Columns.Count == 0)
                    {
                        val = ExecuteDataTable(connection, cmdType, cmdText, commandParameters);
                    }
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                    return val;
                }
            }
        }

        /// 对一个现存的SqlConnection对象执行一条可以返回一个表的SQL语句
        /// 传给SQL语句的parameters为可选项
        /// </summary>
        /// <remarks>
        /// 例如:  
        ///  DataTable dt = ExecuteDataTable(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">一个现存的数据库连接</param>
        /// <param name="cmdType">指定执行的SQL的类型(存储过程, 文本, 等等.)</param>
        /// <param name="cmdText">一个存储过程名称或一条SQL语句</param>
        /// <param name="commandParameters">一组用于执行命令的参数</param>
        /// <returns>一个包含结果的DataTable</returns>
        public static DataTable ExecuteDataTable(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
            {
                DataTable val = new DataTable();
                sqlDataAdapter.Fill(val);
                cmd.Parameters.Clear();

                if (val == null || val.Columns.Count == 0)
                {
                    val = ExecuteDataTable(connection, cmdType, cmdText, commandParameters);       
                }
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
                return val;
            }
        }


        /// <summary>
        /// 分页形式得到泛型结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="QueryStr"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageCurrent"></param>
        /// <param name="FdShow"></param>
        /// <param name="FdOrder"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public static List<T> getList<T>(string QueryStr, int PageSize, int PageCurrent, string FdShow, string FdOrder, ref int rowCount)
        {
            DataTable dt = getDataList(QueryStr, PageSize, PageCurrent, FdShow, FdOrder, ref rowCount);
            List<T> lst = new List<T>();
            foreach (DataRow dr in dt.Rows)
            {
                T model = (T)Activator.CreateInstance(typeof(T));
                foreach (PropertyInfo p in typeof(T).GetProperties())
                {
                    object value = dr[p.Name] == DBNull.Value ? null : dr[p.Name];
                    p.SetValue(model, value, null);
                }
                lst.Add(model);
            }
            return lst;

        }

        public static List<T> GetList<T>(string sql)
        {
            List<T> lst = new List<T>();
            DataTable dt = new DataTable();
            dt = SQL.getDt(sql);
            foreach (DataRow dr in dt.Rows)
            {
                T model = (T)Activator.CreateInstance(typeof(T));
                foreach (PropertyInfo p in typeof(T).GetProperties())
                {
                    if (dr.Table.Columns.Contains(p.Name))
                    {
                        object value = dr[p.Name] == DBNull.Value ? null : dr[p.Name];
                        p.SetValue(model, value, null);
                    }
                }
                lst.Add(model);
            }
            return lst;
        }

        public static DataTable getDt(string sql)
        {
            return ExecuteDataTable(SQL.ConnectionStringProfile, CommandType.Text, sql);
        }

        public static void Exesql(string sql)
        {
            ExecuteNonQuery(SQL.ConnectionStringProfile, CommandType.Text, sql);
        }
         

        public static int ExecuteSql(string sql)
        {
            return SQL.ExecuteNonQuery(SQL.ConnectionStringProfile, CommandType.Text, sql, null);
        }

        public static int ExecuteSql(string sql, SqlParameter[] parameters)
        {
            return SQL.ExecuteNonQuery(SQL.ConnectionStringProfile, CommandType.Text, sql, parameters);
        }

        public static object GetSingle(string sql, SqlParameter[] parameters)
        {
            return SQL.ExecuteScalar(SQL.ConnectionStringProfile, CommandType.Text, sql, parameters);
        }
        
        
        #region 返回DataSet
        /// <summary>
        /// 对在连接字符串中指定的数据库执行一条可以返回多个表的SQL语句
        /// 传给SQL语句的parameters为可选项
        /// </summary>
        /// <remarks>
        /// 例如:  
        ///  DataSet ds = ExecuteDataSet(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">一条正确的用于连接数据库的连接字符串</param>
        /// <param name="cmdType">指定执行的SQL的类型(存储过程, 文本, 等等.)</param>
        /// <param name="cmdText">一个存储过程名称或一条SQL语句</param>
        /// <param name="commandParameters">一组用于执行命令的参数</param>
        /// <returns>一个包含结果的DataSet</returns>
        public static DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
                {
                    DataSet val = new DataSet();
                    sqlDataAdapter.Fill(val);
                    cmd.Parameters.Clear();
                    if (connection.State == ConnectionState.Open)
                    { 
                        connection.Close();
                        connection.Dispose();
                    }
                    return val;
                }
            }
        }

        /// <summary>
        /// 对一个现存的SqlConnection对象执行一条可以返回多个表的SQL语句
        /// 传给SQL语句的parameters为可选项
        /// </summary>
        /// <remarks>
        /// 例如:  
        ///  DataSet ds = ExecuteDataSet(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">一个现存的数据库连接</param>
        /// <param name="cmdType">指定执行的SQL的类型(存储过程, 文本, 等等.)</param>
        /// <param name="cmdText">一个存储过程名称或一条SQL语句</param>
        /// <param name="commandParameters">一组用于执行命令的参数</param>
        /// <returns>一个包含结果的DataSet</returns>
        public static DataSet ExecuteDataSet(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
            {
                DataSet val = new DataSet();
                sqlDataAdapter.Fill(val);
                cmd.Parameters.Clear();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
                return val;
            }
        }


        /// <summary>
        /// connectionString,index是索引，用作分页时的pageindex,以填充DataSet有限行
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText,int pagesize,int index, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
                {
                    DataSet val = new DataSet();
                    sqlDataAdapter.Fill(val,index*(pagesize),pagesize,"table");
                    cmd.Parameters.Clear();
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                    return val;
                }
            }
        }

        /// <summary>
        /// 得到DataTable
        /// </summary>
        /// <param name="QueryStr">表，视图，查询语句</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="PageCurrent">当前页</param>
        /// <param name="FdShow">显示的字段列表</param>
        /// <param name="FdOrder">排序的字段列表</param>
        /// <param name="Rows">行数</param>
        /// <returns>DataTable</returns>
        public static DataTable getDataList(string QueryStr, int PageSize, int PageCurrent, string FdShow, string FdOrder, ref int rowCount)
        {
          

            SqlParameter[] par ={
                new SqlParameter("@QueryStr",SqlDbType.NVarChar,4000),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@PageCurrent",SqlDbType.Int),
                new SqlParameter("@FdShow",SqlDbType.NVarChar,100),
                new SqlParameter("@FdOrder",SqlDbType.NVarChar,100),
                new SqlParameter("@Rows",SqlDbType.Int)
            };

            par[0].Value = QueryStr;
            par[1].Value = PageSize;
            par[2].Value = PageCurrent;
            par[3].Value = FdShow;
            par[4].Value = FdOrder;
            //par[5].Value = rowCount;


            DataSet ds = SQL.ExecuteDataSet(SQL.ConnectionStringProfile, CommandType.StoredProcedure, "P_PageView", par);

            if (rowCount > 0)
                par[5].Value = rowCount;
            else
                par[5].Value = DBNull.Value;
            if (rowCount <= 0)
            {
                rowCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            }
            return ds.Tables[0];


        }




        /// <summary>
        /// 得到DataTable
        /// </summary>
        /// <param name="connectionString">传入连接语句</param>
        /// <param name="QueryStr">表，视图，查询语句</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="PageCurrent">当前页</param>
        /// <param name="FdShow">显示的字段列表</param>
        /// <param name="FdOrder">排序的字段列表</param>
        /// <param name="Rows">行数</param>
        /// <returns>DataTable</returns>
        public static DataTable getDataList(string connectionString, string QueryStr, int PageSize, int PageCurrent, string FdShow, string FdOrder, ref int rowCount)
        {

            SqlParameter[] par ={
                new SqlParameter("@QueryStr",SqlDbType.NVarChar,4000),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@PageCurrent",SqlDbType.Int),
                new SqlParameter("@FdShow",SqlDbType.NVarChar,100),
                new SqlParameter("@FdOrder",SqlDbType.NVarChar,100),
                new SqlParameter("@Rows",SqlDbType.Int)
            };

            par[0].Value = QueryStr;
            par[1].Value = PageSize;
            par[2].Value = PageCurrent;
            par[3].Value = FdShow;
            par[4].Value = FdOrder;
            //par[5].Value = rowCount;


            DataSet ds = SQL.ExecuteDataSet(connectionString, CommandType.StoredProcedure, "P_PageView", par);

            if (rowCount > 0)
                par[5].Value = rowCount;
            else
                par[5].Value = DBNull.Value;
            if (rowCount <= 0)
            {
                rowCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            }
            return ds.Tables[0];


        }
        #endregion

        //public string CountNumber()
        //{

        //    cmd = new SqlCommand("CountNumber", GetConn());
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    SqlParameter i = new SqlParameter("@num", SqlDbType.Int);
        //    //i.Direction = ParameterDirection.Output;
        //    i.Direction = ParameterDirection.ReturnValue;
        //    cmd.Parameters.Add(i);
        //    cmd.ExecuteNonQuery();

        //    //int strReturn = i.Value.ToString(); //返回值--方法1
        //    string num = cmd.Parameters["@num"].Value.ToString();
        //    //返回值--方法2

        //    conn.Close();

        //    return num;

        //}
    }
