using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A9 RID: 1449
	public class Timer : Meter
	{
		// Token: 0x0600247E RID: 9342 RVA: 0x001F7273 File Offset: 0x001F5473
		private void Awake()
		{
			this.gameTime = GameController.Instance.activeDifficultyVariables.gameTime;
			this.starter = UnityEngine.Object.FindObjectOfType<GameStarter>();
			this.isPaused = true;
		}

		// Token: 0x0600247F RID: 9343 RVA: 0x001F729C File Offset: 0x001F549C
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x06002480 RID: 9344 RVA: 0x001F72BE File Offset: 0x001F54BE
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x06002481 RID: 9345 RVA: 0x001F72E0 File Offset: 0x001F54E0
		public void SetPause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x06002482 RID: 9346 RVA: 0x001F72EC File Offset: 0x001F54EC
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

		// Token: 0x04004BFD RID: 19453
		private GameStarter starter;

		// Token: 0x04004BFE RID: 19454
		private float gameTime;

		// Token: 0x04004BFF RID: 19455
		private bool isPaused;
	}
}
