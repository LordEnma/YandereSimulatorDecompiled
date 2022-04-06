using System;
using UnityEngine;

// Token: 0x0200047D RID: 1149
public class TitleExtrasScript : MonoBehaviour
{
	// Token: 0x06001EF0 RID: 7920 RVA: 0x001B4E5C File Offset: 0x001B305C
	private void Start()
	{
		base.transform.localPosition = new Vector3(1050f, base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x06001EF1 RID: 7921 RVA: 0x001B4E94 File Offset: 0x001B3094
	private void Update()
	{
		if (!this.Show)
		{
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 1050f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
			return;
		}
		base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x04004036 RID: 16438
	public bool Show;
}
