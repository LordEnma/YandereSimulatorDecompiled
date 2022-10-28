// Decompiled with JetBrains decompiler
// Type: AudioClipArrayWrapper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
