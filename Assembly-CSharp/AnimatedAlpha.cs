using System;
using UnityEngine;

// Token: 0x02000085 RID: 133
[ExecuteInEditMode]
public class AnimatedAlpha : MonoBehaviour
{
	// Token: 0x0600054C RID: 1356 RVA: 0x00033BCF File Offset: 0x00031DCF
	private void OnEnable()
	{
		this.mWidget = base.GetComponent<UIWidget>();
		this.mPanel = base.GetComponent<UIPanel>();
		this.LateUpdate();
	}

	// Token: 0x0600054D RID: 1357 RVA: 0x00033BEF File Offset: 0x00031DEF
	private void LateUpdate()
	{
		if (this.mWidget != null)
		{
			this.mWidget.alpha = this.alpha;
		}
		if (this.mPanel != null)
		{
			this.mPanel.alpha = this.alpha;
		}
	}

	// Token: 0x04000596 RID: 1430
	[Range(0f, 1f)]
	public float alpha = 1f;

	// Token: 0x04000597 RID: 1431
	private UIWidget mWidget;

	// Token: 0x04000598 RID: 1432
	private UIPanel mPanel;
}
