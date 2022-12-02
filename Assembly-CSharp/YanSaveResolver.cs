using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using UnityEngine;

internal class YanSaveResolver : DefaultContractResolver
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass0_0
	{
		public Type type;

		public PropertyInfo readableInfo;

		public Predicate<object> _003C_003E9__1;

		internal bool _003CCreateProperties_003Eb__1(object instance)
		{
			if (type == typeof(Material))
			{
				return false;
			}
			if (readableInfo != null)
			{
				return (bool)readableInfo.GetValue(instance);
			}
			return true;
		}
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<JsonProperty, bool> _003C_003E9__0_0;

		internal bool _003CCreateProperties_003Eb__0_0(JsonProperty p)
		{
			return p.Writable;
		}
	}

	protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
	{
		_003C_003Ec__DisplayClass0_0 _003C_003Ec__DisplayClass0_ = new _003C_003Ec__DisplayClass0_0();
		_003C_003Ec__DisplayClass0_.type = type;
		IList<JsonProperty> list = base.CreateProperties(_003C_003Ec__DisplayClass0_.type, memberSerialization);
		_003C_003Ec__DisplayClass0_.readableInfo = null;
		MemberInfo[] member = _003C_003Ec__DisplayClass0_.type.GetMember("isReadable");
		foreach (MemberInfo memberInfo in member)
		{
			if (memberInfo.MemberType == MemberTypes.Property)
			{
				_003C_003Ec__DisplayClass0_.readableInfo = (PropertyInfo)memberInfo;
			}
		}
		foreach (JsonProperty item in list)
		{
			item.ShouldSerialize = _003C_003Ec__DisplayClass0_._003C_003E9__1 ?? (_003C_003Ec__DisplayClass0_._003C_003E9__1 = _003C_003Ec__DisplayClass0_._003CCreateProperties_003Eb__1);
		}
		return list.Where(_003C_003Ec._003C_003E9__0_0 ?? (_003C_003Ec._003C_003E9__0_0 = _003C_003Ec._003C_003E9._003CCreateProperties_003Eb__0_0)).ToList();
	}
}
