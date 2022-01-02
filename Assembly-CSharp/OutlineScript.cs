using System;
using HighlightingSystem;
using UnityEngine;

// Token: 0x0200038B RID: 907
public class OutlineScript : MonoBehaviour
{
	// Token: 0x06001A30 RID: 6704 RVA: 0x001157EE File Offset: 0x001139EE
	public void Awake()
	{
		this.h = base.GetComponent<Highlighter>();
		if (this.h == null)
		{
			this.h = base.gameObject.AddComponent<Highlighter>();
		}
	}

	// Token: 0x06001A31 RID: 6705 RVA: 0x0011581B File Offset: 0x00113A1B
	private void Update()
	{
		this.h.ConstantOnImmediate(this.color);
	}

	// Token: 0x04002AD2 RID: 10962
	public YandereScript Yandere;

	// Token: 0x04002AD3 RID: 10963
	public Highlighter h;

	// Token: 0x04002AD4 RID: 10964
	public Color color = new Color(1f, 1f, 1f, 1f);
}
