using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A3 RID: 1443
	[RequireComponent(typeof(SpriteRenderer))]
	public class FoodInstance : MonoBehaviour
	{
		// Token: 0x06002489 RID: 9353 RVA: 0x001FF8AC File Offset: 0x001FDAAC
		private void Start()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.spriteRenderer.sprite = this.food.smallSprite;
			this.heat = this.timeToCool;
		}

		// Token: 0x0600248A RID: 9354 RVA: 0x001FF8DC File Offset: 0x001FDADC
		private void Update()
		{
			this.heat -= Time.deltaTime;
			this.warmthMeter.SetFill(this.heat / this.timeToCool);
		}

		// Token: 0x0600248B RID: 9355 RVA: 0x001FF908 File Offset: 0x001FDB08
		public void SetHeat(float newHeat)
		{
			this.heat = newHeat;
		}

		// Token: 0x04004CDE RID: 19678
		public Food food;

		// Token: 0x04004CDF RID: 19679
		public Meter warmthMeter;

		// Token: 0x04004CE0 RID: 19680
		public float timeToCool = 30f;

		// Token: 0x04004CE1 RID: 19681
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004CE2 RID: 19682
		private float heat;
	}
}
