using System;
using UnityEngine;

// Token: 0x020004D7 RID: 1239
public class YandereShoeLockerScript : MonoBehaviour
{
	// Token: 0x060020AD RID: 8365 RVA: 0x001E200C File Offset: 0x001E020C
	private void Update()
	{
		if (this.Yandere.CanMove && this.Yandere.Schoolwear == 1 && !this.Yandere.ClubAttire && !this.Yandere.Egg && !this.Yandere.WearingRaincoat)
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

	// Token: 0x060020AE RID: 8366 RVA: 0x001E217C File Offset: 0x001E037C
	private void UpdateShoes()
	{
		int bloodiness = this.Yandere.RightFootprintSpawner.Bloodiness = 0;
		int bloodiness2 = this.Yandere.LeftFootprintSpawner.Bloodiness = 0;
		this.Yandere.Casual = this.Outdoors;
		this.Yandere.ChangeSchoolwear();
		this.Yandere.CanMove = true;
		this.Yandere.RightFootprintSpawner.Bloodiness = bloodiness;
		this.Yandere.LeftFootprintSpawner.Bloodiness = bloodiness2;
	}

	// Token: 0x040047C6 RID: 18374
	public PromptScript Prompt;

	// Token: 0x040047C7 RID: 18375
	public YandereScript Yandere;

	// Token: 0x040047C8 RID: 18376
	public bool Outdoors = true;
}
