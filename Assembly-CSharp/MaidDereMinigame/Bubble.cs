using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A2 RID: 1442
	public class Bubble : MonoBehaviour
	{
		// Token: 0x0600249A RID: 9370 RVA: 0x00202E32 File Offset: 0x00201032
		private void Awake()
		{
			this.foodRenderer.sprite = null;
		}

		// Token: 0x0600249B RID: 9371 RVA: 0x00202E40 File Offset: 0x00201040
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x0600249C RID: 9372 RVA: 0x00202E62 File Offset: 0x00201062
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x0600249D RID: 9373 RVA: 0x00202E84 File Offset: 0x00201084
		public void Pause(bool toPause)
		{
			if (toPause)
			{
				base.GetComponent<SpriteRenderer>().enabled = false;
				this.foodRenderer.gameObject.SetActive(false);
				return;
			}
			base.GetComponent<SpriteRenderer>().enabled = true;
			this.foodRenderer.gameObject.SetActive(true);
		}

		// Token: 0x0600249E RID: 9374 RVA: 0x00202EC4 File Offset: 0x002010C4
		public void BubbleReachedMax()
		{
			this.foodRenderer.gameObject.SetActive(true);
			this.foodRenderer.sprite = this.food.largeSprite;
		}

		// Token: 0x0600249F RID: 9375 RVA: 0x00202EED File Offset: 0x002010ED
		public void BubbleClosing()
		{
			this.foodRenderer.gameObject.SetActive(false);
		}

		// Token: 0x060024A0 RID: 9376 RVA: 0x00202F00 File Offset: 0x00201100
		public void KillBubble()
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}

		// Token: 0x04004D2B RID: 19755
		[HideInInspector]
		public Food food;

		// Token: 0x04004D2C RID: 19756
		public SpriteRenderer foodRenderer;
	}
}
