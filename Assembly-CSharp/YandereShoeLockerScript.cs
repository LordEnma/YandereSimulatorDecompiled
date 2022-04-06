using System;
using UnityEngine;

// Token: 0x020004D7 RID: 1239
public class YandereShoeLockerScript : MonoBehaviour
{
	// Token: 0x060020A6 RID: 8358 RVA: 0x001E1604 File Offset: 0x001DF804
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

	// Token: 0x060020A7 RID: 8359 RVA: 0x001E1774 File Offset: 0x001DF974
	private void UpdateShoes()
	{
		this.Yandere.Casual = this.Outdoors;
		this.Yandere.ChangeSchoolwear();
		this.Yandere.CanMove = true;
	}

	// Token: 0x040047B5 RID: 18357
	public YandereScript Yandere;

	// Token: 0x040047B6 RID: 18358
	public bool Outdoors = true;
}
