using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000596 RID: 1430
	[RequireComponent(typeof(SpriteRenderer))]
	public class FoodInstance : MonoBehaviour
	{
		// Token: 0x06002440 RID: 9280 RVA: 0x001F9F34 File Offset: 0x001F8134
		private void Start()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.spriteRenderer.sprite = this.food.smallSprite;
			this.heat = this.timeToCool;
		}

		// Token: 0x06002441 RID: 9281 RVA: 0x001F9F64 File Offset: 0x001F8164
		private void Update()
		{
			this.heat -= Time.deltaTime;
			this.warmthMeter.SetFill(this.heat / this.timeToCool);
		}

		// Token: 0x06002442 RID: 9282 RVA: 0x001F9F90 File Offset: 0x001F8190
		public void SetHeat(float newHeat)
		{
			this.heat = newHeat;
		}

		// Token: 0x04004C10 RID: 19472
		public Food food;

		// Token: 0x04004C11 RID: 19473
		public Meter warmthMeter;

		// Token: 0x04004C12 RID: 19474
		public float timeToCool = 30f;

		// Token: 0x04004C13 RID: 19475
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004C14 RID: 19476
		private float heat;
	}
}
