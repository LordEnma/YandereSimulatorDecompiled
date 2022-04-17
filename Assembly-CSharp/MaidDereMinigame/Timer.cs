using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005BB RID: 1467
	public class Timer : Meter
	{
		// Token: 0x060024F5 RID: 9461 RVA: 0x00201593 File Offset: 0x001FF793
		private void Awake()
		{
			this.gameTime = GameController.Instance.activeDifficultyVariables.gameTime;
			this.starter = UnityEngine.Object.FindObjectOfType<GameStarter>();
			this.isPaused = true;
		}

		// Token: 0x060024F6 RID: 9462 RVA: 0x002015BC File Offset: 0x001FF7BC
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x060024F7 RID: 9463 RVA: 0x002015DE File Offset: 0x001FF7DE
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x060024F8 RID: 9464 RVA: 0x00201600 File Offset: 0x001FF800
		public void SetPause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x060024F9 RID: 9465 RVA: 0x0020160C File Offset: 0x001FF80C
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

		// Token: 0x04004D51 RID: 19793
		private GameStarter starter;

		// Token: 0x04004D52 RID: 19794
		private float gameTime;

		// Token: 0x04004D53 RID: 19795
		private bool isPaused;
	}
}
