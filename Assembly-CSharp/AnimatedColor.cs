using System;
using UnityEngine;

// Token: 0x02000086 RID: 134
[ExecuteInEditMode]
[RequireComponent(typeof(UIWidget))]
public class AnimatedColor : MonoBehaviour
{
	// Token: 0x0600054F RID: 1359 RVA: 0x00033D82 File Offset: 0x00031F82
	private void OnEnable()
	{
		this.mWidget = base.GetComponent<UIWidget>();
		this.LateUpdate();
	}

	// Token: 0x06000550 RID: 1360 RVA: 0x00033D96 File Offset: 0x00031F96
	private void LateUpdate()
	{
		this.mWidget.color = this.color;
	}

	// Token: 0x0400059B RID: 1435
	public Color color = Color.white;

	// Token: 0x0400059C RID: 1436
	private UIWidget mWidget;
}
