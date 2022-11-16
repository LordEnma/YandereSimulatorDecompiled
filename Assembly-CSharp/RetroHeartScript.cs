// Decompiled with JetBrains decompiler
// Type: RetroHeartScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RetroHeartScript : MonoBehaviour
{
  public RetroMinigameScript RetroMinigame;

  private void OnTriggerEnter(Collider other)
  {
    this.RetroMinigame.GameOverGraphic.SetActive(true);
    this.RetroMinigame.GameOver = true;
  }
}
