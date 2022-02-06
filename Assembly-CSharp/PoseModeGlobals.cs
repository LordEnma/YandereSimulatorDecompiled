using System;
using UnityEngine;

// Token: 0x020002F5 RID: 757
public static class PoseModeGlobals
{
	// Token: 0x17000417 RID: 1047
	// (get) Token: 0x060016DF RID: 5855 RVA: 0x000DECE4 File Offset: 0x000DCEE4
	// (set) Token: 0x060016E0 RID: 5856 RVA: 0x000DED14 File Offset: 0x000DCF14
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

	// Token: 0x17000418 RID: 1048
	// (get) Token: 0x060016E1 RID: 5857 RVA: 0x000DED44 File Offset: 0x000DCF44
	// (set) Token: 0x060016E2 RID: 5858 RVA: 0x000DED74 File Offset: 0x000DCF74
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

	// Token: 0x17000419 RID: 1049
	// (get) Token: 0x060016E3 RID: 5859 RVA: 0x000DEDA4 File Offset: 0x000DCFA4
	// (set) Token: 0x060016E4 RID: 5860 RVA: 0x000DEDD4 File Offset: 0x000DCFD4
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

	// Token: 0x060016E5 RID: 5861 RVA: 0x000DEE04 File Offset: 0x000DD004
	public static void DeleteAll()
	{
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PosePosition");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseRotation");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseScale");
	}

	// Token: 0x0400225A RID: 8794
	private const string Str_PosePosition = "PosePosition";

	// Token: 0x0400225B RID: 8795
	private const string Str_PoseRotation = "PoseRotation";

	// Token: 0x0400225C RID: 8796
	private const string Str_PoseScale = "PoseScale";
}
