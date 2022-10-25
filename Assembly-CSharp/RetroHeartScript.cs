// Decompiled with JetBrains decompiler
// Type: RetroHeartScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
