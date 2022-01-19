using System;
using UnityEngine;

// Token: 0x02000474 RID: 1140
public class TitleExtrasScript : MonoBehaviour
{
	// Token: 0x06001EB3 RID: 7859 RVA: 0x001AFB70 File Offset: 0x001ADD70
	private void Start()
	{
		base.transform.localPosition = new Vector3(1050f, base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x06001EB4 RID: 7860 RVA: 0x001AFBA8 File Offset: 0x001ADDA8
	private void Update()
	{
		if (!this.Show)
		{
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 1050f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
			return;
		}
		base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x04003F7A RID: 16250
	public bool Show;
}
