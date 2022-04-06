using System;
using System.Reflection;

// Token: 0x02000519 RID: 1305
public static class YanSaveHelpers
{
	// Token: 0x06002181 RID: 8577 RVA: 0x001EE020 File Offset: 0x001EC220
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
