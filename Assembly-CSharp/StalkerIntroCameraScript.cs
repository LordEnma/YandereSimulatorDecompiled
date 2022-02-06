using System;
using UnityEngine;

// Token: 0x02000440 RID: 1088
public class StalkerIntroCameraScript : MonoBehaviour
{
	// Token: 0x06001CFC RID: 7420 RVA: 0x00159F0C File Offset: 0x0015810C
	private void Update()
	{
		if (this.YandereAnim["f02_wallJump_00"].time > this.YandereAnim["f02_wallJump_00"].length)
		{
			this.Speed += Time.deltaTime;
			this.Yandere.position = Vector3.Lerp(this.Yandere.position, new Vector3(14.33333f, 0f, 15f), Time.deltaTime * this.Speed);
			base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(13.75f, 1.4f, 14.5f), Time.deltaTime * this.Speed);
			base.transform.eulerAngles = Vector3.Lerp(base.transform.eulerAngles, new Vector3(15f, 180f, 0f), Time.deltaTime * this.Speed);
		}
	}

	// Token: 0x040034B3 RID: 13491
	public Animation YandereAnim;

	// Token: 0x040034B4 RID: 13492
	public Transform Yandere;

	// Token: 0x040034B5 RID: 13493
	public float Speed;
}
