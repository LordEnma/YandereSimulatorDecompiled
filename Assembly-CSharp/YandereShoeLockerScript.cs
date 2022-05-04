using System;
using UnityEngine;

// Token: 0x020004D8 RID: 1240
public class YandereShoeLockerScript : MonoBehaviour
{
	// Token: 0x060020B7 RID: 8375 RVA: 0x001E356C File Offset: 0x001E176C
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

	// Token: 0x060020B8 RID: 8376 RVA: 0x001E370C File Offset: 0x001E190C
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

	// Token: 0x040047DC RID: 18396
	public PromptScript Prompt;

	// Token: 0x040047DD RID: 18397
	public YandereScript Yandere;

	// Token: 0x040047DE RID: 18398
	public bool Outdoors = true;
}
