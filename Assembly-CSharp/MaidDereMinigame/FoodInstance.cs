using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A5 RID: 1445
	[RequireComponent(typeof(SpriteRenderer))]
	public class FoodInstance : MonoBehaviour
	{
		// Token: 0x060024A4 RID: 9380 RVA: 0x00202F30 File Offset: 0x00201130
		private void Start()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.spriteRenderer.sprite = this.food.smallSprite;
			this.heat = this.timeToCool;
		}

		// Token: 0x060024A5 RID: 9381 RVA: 0x00202F60 File Offset: 0x00201160
		private void Update()
		{
			this.heat -= Time.deltaTime;
			this.warmthMeter.SetFill(this.heat / this.timeToCool);
		}

		// Token: 0x060024A6 RID: 9382 RVA: 0x00202F8C File Offset: 0x0020118C
		public void SetHeat(float newHeat)
		{
			this.heat = newHeat;
		}

		// Token: 0x04004D30 RID: 19760
		public Food food;

		// Token: 0x04004D31 RID: 19761
		public Meter warmthMeter;

		// Token: 0x04004D32 RID: 19762
		public float timeToCool = 30f;

		// Token: 0x04004D33 RID: 19763
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004D34 RID: 19764
		private float heat;
	}
}
