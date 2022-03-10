using System;
using HighlightingSystem;
using UnityEngine;

// Token: 0x0200038E RID: 910
public class OutlineScript : MonoBehaviour
{
	// Token: 0x06001A48 RID: 6728 RVA: 0x001173BA File Offset: 0x001155BA
	public void Awake()
	{
		this.h = base.GetComponent<Highlighter>();
		if (this.h == null)
		{
			this.h = base.gameObject.AddComponent<Highlighter>();
		}
	}

	// Token: 0x06001A49 RID: 6729 RVA: 0x001173E7 File Offset: 0x001155E7
	private void Update()
	{
		this.h.ConstantOnImmediate(this.color);
	}

	// Token: 0x04002B11 RID: 11025
	public YandereScript Yandere;

	// Token: 0x04002B12 RID: 11026
	public Highlighter h;

	// Token: 0x04002B13 RID: 11027
	public Color color = new Color(1f, 1f, 1f, 1f);
}
