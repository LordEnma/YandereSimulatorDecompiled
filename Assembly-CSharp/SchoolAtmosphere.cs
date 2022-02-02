using System;

// Token: 0x02000412 RID: 1042
public static class SchoolAtmosphere
{
	// Token: 0x170004A0 RID: 1184
	// (get) Token: 0x06001C4B RID: 7243 RVA: 0x0014AAAC File Offset: 0x00148CAC
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
