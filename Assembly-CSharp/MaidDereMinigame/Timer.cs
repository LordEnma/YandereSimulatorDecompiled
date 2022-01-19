using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AE RID: 1454
	public class Timer : Meter
	{
		// Token: 0x0600249F RID: 9375 RVA: 0x001FA607 File Offset: 0x001F8807
		private void Awake()
		{
			this.gameTime = GameController.Instance.activeDifficultyVariables.gameTime;
			this.starter = UnityEngine.Object.FindObjectOfType<GameStarter>();
			this.isPaused = true;
		}

		// Token: 0x060024A0 RID: 9376 RVA: 0x001FA630 File Offset: 0x001F8830
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x060024A1 RID: 9377 RVA: 0x001FA652 File Offset: 0x001F8852
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x060024A2 RID: 9378 RVA: 0x001FA674 File Offset: 0x001F8874
		public void SetPause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x060024A3 RID: 9379 RVA: 0x001FA680 File Offset: 0x001F8880
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

		// Token: 0x04004C60 RID: 19552
		private GameStarter starter;

		// Token: 0x04004C61 RID: 19553
		private float gameTime;

		// Token: 0x04004C62 RID: 19554
		private bool isPaused;
	}
}
