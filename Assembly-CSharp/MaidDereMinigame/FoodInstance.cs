using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000597 RID: 1431
	[RequireComponent(typeof(SpriteRenderer))]
	public class FoodInstance : MonoBehaviour
	{
		// Token: 0x0600244A RID: 9290 RVA: 0x001FA5EC File Offset: 0x001F87EC
		private void Start()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.spriteRenderer.sprite = this.food.smallSprite;
			this.heat = this.timeToCool;
		}

		// Token: 0x0600244B RID: 9291 RVA: 0x001FA61C File Offset: 0x001F881C
		private void Update()
		{
			this.heat -= Time.deltaTime;
			this.warmthMeter.SetFill(this.heat / this.timeToCool);
		}

		// Token: 0x0600244C RID: 9292 RVA: 0x001FA648 File Offset: 0x001F8848
		public void SetHeat(float newHeat)
		{
			this.heat = newHeat;
		}

		// Token: 0x04004C1C RID: 19484
		public Food food;

		// Token: 0x04004C1D RID: 19485
		public Meter warmthMeter;

		// Token: 0x04004C1E RID: 19486
		public float timeToCool = 30f;

		// Token: 0x04004C1F RID: 19487
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004C20 RID: 19488
		private float heat;
	}
}
