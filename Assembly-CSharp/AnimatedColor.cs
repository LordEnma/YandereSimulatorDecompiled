using System;
using UnityEngine;

// Token: 0x02000086 RID: 134
[ExecuteInEditMode]
[RequireComponent(typeof(UIWidget))]
public class AnimatedColor : MonoBehaviour
{
	// Token: 0x0600054F RID: 1359 RVA: 0x00033A9A File Offset: 0x00031C9A
	private void OnEnable()
	{
		this.mWidget = base.GetComponent<UIWidget>();
		this.LateUpdate();
	}

	// Token: 0x06000550 RID: 1360 RVA: 0x00033AAE File Offset: 0x00031CAE
	private void LateUpdate()
	{
		this.mWidget.color = this.color;
	}

	// Token: 0x0400058E RID: 1422
	public Color color = Color.white;

	// Token: 0x0400058F RID: 1423
	private UIWidget mWidget;
}
