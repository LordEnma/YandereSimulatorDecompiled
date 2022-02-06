using System;
using UnityEngine;

// Token: 0x02000044 RID: 68
[AddComponentMenu("NGUI/Interaction/Button Activate")]
public class UIButtonActivate : MonoBehaviour
{
	// Token: 0x0600011E RID: 286 RVA: 0x00013D79 File Offset: 0x00011F79
	private void OnClick()
	{
		if (this.target != null)
		{
			NGUITools.SetActive(this.target, this.state);
		}
	}

	// Token: 0x040002EC RID: 748
	public GameObject target;

	// Token: 0x040002ED RID: 749
	public bool state = true;
}
