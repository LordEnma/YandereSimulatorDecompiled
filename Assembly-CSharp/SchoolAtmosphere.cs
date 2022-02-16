using System;

// Token: 0x02000413 RID: 1043
public static class SchoolAtmosphere
{
	// Token: 0x170004A2 RID: 1186
	// (get) Token: 0x06001C54 RID: 7252 RVA: 0x0014B048 File Offset: 0x00149248
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
