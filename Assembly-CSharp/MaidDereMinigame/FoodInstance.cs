using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A4 RID: 1444
	[RequireComponent(typeof(SpriteRenderer))]
	public class FoodInstance : MonoBehaviour
	{
		// Token: 0x06002499 RID: 9369 RVA: 0x002017E4 File Offset: 0x001FF9E4
		private void Start()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.spriteRenderer.sprite = this.food.smallSprite;
			this.heat = this.timeToCool;
		}

		// Token: 0x0600249A RID: 9370 RVA: 0x00201814 File Offset: 0x001FFA14
		private void Update()
		{
			this.heat -= Time.deltaTime;
			this.warmthMeter.SetFill(this.heat / this.timeToCool);
		}

		// Token: 0x0600249B RID: 9371 RVA: 0x00201840 File Offset: 0x001FFA40
		public void SetHeat(float newHeat)
		{
			this.heat = newHeat;
		}

		// Token: 0x04004D09 RID: 19721
		public Food food;

		// Token: 0x04004D0A RID: 19722
		public Meter warmthMeter;

		// Token: 0x04004D0B RID: 19723
		public float timeToCool = 30f;

		// Token: 0x04004D0C RID: 19724
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004D0D RID: 19725
		private float heat;
	}
}
