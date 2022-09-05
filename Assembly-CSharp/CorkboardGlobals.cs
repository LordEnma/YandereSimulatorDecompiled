// Decompiled with JetBrains decompiler
// Type: CorkboardGlobals
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public static class CorkboardGlobals
{
  public static void DeleteAll()
  {
    for (int index = 0; index < 100; ++index)
    {
      PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardPhoto_" + index.ToString() + "_Exists", 0);
      PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardPhoto_" + index.ToString() + "_PhotoID", 0);
      PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardPhoto_" + index.ToString() + "_PositionX", 0.0f);
      PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardPhoto_" + index.ToString() + "_PositionY", 0.0f);
      PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardPhoto_" + index.ToString() + "_PositionZ", 0.0f);
      PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardPhoto_" + index.ToString() + "_RotationX", 0.0f);
      PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardPhoto_" + index.ToString() + "_RotationY", 0.0f);
      PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardPhoto_" + index.ToString() + "_RotationZ", 0.0f);
      PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardPhoto_" + index.ToString() + "_ScaleX", 0.0f);
      PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardPhoto_" + index.ToString() + "_ScaleY", 0.0f);
      PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardPhoto_" + index.ToString() + "_ScaleZ", 0.0f);
      PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardString_" + index.ToString() + "_Exists", 0);
      PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardString_" + index.ToString() + "_PositionX", 0.0f);
      PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardString_" + index.ToString() + "_PositionY", 0.0f);
      PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardString_" + index.ToString() + "_PositionZ", 0.0f);
      PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardString2_" + index.ToString() + "_PositionX", 0.0f);
      PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardString2_" + index.ToString() + "_PositionY", 0.0f);
      PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_CorkboardString2_" + index.ToString() + "_PositionZ", 0.0f);
    }
  }
}
