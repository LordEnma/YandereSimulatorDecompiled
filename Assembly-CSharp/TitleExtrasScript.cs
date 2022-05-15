using System;
using UnityEngine;

// Token: 0x0200047F RID: 1151
public class TitleExtrasScript : MonoBehaviour
{
	// Token: 0x06001F08 RID: 7944 RVA: 0x001B7E18 File Offset: 0x001B6018
	private void Start()
	{
		base.transform.localPosition = new Vector3(1050f, base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x06001F09 RID: 7945 RVA: 0x001B7E50 File Offset: 0x001B6050
	private void Update()
	{
		if (!this.Show)
		{
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 1050f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
			return;
		}
		base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x0400407A RID: 16506
	public bool Show;
}
