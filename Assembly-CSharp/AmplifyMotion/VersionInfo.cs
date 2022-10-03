// Decompiled with JetBrains decompiler
// Type: AmplifyMotion.VersionInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

namespace AmplifyMotion
{
  [Serializable]
  public class VersionInfo
  {
    public const byte Major = 1;
    public const byte Minor = 8;
    public const byte Release = 3;
    private static string StageSuffix = "_dev001";
    private static string TrialSuffix = "";
    [SerializeField]
    private int m_major;
    [SerializeField]
    private int m_minor;
    [SerializeField]
    private int m_release;

    public static string StaticToString() => string.Format("{0}.{1}.{2}", (object) (byte) 1, (object) (byte) 8, (object) (byte) 3) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;

    public override string ToString() => string.Format("{0}.{1}.{2}", (object) this.m_major, (object) this.m_minor, (object) this.m_release) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;

    public int Number => this.m_major * 100 + this.m_minor * 10 + this.m_release;

    private VersionInfo()
    {
      this.m_major = 1;
      this.m_minor = 8;
      this.m_release = 3;
    }

    private VersionInfo(byte major, byte minor, byte release)
    {
      this.m_major = (int) major;
      this.m_minor = (int) minor;
      this.m_release = (int) release;
    }

    public static VersionInfo Current() => new VersionInfo((byte) 1, (byte) 8, (byte) 3);

    public static bool Matches(VersionInfo version) => 1 == version.m_major && 8 == version.m_minor && 3 == version.m_release;
  }
}
