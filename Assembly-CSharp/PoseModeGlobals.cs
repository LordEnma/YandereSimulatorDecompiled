using System;
using UnityEngine;

// Token: 0x020002F5 RID: 757
public static class PoseModeGlobals
{
	// Token: 0x17000416 RID: 1046
	// (get) Token: 0x060016DD RID: 5853 RVA: 0x000DEB40 File Offset: 0x000DCD40
	// (set) Token: 0x060016DE RID: 5854 RVA: 0x000DEB70 File Offset: 0x000DCD70
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
	// (get) Token: 0x060016DF RID: 5855 RVA: 0x000DEBA0 File Offset: 0x000DCDA0
	// (set) Token: 0x060016E0 RID: 5856 RVA: 0x000DEBD0 File Offset: 0x000DCDD0
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
	// (get) Token: 0x060016E1 RID: 5857 RVA: 0x000DEC00 File Offset: 0x000DCE00
	// (set) Token: 0x060016E2 RID: 5858 RVA: 0x000DEC30 File Offset: 0x000DCE30
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

	// Token: 0x060016E3 RID: 5859 RVA: 0x000DEC60 File Offset: 0x000DCE60
	public static void DeleteAll()
	{
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PosePosition");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseRotation");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseScale");
	}

	// Token: 0x04002256 RID: 8790
	private const string Str_PosePosition = "PosePosition";

	// Token: 0x04002257 RID: 8791
	private const string Str_PoseRotation = "PoseRotation";

	// Token: 0x04002258 RID: 8792
	private const string Str_PoseScale = "PoseScale";
}
