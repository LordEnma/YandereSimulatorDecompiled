using System;
using UnityEngine;

// Token: 0x02000263 RID: 611
public class CrackScript : MonoBehaviour
{
	// Token: 0x060012F1 RID: 4849 RVA: 0x000A799B File Offset: 0x000A5B9B
	private void Update()
	{
		this.Texture.fillAmount += Time.deltaTime * 10f;
	}

	// Token: 0x04001AEB RID: 6891
	public UITexture Texture;
}
