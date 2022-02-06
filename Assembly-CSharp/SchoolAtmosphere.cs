using System;

// Token: 0x02000412 RID: 1042
public static class SchoolAtmosphere
{
	// Token: 0x170004A1 RID: 1185
	// (get) Token: 0x06001C4D RID: 7245 RVA: 0x0014AD48 File Offset: 0x00148F48
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
