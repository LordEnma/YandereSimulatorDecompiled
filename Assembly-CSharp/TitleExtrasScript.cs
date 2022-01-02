using System;
using UnityEngine;

// Token: 0x02000471 RID: 1137
public class TitleExtrasScript : MonoBehaviour
{
	// Token: 0x06001EA6 RID: 7846 RVA: 0x001AE520 File Offset: 0x001AC720
	private void Start()
	{
		base.transform.localPosition = new Vector3(1050f, base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x06001EA7 RID: 7847 RVA: 0x001AE558 File Offset: 0x001AC758
	private void Update()
	{
		if (!this.Show)
		{
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 1050f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
			return;
		}
		base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x04003F5F RID: 16223
	public bool Show;
}
