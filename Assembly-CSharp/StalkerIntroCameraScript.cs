using System;
using UnityEngine;

// Token: 0x02000446 RID: 1094
public class StalkerIntroCameraScript : MonoBehaviour
{
	// Token: 0x06001D26 RID: 7462 RVA: 0x0015CF88 File Offset: 0x0015B188
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

	// Token: 0x04003537 RID: 13623
	public Animation YandereAnim;

	// Token: 0x04003538 RID: 13624
	public Transform Yandere;

	// Token: 0x04003539 RID: 13625
	public float Speed;
}
