using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005BD RID: 1469
	public class Timer : Meter
	{
		// Token: 0x0600250A RID: 9482 RVA: 0x002047E7 File Offset: 0x002029E7
		private void Awake()
		{
			this.gameTime = GameController.Instance.activeDifficultyVariables.gameTime;
			this.starter = UnityEngine.Object.FindObjectOfType<GameStarter>();
			this.isPaused = true;
		}

		// Token: 0x0600250B RID: 9483 RVA: 0x00204810 File Offset: 0x00202A10
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x0600250C RID: 9484 RVA: 0x00204832 File Offset: 0x00202A32
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x0600250D RID: 9485 RVA: 0x00204854 File Offset: 0x00202A54
		public void SetPause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x0600250E RID: 9486 RVA: 0x00204860 File Offset: 0x00202A60
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

		// Token: 0x04004D9F RID: 19871
		private GameStarter starter;

		// Token: 0x04004DA0 RID: 19872
		private float gameTime;

		// Token: 0x04004DA1 RID: 19873
		private bool isPaused;
	}
}
