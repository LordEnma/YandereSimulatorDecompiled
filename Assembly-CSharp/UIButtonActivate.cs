﻿using System;
using UnityEngine;

// Token: 0x02000044 RID: 68
[AddComponentMenu("NGUI/Interaction/Button Activate")]
public class UIButtonActivate : MonoBehaviour
{
	// Token: 0x0600011E RID: 286 RVA: 0x00013D81 File Offset: 0x00011F81
	private void OnClick()
	{
		if (this.target != null)
		{
			NGUITools.SetActive(this.target, this.state);
		}
	}

	// Token: 0x040002EA RID: 746
	public GameObject target;

	// Token: 0x040002EB RID: 747
	public bool state = true;
}