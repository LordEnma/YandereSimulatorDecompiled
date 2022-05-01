using System;
using UnityEngine;

// Token: 0x0200047E RID: 1150
public class TitleExtrasScript : MonoBehaviour
{
	// Token: 0x06001EFF RID: 7935 RVA: 0x001B6BA4 File Offset: 0x001B4DA4
	private void Start()
	{
		base.transform.localPosition = new Vector3(1050f, base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x06001F00 RID: 7936 RVA: 0x001B6BDC File Offset: 0x001B4DDC
	private void Update()
	{
		if (!this.Show)
		{
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 1050f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
			return;
		}
		base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x0400405C RID: 16476
	public bool Show;
}
