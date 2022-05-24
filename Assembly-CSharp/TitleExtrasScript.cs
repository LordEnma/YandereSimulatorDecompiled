using System;
using UnityEngine;

// Token: 0x0200047F RID: 1151
public class TitleExtrasScript : MonoBehaviour
{
	// Token: 0x06001F09 RID: 7945 RVA: 0x001B82A8 File Offset: 0x001B64A8
	private void Start()
	{
		base.transform.localPosition = new Vector3(1050f, base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x06001F0A RID: 7946 RVA: 0x001B82E0 File Offset: 0x001B64E0
	private void Update()
	{
		if (!this.Show)
		{
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 1050f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
			return;
		}
		base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x04004083 RID: 16515
	public bool Show;
}
