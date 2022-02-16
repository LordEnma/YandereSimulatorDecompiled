using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AF RID: 1455
	public class Timer : Meter
	{
		// Token: 0x060024AF RID: 9391 RVA: 0x001FB877 File Offset: 0x001F9A77
		private void Awake()
		{
			this.gameTime = GameController.Instance.activeDifficultyVariables.gameTime;
			this.starter = UnityEngine.Object.FindObjectOfType<GameStarter>();
			this.isPaused = true;
		}

		// Token: 0x060024B0 RID: 9392 RVA: 0x001FB8A0 File Offset: 0x001F9AA0
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x060024B1 RID: 9393 RVA: 0x001FB8C2 File Offset: 0x001F9AC2
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x060024B2 RID: 9394 RVA: 0x001FB8E4 File Offset: 0x001F9AE4
		public void SetPause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x060024B3 RID: 9395 RVA: 0x001FB8F0 File Offset: 0x001F9AF0
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

		// Token: 0x04004C7D RID: 19581
		private GameStarter starter;

		// Token: 0x04004C7E RID: 19582
		private float gameTime;

		// Token: 0x04004C7F RID: 19583
		private bool isPaused;
	}
}
