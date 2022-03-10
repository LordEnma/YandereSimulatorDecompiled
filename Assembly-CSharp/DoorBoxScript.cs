using System;
using UnityEngine;

// Token: 0x0200028B RID: 651
public class DoorBoxScript : MonoBehaviour
{
	// Token: 0x060013A8 RID: 5032 RVA: 0x000B889C File Offset: 0x000B6A9C
	private void Update()
	{
		float y = Mathf.Lerp(base.transform.localPosition.y, this.Show ? -530f : -630f, Time.deltaTime * 10f);
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, y, base.transform.localPosition.z);
	}

	// Token: 0x04001D2A RID: 7466
	public UILabel Label;

	// Token: 0x04001D2B RID: 7467
	public bool Show;
}
