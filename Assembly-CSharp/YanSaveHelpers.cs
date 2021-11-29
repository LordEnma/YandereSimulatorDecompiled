using System;
using System.Reflection;

// Token: 0x02000507 RID: 1287
public static class YanSaveHelpers
{
	// Token: 0x06002111 RID: 8465 RVA: 0x001E475C File Offset: 0x001E295C
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
