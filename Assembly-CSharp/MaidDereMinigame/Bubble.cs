using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000590 RID: 1424
	public class Bubble : MonoBehaviour
	{
		// Token: 0x06002420 RID: 9248 RVA: 0x001F761E File Offset: 0x001F581E
		private void Awake()
		{
			this.foodRenderer.sprite = null;
		}

		// Token: 0x06002421 RID: 9249 RVA: 0x001F762C File Offset: 0x001F582C
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002422 RID: 9250 RVA: 0x001F764E File Offset: 0x001F584E
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002423 RID: 9251 RVA: 0x001F7670 File Offset: 0x001F5870
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

		// Token: 0x06002424 RID: 9252 RVA: 0x001F76B0 File Offset: 0x001F58B0
		public void BubbleReachedMax()
		{
			this.foodRenderer.gameObject.SetActive(true);
			this.foodRenderer.sprite = this.food.largeSprite;
		}

		// Token: 0x06002425 RID: 9253 RVA: 0x001F76D9 File Offset: 0x001F58D9
		public void BubbleClosing()
		{
			this.foodRenderer.gameObject.SetActive(false);
		}

		// Token: 0x06002426 RID: 9254 RVA: 0x001F76EC File Offset: 0x001F58EC
		public void KillBubble()
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}

		// Token: 0x04004BD6 RID: 19414
		[HideInInspector]
		public Food food;

		// Token: 0x04004BD7 RID: 19415
		public SpriteRenderer foodRenderer;
	}
}
