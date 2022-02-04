using System;
using System.Reflection;

// Token: 0x0200050C RID: 1292
public static class YanSaveHelpers
{
	// Token: 0x06002138 RID: 8504 RVA: 0x001E86A8 File Offset: 0x001E68A8
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
