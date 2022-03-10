using System;
using System.Reflection;

// Token: 0x0200050F RID: 1295
public static class YanSaveHelpers
{
	// Token: 0x06002151 RID: 8529 RVA: 0x001EA318 File Offset: 0x001E8518
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
