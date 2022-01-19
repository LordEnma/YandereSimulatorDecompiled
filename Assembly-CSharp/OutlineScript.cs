using System;
using HighlightingSystem;
using UnityEngine;

// Token: 0x0200038C RID: 908
public class OutlineScript : MonoBehaviour
{
	// Token: 0x06001A34 RID: 6708 RVA: 0x00115C92 File Offset: 0x00113E92
	public void Awake()
	{
		this.h = base.GetComponent<Highlighter>();
		if (this.h == null)
		{
			this.h = base.gameObject.AddComponent<Highlighter>();
		}
	}

	// Token: 0x06001A35 RID: 6709 RVA: 0x00115CBF File Offset: 0x00113EBF
	private void Update()
	{
		this.h.ConstantOnImmediate(this.color);
	}

	// Token: 0x04002ADB RID: 10971
	public YandereScript Yandere;

	// Token: 0x04002ADC RID: 10972
	public Highlighter h;

	// Token: 0x04002ADD RID: 10973
	public Color color = new Color(1f, 1f, 1f, 1f);
}
