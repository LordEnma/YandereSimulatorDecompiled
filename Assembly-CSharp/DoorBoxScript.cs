using System;
using UnityEngine;

// Token: 0x0200028C RID: 652
public class DoorBoxScript : MonoBehaviour
{
	// Token: 0x060013B2 RID: 5042 RVA: 0x000B9010 File Offset: 0x000B7210
	private void Update()
	{
		float y = Mathf.Lerp(base.transform.localPosition.y, this.Show ? -530f : -630f, Time.deltaTime * 10f);
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, y, base.transform.localPosition.z);
	}

	// Token: 0x04001D3E RID: 7486
	public UILabel Label;

	// Token: 0x04001D3F RID: 7487
	public bool Show;
}
