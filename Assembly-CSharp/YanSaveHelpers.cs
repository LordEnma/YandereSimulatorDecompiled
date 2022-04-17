using System;
using System.Reflection;

// Token: 0x02000519 RID: 1305
public static class YanSaveHelpers
{
	// Token: 0x06002188 RID: 8584 RVA: 0x001EEA7C File Offset: 0x001ECC7C
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
