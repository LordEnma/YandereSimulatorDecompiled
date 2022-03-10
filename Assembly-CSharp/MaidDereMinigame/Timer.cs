using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B1 RID: 1457
	public class Timer : Meter
	{
		// Token: 0x060024BE RID: 9406 RVA: 0x001FCE2F File Offset: 0x001FB02F
		private void Awake()
		{
			this.gameTime = GameController.Instance.activeDifficultyVariables.gameTime;
			this.starter = UnityEngine.Object.FindObjectOfType<GameStarter>();
			this.isPaused = true;
		}

		// Token: 0x060024BF RID: 9407 RVA: 0x001FCE58 File Offset: 0x001FB058
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x060024C0 RID: 9408 RVA: 0x001FCE7A File Offset: 0x001FB07A
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x060024C1 RID: 9409 RVA: 0x001FCE9C File Offset: 0x001FB09C
		public void SetPause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x060024C2 RID: 9410 RVA: 0x001FCEA8 File Offset: 0x001FB0A8
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

		// Token: 0x04004CAA RID: 19626
		private GameStarter starter;

		// Token: 0x04004CAB RID: 19627
		private float gameTime;

		// Token: 0x04004CAC RID: 19628
		private bool isPaused;
	}
}
