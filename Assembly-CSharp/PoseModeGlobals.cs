using System;
using UnityEngine;

// Token: 0x020002F5 RID: 757
public static class PoseModeGlobals
{
	// Token: 0x17000416 RID: 1046
	// (get) Token: 0x060016DC RID: 5852 RVA: 0x000DE638 File Offset: 0x000DC838
	// (set) Token: 0x060016DD RID: 5853 RVA: 0x000DE668 File Offset: 0x000DC868
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

	// Token: 0x17000417 RID: 1047
	// (get) Token: 0x060016DE RID: 5854 RVA: 0x000DE698 File Offset: 0x000DC898
	// (set) Token: 0x060016DF RID: 5855 RVA: 0x000DE6C8 File Offset: 0x000DC8C8
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

	// Token: 0x17000418 RID: 1048
	// (get) Token: 0x060016E0 RID: 5856 RVA: 0x000DE6F8 File Offset: 0x000DC8F8
	// (set) Token: 0x060016E1 RID: 5857 RVA: 0x000DE728 File Offset: 0x000DC928
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

	// Token: 0x060016E2 RID: 5858 RVA: 0x000DE758 File Offset: 0x000DC958
	public static void DeleteAll()
	{
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PosePosition");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseRotation");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseScale");
	}

	// Token: 0x0400224E RID: 8782
	private const string Str_PosePosition = "PosePosition";

	// Token: 0x0400224F RID: 8783
	private const string Str_PoseRotation = "PoseRotation";

	// Token: 0x04002250 RID: 8784
	private const string Str_PoseScale = "PoseScale";
}
