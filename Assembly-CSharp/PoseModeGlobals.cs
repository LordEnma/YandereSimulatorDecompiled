using System;
using UnityEngine;

// Token: 0x020002F4 RID: 756
public static class PoseModeGlobals
{
	// Token: 0x17000416 RID: 1046
	// (get) Token: 0x060016D8 RID: 5848 RVA: 0x000DE310 File Offset: 0x000DC510
	// (set) Token: 0x060016D9 RID: 5849 RVA: 0x000DE340 File Offset: 0x000DC540
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
	// (get) Token: 0x060016DA RID: 5850 RVA: 0x000DE370 File Offset: 0x000DC570
	// (set) Token: 0x060016DB RID: 5851 RVA: 0x000DE3A0 File Offset: 0x000DC5A0
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
	// (get) Token: 0x060016DC RID: 5852 RVA: 0x000DE3D0 File Offset: 0x000DC5D0
	// (set) Token: 0x060016DD RID: 5853 RVA: 0x000DE400 File Offset: 0x000DC600
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

	// Token: 0x060016DE RID: 5854 RVA: 0x000DE430 File Offset: 0x000DC630
	public static void DeleteAll()
	{
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PosePosition");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseRotation");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseScale");
	}

	// Token: 0x0400224A RID: 8778
	private const string Str_PosePosition = "PosePosition";

	// Token: 0x0400224B RID: 8779
	private const string Str_PoseRotation = "PoseRotation";

	// Token: 0x0400224C RID: 8780
	private const string Str_PoseScale = "PoseScale";
}
