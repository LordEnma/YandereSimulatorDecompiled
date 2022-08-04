// Decompiled with JetBrains decompiler
// Type: PhotoSwapperScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PhotoSwapperScript : MonoBehaviour
{
  public Renderer[] PhotoRenderer;
  public Texture[] EightiesPhoto;

  private void Start()
  {
    for (int index = 1; index < this.PhotoRenderer.Length; ++index)
      this.PhotoRenderer[index].material.mainTexture = this.EightiesPhoto[index];
  }
}
