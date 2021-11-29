using System;
using HighlightingSystem;
using UnityEngine;

// Token: 0x0200038A RID: 906
public class OutlineScript : MonoBehaviour
{
	// Token: 0x06001A26 RID: 6694 RVA: 0x00114CE2 File Offset: 0x00112EE2
	public void Awake()
	{
		this.h = base.GetComponent<Highlighter>();
		if (this.h == null)
		{
			this.h = base.gameObject.AddComponent<Highlighter>();
		}
	}

	// Token: 0x06001A27 RID: 6695 RVA: 0x00114D0F File Offset: 0x00112F0F
	private void Update()
	{
		this.h.ConstantOnImmediate(this.color);
	}

	// Token: 0x04002AA4 RID: 10916
	public YandereScript Yandere;

	// Token: 0x04002AA5 RID: 10917
	public Highlighter h;

	// Token: 0x04002AA6 RID: 10918
	public Color color = new Color(1f, 1f, 1f, 1f);
}
