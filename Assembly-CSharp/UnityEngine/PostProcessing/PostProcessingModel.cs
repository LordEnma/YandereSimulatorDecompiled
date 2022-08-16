// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.PostProcessingModel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

namespace UnityEngine.PostProcessing
{
  [Serializable]
  public abstract class PostProcessingModel
  {
    [SerializeField]
    [GetSet("enabled")]
    private bool m_Enabled;

    public bool enabled
    {
      get => this.m_Enabled;
      set
      {
        this.m_Enabled = value;
        if (!value)
          return;
        this.OnValidate();
      }
    }

    public abstract void Reset();

    public virtual void OnValidate()
    {
    }
  }
}
