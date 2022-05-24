using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A5 RID: 1445
	[RequireComponent(typeof(SpriteRenderer))]
	public class FoodInstance : MonoBehaviour
	{
		// Token: 0x060024A5 RID: 9381 RVA: 0x00203498 File Offset: 0x00201698
		private void Start()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.spriteRenderer.sprite = this.food.smallSprite;
			this.heat = this.timeToCool;
		}

		// Token: 0x060024A6 RID: 9382 RVA: 0x002034C8 File Offset: 0x002016C8
		private void Update()
		{
			this.heat -= Time.deltaTime;
			this.warmthMeter.SetFill(this.heat / this.timeToCool);
		}

		// Token: 0x060024A7 RID: 9383 RVA: 0x002034F4 File Offset: 0x002016F4
		public void SetHeat(float newHeat)
		{
			this.heat = newHeat;
		}

		// Token: 0x04004D39 RID: 19769
		public Food food;

		// Token: 0x04004D3A RID: 19770
		public Meter warmthMeter;

		// Token: 0x04004D3B RID: 19771
		public float timeToCool = 30f;

		// Token: 0x04004D3C RID: 19772
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004D3D RID: 19773
		private float heat;
	}
}
