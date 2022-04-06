using System;

// Token: 0x02000419 RID: 1049
public static class SchoolAtmosphere
{
	// Token: 0x170004A3 RID: 1187
	// (get) Token: 0x06001C7C RID: 7292 RVA: 0x0014DCA8 File Offset: 0x0014BEA8
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
