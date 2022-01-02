using System;
using UnityEngine;

// Token: 0x02000399 RID: 921
public class TextMessageScript : MonoBehaviour
{
	// Token: 0x06001A5C RID: 6748 RVA: 0x0011A294 File Offset: 0x00118494
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

	// Token: 0x06001A5D RID: 6749 RVA: 0x0011A315 File Offset: 0x00118515
	private void Update()
	{
		base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
	}

	// Token: 0x04002B8F RID: 11151
	public UILabel Label;

	// Token: 0x04002B90 RID: 11152
	public GameObject Image;

	// Token: 0x04002B91 RID: 11153
	public bool Attachment;

	// Token: 0x04002B92 RID: 11154
	public bool Right;
}
