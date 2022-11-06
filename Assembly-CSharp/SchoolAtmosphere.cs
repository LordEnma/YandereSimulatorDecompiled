// Decompiled with JetBrains decompiler
// Type: SchoolAtmosphere
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
