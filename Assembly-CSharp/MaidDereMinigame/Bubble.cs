using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A1 RID: 1441
	public class Bubble : MonoBehaviour
	{
		// Token: 0x06002490 RID: 9360 RVA: 0x002017E2 File Offset: 0x001FF9E2
		private void Awake()
		{
			this.foodRenderer.sprite = null;
		}

		// Token: 0x06002491 RID: 9361 RVA: 0x002017F0 File Offset: 0x001FF9F0
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002492 RID: 9362 RVA: 0x00201812 File Offset: 0x001FFA12
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002493 RID: 9363 RVA: 0x00201834 File Offset: 0x001FFA34
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

		// Token: 0x06002494 RID: 9364 RVA: 0x00201874 File Offset: 0x001FFA74
		public void BubbleReachedMax()
		{
			this.foodRenderer.gameObject.SetActive(true);
			this.foodRenderer.sprite = this.food.largeSprite;
		}

		// Token: 0x06002495 RID: 9365 RVA: 0x0020189D File Offset: 0x001FFA9D
		public void BubbleClosing()
		{
			this.foodRenderer.gameObject.SetActive(false);
		}

		// Token: 0x06002496 RID: 9366 RVA: 0x002018B0 File Offset: 0x001FFAB0
		public void KillBubble()
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}

		// Token: 0x04004D04 RID: 19716
		[HideInInspector]
		public Food food;

		// Token: 0x04004D05 RID: 19717
		public SpriteRenderer foodRenderer;
	}
}
