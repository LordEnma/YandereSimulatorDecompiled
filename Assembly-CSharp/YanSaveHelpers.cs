using System;
using System.Reflection;

// Token: 0x0200051A RID: 1306
public static class YanSaveHelpers
{
	// Token: 0x06002192 RID: 8594 RVA: 0x001F0004 File Offset: 0x001EE204
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
