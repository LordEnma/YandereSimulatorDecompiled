using UnityEngine;

public static class PoseModeGlobals
{
	private const string Str_PosePosition = "PosePosition";

	private const string Str_PoseRotation = "PoseRotation";

	private const string Str_PoseScale = "PoseScale";

	public static Vector3 PosePosition
	{
		get
		{
			return GlobalsHelper.GetVector3("Profile_" + GameGlobals.Profile + "_PosePosition");
		}
		set
		{
			GlobalsHelper.SetVector3("Profile_" + GameGlobals.Profile + "_PosePosition", value);
		}
	}

	public static Vector3 PoseRotation
	{
		get
		{
			return GlobalsHelper.GetVector3("Profile_" + GameGlobals.Profile + "_PoseRotation");
		}
		set
		{
			GlobalsHelper.SetVector3("Profile_" + GameGlobals.Profile + "_PoseRotation", value);
		}
	}

	public static Vector3 PoseScale
	{
		get
		{
			return GlobalsHelper.GetVector3("Profile_" + GameGlobals.Profile + "_PoseScale");
		}
		set
		{
			GlobalsHelper.SetVector3("Profile_" + GameGlobals.Profile + "_PoseScale", value);
		}
	}

	public static void DeleteAll()
	{
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile + "_PosePosition");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile + "_PoseRotation");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile + "_PoseScale");
	}
}
