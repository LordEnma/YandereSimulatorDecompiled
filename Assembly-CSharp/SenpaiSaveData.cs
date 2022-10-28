// Decompiled with JetBrains decompiler
// Type: SenpaiSaveData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

[Serializable]
public class SenpaiSaveData
{
  public bool customSenpai;
  public string senpaiEyeColor = string.Empty;
  public int senpaiEyeWear;
  public int senpaiFacialHair;
  public string senpaiHairColor = string.Empty;
  public int senpaiHairStyle;
  public int senpaiSkinColor;

  public static SenpaiSaveData ReadFromGlobals() => new SenpaiSaveData()
  {
    customSenpai = SenpaiGlobals.CustomSenpai,
    senpaiEyeColor = SenpaiGlobals.SenpaiEyeColor,
    senpaiEyeWear = SenpaiGlobals.SenpaiEyeWear,
    senpaiFacialHair = SenpaiGlobals.SenpaiFacialHair,
    senpaiHairColor = SenpaiGlobals.SenpaiHairColor,
    senpaiHairStyle = SenpaiGlobals.SenpaiHairStyle,
    senpaiSkinColor = SenpaiGlobals.SenpaiSkinColor
  };

  public static void WriteToGlobals(SenpaiSaveData data)
  {
    SenpaiGlobals.CustomSenpai = data.customSenpai;
    SenpaiGlobals.SenpaiEyeColor = data.senpaiEyeColor;
    SenpaiGlobals.SenpaiEyeWear = data.senpaiEyeWear;
    SenpaiGlobals.SenpaiFacialHair = data.senpaiFacialHair;
    SenpaiGlobals.SenpaiHairColor = data.senpaiHairColor;
    SenpaiGlobals.SenpaiHairStyle = data.senpaiHairStyle;
    SenpaiGlobals.SenpaiSkinColor = data.senpaiSkinColor;
  }
}
