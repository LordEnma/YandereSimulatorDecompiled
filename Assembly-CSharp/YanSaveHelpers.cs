using System;
using System.Reflection;

// Token: 0x0200050B RID: 1291
public static class YanSaveHelpers
{
	// Token: 0x06002130 RID: 8496 RVA: 0x001E6E20 File Offset: 0x001E5020
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
