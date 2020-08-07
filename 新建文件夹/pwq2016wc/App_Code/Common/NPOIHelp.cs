using System;
using System.Collections.Generic;
using System.Data;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using NPOI.SS.Formula.Eval;
using System.Reflection;
using System.Collections;

/// <summary>
/// 通过NPOI读写Excel
/// </summary>
public class NPOIHelp
{
    private IWorkbook workbook;
    public NPOIHelp()
    {
        workbook = new HSSFWorkbook();
    }

    #region 导出

    /// <summary>
    /// 将多个Sheet合成的Excel导出
    /// </summary>
    public MemoryStream ToExcel()
    {
        if (this.workbook.NumberOfSheets == 0)
            throw new Exception("从未创建工作簿,请先添加Sheet");

        MemoryStream stream = new MemoryStream();
        this.workbook.Write(stream);
        stream.Flush();

        return stream;
    }

    /// <summary>
    /// 创建Sheet并将集合内容填充
    /// </summary>
    /// <typeparam name="T">具体类</typeparam>
    /// <param name="list">集合内容</param>
    /// <param name="sheetName">>sheet名</param>
    public void AddSheet<T>(List<T> list, string sheetName)
    {
        ISheet sheet = workbook.CreateSheet(sheetName);
        IRow rowHead = sheet.CreateRow(0);
        PropertyInfo[] info = typeof(T).GetProperties();

        //创建第一行头部
        for (int i = 0; i < info.Length; i++)
        {
            ICell cell = rowHead.CreateCell(i);
            cell.SetCellValue(info[i].Name);
        }

        //填写主内容
        for (int i = 0; i < list.Count; i++)
        {
            IRow row = sheet.CreateRow(i + 1);
            for (int j = 0; j < info.Length; j++)
            {
                ICell cell = row.CreateCell(j);

                object value = info[j].GetValue(list[i], null);
                SetCellValue(value, ref cell);
            }
        }

        //自动列宽
        AutoSizeColumns(sheet);
        AutoCenter(sheet);
    }

    /// <summary>
    /// List集合转成Excel文档流
    /// </summary>
    /// <typeparam name="T">具体类</typeparam>
    /// <param name="list">需要转成Excel的集合</param>
    /// <param name="columnHead">Excel的标题行{属性名称,列的标题},并将按照此顺序输出</param>
    /// <param name="sheetName">sheet名</param>
    public void AddSheet<T>(List<T> list, Dictionary<string, string> columnHead, string sheetName)
    {
        ISheet sheet = this.workbook.CreateSheet(sheetName);
        IRow rowHead = sheet.CreateRow(0);

        //把集合中的键(数据库字段名存入list集合中,方便使用)  .net4.0中的linq中有扩展方法,可以直接dic.keys.ToList()
        List<string> keys = new List<string>();
        foreach (var item in columnHead.Keys)
        {
            keys.Add(item);
        }

        //把字典中对应键的值(列标题)存入第一行作为标题
        for (int i = 0; i < keys.Count; i++)
        {
            ICell cellHead = rowHead.CreateCell(i);
            cellHead.SetCellValue(columnHead[keys[i]]);
        }

        //循环把值插入workbook中
        Type type = typeof(T);
        for (int i = 0; i < list.Count; i++)
        {
            IRow row = sheet.CreateRow(i + 1);
            for (int j = 0; j < keys.Count; j++)
            {
                //根据对应的属性keys[i]获取值插入到对应的单元格中
                object value = type.GetProperty(keys[j]).GetValue(list[i], null);
                ICell cell = row.CreateCell(j);

                SetCellValue(value, ref cell);
            }
        }

        AutoSizeColumns(sheet);
        AutoCenter(sheet);
    }

