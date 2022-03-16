using System;
using UnityEngine;

// Token: 0x02000443 RID: 1091
public class StalkerIntroCameraScript : MonoBehaviour
{
	// Token: 0x06001D1C RID: 7452 RVA: 0x0015C3F4 File Offset: 0x0015A5F4
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

	// Token: 0x0400351A RID: 13594
	public Animation YandereAnim;

	// Token: 0x0400351B RID: 13595
	public Transform Yandere;

	// Token: 0x0400351C RID: 13596
	public float Speed;
}
