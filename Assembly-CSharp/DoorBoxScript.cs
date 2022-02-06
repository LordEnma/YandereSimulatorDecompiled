using System;
using UnityEngine;

// Token: 0x02000289 RID: 649
public class DoorBoxScript : MonoBehaviour
{
	// Token: 0x0600139B RID: 5019 RVA: 0x000B7EB0 File Offset: 0x000B60B0
	private void Update()
	{
		float y = Mathf.Lerp(base.transform.localPosition.y, this.Show ? -530f : -630f, Time.deltaTime * 10f);
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, y, base.transform.localPosition.z);
	}

	// Token: 0x04001D0F RID: 7439
	public UILabel Label;

	// Token: 0x04001D10 RID: 7440
	public bool Show;
}
