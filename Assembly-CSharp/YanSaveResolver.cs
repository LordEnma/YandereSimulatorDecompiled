using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using UnityEngine;

internal class YanSaveResolver : DefaultContractResolver
{
	protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
	{
		IList<JsonProperty> list = base.CreateProperties(type, memberSerialization);
		PropertyInfo readableInfo = null;
		MemberInfo[] member = type.GetMember("isReadable");
		foreach (MemberInfo memberInfo in member)
		{
			if (memberInfo.MemberType == MemberTypes.Property)
			{
				readableInfo = (PropertyInfo)memberInfo;
			}
		}
		foreach (JsonProperty item in list)
		{
			item.ShouldSerialize = delegate(object instance)
			{
				if (type == typeof(Material))
				{
					return false;
				}
				return !(readableInfo != null) || (bool)readableInfo.GetValue(instance);
			};
		}
		return list.Where((JsonProperty p) => p.Writable).ToList();
	}
}
