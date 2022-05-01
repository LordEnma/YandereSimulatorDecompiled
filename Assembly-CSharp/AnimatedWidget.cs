using System;
using UnityEngine;

// Token: 0x02000087 RID: 135
[ExecuteInEditMode]
public class AnimatedWidget : MonoBehaviour
{
	// Token: 0x06000552 RID: 1362 RVA: 0x00033DBC File Offset: 0x00031FBC
	private void OnEnable()
	{
		this.mWidget = base.GetComponent<UIWidget>();
		this.LateUpdate();
	}

	// Token: 0x06000553 RID: 1363 RVA: 0x00033DD0 File Offset: 0x00031FD0
	private void LateUpdate()
	{
		if (this.mWidget != null)
		{
			this.mWidget.width = Mathf.RoundToInt(this.width);
			this.mWidget.height = Mathf.RoundToInt(this.height);
		}
	}

	// Token: 0x0400059D RID: 1437
	public float width = 1f;

	// Token: 0x0400059E RID: 1438
	public float height = 1f;

	// Token: 0x0400059F RID: 1439
	private UIWidget mWidget;
}
