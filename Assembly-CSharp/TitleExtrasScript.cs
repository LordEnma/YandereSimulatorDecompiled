using System;
using UnityEngine;

// Token: 0x02000470 RID: 1136
public class TitleExtrasScript : MonoBehaviour
{
	// Token: 0x06001E9A RID: 7834 RVA: 0x001AD2E0 File Offset: 0x001AB4E0
	private void Start()
	{
		base.transform.localPosition = new Vector3(1050f, base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x06001E9B RID: 7835 RVA: 0x001AD318 File Offset: 0x001AB518
	private void Update()
	{
		if (!this.Show)
		{
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 1050f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
			return;
		}
		base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x04003F28 RID: 16168
	public bool Show;
}
