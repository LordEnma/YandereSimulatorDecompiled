using System;
using UnityEngine;

// Token: 0x0200039C RID: 924
public class TextMessageScript : MonoBehaviour
{
	// Token: 0x06001A6D RID: 6765 RVA: 0x0011B0C0 File Offset: 0x001192C0
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

	// Token: 0x06001A6E RID: 6766 RVA: 0x0011B141 File Offset: 0x00119341
	private void Update()
	{
		base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
	}

	// Token: 0x04002BA8 RID: 11176
	public UILabel Label;

	// Token: 0x04002BA9 RID: 11177
	public GameObject Image;

	// Token: 0x04002BAA RID: 11178
	public bool Attachment;

	// Token: 0x04002BAB RID: 11179
	public bool Right;
}
