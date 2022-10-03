// Decompiled with JetBrains decompiler
// Type: LargeTextScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
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
