using System;
using UnityEngine;

// Token: 0x020003A1 RID: 929
public class TextMessageScript : MonoBehaviour
{
	// Token: 0x06001A9D RID: 6813 RVA: 0x0011E5CC File Offset: 0x0011C7CC
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

	// Token: 0x06001A9E RID: 6814 RVA: 0x0011E64D File Offset: 0x0011C84D
	private void Update()
	{
		base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
	}

	// Token: 0x04002C39 RID: 11321
	public UILabel Label;

	// Token: 0x04002C3A RID: 11322
	public GameObject Image;

	// Token: 0x04002C3B RID: 11323
	public bool Attachment;

	// Token: 0x04002C3C RID: 11324
	public bool Right;
}
