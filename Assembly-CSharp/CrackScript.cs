using System;
using UnityEngine;

// Token: 0x02000263 RID: 611
public class CrackScript : MonoBehaviour
{
	// Token: 0x060012F1 RID: 4849 RVA: 0x000A78F7 File Offset: 0x000A5AF7
	private void Update()
	{
		this.Texture.fillAmount += Time.deltaTime * 10f;
	}

	// Token: 0x04001AE8 RID: 6888
	public UITexture Texture;
}
