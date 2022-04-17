using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A3 RID: 1443
	[RequireComponent(typeof(SpriteRenderer))]
	public class FoodInstance : MonoBehaviour
	{
		// Token: 0x06002490 RID: 9360 RVA: 0x00200308 File Offset: 0x001FE508
		private void Start()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.spriteRenderer.sprite = this.food.smallSprite;
			this.heat = this.timeToCool;
		}

		// Token: 0x06002491 RID: 9361 RVA: 0x00200338 File Offset: 0x001FE538
		private void Update()
		{
			this.heat -= Time.deltaTime;
			this.warmthMeter.SetFill(this.heat / this.timeToCool);
		}

		// Token: 0x06002492 RID: 9362 RVA: 0x00200364 File Offset: 0x001FE564
		public void SetHeat(float newHeat)
		{
			this.heat = newHeat;
		}

		// Token: 0x04004CF0 RID: 19696
		public Food food;

		// Token: 0x04004CF1 RID: 19697
		public Meter warmthMeter;

		// Token: 0x04004CF2 RID: 19698
		public float timeToCool = 30f;

		// Token: 0x04004CF3 RID: 19699
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004CF4 RID: 19700
		private float heat;
	}
}
