using System;
using UnityEngine;

// Token: 0x02000086 RID: 134
[ExecuteInEditMode]
[RequireComponent(typeof(UIWidget))]
public class AnimatedColor : MonoBehaviour
{
	// Token: 0x0600054F RID: 1359 RVA: 0x00033A92 File Offset: 0x00031C92
	private void OnEnable()
	{
		this.mWidget = base.GetComponent<UIWidget>();
		this.LateUpdate();
	}

	// Token: 0x06000550 RID: 1360 RVA: 0x00033AA6 File Offset: 0x00031CA6
	private void LateUpdate()
	{
		this.mWidget.color = this.color;
	}

	// Token: 0x0400058F RID: 1423
	public Color color = Color.white;

	// Token: 0x04000590 RID: 1424
	private UIWidget mWidget;
}