    /// <summary>
    /// List集合转成Excel文档流
    /// </summary>
    /// <typeparam name="T">具体类</typeparam>
    /// <param name="list">需要转成Excel的集合</param>
    public void AddSheet<T>(List<T> list)
    {
        ISheet sheet = this.workbook.CreateSheet();

        IRow rowHead = sheet.CreateRow(0);
        PropertyInfo[] info = typeof(T).GetProperties();

        //创建第一行头部
        for (int i = 0; i < info.Length; i++)
        {
            ICell cell = rowHead.CreateCell(i);
            cell.SetCellValue(info[i].Name);
        }

        //填写主内容
        for (int i = 0; i < list.Count; i++)
        {
            IRow row = sheet.CreateRow(i + 1);
            for (int j = 0; j < info.Length; j++)
            {
                ICell cell = row.CreateCell(j);

                object value = info[j].GetValue(list[i], null);
                SetCellValue(value, ref cell);
            }
        }

        //自动列宽
        AutoSizeColumns(sheet);
        AutoCenter(sheet);
    }

    /// <summary>
    /// List集合转成Excel文档流
    /// </summary>
    /// <typeparam name="T">具体类</typeparam>
    /// <param name="list">需要转成Excel的集合</param>
    /// <param name="columnHead">Excel的标题行{属性名称,列的标题},并将按照此顺序输出</param>
    public void AddSheet<T>(List<T> list, Dictionary<string, string> columnHead)
    {
        ISheet sheet = this.workbook.CreateSheet();
        IRow rowHead = sheet.CreateRow(0);

        //把集合中的键(数据库字段名存入list集合中,方便使用)  .net4.0中的linq中有扩展方法,可以直接dic.keys.ToList()
        List<string> keys = new List<string>();
        foreach (var item in columnHead.Keys)
        {
            keys.Add(item);
        }

        //把字典中对应键的值(列标题)存入第一行作为标题
        for (int i = 0; i < keys.Count; i++)
        {
            ICell cellHead = rowHead.CreateCell(i);
            cellHead.SetCellValue(columnHead[keys[i]]);
        }

        //循环把值插入workbook中
        Type type = typeof(T);
        for (int i = 0; i < list.Count; i++)
        {
            IRow row = sheet.CreateRow(i + 1);
            for (int j = 0; j < keys.Count; j++)
            {
                //根据对应的属性keys[i]获取值插入到对应的单元格中
                object value = type.GetProperty(keys[j]).GetValue(list[i], null);
                ICell cell = row.CreateCell(j);

                SetCellValue(value, ref cell);
            }
        }

        AutoSizeColumns(sheet);
        AutoCenter(sheet);
    }

    #endregion

    #region 导入

    /// <summary>
    /// 读取Excel文件并返回Datatable
    /// </summary>
    /// <param name="strFilePath">Excel文件目录地址</param>
    /// <param name="strTableName">Datatable表名</param>
    /// <param name="iSheetIndex">第几个工作簿(从0开始)</param>
    /// <returns></returns>
    public DataTable XlsToDataTable(string strFilePath, string strTableName, int iSheetIndex)
    {
        DataTable dt = new DataTable();
        if (!string.IsNullOrEmpty(strTableName))
        {
            dt.TableName = strTableName;
        }

        string strExtName = Path.GetExtension(strFilePath);
        if (strExtName.Equals(".xls") || strExtName.Equals(".xlsx"))
        {
            using (FileStream file = new FileStream(strFilePath, FileMode.Open, FileAccess.Read))
            {
                HSSFWorkbook book = new HSSFWorkbook(file);
                ISheet sheet = book.GetSheetAt(iSheetIndex);

                //列头
                foreach (ICell item in sheet.GetRow(sheet.FirstRowNum).Cells)
                {
                    dt.Columns.Add(item.ToString(), typeof(string));
                }

                //写入内容
                System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
                while (rows.MoveNext())
                {
                    IRow row = (HSSFRow)rows.Current;
                    //如果是第一行则跳过此次循环.因为第一行是表头
                    if (row.RowNum == sheet.FirstRowNum)
                        continue;

                    DataRow dr = ForeachCellReturnRow(row, dt, null);

                    if (!IsAllDbNullValue(dr)) dt.Rows.Add(dr);
                }
            }
        }
        return dt;
    }

