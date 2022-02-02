using System;
using HighlightingSystem;
using UnityEngine;

// Token: 0x0200038C RID: 908
public class OutlineScript : MonoBehaviour
{
	// Token: 0x06001A35 RID: 6709 RVA: 0x001160D6 File Offset: 0x001142D6
	public void Awake()
	{
		this.h = base.GetComponent<Highlighter>();
		if (this.h == null)
		{
			this.h = base.gameObject.AddComponent<Highlighter>();
		}
	}

	// Token: 0x06001A36 RID: 6710 RVA: 0x00116103 File Offset: 0x00114303
	private void Update()
	{
		this.h.ConstantOnImmediate(this.color);
	}

	// Token: 0x04002AE1 RID: 10977
	public YandereScript Yandere;

	// Token: 0x04002AE2 RID: 10978
	public Highlighter h;

	// Token: 0x04002AE3 RID: 10979
	public Color color = new Color(1f, 1f, 1f, 1f);
}
