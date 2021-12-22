using System;
using UnityEngine;

// Token: 0x020002F4 RID: 756
public static class PoseModeGlobals
{
	// Token: 0x17000416 RID: 1046
	// (get) Token: 0x060016D8 RID: 5848 RVA: 0x000DE0C0 File Offset: 0x000DC2C0
	// (set) Token: 0x060016D9 RID: 5849 RVA: 0x000DE0F0 File Offset: 0x000DC2F0
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
	// (get) Token: 0x060016DA RID: 5850 RVA: 0x000DE120 File Offset: 0x000DC320
	// (set) Token: 0x060016DB RID: 5851 RVA: 0x000DE150 File Offset: 0x000DC350
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
	// (get) Token: 0x060016DC RID: 5852 RVA: 0x000DE180 File Offset: 0x000DC380
	// (set) Token: 0x060016DD RID: 5853 RVA: 0x000DE1B0 File Offset: 0x000DC3B0
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

	// Token: 0x060016DE RID: 5854 RVA: 0x000DE1E0 File Offset: 0x000DC3E0
	public static void DeleteAll()
	{
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PosePosition");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseRotation");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseScale");
	}

	// Token: 0x04002247 RID: 8775
	private const string Str_PosePosition = "PosePosition";

	// Token: 0x04002248 RID: 8776
	private const string Str_PoseRotation = "PoseRotation";

	// Token: 0x04002249 RID: 8777
	private const string Str_PoseScale = "PoseScale";
}
