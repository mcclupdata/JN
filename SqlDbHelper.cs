using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace JN_WELD_Service
{
    /// <summary>
    /// 针对SQL Server数据库操作的通用类
    /// 作者：周公
    /// 日期：2009-01-08
    /// Version:1.0
    /// </summary>
    public class SqlDbHelper
    {
        private string connectionString = "Data Source=127.0.0.1;Initial Catalog=JNDB;User ID=sa;Password=Sa123456";
        /// <summary>
        /// 设置数据库连接字符串
        /// </summary>
        public string ConnectionString
        {
            set { connectionString = value; }
            get { return connectionString; }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public SqlDbHelper()
           // : this( Configurat ConfigurationManager.ConnectionStrings["Conn"].ConnectionString)
        {
            INIClass inicls = new INIClass();
            //获取数据库连接字符串
            connectionString = inicls.getDBConntionstr();
        }
        public SqlDbType tranDataType2SQl(Type type)
        {
            if (type == typeof(String))
                return SqlDbType.NVarChar;
            if (type == typeof(Int32))
                return SqlDbType.Int;
            if (type == typeof(long))
                return SqlDbType.BigInt;
            if (type == typeof(DateTime))
                return SqlDbType.DateTime;
            if (type == typeof(Double))
                return SqlDbType.Decimal;
            if (type==typeof(Decimal))
                return SqlDbType.Decimal;
            return SqlDbType.NVarChar;

        }
        public SqlDbType tranDataType2SQl(int type)
        {
            //0表示string；1表示datetime；2表示int；3表示long；6表示decimal.
            if (type == 0)
                return SqlDbType.NVarChar;
            if (type == 2)
                return SqlDbType.Int;
            if (type ==3)
                return SqlDbType.BigInt;
            if (type == 1)
                return SqlDbType.DateTime;
            if (type == 6)
                return SqlDbType.Decimal;
            return SqlDbType.NVarChar;

        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        public SqlDbHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }
        /// <summary>
        /// 执行一个查询，并返回结果集
        /// </summary>
        /// <param name="sql">要执行的查询SQL文本命令</param>
        /// <returns>返回查询结果集</returns>
        public DataTable ExecuteDataTable(string sql)
        {
            return ExecuteDataTable(sql, CommandType.Text, null);
        }
        /// <summary>
        /// 执行一个查询,并返回查询结果
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>
        /// <returns>返回查询结果集</returns>
        public DataTable ExecuteDataTable(string sql, CommandType commandType)
        {
            return ExecuteDataTable(sql, commandType, null);
        }
        public DataTable ExecuteDataTable(string sql, ArrayList parameters)
        {
            DataTable data = new DataTable();//实例化DataTable，用于装载查询结果集
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    
                    connection.Open();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;//设置command的CommandType为指定的CommandType
                    command.CommandTimeout = 5 * 60;
                    //如果同时传入了参数，则添加这些参数
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    //通过包含查询SQL的SqlCommand实例来实例化SqlDataAdapter
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    adapter.Fill(data);//填充DataTable
                    command.Parameters.Clear();
                    connection.Close();
                }
            }
            return data;
        }
        /// <summary>
        /// 依据查询语句进行批量更新--
        /// </summary>
        /// <param name="selSQL">查询语句，待更新数据必须包容该语句</param>
        /// <param name="data">待更新数据</param>
        /// <param name="strKey">关键字段</param>
        /// <returns>执行成功返回True，失败返回false</returns>
        public DataTable UpdateByDataTable(String selSQL,DataTable data,String strKey,params int[] type)
        {
            int vtype = 0;
            if (type.Length > 0)
                vtype = Convert.ToInt32(type.GetValue(0));

            DataSet ds = new DataSet();
            Boolean rsbl = true;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    if (vtype == 1)
                    {
                        selSQL += " where " + strKey + "=0";
                    }
                    SqlDataAdapter adp = new SqlDataAdapter(selSQL, conn);
                    
                    adp.Fill(ds);
                    //添加主键
                    
                    ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns[strKey] };

                    //DataRow dr = ds.Tables[0].NewRow();
                    //dr["name"] = txtName.Text;
                    //dr["age"] = Convert.ToInt32(txtAge.Text);
                    //SqlCommandBuilder cmd = new SqlCommandBuilder(adp);
                    //ds.Tables[0].Rows.Add(dr);
                    //adp.Update(ds);
                    if (vtype == 0)
                    {
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            //if (data.Rows[i].)
                           // if (data.Rows[i].RowState == DataRowState.Modified)
                           // {
                                DataRow dr = ds.Tables[0].Rows.Find(data.Rows[i][strKey]);
                                //DataRow dr = hRDataSet.Tables["emp"].Select("id="+textBox3.Text)[0];
                                dr.BeginEdit();
                                //dr["name"] = textBox1.Text;
                                for (int k = 0; k < data.Columns.Count; k++)
                                {
                                    if (data.Columns[k].ColumnName != strKey)
                                    {
                                        if (ds.Tables[0].Columns.IndexOf(data.Columns[k].ColumnName) >= 0)
                                        {
                                            dr[data.Columns[k].ColumnName] = data.Rows[i][data.Columns[k].ColumnName];
                                        }

                                    }
                                }
                                dr.EndEdit();
                           // }
                        }
                    }
                    if (vtype == 1)
                    {
                        //执行删除和插入新数据;
                        //插入
                        
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            //if (data.Rows[i].)

                            DataRow dr;// //ds.Tables[0].Rows.Find(data.Rows[i][strKey]);
                            //DataRow dr = hRDataSet.Tables["emp"].Select("id="+textBox3.Text)[0];
                            //if (data.Rows[i].RowState==DataRowState.Added )
                            //{
                                dr = ds.Tables[0].NewRow();
                                for (int k = 0; k < data.Columns.Count; k++)
                                {
                                    if (data.Columns[k].ColumnName != strKey)
                                    {
                                        if (ds.Tables[0].Columns.IndexOf(data.Columns[k].ColumnName) >= 0)
                                        {
                                            dr[data.Columns[k].ColumnName] = data.Rows[i][data.Columns[k].ColumnName];
                                        }

                                    }
                                }
                               dr[strKey] = i;
                                ds.Tables[0].Rows.Add(dr);
                            //}
                        }
                        
                       
                    }
                    if (vtype == 2)
                    {
                        //删除
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            //if (data.Rows[i].)
                            //if (data.Rows[i].RowState == DataRowState.Deleted)
                           // {
                                DataRow dr = ds.Tables[0].Rows.Find(data.Rows[i][strKey]);
                                //DataRow dr = hRDataSet.Tables["emp"].Select("id="+textBox3.Text)[0];
                                dr.Delete();
                           // }
                        }
                    }
                    SqlCommandBuilder cmd = new SqlCommandBuilder(adp);
                    adp.Update(ds);
                    adp.Fill(data);
                    return data;
                }


            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 无返回结果的SQL语句的返回信息
        /// </summary>
        /// <param name="vresult">执行结果</param>
        /// <param name="vmsg">消息</param>
        /// <param name="vFID">返回FID</param>
        /// <returns></returns>
        public DataTable excuNoqueryRetrun(Boolean vresult,String vmsg,long vFID)
        {
            DataTable rst = new DataTable();
            DataColumn col = new DataColumn("result", typeof(Boolean));
            rst.Columns.Add(col);
            DataColumn col1 = new DataColumn("msg", typeof(String));
            rst.Columns.Add(col1);
            DataColumn col2 = new DataColumn("FID", typeof(long));
            rst.Columns.Add(col2);
            DataRow row = rst.NewRow();
            row[0] = vresult;
            row[1] = vmsg;
            row[2] = vFID;
            rst.Rows.Add(row);
            return rst;

        }

        /// <summary>
        /// 执行一个查询,并返回查询结果
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string sql)
        {
            DataSet data = new DataSet();//实例化DataTable，用于装载查询结果集
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
               
                    //通过包含查询SQL的SqlCommand实例来实例化SqlDataAdapter
                    SqlDataAdapter adapter = new SqlDataAdapter(sql,connection);

                    adapter.Fill(data);//填充DataTable
                    connection.Close();
                }
            }
            return data;
        }


        /// <summary>
        /// 执行一个查询,并返回查询结果
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>
        /// <param name="parameters">Transact-SQL 语句或存储过程的参数数组</param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            DataTable data = new DataTable();//实例化DataTable，用于装载查询结果集
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandType = commandType;//设置command的CommandType为指定的CommandType
                    command.CommandTimeout = 5 * 60;
                    //如果同时传入了参数，则添加这些参数
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    //通过包含查询SQL的SqlCommand实例来实例化SqlDataAdapter
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    adapter.Fill(data);//填充DataTable
                    connection.Close();
                }
            }
            return data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql">要执行的查询SQL文本命令</param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string sql)
        {
            return ExecuteReader(sql, CommandType.Text, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string sql, CommandType commandType)
        {
            return ExecuteReader(sql, commandType, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>
        /// <param name="parameters">Transact-SQL 语句或存储过程的参数数组</param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            command.CommandTimeout = 5 * 60;
            //如果同时传入了参数，则添加这些参数
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            connection.Open();
            //CommandBehavior.CloseConnection参数指示关闭Reader对象时关闭与其关联的Connection对象

            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql">要执行的查询SQL文本命令</param>
        /// <returns></returns>
        public Object ExecuteScalar(string sql)
        {
            return ExecuteScalar(sql, CommandType.Text, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>
        /// <returns></returns>
        public Object ExecuteScalar(string sql, CommandType commandType)
        {
            return ExecuteScalar(sql, commandType, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>
        /// <param name="parameters">Transact-SQL 语句或存储过程的参数数组</param>
        /// <returns></returns>
        public Object ExecuteScalar(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            object result = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = commandType;//设置command的CommandType为指定的CommandType
                    command.CommandTimeout = 5 * 60;
                    //如果同时传入了参数，则添加这些参数
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    connection.Open();//打开数据库连接
                    result = command.ExecuteScalar();
                    command.Parameters.Clear();
                }
            }
            return result;//返回查询结果的第一行第一列，忽略其它行和列
        }
        /// <summary>
        /// 对数据库执行增删改操作
        /// </summary>
        /// <param name="sql">要执行的查询SQL文本命令</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql)
        {
            ArrayList pa = new ArrayList();
            return ExecuteNonQuery(sql, CommandType.Text, pa);
        }
        /// <summary>
        /// 对数据库执行增删改操作
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, CommandType commandType)
        {
            ArrayList pa = new ArrayList();
            return ExecuteNonQuery(sql, commandType, pa);
        }
        /// <summary>
        /// 对数据库执行增删改操作
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>
        /// <param name="parameters">Transact-SQL 语句或存储过程的参数数组</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = commandType;//设置command的CommandType为指定的CommandType
                    command.CommandTimeout = 5 * 60;
                    //如果同时传入了参数，则添加这些参数
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();//打开数据库连接
                    }
                    count = command.ExecuteNonQuery();
                }
            }
            return count;//返回执行增删改操作之后，数据库中受影响的行数
        }
        /// <summary>
        /// 对数据库执行增删改操作
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>
        /// <param name="parameters">Transact-SQL 语句或存储过程的参数数组</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, CommandType commandType, ArrayList parameters)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = commandType;//设置command的CommandType为指定的CommandType
                    command.CommandTimeout = 5 * 60;
                    //如果同时传入了参数，则添加这些参数
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();//打开数据库连接
                    }
                    count = command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
            return count;//返回执行增删改操作之后，数据库中受影响的行数
        }

        /// <summary>
        /// 返回当前连接的数据库中所有由用户创建的数据库
        /// </summary>
        /// <returns></returns>
        public DataTable GetTables()
        {
            DataTable data = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();//打开数据库连接
                data = connection.GetSchema("Tables");
            }
            return data;
        }
        /// <summary>
        /// 调用存储过程并以Datatable
        /// 形式返回数据
        /// </summary>
        /// <param name="Procedurename">存储过程名称</param>
        /// <returns></returns>
        public DataTable ExecuteProcedureNoParams(String Procedurename)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();//打开数据库连接
                
                SqlCommand com = new SqlCommand();
                com.CommandTimeout = 3000;
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Connection = con;
                com.CommandText = Procedurename;
                SqlDataReader sdr = com.ExecuteReader();
                DataTable result = dataReader2DataTable(sdr);
                return result;
            }

        }
        /// <summary>
        /// 将DataReader转DataTable
        /// </summary>
        /// <param name="datareader">待转换的DataReader</param>
        /// <returns></returns>
        public DataTable dataReader2DataTable(SqlDataReader dataReader)
        {
            DataTable datatable = new DataTable();
            datatable.Load(dataReader);
            return datatable;

            DataTable schemaTable = dataReader.GetSchemaTable();
            //动态添加列
            try
            {

                foreach (DataRow myRow in schemaTable.Rows)
                {                    DataColumn myDataColumn = new DataColumn();
                    myDataColumn.DataType = myRow.GetType();
                    myDataColumn.ColumnName = myRow[0].ToString();
                    datatable.Columns.Add(myDataColumn);
                }
                //添加数据
                while (dataReader.Read())
                {
                    DataRow myDataRow = datatable.NewRow();
                    for (int i = 0; i < schemaTable.Rows.Count; i++)
                    {
                        myDataRow[i] = dataReader[i];
                    }
                    datatable.Rows.Add(myDataRow);
                    myDataRow = null;
                }
                schemaTable = null;
                return datatable;
            }
            catch (Exception ex)
            {
               // Error.Log(ex.ToString());
                return datatable;
            }
        }
        /*
        /// <summary>
        /// 调用存储过程[evaluate_weld] 获取评估结果数据
        /// </summary>
        /// <param name="PID">焊缝ID</param>
        /// <param name="weld_pass">焊道</param>
        /// <returns>评估记过</returns>
        public EvalulateResult GetEvalulateData(long PID, int weld_pass)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();//打开数据库连接

                SqlCommand com = new SqlCommand();
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Connection = con;
                com.CommandText = "evaluate_weld";

                SqlParameter pPID = new SqlParameter("@PID", SqlDbType.BigInt);
                SqlParameter pWELD_PASS = new SqlParameter("@WELD_PASS", SqlDbType.Int);
                pPID.Value = PID;
                pWELD_PASS.Value = weld_pass;

                com.Parameters.Add(pPID);
                com.Parameters.Add(pWELD_PASS);

                EvalulateResult ers = new EvalulateResult();
                SqlDataReader sdr = com.ExecuteReader();
                while (sdr.Read())
                {
                    //@UP as UP, @VP as VP , @IP as IP,@L as L , @IA as IA ,@CVI as CVI,@SI as SI ,@CVV as CVV ,@SV as SV ,@VA as  VA ,
                    //@V as V , @Gv as Gv ,@Gx as Gx,@Gy as Gy,@Gz as Gz
                    ers.CVI = Convert.ToDouble(sdr["CVI"]);
                    ers.CVV = Convert.ToDouble(sdr["CVV"]);
                    ers.Gv = Convert.ToDouble(sdr["Gv"]);
                    ers.Gx = Convert.ToDouble(sdr["Gx"]);
                    ers.Gy = Convert.ToDouble(sdr["Gy"]);
                    ers.Gz = Convert.ToDouble(sdr["Gz"]);
                    ers.IA = Convert.ToDouble(sdr["IA"]);
                    ers.IP = Convert.ToDouble(sdr["IP"]);
                    ers.L = Convert.ToDouble(sdr["L"]);
                    ers.SI = Convert.ToDouble(sdr["SI"]);
                    ers.SV = Convert.ToDouble(sdr["SV"]);
                    ers.UP = Convert.ToDouble(sdr["UP"]);
                    ers.V = Convert.ToDouble(sdr["V"]);
                    ers.VA = Convert.ToDouble(sdr["VA"]);
                    ers.VP = Convert.ToDouble(sdr["VP"]);
                    ers.T = Convert.ToDouble(sdr["T"]);
                }
                ;
                sdr.Close();
                con.Close();
                return ers;
            }
           
        }
     */

    }
}
