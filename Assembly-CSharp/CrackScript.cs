using System;
using UnityEngine;

// Token: 0x02000263 RID: 611
public class CrackScript : MonoBehaviour
{
	// Token: 0x060012F1 RID: 4849 RVA: 0x000A78EF File Offset: 0x000A5AEF
	private void Update()
	{
		this.Texture.fillAmount += Time.deltaTime * 10f;
	}

	// Token: 0x04001AE9 RID: 6889
	public UITexture Texture;
}
