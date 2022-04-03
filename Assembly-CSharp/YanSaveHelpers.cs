using System;
using System.Reflection;

// Token: 0x02000518 RID: 1304
public static class YanSaveHelpers
{
	// Token: 0x06002179 RID: 8569 RVA: 0x001EDAF0 File Offset: 0x001EBCF0
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
