// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.Timer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace MaidDereMinigame
{
  public class Timer : Meter
  {
    private GameStarter starter;
    private float gameTime;
    private bool isPaused;

    private void Awake()
    {
      this.gameTime = GameController.Instance.activeDifficultyVariables.gameTime;
      this.starter = Object.FindObjectOfType<GameStarter>();
      this.isPaused = true;
    }

    private void OnEnable() => GameController.PauseGame += new BoolParameterEvent(this.SetPause);

    private void OnDisable() => GameController.PauseGame -= new BoolParameterEvent(this.SetPause);

    public void SetPause(bool toPause) => this.isPaused = toPause;

    private void Update()
    {
      if (this.isPaused)
        return;
      this.gameTime -= Time.deltaTime;
      this.SetFill(this.gameTime / GameController.Instance.activeDifficultyVariables.gameTime);
      this.starter.SetGameTime(this.gameTime);
    }
  }
}
