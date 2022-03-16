using System;
using HighlightingSystem;
using UnityEngine;

// Token: 0x0200038E RID: 910
public class OutlineScript : MonoBehaviour
{
	// Token: 0x06001A52 RID: 6738 RVA: 0x00117ECA File Offset: 0x001160CA
	public void Awake()
	{
		this.h = base.GetComponent<Highlighter>();
		if (this.h == null)
		{
			this.h = base.gameObject.AddComponent<Highlighter>();
		}
	}

	// Token: 0x06001A53 RID: 6739 RVA: 0x00117EF7 File Offset: 0x001160F7
	private void Update()
	{
		this.h.ConstantOnImmediate(this.color);
	}

	// Token: 0x04002B3A RID: 11066
	public YandereScript Yandere;

	// Token: 0x04002B3B RID: 11067
	public Highlighter h;

	// Token: 0x04002B3C RID: 11068
	public Color color = new Color(1f, 1f, 1f, 1f);
}
