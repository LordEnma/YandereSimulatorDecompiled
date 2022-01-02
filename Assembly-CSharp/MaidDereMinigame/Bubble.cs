using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000590 RID: 1424
	public class Bubble : MonoBehaviour
	{
		// Token: 0x06002423 RID: 9251 RVA: 0x001F7C0E File Offset: 0x001F5E0E
		private void Awake()
		{
			this.foodRenderer.sprite = null;
		}

		// Token: 0x06002424 RID: 9252 RVA: 0x001F7C1C File Offset: 0x001F5E1C
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002425 RID: 9253 RVA: 0x001F7C3E File Offset: 0x001F5E3E
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002426 RID: 9254 RVA: 0x001F7C60 File Offset: 0x001F5E60
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

		// Token: 0x06002427 RID: 9255 RVA: 0x001F7CA0 File Offset: 0x001F5EA0
		public void BubbleReachedMax()
		{
			this.foodRenderer.gameObject.SetActive(true);
			this.foodRenderer.sprite = this.food.largeSprite;
		}

		// Token: 0x06002428 RID: 9256 RVA: 0x001F7CC9 File Offset: 0x001F5EC9
		public void BubbleClosing()
		{
			this.foodRenderer.gameObject.SetActive(false);
		}

		// Token: 0x06002429 RID: 9257 RVA: 0x001F7CDC File Offset: 0x001F5EDC
		public void KillBubble()
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}

		// Token: 0x04004BDF RID: 19423
		[HideInInspector]
		public Food food;

		// Token: 0x04004BE0 RID: 19424
		public SpriteRenderer foodRenderer;
	}
}
