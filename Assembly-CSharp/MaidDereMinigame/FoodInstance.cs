using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000598 RID: 1432
	[RequireComponent(typeof(SpriteRenderer))]
	public class FoodInstance : MonoBehaviour
	{
		// Token: 0x06002453 RID: 9299 RVA: 0x001FB1CC File Offset: 0x001F93CC
		private void Start()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.spriteRenderer.sprite = this.food.smallSprite;
			this.heat = this.timeToCool;
		}

		// Token: 0x06002454 RID: 9300 RVA: 0x001FB1FC File Offset: 0x001F93FC
		private void Update()
		{
			this.heat -= Time.deltaTime;
			this.warmthMeter.SetFill(this.heat / this.timeToCool);
		}

		// Token: 0x06002455 RID: 9301 RVA: 0x001FB228 File Offset: 0x001F9428
		public void SetHeat(float newHeat)
		{
			this.heat = newHeat;
		}

		// Token: 0x04004C2C RID: 19500
		public Food food;

		// Token: 0x04004C2D RID: 19501
		public Meter warmthMeter;

		// Token: 0x04004C2E RID: 19502
		public float timeToCool = 30f;

		// Token: 0x04004C2F RID: 19503
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004C30 RID: 19504
		private float heat;
	}
}
