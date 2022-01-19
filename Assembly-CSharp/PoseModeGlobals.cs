using System;
using UnityEngine;

// Token: 0x020002F5 RID: 757
public static class PoseModeGlobals
{
	// Token: 0x17000416 RID: 1046
	// (get) Token: 0x060016DC RID: 5852 RVA: 0x000DE724 File Offset: 0x000DC924
	// (set) Token: 0x060016DD RID: 5853 RVA: 0x000DE754 File Offset: 0x000DC954
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
	// (get) Token: 0x060016DE RID: 5854 RVA: 0x000DE784 File Offset: 0x000DC984
	// (set) Token: 0x060016DF RID: 5855 RVA: 0x000DE7B4 File Offset: 0x000DC9B4
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
	// (get) Token: 0x060016E0 RID: 5856 RVA: 0x000DE7E4 File Offset: 0x000DC9E4
	// (set) Token: 0x060016E1 RID: 5857 RVA: 0x000DE814 File Offset: 0x000DCA14
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

	// Token: 0x060016E2 RID: 5858 RVA: 0x000DE844 File Offset: 0x000DCA44
	public static void DeleteAll()
	{
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PosePosition");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseRotation");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseScale");
	}

	// Token: 0x04002251 RID: 8785
	private const string Str_PosePosition = "PosePosition";

	// Token: 0x04002252 RID: 8786
	private const string Str_PoseRotation = "PoseRotation";

	// Token: 0x04002253 RID: 8787
	private const string Str_PoseScale = "PoseScale";
}
