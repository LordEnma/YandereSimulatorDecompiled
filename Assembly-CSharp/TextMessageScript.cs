using System;
using UnityEngine;

// Token: 0x020003A1 RID: 929
public class TextMessageScript : MonoBehaviour
{
	// Token: 0x06001A9C RID: 6812 RVA: 0x0011E39C File Offset: 0x0011C59C
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

	// Token: 0x06001A9D RID: 6813 RVA: 0x0011E41D File Offset: 0x0011C61D
	private void Update()
	{
		base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
	}

	// Token: 0x04002C32 RID: 11314
	public UILabel Label;

	// Token: 0x04002C33 RID: 11315
	public GameObject Image;

	// Token: 0x04002C34 RID: 11316
	public bool Attachment;

	// Token: 0x04002C35 RID: 11317
	public bool Right;
}
