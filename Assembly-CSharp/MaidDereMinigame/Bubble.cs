using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059A RID: 1434
	public class Bubble : MonoBehaviour
	{
		// Token: 0x06002467 RID: 9319 RVA: 0x001FDA0E File Offset: 0x001FBC0E
		private void Awake()
		{
			this.foodRenderer.sprite = null;
		}

		// Token: 0x06002468 RID: 9320 RVA: 0x001FDA1C File Offset: 0x001FBC1C
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002469 RID: 9321 RVA: 0x001FDA3E File Offset: 0x001FBC3E
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x0600246A RID: 9322 RVA: 0x001FDA60 File Offset: 0x001FBC60
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

		// Token: 0x0600246B RID: 9323 RVA: 0x001FDAA0 File Offset: 0x001FBCA0
		public void BubbleReachedMax()
		{
			this.foodRenderer.gameObject.SetActive(true);
			this.foodRenderer.sprite = this.food.largeSprite;
		}

		// Token: 0x0600246C RID: 9324 RVA: 0x001FDAC9 File Offset: 0x001FBCC9
		public void BubbleClosing()
		{
			this.foodRenderer.gameObject.SetActive(false);
		}

		// Token: 0x0600246D RID: 9325 RVA: 0x001FDADC File Offset: 0x001FBCDC
		public void KillBubble()
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}

		// Token: 0x04004CA3 RID: 19619
		[HideInInspector]
		public Food food;

		// Token: 0x04004CA4 RID: 19620
		public SpriteRenderer foodRenderer;
	}
}
