using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AE RID: 1454
	public class Timer : Meter
	{
		// Token: 0x060024A3 RID: 9379 RVA: 0x001FAEA7 File Offset: 0x001F90A7
		private void Awake()
		{
			this.gameTime = GameController.Instance.activeDifficultyVariables.gameTime;
			this.starter = UnityEngine.Object.FindObjectOfType<GameStarter>();
			this.isPaused = true;
		}

		// Token: 0x060024A4 RID: 9380 RVA: 0x001FAED0 File Offset: 0x001F90D0
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x060024A5 RID: 9381 RVA: 0x001FAEF2 File Offset: 0x001F90F2
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x060024A6 RID: 9382 RVA: 0x001FAF14 File Offset: 0x001F9114
		public void SetPause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x060024A7 RID: 9383 RVA: 0x001FAF20 File Offset: 0x001F9120
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

		// Token: 0x04004C6B RID: 19563
		private GameStarter starter;

		// Token: 0x04004C6C RID: 19564
		private float gameTime;

		// Token: 0x04004C6D RID: 19565
		private bool isPaused;
	}
}
