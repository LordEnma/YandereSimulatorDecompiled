using System;
using HighlightingSystem;
using UnityEngine;

// Token: 0x0200038C RID: 908
public class OutlineScript : MonoBehaviour
{
	// Token: 0x06001A35 RID: 6709 RVA: 0x00116192 File Offset: 0x00114392
	public void Awake()
	{
		this.h = base.GetComponent<Highlighter>();
		if (this.h == null)
		{
			this.h = base.gameObject.AddComponent<Highlighter>();
		}
	}

	// Token: 0x06001A36 RID: 6710 RVA: 0x001161BF File Offset: 0x001143BF
	private void Update()
	{
		this.h.ConstantOnImmediate(this.color);
	}

	// Token: 0x04002AE2 RID: 10978
	public YandereScript Yandere;

	// Token: 0x04002AE3 RID: 10979
	public Highlighter h;

	// Token: 0x04002AE4 RID: 10980
	public Color color = new Color(1f, 1f, 1f, 1f);
}
