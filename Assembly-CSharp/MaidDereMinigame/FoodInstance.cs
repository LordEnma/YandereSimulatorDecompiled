using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A2 RID: 1442
	[RequireComponent(typeof(SpriteRenderer))]
	public class FoodInstance : MonoBehaviour
	{
		// Token: 0x06002481 RID: 9345 RVA: 0x001FF37C File Offset: 0x001FD57C
		private void Start()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.spriteRenderer.sprite = this.food.smallSprite;
			this.heat = this.timeToCool;
		}

		// Token: 0x06002482 RID: 9346 RVA: 0x001FF3AC File Offset: 0x001FD5AC
		private void Update()
		{
			this.heat -= Time.deltaTime;
			this.warmthMeter.SetFill(this.heat / this.timeToCool);
		}

		// Token: 0x06002483 RID: 9347 RVA: 0x001FF3D8 File Offset: 0x001FD5D8
		public void SetHeat(float newHeat)
		{
			this.heat = newHeat;
		}

		// Token: 0x04004CDA RID: 19674
		public Food food;

		// Token: 0x04004CDB RID: 19675
		public Meter warmthMeter;

		// Token: 0x04004CDC RID: 19676
		public float timeToCool = 30f;

		// Token: 0x04004CDD RID: 19677
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x04004CDE RID: 19678
		private float heat;
	}
}
