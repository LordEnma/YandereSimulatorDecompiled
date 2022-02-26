using System;
using UnityEngine;

// Token: 0x0200028B RID: 651
public class DoorBoxScript : MonoBehaviour
{
	// Token: 0x060013A8 RID: 5032 RVA: 0x000B8734 File Offset: 0x000B6934
	private void Update()
	{
		float y = Mathf.Lerp(base.transform.localPosition.y, this.Show ? -530f : -630f, Time.deltaTime * 10f);
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, y, base.transform.localPosition.z);
	}

	// Token: 0x04001D21 RID: 7457
	public UILabel Label;

	// Token: 0x04001D22 RID: 7458
	public bool Show;
}
