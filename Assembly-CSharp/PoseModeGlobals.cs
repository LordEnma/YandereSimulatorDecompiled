using System;
using UnityEngine;

// Token: 0x020002F5 RID: 757
public static class PoseModeGlobals
{
	// Token: 0x17000416 RID: 1046
	// (get) Token: 0x060016DD RID: 5853 RVA: 0x000DEBF8 File Offset: 0x000DCDF8
	// (set) Token: 0x060016DE RID: 5854 RVA: 0x000DEC28 File Offset: 0x000DCE28
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
	// (get) Token: 0x060016DF RID: 5855 RVA: 0x000DEC58 File Offset: 0x000DCE58
	// (set) Token: 0x060016E0 RID: 5856 RVA: 0x000DEC88 File Offset: 0x000DCE88
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
	// (get) Token: 0x060016E1 RID: 5857 RVA: 0x000DECB8 File Offset: 0x000DCEB8
	// (set) Token: 0x060016E2 RID: 5858 RVA: 0x000DECE8 File Offset: 0x000DCEE8
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

	// Token: 0x060016E3 RID: 5859 RVA: 0x000DED18 File Offset: 0x000DCF18
	public static void DeleteAll()
	{
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PosePosition");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseRotation");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseScale");
	}

	// Token: 0x04002257 RID: 8791
	private const string Str_PosePosition = "PosePosition";

	// Token: 0x04002258 RID: 8792
	private const string Str_PoseRotation = "PoseRotation";

	// Token: 0x04002259 RID: 8793
	private const string Str_PoseScale = "PoseScale";
}
