using System;
using UnityEngine;

// Token: 0x020004D6 RID: 1238
public class YandereShoeLockerScript : MonoBehaviour
{
	// Token: 0x0600209E RID: 8350 RVA: 0x001E10E4 File Offset: 0x001DF2E4
	private void Update()
	{
		if (this.Yandere.CanMove && this.Yandere.Schoolwear == 1 && !this.Yandere.ClubAttire && !this.Yandere.Egg)
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

	// Token: 0x0600209F RID: 8351 RVA: 0x001E1244 File Offset: 0x001DF444
	private void UpdateShoes()
	{
		this.Yandere.Casual = this.Outdoors;
		this.Yandere.ChangeSchoolwear();
		this.Yandere.CanMove = true;
	}

	// Token: 0x040047B1 RID: 18353
	public YandereScript Yandere;

	// Token: 0x040047B2 RID: 18354
	public bool Outdoors = true;
}
