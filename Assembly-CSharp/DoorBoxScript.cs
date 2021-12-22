using System;
using UnityEngine;

// Token: 0x02000288 RID: 648
public class DoorBoxScript : MonoBehaviour
{
	// Token: 0x06001397 RID: 5015 RVA: 0x000B7960 File Offset: 0x000B5B60
	private void Update()
	{
		float y = Mathf.Lerp(base.transform.localPosition.y, this.Show ? -530f : -630f, Time.deltaTime * 10f);
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, y, base.transform.localPosition.z);
	}

	// Token: 0x04001D03 RID: 7427
	public UILabel Label;

	// Token: 0x04001D04 RID: 7428
	public bool Show;
}
