using System;
using UnityEngine;

// Token: 0x020002F6 RID: 758
public static class PoseModeGlobals
{
	// Token: 0x17000418 RID: 1048
	// (get) Token: 0x060016E6 RID: 5862 RVA: 0x000DEE58 File Offset: 0x000DD058
	// (set) Token: 0x060016E7 RID: 5863 RVA: 0x000DEE88 File Offset: 0x000DD088
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

	// Token: 0x17000419 RID: 1049
	// (get) Token: 0x060016E8 RID: 5864 RVA: 0x000DEEB8 File Offset: 0x000DD0B8
	// (set) Token: 0x060016E9 RID: 5865 RVA: 0x000DEEE8 File Offset: 0x000DD0E8
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

	// Token: 0x1700041A RID: 1050
	// (get) Token: 0x060016EA RID: 5866 RVA: 0x000DEF18 File Offset: 0x000DD118
	// (set) Token: 0x060016EB RID: 5867 RVA: 0x000DEF48 File Offset: 0x000DD148
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

	// Token: 0x060016EC RID: 5868 RVA: 0x000DEF78 File Offset: 0x000DD178
	public static void DeleteAll()
	{
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PosePosition");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseRotation");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseScale");
	}

	// Token: 0x04002260 RID: 8800
	private const string Str_PosePosition = "PosePosition";

	// Token: 0x04002261 RID: 8801
	private const string Str_PoseRotation = "PoseRotation";

	// Token: 0x04002262 RID: 8802
	private const string Str_PoseScale = "PoseScale";
}
