// Decompiled with JetBrains decompiler
// Type: TitleScreenOsanaScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
