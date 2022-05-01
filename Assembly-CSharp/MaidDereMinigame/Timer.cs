using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005BC RID: 1468
	public class Timer : Meter
	{
		// Token: 0x060024FE RID: 9470 RVA: 0x00202B33 File Offset: 0x00200D33
		private void Awake()
		{
			this.gameTime = GameController.Instance.activeDifficultyVariables.gameTime;
			this.starter = UnityEngine.Object.FindObjectOfType<GameStarter>();
			this.isPaused = true;
		}

		// Token: 0x060024FF RID: 9471 RVA: 0x00202B5C File Offset: 0x00200D5C
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x06002500 RID: 9472 RVA: 0x00202B7E File Offset: 0x00200D7E
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x06002501 RID: 9473 RVA: 0x00202BA0 File Offset: 0x00200DA0
		public void SetPause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x06002502 RID: 9474 RVA: 0x00202BAC File Offset: 0x00200DAC
		private void Update()
		{
			if (this.isPaused)
			{
				return;
			}
			this.gameTime -= Time.deltaTime;
			base.SetFill(this.gameTime / GameController.Instance.activeDifficultyVariables.gameTime);
			this.starter.SetGameTime(this.gameTime);
		}

		// Token: 0x04004D6F RID: 19823
		private GameStarter starter;

		// Token: 0x04004D70 RID: 19824
		private float gameTime;

		// Token: 0x04004D71 RID: 19825
		private bool isPaused;
	}
}
