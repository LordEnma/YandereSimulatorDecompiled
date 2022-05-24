using System;
using UnityEngine;

// Token: 0x0200028D RID: 653
public class DoorBoxScript : MonoBehaviour
{
	// Token: 0x060013B8 RID: 5048 RVA: 0x000B978C File Offset: 0x000B798C
	private void Update()
	{
		float y = Mathf.Lerp(base.transform.localPosition.y, this.Show ? -530f : -630f, Time.deltaTime * 10f);
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, y, base.transform.localPosition.z);
	}

	// Token: 0x04001D4E RID: 7502
	public UILabel Label;

	// Token: 0x04001D4F RID: 7503
	public bool Show;
}
