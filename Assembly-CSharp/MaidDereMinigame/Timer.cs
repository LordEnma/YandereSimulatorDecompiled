using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005BB RID: 1467
	public class Timer : Meter
	{
		// Token: 0x060024EE RID: 9454 RVA: 0x00200B37 File Offset: 0x001FED37
		private void Awake()
		{
			this.gameTime = GameController.Instance.activeDifficultyVariables.gameTime;
			this.starter = UnityEngine.Object.FindObjectOfType<GameStarter>();
			this.isPaused = true;
		}

		// Token: 0x060024EF RID: 9455 RVA: 0x00200B60 File Offset: 0x001FED60
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x060024F0 RID: 9456 RVA: 0x00200B82 File Offset: 0x001FED82
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x060024F1 RID: 9457 RVA: 0x00200BA4 File Offset: 0x001FEDA4
		public void SetPause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x060024F2 RID: 9458 RVA: 0x00200BB0 File Offset: 0x001FEDB0
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

		// Token: 0x04004D3F RID: 19775
		private GameStarter starter;

		// Token: 0x04004D40 RID: 19776
		private float gameTime;

		// Token: 0x04004D41 RID: 19777
		private bool isPaused;
	}
}
