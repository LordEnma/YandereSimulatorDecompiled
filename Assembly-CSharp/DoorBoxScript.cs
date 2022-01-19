using System;
using UnityEngine;

// Token: 0x02000289 RID: 649
public class DoorBoxScript : MonoBehaviour
{
	// Token: 0x0600139A RID: 5018 RVA: 0x000B7C90 File Offset: 0x000B5E90
	private void Update()
	{
		float y = Mathf.Lerp(base.transform.localPosition.y, this.Show ? -530f : -630f, Time.deltaTime * 10f);
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, y, base.transform.localPosition.z);
	}

	// Token: 0x04001D09 RID: 7433
	public UILabel Label;

	// Token: 0x04001D0A RID: 7434
	public bool Show;
}
