using System;
using System.Collections.Generic;

[Serializable]
public struct YanSavePlayerPrefTracker
{
	public List<string> PrefFormatValues;

	public YanSavePlayerPrefsType PrefType;

	public string PrefFormat;

	public int RangeMax;

	public int SecondRangeMax;
}
