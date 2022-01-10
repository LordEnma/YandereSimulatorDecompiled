using System;

// Token: 0x02000411 RID: 1041
public static class SchoolAtmosphere
{
	// Token: 0x170004A0 RID: 1184
	// (get) Token: 0x06001C48 RID: 7240 RVA: 0x00148F70 File Offset: 0x00147170
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
