// Decompiled with JetBrains decompiler
// Type: SchoolAtmosphere
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

public static class SchoolAtmosphere
{
  public static SchoolAtmosphereType Type
  {
    get
    {
      float schoolAtmosphere = SchoolGlobals.SchoolAtmosphere;
      if ((double) schoolAtmosphere > 0.666666686534882)
        return SchoolAtmosphereType.High;
      return (double) schoolAtmosphere > 0.333333343267441 ? SchoolAtmosphereType.Medium : SchoolAtmosphereType.Low;
    }
  }
}
