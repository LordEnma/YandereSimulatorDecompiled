using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059D RID: 1437
	[RequireComponent(typeof(SpriteRenderer))]
	public class FoodInstance : MonoBehaviour
	{
		// Token: 0x06002471 RID: 9329 RVA: 0x001FDB0C File Offset: 0x001FBD0C
		private void Start()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.spriteRenderer.sprite = this.food.smallSprite;
			this.heat = this.timeToCool;
		}

		// Token: 0x06002472 RID: 9330 RVA: 0x001FDB3C File Offset: 0x001FBD3C
		private void Update()
		{
			this.heat -= Time.deltaTime;
			this.warmthMeter.SetFill(this.heat / this.timeToCool);
		}

		// Token: 0x06002473 RID: 9331 RVA: 0x001FDB68 File Offset: 0x001FBD68
		public void SetHeat(float newHeat)
		{
			this.heat = newHeat;
		}

		// Token: 0x04004CA8 RID: 19624
		public Food food;

		// Token: 0x04004CA9 RID: 19625
		public Meter warmthMeter;

		// Token: 0x04004CAA RID: 19626
		public float timeToCool = 30f;

		// Token: 0x04004CAB RID: 19627
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004CAC RID: 19628
		private float heat;
	}
}
