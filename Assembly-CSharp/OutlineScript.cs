using System;
using HighlightingSystem;
using UnityEngine;

// Token: 0x02000390 RID: 912
public class OutlineScript : MonoBehaviour
{
	// Token: 0x06001A62 RID: 6754 RVA: 0x00118996 File Offset: 0x00116B96
	public void Awake()
	{
		this.h = base.GetComponent<Highlighter>();
		if (this.h == null)
		{
			this.h = base.gameObject.AddComponent<Highlighter>();
		}
	}

	// Token: 0x06001A63 RID: 6755 RVA: 0x001189C3 File Offset: 0x00116BC3
	private void Update()
	{
		this.h.ConstantOnImmediate(this.color);
	}

	// Token: 0x04002B58 RID: 11096
	public YandereScript Yandere;

	// Token: 0x04002B59 RID: 11097
	public Highlighter h;

	// Token: 0x04002B5A RID: 11098
	public Color color = new Color(1f, 1f, 1f, 1f);
}
