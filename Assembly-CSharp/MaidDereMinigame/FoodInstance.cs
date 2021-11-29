using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000591 RID: 1425
	[RequireComponent(typeof(SpriteRenderer))]
	public class FoodInstance : MonoBehaviour
	{
		// Token: 0x06002419 RID: 9241 RVA: 0x001F5FE8 File Offset: 0x001F41E8
		private void Start()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.spriteRenderer.sprite = this.food.smallSprite;
			this.heat = this.timeToCool;
		}

		// Token: 0x0600241A RID: 9242 RVA: 0x001F6018 File Offset: 0x001F4218
		private void Update()
		{
			this.heat -= Time.deltaTime;
			this.warmthMeter.SetFill(this.heat / this.timeToCool);
		}

		// Token: 0x0600241B RID: 9243 RVA: 0x001F6044 File Offset: 0x001F4244
		public void SetHeat(float newHeat)
		{
			this.heat = newHeat;
		}

		// Token: 0x04004B9C RID: 19356
		public Food food;

		// Token: 0x04004B9D RID: 19357
		public Meter warmthMeter;

		// Token: 0x04004B9E RID: 19358
		public float timeToCool = 30f;

		// Token: 0x04004B9F RID: 19359
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004BA0 RID: 19360
		private float heat;
	}
}
