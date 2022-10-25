// Decompiled with JetBrains decompiler
// Type: LargeTextScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
