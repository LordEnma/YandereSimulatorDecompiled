using System;

// Token: 0x0200040F RID: 1039
public static class SchoolAtmosphere
{
	// Token: 0x1700049F RID: 1183
	// (get) Token: 0x06001C3F RID: 7231 RVA: 0x001487F4 File Offset: 0x001469F4
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
