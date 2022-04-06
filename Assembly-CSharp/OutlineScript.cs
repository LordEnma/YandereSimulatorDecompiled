using System;
using HighlightingSystem;
using UnityEngine;

// Token: 0x02000390 RID: 912
public class OutlineScript : MonoBehaviour
{
	// Token: 0x06001A5E RID: 6750 RVA: 0x0011868E File Offset: 0x0011688E
	public void Awake()
	{
		this.h = base.GetComponent<Highlighter>();
		if (this.h == null)
		{
			this.h = base.gameObject.AddComponent<Highlighter>();
		}
	}

	// Token: 0x06001A5F RID: 6751 RVA: 0x001186BB File Offset: 0x001168BB
	private void Update()
	{
		this.h.ConstantOnImmediate(this.color);
	}

	// Token: 0x04002B50 RID: 11088
	public YandereScript Yandere;

	// Token: 0x04002B51 RID: 11089
	public Highlighter h;

	// Token: 0x04002B52 RID: 11090
	public Color color = new Color(1f, 1f, 1f, 1f);
}
