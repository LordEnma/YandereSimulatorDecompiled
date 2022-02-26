using System;
using System.Reflection;

// Token: 0x0200050E RID: 1294
public static class YanSaveHelpers
{
	// Token: 0x0600214B RID: 8523 RVA: 0x001E9940 File Offset: 0x001E7B40
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
