// Decompiled with JetBrains decompiler
// Type: RetroHeartScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
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
