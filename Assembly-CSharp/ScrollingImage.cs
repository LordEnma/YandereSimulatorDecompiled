using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200000A RID: 10
public class ScrollingImage : MonoBehaviour
{
	// Token: 0x06000023 RID: 35 RVA: 0x000033D8 File Offset: 0x000015D8
	private void Update()
	{
		this.scroll += Time.deltaTime * this.scrollSpeed;
		if (this.image != null)
		{
			this.image.uvRect = new Rect(this.scroll, this.scroll, 1f, 1f);
		}
	}

	// Token: 0x04000057 RID: 87
	[SerializeField]
	private RawImage image;

	// Token: 0x04000058 RID: 88
	[SerializeField]
	private float scrollSpeed;

	// Token: 0x04000059 RID: 89
	private float scroll;
}
