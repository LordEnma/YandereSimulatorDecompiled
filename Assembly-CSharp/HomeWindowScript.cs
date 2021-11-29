using System;
using UnityEngine;

// Token: 0x02000326 RID: 806
public class HomeWindowScript : MonoBehaviour
{
	// Token: 0x06001896 RID: 6294 RVA: 0x000F1184 File Offset: 0x000EF384
	private void Start()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
	}

	// Token: 0x06001897 RID: 6295 RVA: 0x000F11D8 File Offset: 0x000EF3D8
	private void Update()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, Mathf.Lerp(this.Sprite.color.a, this.Show ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x0400254F RID: 9551
	public UISprite Sprite;

	// Token: 0x04002550 RID: 9552
	public bool Show;
}
