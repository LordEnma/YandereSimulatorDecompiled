using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000593 RID: 1427
	public class Bubble : MonoBehaviour
	{
		// Token: 0x06002436 RID: 9270 RVA: 0x001F9E36 File Offset: 0x001F8036
		private void Awake()
		{
			this.foodRenderer.sprite = null;
		}

		// Token: 0x06002437 RID: 9271 RVA: 0x001F9E44 File Offset: 0x001F8044
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002438 RID: 9272 RVA: 0x001F9E66 File Offset: 0x001F8066
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002439 RID: 9273 RVA: 0x001F9E88 File Offset: 0x001F8088
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

		// Token: 0x0600243A RID: 9274 RVA: 0x001F9EC8 File Offset: 0x001F80C8
		public void BubbleReachedMax()
		{
			this.foodRenderer.gameObject.SetActive(true);
			this.foodRenderer.sprite = this.food.largeSprite;
		}

		// Token: 0x0600243B RID: 9275 RVA: 0x001F9EF1 File Offset: 0x001F80F1
		public void BubbleClosing()
		{
			this.foodRenderer.gameObject.SetActive(false);
		}

		// Token: 0x0600243C RID: 9276 RVA: 0x001F9F04 File Offset: 0x001F8104
		public void KillBubble()
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}

		// Token: 0x04004C0B RID: 19467
		[HideInInspector]
		public Food food;

		// Token: 0x04004C0C RID: 19468
		public SpriteRenderer foodRenderer;
	}
}
