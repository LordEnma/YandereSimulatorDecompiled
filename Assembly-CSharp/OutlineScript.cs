using System;
using HighlightingSystem;
using UnityEngine;

// Token: 0x0200038E RID: 910
public class OutlineScript : MonoBehaviour
{
	// Token: 0x06001A47 RID: 6727 RVA: 0x00116FE2 File Offset: 0x001151E2
	public void Awake()
	{
		this.h = base.GetComponent<Highlighter>();
		if (this.h == null)
		{
			this.h = base.gameObject.AddComponent<Highlighter>();
		}
	}

	// Token: 0x06001A48 RID: 6728 RVA: 0x0011700F File Offset: 0x0011520F
	private void Update()
	{
		this.h.ConstantOnImmediate(this.color);
	}

	// Token: 0x04002AFB RID: 11003
	public YandereScript Yandere;

	// Token: 0x04002AFC RID: 11004
	public Highlighter h;

	// Token: 0x04002AFD RID: 11005
	public Color color = new Color(1f, 1f, 1f, 1f);
}