    /// <summary>
    /// 读取Excel文件生成并返回Datatable
    /// </summary>
    /// <param name="strFilePath">Excel文件目录地址</param>
    /// <param name="strTableName">Datatable表名</param>
    /// <param name="iSheetIndex">第几个工作簿(从0开始)</param>
    /// <param name="columnName">键值对集合,键为Excel中表头,值为数据库字段</param>
    /// <returns></returns>
    public DataTable XlsToDataTable(string strFilePath, string strTableName, int iSheetIndex, Dictionary<string, string> columnName)
    {
        DataTable dt = new DataTable();
        if (!string.IsNullOrEmpty(strTableName))
        {
            dt.TableName = strTableName;
        }

        string strExtName = Path.GetExtension(strFilePath);
        if (strExtName.Equals(".xls") || strExtName.Equals(".xlsx"))
        {
            using (FileStream file = new FileStream(strFilePath, FileMode.Open, FileAccess.Read))
            {
                HSSFWorkbook book = new HSSFWorkbook(file);
                ISheet sheet = book.GetSheetAt(iSheetIndex);

                //列头,把对应的数据库字段加入得到datatable的第一行
                foreach (ICell item in sheet.GetRow(sheet.FirstRowNum).Cells)
                {
                    //当表中的列名有与dic中的key相同时,取其value值作为表头
                    if (columnName.ContainsKey(item.ToString()))
                        dt.Columns.Add(columnName[item.ToString()], typeof(string));
                    else
                        dt.Columns.Add(item.ToString(), typeof(string));
                }

                //写入内容
                System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
                while (rows.MoveNext())
                {
                    IRow row = (HSSFRow)rows.Current;
                    //如果是第一行则跳过此次循环
                    if (row.RowNum == sheet.FirstRowNum)
                        continue;

                    DataRow dr = ForeachCellReturnRow(row, dt, columnName);
                    if (!IsAllDbNullValue(dr)) dt.Rows.Add(dr);
                }
            }
        }
        return dt;
    }

    /// <summary>
    /// 读取Excel文件生成并返回Datatable
    /// </summary>
    /// <param name="stream">文件流</param>
    /// <param name="strTableName">Datatable表名</param>
    /// <param name="iSheetIndex">第几个工作簿(从0开始)</param>
    /// <returns></returns>
    public DataTable XlsToDataTable(Stream stream, string strTableName, int iSheetIndex)
    {
        DataTable dt = new DataTable();
        if (!string.IsNullOrEmpty(strTableName))
        {
            dt.TableName = strTableName;
        }

        HSSFWorkbook book = new HSSFWorkbook(stream);
        ISheet sheet = book.GetSheetAt(iSheetIndex);

        //列头
        foreach (ICell item in sheet.GetRow(sheet.FirstRowNum).Cells)
        {
            dt.Columns.Add(item.ToString(), typeof(string));
        }

        //写入内容
        System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
        while (rows.MoveNext())
        {
            IRow row = (HSSFRow)rows.Current;
            //如果是第一行则跳过此次循环.因为第一行是表头
            if (row.RowNum == sheet.FirstRowNum)
                continue;

            DataRow dr = ForeachCellReturnRow(row, dt, null);

            if (!IsAllDbNullValue(dr)) dt.Rows.Add(dr);
        }

        return dt;
    }

    /// <summary>
    /// 读取Excel文件生成并返回Datatable
    /// </summary>
    /// <param name="stream">文件流</param>
    /// <param name="strTableName">Datatable表名</param>
    /// <param name="iSheetIndex">第几个工作簿(从0开始)</param>
    /// <param name="columnName">键值对集合,键为Excel中表头,值为数据库字段</param>
    /// <returns></returns>
    public DataTable XlsToDataTable(Stream stream, string strTableName, int iSheetIndex, Dictionary<string, string> columnName)
    {
        DataTable dt = new DataTable();
        if (!string.IsNullOrEmpty(strTableName))
        {
            dt.TableName = strTableName;
        }

        HSSFWorkbook book = new HSSFWorkbook(stream);
        ISheet sheet = book.GetSheetAt(iSheetIndex);

        //列头,把对应的数据库字段加入得到datatable的第一行
        foreach (ICell item in sheet.GetRow(sheet.FirstRowNum).Cells)
        {
            //当表中的列名有与dic中的key相同时,取其value值作为表头
            if (columnName.ContainsKey(item.ToString()))
                dt.Columns.Add(columnName[item.ToString()], typeof(string));
            else
                dt.Columns.Add(item.ToString(), typeof(string));
        }

        //写入内容
        System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
        while (rows.MoveNext())
        {
            IRow row = (HSSFRow)rows.Current;
            //如果是第一行则跳过此次循环
            if (row.RowNum == sheet.FirstRowNum)
                continue;

            DataRow dr = ForeachCellReturnRow(row, dt, columnName);

            if (!IsAllDbNullValue(dr)) dt.Rows.Add(dr);
        }

        return dt;
    }

