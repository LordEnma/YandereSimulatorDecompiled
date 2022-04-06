using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A0 RID: 1440
	public class Bubble : MonoBehaviour
	{
		// Token: 0x0600247F RID: 9343 RVA: 0x001FF7AE File Offset: 0x001FD9AE
		private void Awake()
		{
			this.foodRenderer.sprite = null;
		}

		// Token: 0x06002480 RID: 9344 RVA: 0x001FF7BC File Offset: 0x001FD9BC
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002481 RID: 9345 RVA: 0x001FF7DE File Offset: 0x001FD9DE
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002482 RID: 9346 RVA: 0x001FF800 File Offset: 0x001FDA00
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

		// Token: 0x06002483 RID: 9347 RVA: 0x001FF840 File Offset: 0x001FDA40
		public void BubbleReachedMax()
		{
			this.foodRenderer.gameObject.SetActive(true);
			this.foodRenderer.sprite = this.food.largeSprite;
		}

		// Token: 0x06002484 RID: 9348 RVA: 0x001FF869 File Offset: 0x001FDA69
		public void BubbleClosing()
		{
			this.foodRenderer.gameObject.SetActive(false);
		}

		// Token: 0x06002485 RID: 9349 RVA: 0x001FF87C File Offset: 0x001FDA7C
		public void KillBubble()
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}

		// Token: 0x04004CD9 RID: 19673
		[HideInInspector]
		public Food food;

		// Token: 0x04004CDA RID: 19674
		public SpriteRenderer foodRenderer;
	}
}
