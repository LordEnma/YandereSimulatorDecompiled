using System;
using UnityEngine;

// Token: 0x02000263 RID: 611
public class CrackScript : MonoBehaviour
{
	// Token: 0x060012F0 RID: 4848 RVA: 0x000A7767 File Offset: 0x000A5967
	private void Update()
	{
		this.Texture.fillAmount += Time.deltaTime * 10f;
	}

	// Token: 0x04001AE3 RID: 6883
	public UITexture Texture;
}
