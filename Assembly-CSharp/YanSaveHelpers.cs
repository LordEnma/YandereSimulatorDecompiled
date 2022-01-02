using System;
using System.Reflection;

// Token: 0x02000509 RID: 1289
public static class YanSaveHelpers
{
	// Token: 0x06002125 RID: 8485 RVA: 0x001E6480 File Offset: 0x001E4680
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
