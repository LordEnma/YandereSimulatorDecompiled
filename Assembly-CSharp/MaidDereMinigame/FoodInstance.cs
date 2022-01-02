using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000593 RID: 1427
	[RequireComponent(typeof(SpriteRenderer))]
	public class FoodInstance : MonoBehaviour
	{
		// Token: 0x0600242D RID: 9261 RVA: 0x001F7D0C File Offset: 0x001F5F0C
		private void Start()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.spriteRenderer.sprite = this.food.smallSprite;
			this.heat = this.timeToCool;
		}

		// Token: 0x0600242E RID: 9262 RVA: 0x001F7D3C File Offset: 0x001F5F3C
		private void Update()
		{
			this.heat -= Time.deltaTime;
			this.warmthMeter.SetFill(this.heat / this.timeToCool);
		}

		// Token: 0x0600242F RID: 9263 RVA: 0x001F7D68 File Offset: 0x001F5F68
		public void SetHeat(float newHeat)
		{
			this.heat = newHeat;
		}

		// Token: 0x04004BE4 RID: 19428
		public Food food;

		// Token: 0x04004BE5 RID: 19429
		public Meter warmthMeter;

		// Token: 0x04004BE6 RID: 19430
		public float timeToCool = 30f;

		// Token: 0x04004BE7 RID: 19431
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004BE8 RID: 19432
		private float heat;
	}
}
