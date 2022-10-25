// Decompiled with JetBrains decompiler
// Type: DelinquentMaskScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DelinquentMaskScript : MonoBehaviour
{
  public MeshFilter MyRenderer;
  public Mesh[] Meshes;
  public int ID;

  private void Update()
  {
    if (!Input.GetKeyDown(KeyCode.LeftAlt))
      return;
    ++this.ID;
    if (this.ID > 4)
      this.ID = 0;
    this.MyRenderer.mesh = this.Meshes[this.ID];
  }
}
