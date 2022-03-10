using System;
using UnityEngine;

// Token: 0x02000476 RID: 1142
public class TitleExtrasScript : MonoBehaviour
{
	// Token: 0x06001ECC RID: 7884 RVA: 0x001B1C90 File Offset: 0x001AFE90
	private void Start()
	{
		base.transform.localPosition = new Vector3(1050f, base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x06001ECD RID: 7885 RVA: 0x001B1CC8 File Offset: 0x001AFEC8
	private void Update()
	{
		if (!this.Show)
		{
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 1050f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
			return;
		}
		base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x04003FBB RID: 16315
	public bool Show;
}
