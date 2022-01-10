using System;
using UnityEngine;

// Token: 0x02000473 RID: 1139
public class TitleExtrasScript : MonoBehaviour
{
	// Token: 0x06001EB1 RID: 7857 RVA: 0x001AEEA0 File Offset: 0x001AD0A0
	private void Start()
	{
		base.transform.localPosition = new Vector3(1050f, base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x06001EB2 RID: 7858 RVA: 0x001AEED8 File Offset: 0x001AD0D8
	private void Update()
	{
		if (!this.Show)
		{
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 1050f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
			return;
		}
		base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x04003F73 RID: 16243
	public bool Show;
}
