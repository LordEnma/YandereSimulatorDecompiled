using System;
using UnityEngine;

// Token: 0x02000476 RID: 1142
public class TitleExtrasScript : MonoBehaviour
{
	// Token: 0x06001EC9 RID: 7881 RVA: 0x001B1568 File Offset: 0x001AF768
	private void Start()
	{
		base.transform.localPosition = new Vector3(1050f, base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x06001ECA RID: 7882 RVA: 0x001B15A0 File Offset: 0x001AF7A0
	private void Update()
	{
		if (!this.Show)
		{
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 1050f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
			return;
		}
		base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x04003FA4 RID: 16292
	public bool Show;
}
