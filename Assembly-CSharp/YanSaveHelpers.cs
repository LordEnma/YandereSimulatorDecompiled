using System;
using System.Reflection;

// Token: 0x02000513 RID: 1299
public static class YanSaveHelpers
{
	// Token: 0x06002169 RID: 8553 RVA: 0x001EC280 File Offset: 0x001EA480
	public static Type GrabType(string type)
	{
		if (string.IsNullOrEmpty(type))
		{
			return null;
		}
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		for (int i = 0; i < assemblies.Length; i++)
		{
			Type type2 = assemblies[i].GetType(type);
			if (type2 != null)
			{
				return type2;
			}
		}
		return null;
	}
}
