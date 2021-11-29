using System;
using UnityEngine;

// Token: 0x02000087 RID: 135
[ExecuteInEditMode]
public class AnimatedWidget : MonoBehaviour
{
	// Token: 0x06000552 RID: 1362 RVA: 0x00033AD4 File Offset: 0x00031CD4
	private void OnEnable()
	{
		this.mWidget = base.GetComponent<UIWidget>();
		this.LateUpdate();
	}

	// Token: 0x06000553 RID: 1363 RVA: 0x00033AE8 File Offset: 0x00031CE8
	private void LateUpdate()
	{
		if (this.mWidget != null)
		{
			this.mWidget.width = Mathf.RoundToInt(this.width);
			this.mWidget.height = Mathf.RoundToInt(this.height);
		}
	}

	// Token: 0x04000590 RID: 1424
	public float width = 1f;

	// Token: 0x04000591 RID: 1425
	public float height = 1f;

	// Token: 0x04000592 RID: 1426
	private UIWidget mWidget;
}
