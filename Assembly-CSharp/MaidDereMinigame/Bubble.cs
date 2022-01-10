using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000592 RID: 1426
	public class Bubble : MonoBehaviour
	{
		// Token: 0x0600242E RID: 9262 RVA: 0x001F85AE File Offset: 0x001F67AE
		private void Awake()
		{
			this.foodRenderer.sprite = null;
		}

		// Token: 0x0600242F RID: 9263 RVA: 0x001F85BC File Offset: 0x001F67BC
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002430 RID: 9264 RVA: 0x001F85DE File Offset: 0x001F67DE
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002431 RID: 9265 RVA: 0x001F8600 File Offset: 0x001F6800
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

		// Token: 0x06002432 RID: 9266 RVA: 0x001F8640 File Offset: 0x001F6840
		public void BubbleReachedMax()
		{
			this.foodRenderer.gameObject.SetActive(true);
			this.foodRenderer.sprite = this.food.largeSprite;
		}

		// Token: 0x06002433 RID: 9267 RVA: 0x001F8669 File Offset: 0x001F6869
		public void BubbleClosing()
		{
			this.foodRenderer.gameObject.SetActive(false);
		}

		// Token: 0x06002434 RID: 9268 RVA: 0x001F867C File Offset: 0x001F687C
		public void KillBubble()
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}

		// Token: 0x04004BF3 RID: 19443
		[HideInInspector]
		public Food food;

		// Token: 0x04004BF4 RID: 19444
		public SpriteRenderer foodRenderer;
	}
}
