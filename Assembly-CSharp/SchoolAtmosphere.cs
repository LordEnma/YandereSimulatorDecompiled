using System;

// Token: 0x02000418 RID: 1048
public static class SchoolAtmosphere
{
	// Token: 0x170004A3 RID: 1187
	// (get) Token: 0x06001C76 RID: 7286 RVA: 0x0014D9C4 File Offset: 0x0014BBC4
	public static SchoolAtmosphereType Type
	{
		get
		{
			float schoolAtmosphere = SchoolGlobals.SchoolAtmosphere;
			if (schoolAtmosphere > 0.6666667f)
			{
				return SchoolAtmosphereType.High;
			}
			if (schoolAtmosphere > 0.33333334f)
			{
				return SchoolAtmosphereType.Medium;
			}
			return SchoolAtmosphereType.Low;
		}
	}
}
