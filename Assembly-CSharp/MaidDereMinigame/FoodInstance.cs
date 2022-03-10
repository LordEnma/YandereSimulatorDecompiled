using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000599 RID: 1433
	[RequireComponent(typeof(SpriteRenderer))]
	public class FoodInstance : MonoBehaviour
	{
		// Token: 0x06002459 RID: 9305 RVA: 0x001FBBA4 File Offset: 0x001F9DA4
		private void Start()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.spriteRenderer.sprite = this.food.smallSprite;
			this.heat = this.timeToCool;
		}

		// Token: 0x0600245A RID: 9306 RVA: 0x001FBBD4 File Offset: 0x001F9DD4
		private void Update()
		{
			this.heat -= Time.deltaTime;
			this.warmthMeter.SetFill(this.heat / this.timeToCool);
		}

		// Token: 0x0600245B RID: 9307 RVA: 0x001FBC00 File Offset: 0x001F9E00
		public void SetHeat(float newHeat)
		{
			this.heat = newHeat;
		}

		// Token: 0x04004C49 RID: 19529
		public Food food;

		// Token: 0x04004C4A RID: 19530
		public Meter warmthMeter;

		// Token: 0x04004C4B RID: 19531
		public float timeToCool = 30f;

		// Token: 0x04004C4C RID: 19532
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004C4D RID: 19533
		private float heat;
	}
}
