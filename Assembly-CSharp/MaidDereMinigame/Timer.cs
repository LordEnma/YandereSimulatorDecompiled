using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AD RID: 1453
	public class Timer : Meter
	{
		// Token: 0x0600249D RID: 9373 RVA: 0x001F9937 File Offset: 0x001F7B37
		private void Awake()
		{
			this.gameTime = GameController.Instance.activeDifficultyVariables.gameTime;
			this.starter = UnityEngine.Object.FindObjectOfType<GameStarter>();
			this.isPaused = true;
		}

		// Token: 0x0600249E RID: 9374 RVA: 0x001F9960 File Offset: 0x001F7B60
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x0600249F RID: 9375 RVA: 0x001F9982 File Offset: 0x001F7B82
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x060024A0 RID: 9376 RVA: 0x001F99A4 File Offset: 0x001F7BA4
		public void SetPause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x060024A1 RID: 9377 RVA: 0x001F99B0 File Offset: 0x001F7BB0
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

		// Token: 0x04004C59 RID: 19545
		private GameStarter starter;

		// Token: 0x04004C5A RID: 19546
		private float gameTime;

		// Token: 0x04004C5B RID: 19547
		private bool isPaused;
	}
}
