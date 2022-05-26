// Decompiled with JetBrains decompiler
// Type: ChangeTextureScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ChangeTextureScript : MonoBehaviour
{
  public Renderer MyRenderer;
  public Texture[] Textures;
  public int ID = 1;

  private void Update()
  {
    if (!Input.GetKeyDown(KeyCode.LeftAlt))
      return;
    ++this.ID;
    if (this.ID == this.Textures.Length)
      this.ID = 1;
    this.MyRenderer.material.mainTexture = this.Textures[this.ID];
  }
}
