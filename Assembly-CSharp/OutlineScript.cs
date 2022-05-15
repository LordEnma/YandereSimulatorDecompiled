using System;
using HighlightingSystem;
using UnityEngine;

// Token: 0x02000391 RID: 913
public class OutlineScript : MonoBehaviour
{
	// Token: 0x06001A6C RID: 6764 RVA: 0x00119826 File Offset: 0x00117A26
	public void Awake()
	{
		this.h = base.GetComponent<Highlighter>();
		if (this.h == null)
		{
			this.h = base.gameObject.AddComponent<Highlighter>();
		}
	}

	// Token: 0x06001A6D RID: 6765 RVA: 0x00119853 File Offset: 0x00117A53
	private void Update()
	{
		this.h.ConstantOnImmediate(this.color);
	}

	// Token: 0x04002B73 RID: 11123
	public YandereScript Yandere;

	// Token: 0x04002B74 RID: 11124
	public Highlighter h;

	// Token: 0x04002B75 RID: 11125
	public Color color = new Color(1f, 1f, 1f, 1f);
}