    #endregion

    #region 公有方法

    /// <summary> 
    /// 将DataTable转换为List<T>对象,注意:如DataTable中存在一个不为null但是里面的所有列都是空的对象,则此对象不会被加入到集合中
    /// </summary> 
    /// <param name="dt">DataTable 对象</param> 
    /// <returns>List<T>集合</returns> 
    public List<T> DataTableToList<T>(DataTable dt) where T : class, new()
    {
        List<T> ts = new List<T>();
        //定义一个临时变量 
        string tempName = string.Empty;

        //遍历DataTable中所有的数据行 
        foreach (DataRow dr in dt.Rows)
        {
            T t = new T();
            // 获得此模型的公共属性 
            PropertyInfo[] propertys = t.GetType().GetProperties();

            //遍历该对象的所有属性 
            foreach (PropertyInfo pi in propertys)
            {
                tempName = pi.Name;//将属性名称赋值给临时变量 

                //检查DataTable是否包含此列（列名==对象的属性名）  
                int index = dt.Columns.IndexOf(tempName);//使用索引获取值会比使用列名获取更快
                if (index != -1)//dt.Columns.Contains(tempName)
                {
                    //取值 
                    object value = dr[index];
                    //如果非空，则赋给对象的属性 
                    if (value != DBNull.Value && !string.IsNullOrEmpty(Convert.ToString(value)))
                    {
                        //一般属性直接通过SetValue(t, value, null)可以成功,但是decimal数据类型不行,所以加以判断
                        switch (pi.PropertyType.FullName)
                        {
                            case "System.Int32": pi.SetValue(t, Convert.ToInt32(value), null); break;
                            case "System.Int16": pi.SetValue(t, Convert.ToInt16(value), null); break;
                            case "System.Int64": pi.SetValue(t, Convert.ToInt64(value), null); break;
                            case "System.Boolean": pi.SetValue(t, Convert.ToBoolean(value), null); break;
                            case "System.Byte": pi.SetValue(t, Convert.ToByte(value), null); break;
                            case "System.Char": pi.SetValue(t, Convert.ToChar(value), null); break;
                            case "System.DateTime": pi.SetValue(t, Convert.ToDateTime(value), null); break;
                            case "System.Decimal": pi.SetValue(t, Convert.ToDecimal(value), null); break;
                            case "System.Double": pi.SetValue(t, Convert.ToDouble(value), null); break;
                            case "System.String": pi.SetValue(t, Convert.ToString(value), null); break;
                            default: pi.SetValue(t, value, null); break;
                        }
                    }
                }
            }

            //对象添加到泛型集合中
            ts.Add(t);
        }
        return ts;
    }
    #endregion

    #region 私有方法

    /// <summary>
    /// 判断行中所有的单元格是不是都是空的
    /// </summary>
    /// <param name="dr"></param>
    /// <returns></returns>
    private bool IsAllDbNullValue(DataRow dr)
    {
        int columnCount = dr.Table.Columns.Count;
        for (int i = 0; i < columnCount; i++)
        {
            if (!dr.IsNull(i)) return false;
        }
        return true;
    }

