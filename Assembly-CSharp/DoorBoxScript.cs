using System;
using UnityEngine;

// Token: 0x0200028C RID: 652
public class DoorBoxScript : MonoBehaviour
{
	// Token: 0x060013B6 RID: 5046 RVA: 0x000B94B4 File Offset: 0x000B76B4
	private void Update()
	{
		float y = Mathf.Lerp(base.transform.localPosition.y, this.Show ? -530f : -630f, Time.deltaTime * 10f);
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, y, base.transform.localPosition.z);
	}

	// Token: 0x04001D47 RID: 7495
	public UILabel Label;

	// Token: 0x04001D48 RID: 7496
	public bool Show;
}
