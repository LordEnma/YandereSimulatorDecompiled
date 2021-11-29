using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058E RID: 1422
	public class Bubble : MonoBehaviour
	{
		// Token: 0x0600240F RID: 9231 RVA: 0x001F5EEA File Offset: 0x001F40EA
		private void Awake()
		{
			this.foodRenderer.sprite = null;
		}

		// Token: 0x06002410 RID: 9232 RVA: 0x001F5EF8 File Offset: 0x001F40F8
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002411 RID: 9233 RVA: 0x001F5F1A File Offset: 0x001F411A
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002412 RID: 9234 RVA: 0x001F5F3C File Offset: 0x001F413C
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

		// Token: 0x06002413 RID: 9235 RVA: 0x001F5F7C File Offset: 0x001F417C
		public void BubbleReachedMax()
		{
			this.foodRenderer.gameObject.SetActive(true);
			this.foodRenderer.sprite = this.food.largeSprite;
		}

		// Token: 0x06002414 RID: 9236 RVA: 0x001F5FA5 File Offset: 0x001F41A5
		public void BubbleClosing()
		{
			this.foodRenderer.gameObject.SetActive(false);
		}

		// Token: 0x06002415 RID: 9237 RVA: 0x001F5FB8 File Offset: 0x001F41B8
		public void KillBubble()
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}

		// Token: 0x04004B97 RID: 19351
		[HideInInspector]
		public Food food;

		// Token: 0x04004B98 RID: 19352
		public SpriteRenderer foodRenderer;
	}
}
