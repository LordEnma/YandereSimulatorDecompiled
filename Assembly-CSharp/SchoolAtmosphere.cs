using System;

// Token: 0x0200040E RID: 1038
public static class SchoolAtmosphere
{
	// Token: 0x1700049F RID: 1183
	// (get) Token: 0x06001C37 RID: 7223 RVA: 0x00147F18 File Offset: 0x00146118
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
