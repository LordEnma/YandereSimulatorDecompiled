using System;
using UnityEngine;

// Token: 0x0200047C RID: 1148
public class TitleExtrasScript : MonoBehaviour
{
	// Token: 0x06001EE8 RID: 7912 RVA: 0x001B4954 File Offset: 0x001B2B54
	private void Start()
	{
		base.transform.localPosition = new Vector3(1050f, base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x06001EE9 RID: 7913 RVA: 0x001B498C File Offset: 0x001B2B8C
	private void Update()
	{
		if (!this.Show)
		{
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 1050f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
			return;
		}
		base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x04004033 RID: 16435
	public bool Show;
}
