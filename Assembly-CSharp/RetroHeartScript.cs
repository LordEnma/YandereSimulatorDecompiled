// Decompiled with JetBrains decompiler
// Type: RetroHeartScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
