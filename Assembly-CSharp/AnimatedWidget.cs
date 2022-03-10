using System;
using UnityEngine;

// Token: 0x02000087 RID: 135
[ExecuteInEditMode]
public class AnimatedWidget : MonoBehaviour
{
	// Token: 0x06000552 RID: 1362 RVA: 0x00033BC4 File Offset: 0x00031DC4
	private void OnEnable()
	{
		this.mWidget = base.GetComponent<UIWidget>();
		this.LateUpdate();
	}

	// Token: 0x06000553 RID: 1363 RVA: 0x00033BD8 File Offset: 0x00031DD8
	private void LateUpdate()
	{
		if (this.mWidget != null)
		{
			this.mWidget.width = Mathf.RoundToInt(this.width);
			this.mWidget.height = Mathf.RoundToInt(this.height);
		}
	}

	// Token: 0x0400059B RID: 1435
	public float width = 1f;

	// Token: 0x0400059C RID: 1436
	public float height = 1f;

	// Token: 0x0400059D RID: 1437
	private UIWidget mWidget;
}
