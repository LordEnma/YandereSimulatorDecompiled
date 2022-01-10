using System;
using HighlightingSystem;
using UnityEngine;

// Token: 0x0200038C RID: 908
public class OutlineScript : MonoBehaviour
{
	// Token: 0x06001A34 RID: 6708 RVA: 0x00115B2A File Offset: 0x00113D2A
	public void Awake()
	{
		this.h = base.GetComponent<Highlighter>();
		if (this.h == null)
		{
			this.h = base.gameObject.AddComponent<Highlighter>();
		}
	}

	// Token: 0x06001A35 RID: 6709 RVA: 0x00115B57 File Offset: 0x00113D57
	private void Update()
	{
		this.h.ConstantOnImmediate(this.color);
	}

	// Token: 0x04002AD8 RID: 10968
	public YandereScript Yandere;

	// Token: 0x04002AD9 RID: 10969
	public Highlighter h;

	// Token: 0x04002ADA RID: 10970
	public Color color = new Color(1f, 1f, 1f, 1f);
}
