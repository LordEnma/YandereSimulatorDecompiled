using System;
using UnityEngine;

// Token: 0x02000289 RID: 649
public class DoorBoxScript : MonoBehaviour
{
	// Token: 0x0600139A RID: 5018 RVA: 0x000B7C2C File Offset: 0x000B5E2C
	private void Update()
	{
		float y = Mathf.Lerp(base.transform.localPosition.y, this.Show ? -530f : -630f, Time.deltaTime * 10f);
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, y, base.transform.localPosition.z);
	}

	// Token: 0x04001D07 RID: 7431
	public UILabel Label;

	// Token: 0x04001D08 RID: 7432
	public bool Show;
}