    /// <summary>
    /// 判断类型后赋值给单元格,并返回row
    /// </summary>
    private DataRow ForeachCellReturnRow(IRow row, DataTable dt, Dictionary<string, string> columnName)
    {
        DataRow dr = dt.NewRow();
        foreach (ICell item in row.Cells)
        {
            if (columnName != null && item.ColumnIndex > columnName.Count - 1) continue;

            #region 判断类型并赋值给单元格

            switch (item.CellType)
            {
                case CellType.Boolean:
                    dr[item.ColumnIndex] = item.BooleanCellValue;
                    break;
                case CellType.Error:
                    dr[item.ColumnIndex] = ErrorEval.GetText(item.ErrorCellValue);
                    break;
                case CellType.Formula:
                    switch (item.CachedFormulaResultType)
                    {
                        case CellType.Boolean:
                            dr[item.ColumnIndex] = item.BooleanCellValue;
                            break;
                        case CellType.Error:
                            dr[item.ColumnIndex] = ErrorEval.GetText(item.ErrorCellValue);
                            break;
                        case CellType.Numeric:
                            if (DateUtil.IsCellDateFormatted(item))
                            {
                                dr[item.ColumnIndex] = item.DateCellValue.ToString("yyyy-MM-dd hh:MM:ss");
                            }
                            else
                            {
                                dr[item.ColumnIndex] = item.NumericCellValue;
                            }
                            break;
                        case CellType.String:
                            string str = item.StringCellValue;
                            if (!string.IsNullOrEmpty(str))
                            {
                                dr[item.ColumnIndex] = str.ToString();
                            }
                            else
                            {
                                dr[item.ColumnIndex] = null;
                            }
                            break;
                        case CellType.Unknown:
                        case CellType.Blank:
                        default:
                            dr[item.ColumnIndex] = string.Empty;
                            break;
                    }
                    break;
                case CellType.Numeric:
                    if (DateUtil.IsCellDateFormatted(item))
                    {
                        dr[item.ColumnIndex] = item.DateCellValue.ToString("yyyy-MM-dd hh:MM:ss");
                    }
                    else
                    {
                        dr[item.ColumnIndex] = item.NumericCellValue;
                    }
                    break;
                case CellType.String:
                    string strValue = item.StringCellValue;
                    if (!string.IsNullOrEmpty(strValue))
                    {
                        dr[item.ColumnIndex] = strValue.ToString();
                    }
                    else
                    {
                        dr[item.ColumnIndex] = null;
                    }
                    break;
                case CellType.Unknown:
                case CellType.Blank:
                default:
                    dr[item.ColumnIndex] = string.Empty;
                    break;
            }
            #endregion
        }
        return dr;
    }

    /// <summary>
    /// 自动设置Excel列宽
    /// </summary>
    /// <param name="sheet">Excel表</param>
    private void AutoSizeColumns(ISheet sheet)
    {
        if (sheet.PhysicalNumberOfRows > 0)
        {
            IRow headerRow = sheet.GetRow(0);

            for (int i = 0, l = headerRow.LastCellNum; i < l; i++)
            {
                sheet.AutoSizeColumn(i);
            }
        }
    }

    /// <summary>
    /// 设置水平垂直居中和自动换行
    /// </summary>
    private void AutoCenter(ISheet sheet)
    {
        ICellStyle style = sheet.Workbook.CreateCellStyle();
        style.VerticalAlignment = VerticalAlignment.Center;//垂直居中
        style.Alignment = HorizontalAlignment.Center;//水平居中
        style.WrapText = true;//自动换行

        //遍历所有的单元格
        IEnumerator rows = sheet.GetRowEnumerator();
        while (rows.MoveNext())
        {
            IRow row = (IRow)rows.Current;
            for (int i = 0; i < row.LastCellNum; i++)
            {
                row.GetCell(i).CellStyle = style;
            }
        }
    }

    /// <summary>
    /// 设置单元格内容及格式
    /// </summary>
    /// <param name="value">内容</param>
    /// <param name="cell">单元格</param>
    private void SetCellValue(object value, ref ICell cell)
    {
        if (value != null)
        {
            switch (value.GetType().Name)
            {
                case "Int32":
                case "Int16":
                case "Int64":
                case "Decimal":
                case "Double": cell.SetCellValue(Convert.ToDouble(value)); break;
                case "Boolean": cell.SetCellValue(Convert.ToBoolean(value)); break;
                case "DateTime": cell.SetCellValue(Convert.ToDateTime(value)); break;
                default: cell.SetCellValue(Convert.ToString(value)); break;
            }
        }
        else
        {
            cell.SetCellValue(string.Empty);
        }
    }
    #endregion
}