using System;
using UnityEngine;

// Token: 0x02000086 RID: 134
[ExecuteInEditMode]
[RequireComponent(typeof(UIWidget))]
public class AnimatedColor : MonoBehaviour
{
	// Token: 0x0600054F RID: 1359 RVA: 0x00033B8A File Offset: 0x00031D8A
	private void OnEnable()
	{
		this.mWidget = base.GetComponent<UIWidget>();
		this.LateUpdate();
	}

	// Token: 0x06000550 RID: 1360 RVA: 0x00033B9E File Offset: 0x00031D9E
	private void LateUpdate()
	{
		this.mWidget.color = this.color;
	}

	// Token: 0x04000599 RID: 1433
	public Color color = Color.white;

	// Token: 0x0400059A RID: 1434
	private UIWidget mWidget;
}
