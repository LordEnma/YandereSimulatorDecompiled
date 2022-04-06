using System;
using UnityEngine;

// Token: 0x020002F9 RID: 761
public static class PoseModeGlobals
{
	// Token: 0x17000419 RID: 1049
	// (get) Token: 0x06001700 RID: 5888 RVA: 0x000E0528 File Offset: 0x000DE728
	// (set) Token: 0x06001701 RID: 5889 RVA: 0x000E0558 File Offset: 0x000DE758
	public static Vector3 PosePosition
	{
		get
		{
			return GlobalsHelper.GetVector3("Profile_" + GameGlobals.Profile.ToString() + "_PosePosition");
		}
		set
		{
			GlobalsHelper.SetVector3("Profile_" + GameGlobals.Profile.ToString() + "_PosePosition", value);
		}
	}

	// Token: 0x1700041A RID: 1050
	// (get) Token: 0x06001702 RID: 5890 RVA: 0x000E0588 File Offset: 0x000DE788
	// (set) Token: 0x06001703 RID: 5891 RVA: 0x000E05B8 File Offset: 0x000DE7B8
	public static Vector3 PoseRotation
	{
		get
		{
			return GlobalsHelper.GetVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseRotation");
		}
		set
		{
			GlobalsHelper.SetVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseRotation", value);
		}
	}

	// Token: 0x1700041B RID: 1051
	// (get) Token: 0x06001704 RID: 5892 RVA: 0x000E05E8 File Offset: 0x000DE7E8
	// (set) Token: 0x06001705 RID: 5893 RVA: 0x000E0618 File Offset: 0x000DE818
	public static Vector3 PoseScale
	{
		get
		{
			return GlobalsHelper.GetVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseScale");
		}
		set
		{
			GlobalsHelper.SetVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseScale", value);
		}
	}

	// Token: 0x06001706 RID: 5894 RVA: 0x000E0648 File Offset: 0x000DE848
	public static void DeleteAll()
	{
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PosePosition");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseRotation");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseScale");
	}

	// Token: 0x040022A4 RID: 8868
	private const string Str_PosePosition = "PosePosition";

	// Token: 0x040022A5 RID: 8869
	private const string Str_PoseRotation = "PoseRotation";

	// Token: 0x040022A6 RID: 8870
	private const string Str_PoseScale = "PoseScale";
}
