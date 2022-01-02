using System;
using UnityEngine;

// Token: 0x02000288 RID: 648
public class DoorBoxScript : MonoBehaviour
{
	// Token: 0x06001397 RID: 5015 RVA: 0x000B7B90 File Offset: 0x000B5D90
	private void Update()
	{
		float y = Mathf.Lerp(base.transform.localPosition.y, this.Show ? -530f : -630f, Time.deltaTime * 10f);
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, y, base.transform.localPosition.z);
	}

	// Token: 0x04001D06 RID: 7430
	public UILabel Label;

	// Token: 0x04001D07 RID: 7431
	public bool Show;
}
