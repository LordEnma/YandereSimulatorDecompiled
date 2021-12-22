using System;
using UnityEngine;

// Token: 0x0200043D RID: 1085
public class StalkerIntroCameraScript : MonoBehaviour
{
	// Token: 0x06001CEB RID: 7403 RVA: 0x001573C8 File Offset: 0x001555C8
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

	// Token: 0x04003488 RID: 13448
	public Animation YandereAnim;

	// Token: 0x04003489 RID: 13449
	public Transform Yandere;

	// Token: 0x0400348A RID: 13450
	public float Speed;
}
