using System;

// Token: 0x0200040F RID: 1039
public static class SchoolAtmosphere
{
	// Token: 0x170004A0 RID: 1184
	// (get) Token: 0x06001C41 RID: 7233 RVA: 0x00148BFC File Offset: 0x00146DFC
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
