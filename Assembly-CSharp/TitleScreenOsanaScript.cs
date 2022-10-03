// Decompiled with JetBrains decompiler
// Type: TitleScreenOsanaScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TitleScreenOsanaScript : MonoBehaviour
{
  public NewTitleScreenScript NewTitleScreen;
  public Animation SuicideCorpseAnimation;
  public Animation SuicideHairAnimation;
  public GameObject BloodPool;
  public GameObject[] DeadOsanas;

  private void Start()
  {
    this.SuicideCorpseAnimation["SwingingOsana"].speed = 0.5f;
    this.SuicideHairAnimation["OsanaHairSwing"].speed = 0.5f;
    if (GameGlobals.SpecificEliminationID <= 0)
      return;
    this.NewTitleScreen.ExtrasLabel.alpha = 1f;
    this.DeadOsanas[GameGlobals.SpecificEliminationID].SetActive(true);
  }
}
