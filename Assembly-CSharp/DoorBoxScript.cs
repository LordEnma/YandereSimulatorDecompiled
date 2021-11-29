using System;
using UnityEngine;

// Token: 0x02000287 RID: 647
public class DoorBoxScript : MonoBehaviour
{
	// Token: 0x06001390 RID: 5008 RVA: 0x000B73C4 File Offset: 0x000B55C4
	private void Update()
	{
		float y = Mathf.Lerp(base.transform.localPosition.y, this.Show ? -530f : -630f, Time.deltaTime * 10f);
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, y, base.transform.localPosition.z);
	}

	// Token: 0x04001CE3 RID: 7395
	public UILabel Label;

	// Token: 0x04001CE4 RID: 7396
	public bool Show;
}
