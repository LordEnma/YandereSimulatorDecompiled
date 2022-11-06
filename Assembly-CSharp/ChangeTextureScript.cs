// Decompiled with JetBrains decompiler
// Type: ChangeTextureScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
