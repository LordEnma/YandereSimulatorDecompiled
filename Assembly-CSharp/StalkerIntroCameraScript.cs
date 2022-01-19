using System;
using UnityEngine;

// Token: 0x02000440 RID: 1088
public class StalkerIntroCameraScript : MonoBehaviour
{
	// Token: 0x06001CF9 RID: 7417 RVA: 0x00159830 File Offset: 0x00157A30
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

	// Token: 0x040034A9 RID: 13481
	public Animation YandereAnim;

	// Token: 0x040034AA RID: 13482
	public Transform Yandere;

	// Token: 0x040034AB RID: 13483
	public float Speed;
}
