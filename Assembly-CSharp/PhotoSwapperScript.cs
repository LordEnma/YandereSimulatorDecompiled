// Decompiled with JetBrains decompiler
// Type: PhotoSwapperScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
