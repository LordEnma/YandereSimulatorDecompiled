using System;
using HighlightingSystem;
using UnityEngine;

// Token: 0x0200038C RID: 908
public class OutlineScript : MonoBehaviour
{
	// Token: 0x06001A37 RID: 6711 RVA: 0x001162AA File Offset: 0x001144AA
	public void Awake()
	{
		this.h = base.GetComponent<Highlighter>();
		if (this.h == null)
		{
			this.h = base.gameObject.AddComponent<Highlighter>();
		}
	}

	// Token: 0x06001A38 RID: 6712 RVA: 0x001162D7 File Offset: 0x001144D7
	private void Update()
	{
		this.h.ConstantOnImmediate(this.color);
	}

	// Token: 0x04002AE5 RID: 10981
	public YandereScript Yandere;

	// Token: 0x04002AE6 RID: 10982
	public Highlighter h;

	// Token: 0x04002AE7 RID: 10983
	public Color color = new Color(1f, 1f, 1f, 1f);
}
