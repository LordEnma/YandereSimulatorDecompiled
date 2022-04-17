using System;
using UnityEngine;

// Token: 0x02000044 RID: 68
[AddComponentMenu("NGUI/Interaction/Button Activate")]
public class UIButtonActivate : MonoBehaviour
{
	// Token: 0x0600011E RID: 286 RVA: 0x00013F29 File Offset: 0x00012129
	private void OnClick()
	{
		if (this.target != null)
		{
			NGUITools.SetActive(this.target, this.state);
		}
	}

	// Token: 0x040002F5 RID: 757
	public GameObject target;

	// Token: 0x040002F6 RID: 758
	public bool state = true;
}
