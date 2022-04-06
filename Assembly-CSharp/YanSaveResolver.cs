using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using UnityEngine;

// Token: 0x0200051C RID: 1308
internal class YanSaveResolver : DefaultContractResolver
{
	// Token: 0x06002188 RID: 8584 RVA: 0x001EE1B8 File Offset: 0x001EC3B8
	protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
	{
		IList<JsonProperty> list = base.CreateProperties(type, memberSerialization);
		PropertyInfo readableInfo = null;
		foreach (MemberInfo memberInfo in type.GetMember("isReadable"))
		{
			if (memberInfo.MemberType == MemberTypes.Property)
			{
				readableInfo = (PropertyInfo)memberInfo;
			}
		}
		Predicate<object> <>9__1;
		foreach (JsonProperty jsonProperty in list)
		{
			Predicate<object> shouldSerialize;
			if ((shouldSerialize = <>9__1) == null)
			{
				shouldSerialize = (<>9__1 = ((object instance) => !(type == typeof(Material)) && (!(readableInfo != null) || (bool)readableInfo.GetValue(instance))));
			}
			jsonProperty.ShouldSerialize = shouldSerialize;
		}
		return (from p in list
		where p.Writable
		select p).ToList<JsonProperty>();
	}
}
