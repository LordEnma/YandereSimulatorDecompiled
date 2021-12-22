using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AB RID: 1451
	public class Timer : Meter
	{
		// Token: 0x0600248F RID: 9359 RVA: 0x001F89A7 File Offset: 0x001F6BA7
		private void Awake()
		{
			this.gameTime = GameController.Instance.activeDifficultyVariables.gameTime;
			this.starter = UnityEngine.Object.FindObjectOfType<GameStarter>();
			this.isPaused = true;
		}

		// Token: 0x06002490 RID: 9360 RVA: 0x001F89D0 File Offset: 0x001F6BD0
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x06002491 RID: 9361 RVA: 0x001F89F2 File Offset: 0x001F6BF2
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x06002492 RID: 9362 RVA: 0x001F8A14 File Offset: 0x001F6C14
		public void SetPause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x06002493 RID: 9363 RVA: 0x001F8A20 File Offset: 0x001F6C20
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

		// Token: 0x04004C3C RID: 19516
		private GameStarter starter;

		// Token: 0x04004C3D RID: 19517
		private float gameTime;

		// Token: 0x04004C3E RID: 19518
		private bool isPaused;
	}
}
