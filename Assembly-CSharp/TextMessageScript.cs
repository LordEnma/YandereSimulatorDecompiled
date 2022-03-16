using System;
using UnityEngine;

// Token: 0x0200039D RID: 925
public class TextMessageScript : MonoBehaviour
{
	// Token: 0x06001A81 RID: 6785 RVA: 0x0011C9BC File Offset: 0x0011ABBC
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

	// Token: 0x06001A82 RID: 6786 RVA: 0x0011CA3D File Offset: 0x0011AC3D
	private void Update()
	{
		base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
	}

	// Token: 0x04002BF7 RID: 11255
	public UILabel Label;

	// Token: 0x04002BF8 RID: 11256
	public GameObject Image;

	// Token: 0x04002BF9 RID: 11257
	public bool Attachment;

	// Token: 0x04002BFA RID: 11258
	public bool Right;
}
