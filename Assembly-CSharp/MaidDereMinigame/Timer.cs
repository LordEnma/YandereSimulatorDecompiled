using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005BD RID: 1469
	public class Timer : Meter
	{
		// Token: 0x06002509 RID: 9481 RVA: 0x0020427F File Offset: 0x0020247F
		private void Awake()
		{
			this.gameTime = GameController.Instance.activeDifficultyVariables.gameTime;
			this.starter = UnityEngine.Object.FindObjectOfType<GameStarter>();
			this.isPaused = true;
		}

		// Token: 0x0600250A RID: 9482 RVA: 0x002042A8 File Offset: 0x002024A8
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x0600250B RID: 9483 RVA: 0x002042CA File Offset: 0x002024CA
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x0600250C RID: 9484 RVA: 0x002042EC File Offset: 0x002024EC
		public void SetPause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x0600250D RID: 9485 RVA: 0x002042F8 File Offset: 0x002024F8
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

		// Token: 0x04004D96 RID: 19862
		private GameStarter starter;

		// Token: 0x04004D97 RID: 19863
		private float gameTime;

		// Token: 0x04004D98 RID: 19864
		private bool isPaused;
	}
}
