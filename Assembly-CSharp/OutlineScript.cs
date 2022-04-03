using System;
using HighlightingSystem;
using UnityEngine;

// Token: 0x0200038F RID: 911
public class OutlineScript : MonoBehaviour
{
	// Token: 0x06001A58 RID: 6744 RVA: 0x00118522 File Offset: 0x00116722
	public void Awake()
	{
		this.h = base.GetComponent<Highlighter>();
		if (this.h == null)
		{
			this.h = base.gameObject.AddComponent<Highlighter>();
		}
	}

	// Token: 0x06001A59 RID: 6745 RVA: 0x0011854F File Offset: 0x0011674F
	private void Update()
	{
		this.h.ConstantOnImmediate(this.color);
	}

	// Token: 0x04002B4D RID: 11085
	public YandereScript Yandere;

	// Token: 0x04002B4E RID: 11086
	public Highlighter h;

	// Token: 0x04002B4F RID: 11087
	public Color color = new Color(1f, 1f, 1f, 1f);
}
