using System;
using HighlightingSystem;
using UnityEngine;

// Token: 0x02000391 RID: 913
public class OutlineScript : MonoBehaviour
{
	// Token: 0x06001A6D RID: 6765 RVA: 0x00119A56 File Offset: 0x00117C56
	public void Awake()
	{
		this.h = base.GetComponent<Highlighter>();
		if (this.h == null)
		{
			this.h = base.gameObject.AddComponent<Highlighter>();
		}
	}

	// Token: 0x06001A6E RID: 6766 RVA: 0x00119A83 File Offset: 0x00117C83
	private void Update()
	{
		this.h.ConstantOnImmediate(this.color);
	}

	// Token: 0x04002B7A RID: 11130
	public YandereScript Yandere;

	// Token: 0x04002B7B RID: 11131
	public Highlighter h;

	// Token: 0x04002B7C RID: 11132
	public Color color = new Color(1f, 1f, 1f, 1f);
}
