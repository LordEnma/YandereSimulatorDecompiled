using System;
using UnityEngine;

// Token: 0x02000264 RID: 612
public class CrackScript : MonoBehaviour
{
	// Token: 0x060012F8 RID: 4856 RVA: 0x000A80EB File Offset: 0x000A62EB
	private void Update()
	{
		this.Texture.fillAmount += Time.deltaTime * 10f;
	}

	// Token: 0x04001B03 RID: 6915
	public UITexture Texture;
}
