using System;
using UnityEngine;

// Token: 0x02000265 RID: 613
public class CrackScript : MonoBehaviour
{
	// Token: 0x060012FF RID: 4863 RVA: 0x000A8A8B File Offset: 0x000A6C8B
	private void Update()
	{
		this.Texture.fillAmount += Time.deltaTime * 10f;
	}

	// Token: 0x04001B16 RID: 6934
	public UITexture Texture;
}
