using System;
using UnityEngine;

// Token: 0x02000264 RID: 612
public class CrackScript : MonoBehaviour
{
	// Token: 0x060012F5 RID: 4853 RVA: 0x000A78AB File Offset: 0x000A5AAB
	private void Update()
	{
		this.Texture.fillAmount += Time.deltaTime * 10f;
	}

	// Token: 0x04001AEE RID: 6894
	public UITexture Texture;
}
