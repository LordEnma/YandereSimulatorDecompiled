using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000595 RID: 1429
	public class Bubble : MonoBehaviour
	{
		// Token: 0x06002449 RID: 9289 RVA: 0x001FB0CE File Offset: 0x001F92CE
		private void Awake()
		{
			this.foodRenderer.sprite = null;
		}

		// Token: 0x0600244A RID: 9290 RVA: 0x001FB0DC File Offset: 0x001F92DC
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x0600244B RID: 9291 RVA: 0x001FB0FE File Offset: 0x001F92FE
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x0600244C RID: 9292 RVA: 0x001FB120 File Offset: 0x001F9320
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

		// Token: 0x0600244D RID: 9293 RVA: 0x001FB160 File Offset: 0x001F9360
		public void BubbleReachedMax()
		{
			this.foodRenderer.gameObject.SetActive(true);
			this.foodRenderer.sprite = this.food.largeSprite;
		}

		// Token: 0x0600244E RID: 9294 RVA: 0x001FB189 File Offset: 0x001F9389
		public void BubbleClosing()
		{
			this.foodRenderer.gameObject.SetActive(false);
		}

		// Token: 0x0600244F RID: 9295 RVA: 0x001FB19C File Offset: 0x001F939C
		public void KillBubble()
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}

		// Token: 0x04004C27 RID: 19495
		[HideInInspector]
		public Food food;

		// Token: 0x04004C28 RID: 19496
		public SpriteRenderer foodRenderer;
	}
}
