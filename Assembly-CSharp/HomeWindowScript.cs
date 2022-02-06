using System;
using UnityEngine;

// Token: 0x02000328 RID: 808
public class HomeWindowScript : MonoBehaviour
{
	// Token: 0x060018A6 RID: 6310 RVA: 0x000F2614 File Offset: 0x000F0814
	private void Start()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
	}

	// Token: 0x060018A7 RID: 6311 RVA: 0x000F2668 File Offset: 0x000F0868
	private void Update()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, Mathf.Lerp(this.Sprite.color.a, this.Show ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x04002583 RID: 9603
	public UISprite Sprite;

	// Token: 0x04002584 RID: 9604
	public bool Show;
}
