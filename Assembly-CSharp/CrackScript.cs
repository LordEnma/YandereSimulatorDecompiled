using System;
using UnityEngine;

// Token: 0x02000264 RID: 612
public class CrackScript : MonoBehaviour
{
	// Token: 0x060012F9 RID: 4857 RVA: 0x000A81B3 File Offset: 0x000A63B3
	private void Update()
	{
		this.Texture.fillAmount += Time.deltaTime * 10f;
	}

	// Token: 0x04001B06 RID: 6918
	public UITexture Texture;
}
