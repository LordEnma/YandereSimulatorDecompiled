using System;
using UnityEngine;

// Token: 0x0200032A RID: 810
public class HomeWindowScript : MonoBehaviour
{
	// Token: 0x060018B6 RID: 6326 RVA: 0x000F309C File Offset: 0x000F129C
	private void Start()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
	}

	// Token: 0x060018B7 RID: 6327 RVA: 0x000F30F0 File Offset: 0x000F12F0
	private void Update()
	{
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, Mathf.Lerp(this.Sprite.color.a, this.Show ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x04002598 RID: 9624
	public UISprite Sprite;

	// Token: 0x04002599 RID: 9625
	public bool Show;
}
