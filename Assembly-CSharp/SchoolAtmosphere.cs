using System;

// Token: 0x02000414 RID: 1044
public static class SchoolAtmosphere
{
	// Token: 0x170004A2 RID: 1186
	// (get) Token: 0x06001C5F RID: 7263 RVA: 0x0014BFFC File Offset: 0x0014A1FC
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
