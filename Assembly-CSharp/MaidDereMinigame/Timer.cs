using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AE RID: 1454
	public class Timer : Meter
	{
		// Token: 0x060024A5 RID: 9381 RVA: 0x001FB1BF File Offset: 0x001F93BF
		private void Awake()
		{
			this.gameTime = GameController.Instance.activeDifficultyVariables.gameTime;
			this.starter = UnityEngine.Object.FindObjectOfType<GameStarter>();
			this.isPaused = true;
		}

		// Token: 0x060024A6 RID: 9382 RVA: 0x001FB1E8 File Offset: 0x001F93E8
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x060024A7 RID: 9383 RVA: 0x001FB20A File Offset: 0x001F940A
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x060024A8 RID: 9384 RVA: 0x001FB22C File Offset: 0x001F942C
		public void SetPause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x060024A9 RID: 9385 RVA: 0x001FB238 File Offset: 0x001F9438
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

		// Token: 0x04004C71 RID: 19569
		private GameStarter starter;

		// Token: 0x04004C72 RID: 19570
		private float gameTime;

		// Token: 0x04004C73 RID: 19571
		private bool isPaused;
	}
}
