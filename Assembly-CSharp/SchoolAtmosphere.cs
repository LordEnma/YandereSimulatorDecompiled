public static class SchoolAtmosphere
{
	public static SchoolAtmosphereType Type
	{
		get
		{
			float schoolAtmosphere = SchoolGlobals.SchoolAtmosphere;
			if (schoolAtmosphere > 2f / 3f)
			{
				return SchoolAtmosphereType.High;
			}
			if (schoolAtmosphere > 1f / 3f)
			{
				return SchoolAtmosphereType.Medium;
			}
			return SchoolAtmosphereType.Low;
		}
	}
}
