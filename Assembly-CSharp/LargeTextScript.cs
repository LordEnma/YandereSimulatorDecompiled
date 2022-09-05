// Decompiled with JetBrains decompiler
// Type: LargeTextScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LargeTextScript : MonoBehaviour
{
  public UILabel Label;
  public string[] String;
  public int ID;

  private void Start() => this.Label.text = this.String[this.ID];

  private void Update()
  {
    if (!Input.GetKeyDown("space"))
      return;
    ++this.ID;
    this.Label.text = this.String[this.ID];
  }
}
