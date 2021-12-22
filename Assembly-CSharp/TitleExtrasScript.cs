using System;
using UnityEngine;

// Token: 0x02000471 RID: 1137
public class TitleExtrasScript : MonoBehaviour
{
	// Token: 0x06001EA4 RID: 7844 RVA: 0x001AE06C File Offset: 0x001AC26C
	private void Start()
	{
		base.transform.localPosition = new Vector3(1050f, base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x06001EA5 RID: 7845 RVA: 0x001AE0A4 File Offset: 0x001AC2A4
	private void Update()
	{
		if (!this.Show)
		{
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 1050f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
			return;
		}
		base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x04003F58 RID: 16216
	public bool Show;
}
