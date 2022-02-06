using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000596 RID: 1430
	[RequireComponent(typeof(SpriteRenderer))]
	public class FoodInstance : MonoBehaviour
	{
		// Token: 0x06002443 RID: 9283 RVA: 0x001FA138 File Offset: 0x001F8338
		private void Start()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.spriteRenderer.sprite = this.food.smallSprite;
			this.heat = this.timeToCool;
		}

		// Token: 0x06002444 RID: 9284 RVA: 0x001FA168 File Offset: 0x001F8368
		private void Update()
		{
			this.heat -= Time.deltaTime;
			this.warmthMeter.SetFill(this.heat / this.timeToCool);
		}

		// Token: 0x06002445 RID: 9285 RVA: 0x001FA194 File Offset: 0x001F8394
		public void SetHeat(float newHeat)
		{
			this.heat = newHeat;
		}

		// Token: 0x04004C13 RID: 19475
		public Food food;

		// Token: 0x04004C14 RID: 19476
		public Meter warmthMeter;

		// Token: 0x04004C15 RID: 19477
		public float timeToCool = 30f;

		// Token: 0x04004C16 RID: 19478
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004C17 RID: 19479
		private float heat;
	}
}
