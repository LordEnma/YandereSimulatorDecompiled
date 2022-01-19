using System;
using System.Reflection;

// Token: 0x0200050C RID: 1292
public static class YanSaveHelpers
{
	// Token: 0x06002132 RID: 8498 RVA: 0x001E7AF0 File Offset: 0x001E5CF0
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
