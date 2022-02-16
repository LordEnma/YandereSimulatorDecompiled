using System;
using UnityEngine;

// Token: 0x02000329 RID: 809
public class HomeWindowScript : MonoBehaviour
{
	// Token: 0x060018AD RID: 6317 RVA: 0x000F27B8 File Offset: 0x000F09B8
	private void Start()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
	}

	// Token: 0x060018AE RID: 6318 RVA: 0x000F280C File Offset: 0x000F0A0C
	private void Update()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, Mathf.Lerp(this.Sprite.color.a, this.Show ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x04002589 RID: 9609
	public UISprite Sprite;

	// Token: 0x0400258A RID: 9610
	public bool Show;
}
