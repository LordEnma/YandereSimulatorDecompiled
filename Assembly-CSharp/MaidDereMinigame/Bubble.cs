using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A1 RID: 1441
	public class Bubble : MonoBehaviour
	{
		// Token: 0x0600248F RID: 9359 RVA: 0x002016E6 File Offset: 0x001FF8E6
		private void Awake()
		{
			this.foodRenderer.sprite = null;
		}

		// Token: 0x06002490 RID: 9360 RVA: 0x002016F4 File Offset: 0x001FF8F4
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002491 RID: 9361 RVA: 0x00201716 File Offset: 0x001FF916
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002492 RID: 9362 RVA: 0x00201738 File Offset: 0x001FF938
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

		// Token: 0x06002493 RID: 9363 RVA: 0x00201778 File Offset: 0x001FF978
		public void BubbleReachedMax()
		{
			this.foodRenderer.gameObject.SetActive(true);
			this.foodRenderer.sprite = this.food.largeSprite;
		}

		// Token: 0x06002494 RID: 9364 RVA: 0x002017A1 File Offset: 0x001FF9A1
		public void BubbleClosing()
		{
			this.foodRenderer.gameObject.SetActive(false);
		}

		// Token: 0x06002495 RID: 9365 RVA: 0x002017B4 File Offset: 0x001FF9B4
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
