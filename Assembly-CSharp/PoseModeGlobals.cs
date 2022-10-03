// Decompiled with JetBrains decompiler
// Type: PoseModeGlobals
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public static class PoseModeGlobals
{
  private const string Str_PosePosition = "PosePosition";
  private const string Str_PoseRotation = "PoseRotation";
  private const string Str_PoseScale = "PoseScale";

  public static Vector3 PosePosition
  {
    get => GlobalsHelper.GetVector3("Profile_" + GameGlobals.Profile.ToString() + "_PosePosition");
    set => GlobalsHelper.SetVector3("Profile_" + GameGlobals.Profile.ToString() + "_PosePosition", value);
  }

  public static Vector3 PoseRotation
  {
    get => GlobalsHelper.GetVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseRotation");
    set => GlobalsHelper.SetVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseRotation", value);
  }

  public static Vector3 PoseScale
  {
    get => GlobalsHelper.GetVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseScale");
    set => GlobalsHelper.SetVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseScale", value);
  }

  public static void DeleteAll()
  {
    GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PosePosition");
    GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseRotation");
    GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseScale");
  }
}
