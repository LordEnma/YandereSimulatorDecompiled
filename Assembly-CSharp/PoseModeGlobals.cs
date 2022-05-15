using System;
using UnityEngine;

// Token: 0x020002FA RID: 762
public static class PoseModeGlobals
{
	// Token: 0x1700041A RID: 1050
	// (get) Token: 0x0600170A RID: 5898 RVA: 0x000E0F28 File Offset: 0x000DF128
	// (set) Token: 0x0600170B RID: 5899 RVA: 0x000E0F58 File Offset: 0x000DF158
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

	// Token: 0x1700041B RID: 1051
	// (get) Token: 0x0600170C RID: 5900 RVA: 0x000E0F88 File Offset: 0x000DF188
	// (set) Token: 0x0600170D RID: 5901 RVA: 0x000E0FB8 File Offset: 0x000DF1B8
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

	// Token: 0x1700041C RID: 1052
	// (get) Token: 0x0600170E RID: 5902 RVA: 0x000E0FE8 File Offset: 0x000DF1E8
	// (set) Token: 0x0600170F RID: 5903 RVA: 0x000E1018 File Offset: 0x000DF218
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

	// Token: 0x06001710 RID: 5904 RVA: 0x000E1048 File Offset: 0x000DF248
	public static void DeleteAll()
	{
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PosePosition");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseRotation");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseScale");
	}

	// Token: 0x040022B9 RID: 8889
	private const string Str_PosePosition = "PosePosition";

	// Token: 0x040022BA RID: 8890
	private const string Str_PoseRotation = "PoseRotation";

	// Token: 0x040022BB RID: 8891
	private const string Str_PoseScale = "PoseScale";
}
