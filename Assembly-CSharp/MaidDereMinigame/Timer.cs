using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AB RID: 1451
	public class Timer : Meter
	{
		// Token: 0x06002492 RID: 9362 RVA: 0x001F8F97 File Offset: 0x001F7197
		private void Awake()
		{
			this.gameTime = GameController.Instance.activeDifficultyVariables.gameTime;
			this.starter = UnityEngine.Object.FindObjectOfType<GameStarter>();
			this.isPaused = true;
		}

		// Token: 0x06002493 RID: 9363 RVA: 0x001F8FC0 File Offset: 0x001F71C0
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x06002494 RID: 9364 RVA: 0x001F8FE2 File Offset: 0x001F71E2
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x06002495 RID: 9365 RVA: 0x001F9004 File Offset: 0x001F7204
		public void SetPause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x06002496 RID: 9366 RVA: 0x001F9010 File Offset: 0x001F7210
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

		// Token: 0x04004C45 RID: 19525
		private GameStarter starter;

		// Token: 0x04004C46 RID: 19526
		private float gameTime;

		// Token: 0x04004C47 RID: 19527
		private bool isPaused;
	}
}
