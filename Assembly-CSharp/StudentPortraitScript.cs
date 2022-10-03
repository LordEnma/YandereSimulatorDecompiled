// Decompiled with JetBrains decompiler
// Type: StudentPortraitScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class StudentPortraitScript : MonoBehaviour
{
  public GameObject DeathShadow;
  public GameObject PrisonBars;
  public GameObject Panties;
  public GameObject Friend;
  public UITexture Portrait;

  private void Start()
  {
    this.DeathShadow.SetActive(false);
    this.PrisonBars.SetActive(false);
    this.Panties.SetActive(false);
    this.Friend.SetActive(false);
  }
}
