using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000596 RID: 1430
	[RequireComponent(typeof(SpriteRenderer))]
	public class FoodInstance : MonoBehaviour
	{
		// Token: 0x0600243A RID: 9274 RVA: 0x001F937C File Offset: 0x001F757C
		private void Start()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.spriteRenderer.sprite = this.food.smallSprite;
			this.heat = this.timeToCool;
		}

		// Token: 0x0600243B RID: 9275 RVA: 0x001F93AC File Offset: 0x001F75AC
		private void Update()
		{
			this.heat -= Time.deltaTime;
			this.warmthMeter.SetFill(this.heat / this.timeToCool);
		}

		// Token: 0x0600243C RID: 9276 RVA: 0x001F93D8 File Offset: 0x001F75D8
		public void SetHeat(float newHeat)
		{
			this.heat = newHeat;
		}

		// Token: 0x04004BFF RID: 19455
		public Food food;

		// Token: 0x04004C00 RID: 19456
		public Meter warmthMeter;

		// Token: 0x04004C01 RID: 19457
		public float timeToCool = 30f;

		// Token: 0x04004C02 RID: 19458
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004C03 RID: 19459
		private float heat;
	}
}
