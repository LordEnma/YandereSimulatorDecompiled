// Decompiled with JetBrains decompiler
// Type: GreenRoomScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class GreenRoomScript : MonoBehaviour
{
  public QualityManagerScript QualityManager;
  public Color[] Colors;
  public Renderer[] Renderers;
  public int ID;

  private void Start()
  {
    this.QualityManager.Obscurance.enabled = false;
    this.UpdateColor();
  }

  private void Update()
  {
    if (!Input.GetKeyDown("z"))
      return;
    this.UpdateColor();
  }

  private void UpdateColor()
  {
    ++this.ID;
    if (this.ID > 7)
      this.ID = 0;
    this.Renderers[0].material.color = this.Colors[this.ID];
    this.Renderers[1].material.color = this.Colors[this.ID];
  }
}
