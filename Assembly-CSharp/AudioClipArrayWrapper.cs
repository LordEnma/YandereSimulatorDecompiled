// Decompiled with JetBrains decompiler
// Type: AudioClipArrayWrapper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[Serializable]
public class AudioClipArrayWrapper : ArrayWrapper<AudioClip>
{
  public AudioClipArrayWrapper(int size)
    : base(size)
  {
  }

  public AudioClipArrayWrapper(AudioClip[] elements)
    : base(elements)
  {
  }
}
