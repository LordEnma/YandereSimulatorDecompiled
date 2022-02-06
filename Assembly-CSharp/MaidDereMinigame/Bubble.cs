using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000593 RID: 1427
	public class Bubble : MonoBehaviour
	{
		// Token: 0x06002439 RID: 9273 RVA: 0x001FA03A File Offset: 0x001F823A
		private void Awake()
		{
			this.foodRenderer.sprite = null;
		}

		// Token: 0x0600243A RID: 9274 RVA: 0x001FA048 File Offset: 0x001F8248
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x0600243B RID: 9275 RVA: 0x001FA06A File Offset: 0x001F826A
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x0600243C RID: 9276 RVA: 0x001FA08C File Offset: 0x001F828C
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

		// Token: 0x0600243D RID: 9277 RVA: 0x001FA0CC File Offset: 0x001F82CC
		public void BubbleReachedMax()
		{
			this.foodRenderer.gameObject.SetActive(true);
			this.foodRenderer.sprite = this.food.largeSprite;
		}

		// Token: 0x0600243E RID: 9278 RVA: 0x001FA0F5 File Offset: 0x001F82F5
		public void BubbleClosing()
		{
			this.foodRenderer.gameObject.SetActive(false);
		}

		// Token: 0x0600243F RID: 9279 RVA: 0x001FA108 File Offset: 0x001F8308
		public void KillBubble()
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}

		// Token: 0x04004C0E RID: 19470
		[HideInInspector]
		public Food food;

		// Token: 0x04004C0F RID: 19471
		public SpriteRenderer foodRenderer;
	}
}
