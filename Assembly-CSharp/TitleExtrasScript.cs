using System;
using UnityEngine;

// Token: 0x0200047D RID: 1149
public class TitleExtrasScript : MonoBehaviour
{
	// Token: 0x06001EF6 RID: 7926 RVA: 0x001B5834 File Offset: 0x001B3A34
	private void Start()
	{
		base.transform.localPosition = new Vector3(1050f, base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x06001EF7 RID: 7927 RVA: 0x001B586C File Offset: 0x001B3A6C
	private void Update()
	{
		if (!this.Show)
		{
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 1050f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
			return;
		}
		base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x04004046 RID: 16454
	public bool Show;
}
