using System;
using UnityEngine;

// Token: 0x02000474 RID: 1140
public class TitleExtrasScript : MonoBehaviour
{
	// Token: 0x06001EB6 RID: 7862 RVA: 0x001B0354 File Offset: 0x001AE554
	private void Start()
	{
		base.transform.localPosition = new Vector3(1050f, base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x06001EB7 RID: 7863 RVA: 0x001B038C File Offset: 0x001AE58C
	private void Update()
	{
		if (!this.Show)
		{
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 1050f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
			return;
		}
		base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x04003F88 RID: 16264
	public bool Show;
}
