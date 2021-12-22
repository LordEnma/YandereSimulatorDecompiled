using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000593 RID: 1427
	[RequireComponent(typeof(SpriteRenderer))]
	public class FoodInstance : MonoBehaviour
	{
		// Token: 0x0600242A RID: 9258 RVA: 0x001F771C File Offset: 0x001F591C
		private void Start()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.spriteRenderer.sprite = this.food.smallSprite;
			this.heat = this.timeToCool;
		}

		// Token: 0x0600242B RID: 9259 RVA: 0x001F774C File Offset: 0x001F594C
		private void Update()
		{
			this.heat -= Time.deltaTime;
			this.warmthMeter.SetFill(this.heat / this.timeToCool);
		}

		// Token: 0x0600242C RID: 9260 RVA: 0x001F7778 File Offset: 0x001F5978
		public void SetHeat(float newHeat)
		{
			this.heat = newHeat;
		}

		// Token: 0x04004BDB RID: 19419
		public Food food;

		// Token: 0x04004BDC RID: 19420
		public Meter warmthMeter;

		// Token: 0x04004BDD RID: 19421
		public float timeToCool = 30f;

		// Token: 0x04004BDE RID: 19422
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004BDF RID: 19423
		private float heat;
	}
}
