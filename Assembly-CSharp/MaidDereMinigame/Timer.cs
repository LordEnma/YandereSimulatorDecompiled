using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B0 RID: 1456
	public class Timer : Meter
	{
		// Token: 0x060024B8 RID: 9400 RVA: 0x001FC457 File Offset: 0x001FA657
		private void Awake()
		{
			this.gameTime = GameController.Instance.activeDifficultyVariables.gameTime;
			this.starter = UnityEngine.Object.FindObjectOfType<GameStarter>();
			this.isPaused = true;
		}

		// Token: 0x060024B9 RID: 9401 RVA: 0x001FC480 File Offset: 0x001FA680
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x060024BA RID: 9402 RVA: 0x001FC4A2 File Offset: 0x001FA6A2
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x060024BB RID: 9403 RVA: 0x001FC4C4 File Offset: 0x001FA6C4
		public void SetPause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x060024BC RID: 9404 RVA: 0x001FC4D0 File Offset: 0x001FA6D0
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

		// Token: 0x04004C8D RID: 19597
		private GameStarter starter;

		// Token: 0x04004C8E RID: 19598
		private float gameTime;

		// Token: 0x04004C8F RID: 19599
		private bool isPaused;
	}
}
