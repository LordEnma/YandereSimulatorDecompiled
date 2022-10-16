// Decompiled with JetBrains decompiler
// Type: RetroHeartScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
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
