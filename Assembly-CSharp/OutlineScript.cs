using System;
using HighlightingSystem;
using UnityEngine;

// Token: 0x0200038D RID: 909
public class OutlineScript : MonoBehaviour
{
	// Token: 0x06001A3E RID: 6718 RVA: 0x001165CE File Offset: 0x001147CE
	public void Awake()
	{
		this.h = base.GetComponent<Highlighter>();
		if (this.h == null)
		{
			this.h = base.gameObject.AddComponent<Highlighter>();
		}
	}

	// Token: 0x06001A3F RID: 6719 RVA: 0x001165FB File Offset: 0x001147FB
	private void Update()
	{
		this.h.ConstantOnImmediate(this.color);
	}

	// Token: 0x04002AEB RID: 10987
	public YandereScript Yandere;

	// Token: 0x04002AEC RID: 10988
	public Highlighter h;

	// Token: 0x04002AED RID: 10989
	public Color color = new Color(1f, 1f, 1f, 1f);
}
