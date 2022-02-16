using System;
using UnityEngine;

// Token: 0x0200028A RID: 650
public class DoorBoxScript : MonoBehaviour
{
	// Token: 0x0600139F RID: 5023 RVA: 0x000B7DF4 File Offset: 0x000B5FF4
	private void Update()
	{
		float y = Mathf.Lerp(base.transform.localPosition.y, this.Show ? -530f : -630f, Time.deltaTime * 10f);
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, y, base.transform.localPosition.z);
	}

	// Token: 0x04001D12 RID: 7442
	public UILabel Label;

	// Token: 0x04001D13 RID: 7443
	public bool Show;
}
