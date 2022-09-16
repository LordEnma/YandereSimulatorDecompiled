// Decompiled with JetBrains decompiler
// Type: MatchmakingResultsWindowScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MatchmakingResultsWindowScript : MonoBehaviour
{
  public AdviceWindowScript AdviceWindow;

  private void Update()
  {
    if (!Input.GetButtonDown("B"))
      return;
    this.AdviceWindow.Yandere.PromptParent.gameObject.SetActive(true);
    this.AdviceWindow.HUDElement[1].SetActive(true);
    this.AdviceWindow.HUDElement[2].SetActive(true);
    this.AdviceWindow.HUDElement[3].SetActive(true);
    this.gameObject.SetActive(false);
    Time.timeScale = 1f;
  }
}
