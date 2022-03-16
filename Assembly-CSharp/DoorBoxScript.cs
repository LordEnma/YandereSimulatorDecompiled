using System;
using UnityEngine;

// Token: 0x0200028B RID: 651
public class DoorBoxScript : MonoBehaviour
{
	// Token: 0x060013AB RID: 5035 RVA: 0x000B8C78 File Offset: 0x000B6E78
	private void Update()
	{
		float y = Mathf.Lerp(base.transform.localPosition.y, this.Show ? -530f : -630f, Time.deltaTime * 10f);
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, y, base.transform.localPosition.z);
	}

	// Token: 0x04001D38 RID: 7480
	public UILabel Label;

	// Token: 0x04001D39 RID: 7481
	public bool Show;
}
