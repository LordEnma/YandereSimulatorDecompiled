using System;
using UnityEngine;

// Token: 0x020002F9 RID: 761
public static class PoseModeGlobals
{
	// Token: 0x17000419 RID: 1049
	// (get) Token: 0x06001706 RID: 5894 RVA: 0x000E0BE0 File Offset: 0x000DEDE0
	// (set) Token: 0x06001707 RID: 5895 RVA: 0x000E0C10 File Offset: 0x000DEE10
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
	// (get) Token: 0x06001708 RID: 5896 RVA: 0x000E0C40 File Offset: 0x000DEE40
	// (set) Token: 0x06001709 RID: 5897 RVA: 0x000E0C70 File Offset: 0x000DEE70
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
	// (get) Token: 0x0600170A RID: 5898 RVA: 0x000E0CA0 File Offset: 0x000DEEA0
	// (set) Token: 0x0600170B RID: 5899 RVA: 0x000E0CD0 File Offset: 0x000DEED0
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

	// Token: 0x0600170C RID: 5900 RVA: 0x000E0D00 File Offset: 0x000DEF00
	public static void DeleteAll()
	{
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PosePosition");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseRotation");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseScale");
	}

	// Token: 0x040022AF RID: 8879
	private const string Str_PosePosition = "PosePosition";

	// Token: 0x040022B0 RID: 8880
	private const string Str_PoseRotation = "PoseRotation";

	// Token: 0x040022B1 RID: 8881
	private const string Str_PoseScale = "PoseScale";
}
