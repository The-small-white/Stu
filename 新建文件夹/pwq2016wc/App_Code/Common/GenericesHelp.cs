using System;
using System.Collections.Generic;
using System.Web;
using System.Reflection;


/// <summary>
/// 反射/扩展方法帮助类
/// </summary>
public static class GenericesHelp
{
    /// <summary>
    /// 根据ID查询对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="id"></param>
    /// <returns></returns>
    public static T GetModelByID<T>(int id) where T : class,new()
    {
        Type type = typeof(T);

        string sql = "select * from " + type.Name + " where ID=" + id;
        List<T> list = SQL.GetList<T>(sql);
        if (list.Count == 0)
            return new T();
        return list[0];
    }

    /// <summary>
    /// 设置私有字段的值
    /// </summary>
    /// <param name="instance">调用该方法的对象</param>
    /// <param name="fieldname">私有字段名称</param>
    /// <param name="value">需要设置的值</param>
    public static void SetPrivateField(this Dejun.DataProvider.IDateBuildTable instance, string fieldname, object value)
    {
        BindingFlags flag = BindingFlags.Instance | BindingFlags.NonPublic;
        Type type = instance.GetType();
        FieldInfo field = type.GetField(fieldname, flag);
        field.SetValue(instance, value);
    }

    /// <summary>
    /// 在插入或修改模型时调用该方法以避免sql语句中传入多余参数以致报错
    /// </summary>
    /// <param name="instance"></param>
    public static void SetInitializedToFalse(this Dejun.DataProvider.IDateBuildTable instance)
    {
        Type type = instance.GetType();
        PropertyInfo[] info = type.GetProperties();
        //遍历所有公有属性
        for (int i = 0; i < info.Length; i++)
        {
            if (Convert.ToString(info[i].GetValue(instance,null)) == "")
            {
                //如果该公有属性的值为空,则根据该公有属性拼接出所对应的私有字段
                string propertyName = info[i].Name;
                string fieldName = propertyName.Substring(0, 1).ToLower() + propertyName.Substring(1, propertyName.Length - 1) + "_initialized";

                //设置对应私有字段的值为false
                FieldInfo field = type.GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
                field.SetValue(instance, false);
            }
        }
    }

    /// <summary>
    /// 设置iD_initialized值为false
    /// </summary>
    /// <param name="instance"></param>
    public static void SetIdInitializedToFalse(this Dejun.DataProvider.IDateBuildTable instance)
    {
        Type type = instance.GetType();
        type.GetField("iD_initialized", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(instance, false);
    }

    /// <summary>
    /// 设置所有在Request中为空的key所对应的具体类中所对应的initialized值为true(若字段为string类型则跳过,以避免无法设置为空字符串),因为在具体类中的AutoForm方法检测到initialized为true时,会检查Request是否为空,为空则跳过,此方法需要在AutoFrom之前使用
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="request">当前请求</param>
    /// <param name="instance"></param>
    public static void SetInitializedToTrueIfIsNotStringTypeAndISEmpty(this Dejun.DataProvider.IDateBuildTable instance, HttpRequest request)
    {
        string[] allKeys = request.QueryString.AllKeys;
        Type type = instance.GetType();

        BindingFlags publicFlag = BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance;//获取属性的设置,忽略大小写
        BindingFlags nonPublicFlag = BindingFlags.NonPublic | BindingFlags.IgnoreCase | BindingFlags.Instance;//获取私有字段的设置,忽略大小写

        foreach (var item in allKeys)
        {
            if (item == null) continue;

            PropertyInfo proInfo = type.GetProperty(item, publicFlag);
            if (proInfo != null)
            {
                string typeName = proInfo.PropertyType.Name;
                if (typeName == "String") continue;

                if (string.IsNullOrEmpty(request[item]))
                {
                    FieldInfo fieldInfo = type.GetField(item + "_initialized", nonPublicFlag);
                    if (fieldInfo != null) fieldInfo.SetValue(instance, true);
                }
            }
        }
    }
}
