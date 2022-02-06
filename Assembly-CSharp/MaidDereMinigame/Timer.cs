using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AE RID: 1454
	public class Timer : Meter
	{
		// Token: 0x060024A8 RID: 9384 RVA: 0x001FB3C3 File Offset: 0x001F95C3
		private void Awake()
		{
			this.gameTime = GameController.Instance.activeDifficultyVariables.gameTime;
			this.starter = UnityEngine.Object.FindObjectOfType<GameStarter>();
			this.isPaused = true;
		}

		// Token: 0x060024A9 RID: 9385 RVA: 0x001FB3EC File Offset: 0x001F95EC
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x060024AA RID: 9386 RVA: 0x001FB40E File Offset: 0x001F960E
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x060024AB RID: 9387 RVA: 0x001FB430 File Offset: 0x001F9630
		public void SetPause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x060024AC RID: 9388 RVA: 0x001FB43C File Offset: 0x001F963C
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

		// Token: 0x04004C74 RID: 19572
		private GameStarter starter;

		// Token: 0x04004C75 RID: 19573
		private float gameTime;

		// Token: 0x04004C76 RID: 19574
		private bool isPaused;
	}
}
