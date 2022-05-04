using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005BC RID: 1468
	public class Timer : Meter
	{
		// Token: 0x060024FF RID: 9471 RVA: 0x00202C2F File Offset: 0x00200E2F
		private void Awake()
		{
			this.gameTime = GameController.Instance.activeDifficultyVariables.gameTime;
			this.starter = UnityEngine.Object.FindObjectOfType<GameStarter>();
			this.isPaused = true;
		}

		// Token: 0x06002500 RID: 9472 RVA: 0x00202C58 File Offset: 0x00200E58
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x06002501 RID: 9473 RVA: 0x00202C7A File Offset: 0x00200E7A
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x06002502 RID: 9474 RVA: 0x00202C9C File Offset: 0x00200E9C
		public void SetPause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x06002503 RID: 9475 RVA: 0x00202CA8 File Offset: 0x00200EA8
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
