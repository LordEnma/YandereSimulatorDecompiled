using System;
using UnityEngine;

// Token: 0x02000328 RID: 808
public class HomeWindowScript : MonoBehaviour
{
	// Token: 0x060018A3 RID: 6307 RVA: 0x000F1F60 File Offset: 0x000F0160
	private void Start()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
	}

	// Token: 0x060018A4 RID: 6308 RVA: 0x000F1FB4 File Offset: 0x000F01B4
	private void Update()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, Mathf.Lerp(this.Sprite.color.a, this.Show ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x04002577 RID: 9591
	public UISprite Sprite;

	// Token: 0x04002578 RID: 9592
	public bool Show;
}
