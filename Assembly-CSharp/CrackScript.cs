using System;
using UnityEngine;

// Token: 0x02000265 RID: 613
public class CrackScript : MonoBehaviour
{
	// Token: 0x060012FF RID: 4863 RVA: 0x000A89F3 File Offset: 0x000A6BF3
	private void Update()
	{
		this.Texture.fillAmount += Time.deltaTime * 10f;
	}

	// Token: 0x04001B16 RID: 6934
	public UITexture Texture;
}
