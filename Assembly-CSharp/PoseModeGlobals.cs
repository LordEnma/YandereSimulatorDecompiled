using System;
using UnityEngine;

// Token: 0x020002F8 RID: 760
public static class PoseModeGlobals
{
	// Token: 0x17000419 RID: 1049
	// (get) Token: 0x060016FA RID: 5882 RVA: 0x000E0418 File Offset: 0x000DE618
	// (set) Token: 0x060016FB RID: 5883 RVA: 0x000E0448 File Offset: 0x000DE648
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
	// (get) Token: 0x060016FC RID: 5884 RVA: 0x000E0478 File Offset: 0x000DE678
	// (set) Token: 0x060016FD RID: 5885 RVA: 0x000E04A8 File Offset: 0x000DE6A8
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
	// (get) Token: 0x060016FE RID: 5886 RVA: 0x000E04D8 File Offset: 0x000DE6D8
	// (set) Token: 0x060016FF RID: 5887 RVA: 0x000E0508 File Offset: 0x000DE708
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

	// Token: 0x06001700 RID: 5888 RVA: 0x000E0538 File Offset: 0x000DE738
	public static void DeleteAll()
	{
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PosePosition");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseRotation");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseScale");
	}

	// Token: 0x040022A2 RID: 8866
	private const string Str_PosePosition = "PosePosition";

	// Token: 0x040022A3 RID: 8867
	private const string Str_PoseRotation = "PoseRotation";

	// Token: 0x040022A4 RID: 8868
	private const string Str_PoseScale = "PoseScale";
}
