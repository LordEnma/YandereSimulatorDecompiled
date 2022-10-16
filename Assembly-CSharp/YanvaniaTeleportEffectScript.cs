// Decompiled with JetBrains decompiler
// Type: YanvaniaTeleportEffectScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class YanvaniaTeleportEffectScript : MonoBehaviour
{
  public YanvaniaDraculaScript Dracula;
  public Transform SecondBeamParent;
  public Renderer SecondBeam;
  public Renderer FirstBeam;
  public bool InformedDracula;
  public float Timer;

  private void Start()
  {
    this.FirstBeam.material.color = new Color(this.FirstBeam.material.color.r, this.FirstBeam.material.color.g, this.FirstBeam.material.color.b, 0.0f);
    this.SecondBeam.material.color = new Color(this.SecondBeam.material.color.r, this.SecondBeam.material.color.g, this.SecondBeam.material.color.b, 0.0f);
    this.FirstBeam.transform.localScale = new Vector3(0.0f, this.FirstBeam.transform.localScale.y, 0.0f);
    this.SecondBeamParent.transform.localScale = new Vector3(this.SecondBeamParent.transform.localScale.x, 0.0f, this.SecondBeamParent.transform.localScale.z);
  }

  private void Update()
  {
  }
}
