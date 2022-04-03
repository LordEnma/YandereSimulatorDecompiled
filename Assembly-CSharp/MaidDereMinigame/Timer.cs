using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005BA RID: 1466
	public class Timer : Meter
	{
		// Token: 0x060024E6 RID: 9446 RVA: 0x00200607 File Offset: 0x001FE807
		private void Awake()
		{
			this.gameTime = GameController.Instance.activeDifficultyVariables.gameTime;
			this.starter = UnityEngine.Object.FindObjectOfType<GameStarter>();
			this.isPaused = true;
		}

		// Token: 0x060024E7 RID: 9447 RVA: 0x00200630 File Offset: 0x001FE830
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x060024E8 RID: 9448 RVA: 0x00200652 File Offset: 0x001FE852
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x060024E9 RID: 9449 RVA: 0x00200674 File Offset: 0x001FE874
		public void SetPause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x060024EA RID: 9450 RVA: 0x00200680 File Offset: 0x001FE880
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

		// Token: 0x04004D3B RID: 19771
		private GameStarter starter;

		// Token: 0x04004D3C RID: 19772
		private float gameTime;

		// Token: 0x04004D3D RID: 19773
		private bool isPaused;
	}
}
