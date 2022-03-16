using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B5 RID: 1461
	public class Timer : Meter
	{
		// Token: 0x060024D6 RID: 9430 RVA: 0x001FED97 File Offset: 0x001FCF97
		private void Awake()
		{
			this.gameTime = GameController.Instance.activeDifficultyVariables.gameTime;
			this.starter = UnityEngine.Object.FindObjectOfType<GameStarter>();
			this.isPaused = true;
		}

		// Token: 0x060024D7 RID: 9431 RVA: 0x001FEDC0 File Offset: 0x001FCFC0
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x060024D8 RID: 9432 RVA: 0x001FEDE2 File Offset: 0x001FCFE2
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x060024D9 RID: 9433 RVA: 0x001FEE04 File Offset: 0x001FD004
		public void SetPause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x060024DA RID: 9434 RVA: 0x001FEE10 File Offset: 0x001FD010
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

		// Token: 0x04004D09 RID: 19721
		private GameStarter starter;

		// Token: 0x04004D0A RID: 19722
		private float gameTime;

		// Token: 0x04004D0B RID: 19723
		private bool isPaused;
	}
}
