using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A0 RID: 1440
	public class Bubble : MonoBehaviour
	{
		// Token: 0x06002486 RID: 9350 RVA: 0x0020020A File Offset: 0x001FE40A
		private void Awake()
		{
			this.foodRenderer.sprite = null;
		}

		// Token: 0x06002487 RID: 9351 RVA: 0x00200218 File Offset: 0x001FE418
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002488 RID: 9352 RVA: 0x0020023A File Offset: 0x001FE43A
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002489 RID: 9353 RVA: 0x0020025C File Offset: 0x001FE45C
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

		// Token: 0x0600248A RID: 9354 RVA: 0x0020029C File Offset: 0x001FE49C
		public void BubbleReachedMax()
		{
			this.foodRenderer.gameObject.SetActive(true);
			this.foodRenderer.sprite = this.food.largeSprite;
		}

		// Token: 0x0600248B RID: 9355 RVA: 0x002002C5 File Offset: 0x001FE4C5
		public void BubbleClosing()
		{
			this.foodRenderer.gameObject.SetActive(false);
		}

		// Token: 0x0600248C RID: 9356 RVA: 0x002002D8 File Offset: 0x001FE4D8
		public void KillBubble()
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}

		// Token: 0x04004CEB RID: 19691
		[HideInInspector]
		public Food food;

		// Token: 0x04004CEC RID: 19692
		public SpriteRenderer foodRenderer;
	}
}
