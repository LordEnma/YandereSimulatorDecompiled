using System;
using UnityEngine;

// Token: 0x020004D9 RID: 1241
public class YandereShoeLockerScript : MonoBehaviour
{
	// Token: 0x060020C2 RID: 8386 RVA: 0x001E5124 File Offset: 0x001E3324
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

	// Token: 0x060020C3 RID: 8387 RVA: 0x001E52C4 File Offset: 0x001E34C4
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

	// Token: 0x0400480C RID: 18444
	public PromptScript Prompt;

	// Token: 0x0400480D RID: 18445
	public YandereScript Yandere;

	// Token: 0x0400480E RID: 18446
	public bool Outdoors = true;
}
