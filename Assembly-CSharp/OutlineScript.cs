using System;
using HighlightingSystem;
using UnityEngine;

// Token: 0x0200038B RID: 907
public class OutlineScript : MonoBehaviour
{
	// Token: 0x06001A2E RID: 6702 RVA: 0x00115512 File Offset: 0x00113712
	public void Awake()
	{
		this.h = base.GetComponent<Highlighter>();
		if (this.h == null)
		{
			this.h = base.gameObject.AddComponent<Highlighter>();
		}
	}

	// Token: 0x06001A2F RID: 6703 RVA: 0x0011553F File Offset: 0x0011373F
	private void Update()
	{
		this.h.ConstantOnImmediate(this.color);
	}

	// Token: 0x04002ACE RID: 10958
	public YandereScript Yandere;

	// Token: 0x04002ACF RID: 10959
	public Highlighter h;

	// Token: 0x04002AD0 RID: 10960
	public Color color = new Color(1f, 1f, 1f, 1f);
}
