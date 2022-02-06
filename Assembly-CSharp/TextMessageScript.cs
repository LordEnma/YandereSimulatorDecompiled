using System;
using UnityEngine;

// Token: 0x0200039B RID: 923
public class TextMessageScript : MonoBehaviour
{
	// Token: 0x06001A66 RID: 6758 RVA: 0x0011ADA4 File Offset: 0x00118FA4
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

	// Token: 0x06001A67 RID: 6759 RVA: 0x0011AE25 File Offset: 0x00119025
	private void Update()
	{
		base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
	}

	// Token: 0x04002BA2 RID: 11170
	public UILabel Label;

	// Token: 0x04002BA3 RID: 11171
	public GameObject Image;

	// Token: 0x04002BA4 RID: 11172
	public bool Attachment;

	// Token: 0x04002BA5 RID: 11173
	public bool Right;
}
