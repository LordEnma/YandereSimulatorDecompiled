using System;
using HighlightingSystem;
using UnityEngine;

// Token: 0x02000390 RID: 912
public class OutlineScript : MonoBehaviour
{
	// Token: 0x06001A66 RID: 6758 RVA: 0x00118EFE File Offset: 0x001170FE
	public void Awake()
	{
		this.h = base.GetComponent<Highlighter>();
		if (this.h == null)
		{
			this.h = base.gameObject.AddComponent<Highlighter>();
		}
	}

	// Token: 0x06001A67 RID: 6759 RVA: 0x00118F2B File Offset: 0x0011712B
	private void Update()
	{
		this.h.ConstantOnImmediate(this.color);
	}

	// Token: 0x04002B61 RID: 11105
	public YandereScript Yandere;

	// Token: 0x04002B62 RID: 11106
	public Highlighter h;

	// Token: 0x04002B63 RID: 11107
	public Color color = new Color(1f, 1f, 1f, 1f);
}
