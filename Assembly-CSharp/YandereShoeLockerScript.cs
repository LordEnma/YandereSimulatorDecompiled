using System;
using UnityEngine;

// Token: 0x020004D9 RID: 1241
public class YandereShoeLockerScript : MonoBehaviour
{
	// Token: 0x060020C1 RID: 8385 RVA: 0x001E4BBC File Offset: 0x001E2DBC
	private void Update()
	{
		if (this.Yandere.transform.position.y < 1f && this.Yandere.CanMove && this.Yandere.Schoolwear == 1 && !this.Yandere.ClubAttire && !this.Yandere.Egg && !this.Yandere.WearingRaincoat && !this.Yandere.CanCloak)
		{
			if (this.Outdoors)
			{
				if (this.Yandere.transform.position.x > -30f && this.Yandere.transform.position.x < 30f && this.Yandere.transform.position.z > -34f && this.Yandere.transform.position.z < 30f)
				{
					this.Outdoors = false;
					this.UpdateShoes();
					return;
				}
			}
			else if (this.Yandere.transform.position.z > 30f || (this.Yandere.transform.position.z < -34f && this.Yandere.transform.position.x > -6f && this.Yandere.transform.position.x < 6f))
			{
				this.Outdoors = true;
				this.UpdateShoes();
			}
		}
	}

	// Token: 0x060020C2 RID: 8386 RVA: 0x001E4D5C File Offset: 0x001E2F5C
	private void UpdateShoes()
	{
		int bloodiness = this.Yandere.RightFootprintSpawner.Bloodiness;
		int bloodiness2 = this.Yandere.LeftFootprintSpawner.Bloodiness;
		this.Yandere.Casual = this.Outdoors;
		this.Yandere.ChangeSchoolwear();
		this.Yandere.CanMove = true;
		this.Yandere.RightFootprintSpawner.Bloodiness = bloodiness;
		this.Yandere.LeftFootprintSpawner.Bloodiness = bloodiness2;
	}

	// Token: 0x04004803 RID: 18435
	public PromptScript Prompt;

	// Token: 0x04004804 RID: 18436
	public YandereScript Yandere;

	// Token: 0x04004805 RID: 18437
	public bool Outdoors = true;
}
