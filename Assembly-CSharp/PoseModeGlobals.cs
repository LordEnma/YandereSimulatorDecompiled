using System;
using UnityEngine;

// Token: 0x020002F7 RID: 759
public static class PoseModeGlobals
{
	// Token: 0x17000419 RID: 1049
	// (get) Token: 0x060016F4 RID: 5876 RVA: 0x000DFF18 File Offset: 0x000DE118
	// (set) Token: 0x060016F5 RID: 5877 RVA: 0x000DFF48 File Offset: 0x000DE148
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
	// (get) Token: 0x060016F6 RID: 5878 RVA: 0x000DFF78 File Offset: 0x000DE178
	// (set) Token: 0x060016F7 RID: 5879 RVA: 0x000DFFA8 File Offset: 0x000DE1A8
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
	// (get) Token: 0x060016F8 RID: 5880 RVA: 0x000DFFD8 File Offset: 0x000DE1D8
	// (set) Token: 0x060016F9 RID: 5881 RVA: 0x000E0008 File Offset: 0x000DE208
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

	// Token: 0x060016FA RID: 5882 RVA: 0x000E0038 File Offset: 0x000DE238
	public static void DeleteAll()
	{
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PosePosition");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseRotation");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseScale");
	}

	// Token: 0x04002294 RID: 8852
	private const string Str_PosePosition = "PosePosition";

	// Token: 0x04002295 RID: 8853
	private const string Str_PoseRotation = "PoseRotation";

	// Token: 0x04002296 RID: 8854
	private const string Str_PoseScale = "PoseScale";
}
