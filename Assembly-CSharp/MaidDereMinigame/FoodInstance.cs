using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000595 RID: 1429
	[RequireComponent(typeof(SpriteRenderer))]
	public class FoodInstance : MonoBehaviour
	{
		// Token: 0x06002438 RID: 9272 RVA: 0x001F86AC File Offset: 0x001F68AC
		private void Start()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.spriteRenderer.sprite = this.food.smallSprite;
			this.heat = this.timeToCool;
		}

		// Token: 0x06002439 RID: 9273 RVA: 0x001F86DC File Offset: 0x001F68DC
		private void Update()
		{
			this.heat -= Time.deltaTime;
			this.warmthMeter.SetFill(this.heat / this.timeToCool);
		}

		// Token: 0x0600243A RID: 9274 RVA: 0x001F8708 File Offset: 0x001F6908
		public void SetHeat(float newHeat)
		{
			this.heat = newHeat;
		}

		// Token: 0x04004BF8 RID: 19448
		public Food food;

		// Token: 0x04004BF9 RID: 19449
		public Meter warmthMeter;

		// Token: 0x04004BFA RID: 19450
		public float timeToCool = 30f;

		// Token: 0x04004BFB RID: 19451
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004BFC RID: 19452
		private float heat;
	}
}
