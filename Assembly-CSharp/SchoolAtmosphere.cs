using System;

// Token: 0x0200041B RID: 1051
public static class SchoolAtmosphere
{
	// Token: 0x170004A5 RID: 1189
	// (get) Token: 0x06001C8D RID: 7309 RVA: 0x0014F574 File Offset: 0x0014D774
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
