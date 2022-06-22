// Decompiled with JetBrains decompiler
// Type: TitleScreenOsanaScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TitleScreenOsanaScript : MonoBehaviour
{
  public NewTitleScreenScript NewTitleScreen;
  public Animation CharacterAnimation;
  public GameObject BloodPool;
  public GameObject[] DeadOsanas;

  private void Start()
  {
    if (GameGlobals.SpecificEliminationID <= 0)
      return;
    this.NewTitleScreen.ExtrasLabel.alpha = 1f;
    this.DeadOsanas[GameGlobals.SpecificEliminationID].SetActive(true);
  }
}
