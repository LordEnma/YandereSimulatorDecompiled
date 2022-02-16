using System;
using System.Reflection;

// Token: 0x0200050D RID: 1293
public static class YanSaveHelpers
{
	// Token: 0x06002142 RID: 8514 RVA: 0x001E8D60 File Offset: 0x001E6F60
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
