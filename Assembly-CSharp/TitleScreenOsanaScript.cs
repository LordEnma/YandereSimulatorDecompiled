// Decompiled with JetBrains decompiler
// Type: TitleScreenOsanaScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
