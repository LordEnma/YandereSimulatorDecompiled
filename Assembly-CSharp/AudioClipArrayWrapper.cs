// Decompiled with JetBrains decompiler
// Type: AudioClipArrayWrapper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
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
