using System;
using UnityEngine;

// Token: 0x0200028B RID: 651
public class DoorBoxScript : MonoBehaviour
{
	// Token: 0x060013AC RID: 5036 RVA: 0x000B8D84 File Offset: 0x000B6F84
	private void Update()
	{
		float y = Mathf.Lerp(base.transform.localPosition.y, this.Show ? -530f : -630f, Time.deltaTime * 10f);
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, y, base.transform.localPosition.z);
	}

	// Token: 0x04001D3B RID: 7483
	public UILabel Label;

	// Token: 0x04001D3C RID: 7484
	public bool Show;
}
