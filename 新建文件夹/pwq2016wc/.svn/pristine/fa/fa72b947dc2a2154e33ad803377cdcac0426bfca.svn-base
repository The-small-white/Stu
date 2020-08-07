using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

/// <summary>
/// 设置要显示或忽略序列化的属性
/// </summary>
public class JsonPropertyContractResolver : DefaultContractResolver
{
    string[] props = null;

    bool retain;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="props">传入的属性数组</param>
    /// <param name="retain">true:表示props是需要保留的字段  false：表示props是要排除的字段</param>
    public JsonPropertyContractResolver(string[] props, bool retain = true)
    {
        //指定要序列化属性的清单
        this.props = props;

        this.retain = retain;
    }

    protected override IList<JsonProperty> CreateProperties(Type type,

    MemberSerialization memberSerialization)
    {
        IList<JsonProperty> list =
        base.CreateProperties(type, memberSerialization);
        //只保留清单有列出的属性
        return list.Where(p => {
            if (retain)
            {
                return props.Contains(p.PropertyName);
            }
            else
            {
                return !props.Contains(p.PropertyName);
            }
        }).ToList();
    }
}