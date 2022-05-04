using System;
using UnityEngine;

// Token: 0x020003A0 RID: 928
public class TextMessageScript : MonoBehaviour
{
	// Token: 0x06001A96 RID: 6806 RVA: 0x0011DA38 File Offset: 0x0011BC38
	private void Start()
	{
		if (!this.Attachment && this.Image != null)
		{
			this.Image.SetActive(false);
		}
		if (this.Right && EventGlobals.OsanaConversation)
		{
			base.gameObject.GetComponent<UISprite>().color = new Color(1f, 0.5f, 0f);
			this.Label.color = new Color(1f, 1f, 1f);
		}
	}

	// Token: 0x06001A97 RID: 6807 RVA: 0x0011DAB9 File Offset: 0x0011BCB9
	private void Update()
	{
		base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
	}

	// Token: 0x04002C20 RID: 11296
	public UILabel Label;

	// Token: 0x04002C21 RID: 11297
	public GameObject Image;

	// Token: 0x04002C22 RID: 11298
	public bool Attachment;

	// Token: 0x04002C23 RID: 11299
	public bool Right;
}
