using System;
using UnityEngine;

// Token: 0x020002F9 RID: 761
public static class PoseModeGlobals
{
	// Token: 0x17000419 RID: 1049
	// (get) Token: 0x06001702 RID: 5890 RVA: 0x000E0710 File Offset: 0x000DE910
	// (set) Token: 0x06001703 RID: 5891 RVA: 0x000E0740 File Offset: 0x000DE940
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
	// (get) Token: 0x06001704 RID: 5892 RVA: 0x000E0770 File Offset: 0x000DE970
	// (set) Token: 0x06001705 RID: 5893 RVA: 0x000E07A0 File Offset: 0x000DE9A0
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
	// (get) Token: 0x06001706 RID: 5894 RVA: 0x000E07D0 File Offset: 0x000DE9D0
	// (set) Token: 0x06001707 RID: 5895 RVA: 0x000E0800 File Offset: 0x000DEA00
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

	// Token: 0x06001708 RID: 5896 RVA: 0x000E0830 File Offset: 0x000DEA30
	public static void DeleteAll()
	{
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PosePosition");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseRotation");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseScale");
	}

	// Token: 0x040022A6 RID: 8870
	private const string Str_PosePosition = "PosePosition";

	// Token: 0x040022A7 RID: 8871
	private const string Str_PoseRotation = "PoseRotation";

	// Token: 0x040022A8 RID: 8872
	private const string Str_PoseScale = "PoseScale";
}
