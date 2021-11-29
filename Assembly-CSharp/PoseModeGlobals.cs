using System;
using UnityEngine;

// Token: 0x020002F3 RID: 755
public static class PoseModeGlobals
{
	// Token: 0x17000416 RID: 1046
	// (get) Token: 0x060016D1 RID: 5841 RVA: 0x000DD900 File Offset: 0x000DBB00
	// (set) Token: 0x060016D2 RID: 5842 RVA: 0x000DD930 File Offset: 0x000DBB30
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
	// (get) Token: 0x060016D3 RID: 5843 RVA: 0x000DD960 File Offset: 0x000DBB60
	// (set) Token: 0x060016D4 RID: 5844 RVA: 0x000DD990 File Offset: 0x000DBB90
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
	// (get) Token: 0x060016D5 RID: 5845 RVA: 0x000DD9C0 File Offset: 0x000DBBC0
	// (set) Token: 0x060016D6 RID: 5846 RVA: 0x000DD9F0 File Offset: 0x000DBBF0
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

	// Token: 0x060016D7 RID: 5847 RVA: 0x000DDA20 File Offset: 0x000DBC20
	public static void DeleteAll()
	{
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PosePosition");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseRotation");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseScale");
	}

	// Token: 0x04002227 RID: 8743
	private const string Str_PosePosition = "PosePosition";

	// Token: 0x04002228 RID: 8744
	private const string Str_PoseRotation = "PoseRotation";

	// Token: 0x04002229 RID: 8745
	private const string Str_PoseScale = "PoseScale";
}
