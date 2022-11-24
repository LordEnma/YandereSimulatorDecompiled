// Decompiled with JetBrains decompiler
// Type: SchoolAtmosphere
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

public static class SchoolAtmosphere
{
  public static SchoolAtmosphereType Type
  {
    get
    {
      float schoolAtmosphere = SchoolGlobals.SchoolAtmosphere;
      if ((double) schoolAtmosphere > 0.66666668653488159)
        return SchoolAtmosphereType.High;
      return (double) schoolAtmosphere > 0.3333333432674408 ? SchoolAtmosphereType.Medium : SchoolAtmosphereType.Low;
    }
  }
}
