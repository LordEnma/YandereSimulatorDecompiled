using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000596 RID: 1430
	[RequireComponent(typeof(SpriteRenderer))]
	public class FoodInstance : MonoBehaviour
	{
		// Token: 0x0600243E RID: 9278 RVA: 0x001F9C1C File Offset: 0x001F7E1C
		private void Start()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.spriteRenderer.sprite = this.food.smallSprite;
			this.heat = this.timeToCool;
		}

		// Token: 0x0600243F RID: 9279 RVA: 0x001F9C4C File Offset: 0x001F7E4C
		private void Update()
		{
			this.heat -= Time.deltaTime;
			this.warmthMeter.SetFill(this.heat / this.timeToCool);
		}

		// Token: 0x06002440 RID: 9280 RVA: 0x001F9C78 File Offset: 0x001F7E78
		public void SetHeat(float newHeat)
		{
			this.heat = newHeat;
		}

		// Token: 0x04004C0A RID: 19466
		public Food food;

		// Token: 0x04004C0B RID: 19467
		public Meter warmthMeter;

		// Token: 0x04004C0C RID: 19468
		public float timeToCool = 30f;

		// Token: 0x04004C0D RID: 19469
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004C0E RID: 19470
		private float heat;
	}
}
