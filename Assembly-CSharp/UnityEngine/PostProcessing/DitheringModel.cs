// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.DitheringModel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;

namespace UnityEngine.PostProcessing
{
  [Serializable]
  public class DitheringModel : PostProcessingModel
  {
    [SerializeField]
    private DitheringModel.Settings m_Settings = DitheringModel.Settings.defaultSettings;

    public DitheringModel.Settings settings
    {
      get => this.m_Settings;
      set => this.m_Settings = value;
    }

    public override void Reset() => this.m_Settings = DitheringModel.Settings.defaultSettings;

    [Serializable]
    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct Settings
    {
      public static DitheringModel.Settings defaultSettings => new DitheringModel.Settings();
    }
  }
}
