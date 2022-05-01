using System;
using UnityEngine;

// Token: 0x02000264 RID: 612
public class CrackScript : MonoBehaviour
{
	// Token: 0x060012FD RID: 4861 RVA: 0x000A87AB File Offset: 0x000A69AB
	private void Update()
	{
		this.Texture.fillAmount += Time.deltaTime * 10f;
	}

	// Token: 0x04001B0F RID: 6927
	public UITexture Texture;
}
