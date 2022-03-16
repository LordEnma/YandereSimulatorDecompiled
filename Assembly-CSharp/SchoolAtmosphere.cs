using System;

// Token: 0x02000415 RID: 1045
public static class SchoolAtmosphere
{
	// Token: 0x170004A3 RID: 1187
	// (get) Token: 0x06001C6C RID: 7276 RVA: 0x0014CEA0 File Offset: 0x0014B0A0
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
