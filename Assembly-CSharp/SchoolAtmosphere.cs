using System;

// Token: 0x0200041A RID: 1050
public static class SchoolAtmosphere
{
	// Token: 0x170004A4 RID: 1188
	// (get) Token: 0x06001C87 RID: 7303 RVA: 0x0014E8F4 File Offset: 0x0014CAF4
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
