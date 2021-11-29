using System;
using UnityEngine;

// Token: 0x02000262 RID: 610
public class CrackScript : MonoBehaviour
{
	// Token: 0x060012E9 RID: 4841 RVA: 0x000A70A3 File Offset: 0x000A52A3
	private void Update()
	{
		this.Texture.fillAmount += Time.deltaTime * 10f;
	}

	// Token: 0x04001AC8 RID: 6856
	public UITexture Texture;
}
