using System;
using UnityEngine;

// Token: 0x02000442 RID: 1090
public class StalkerIntroCameraScript : MonoBehaviour
{
	// Token: 0x06001D0C RID: 7436 RVA: 0x0015ACC0 File Offset: 0x00158EC0
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

	// Token: 0x040034C9 RID: 13513
	public Animation YandereAnim;

	// Token: 0x040034CA RID: 13514
	public Transform Yandere;

	// Token: 0x040034CB RID: 13515
	public float Speed;
}
