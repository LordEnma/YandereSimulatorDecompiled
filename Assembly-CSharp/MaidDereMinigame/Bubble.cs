using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059F RID: 1439
	public class Bubble : MonoBehaviour
	{
		// Token: 0x06002477 RID: 9335 RVA: 0x001FF27E File Offset: 0x001FD47E
		private void Awake()
		{
			this.foodRenderer.sprite = null;
		}

		// Token: 0x06002478 RID: 9336 RVA: 0x001FF28C File Offset: 0x001FD48C
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002479 RID: 9337 RVA: 0x001FF2AE File Offset: 0x001FD4AE
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x0600247A RID: 9338 RVA: 0x001FF2D0 File Offset: 0x001FD4D0
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

		// Token: 0x0600247B RID: 9339 RVA: 0x001FF310 File Offset: 0x001FD510
		public void BubbleReachedMax()
		{
			this.foodRenderer.gameObject.SetActive(true);
			this.foodRenderer.sprite = this.food.largeSprite;
		}

		// Token: 0x0600247C RID: 9340 RVA: 0x001FF339 File Offset: 0x001FD539
		public void BubbleClosing()
		{
			this.foodRenderer.gameObject.SetActive(false);
		}

		// Token: 0x0600247D RID: 9341 RVA: 0x001FF34C File Offset: 0x001FD54C
		public void KillBubble()
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}

		// Token: 0x04004CD5 RID: 19669
		[HideInInspector]
		public Food food;

		// Token: 0x04004CD6 RID: 19670
		public SpriteRenderer foodRenderer;
	}
}
