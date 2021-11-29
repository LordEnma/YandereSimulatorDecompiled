using System;
using UnityEngine;

// Token: 0x02000468 RID: 1128
public class TextMessageManagerScript : MonoBehaviour
{
	// Token: 0x06001E7B RID: 7803 RVA: 0x001AAC58 File Offset: 0x001A8E58
	private void Update()
	{
		if (Input.GetButtonDown("B"))
		{
			UnityEngine.Object.Destroy(this.NewMessage);
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Accept";
			this.PromptBar.Label[1].text = "Exit";
			this.PromptBar.Label[5].text = "Choose";
			this.PromptBar.UpdateButtons();
			this.PauseScreen.Sideways = true;
			this.ServicesMenu.SetActive(true);
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001E7C RID: 7804 RVA: 0x001AAD00 File Offset: 0x001A8F00
	public void SpawnMessage(int ServiceID)
	{
		this.PromptBar.ClearButtons();
		this.PromptBar.Label[1].text = "Exit";
		this.PromptBar.UpdateButtons();
		this.PauseScreen.Sideways = false;
		this.ServicesMenu.SetActive(false);
		base.gameObject.SetActive(true);
		if (this.NewMessage != null)
		{
			UnityEngine.Object.Destroy(this.NewMessage);
		}
		this.NewMessage = UnityEngine.Object.Instantiate<GameObject>(this.Message);
		this.NewMessage.transform.parent = base.transform;
		this.NewMessage.transform.localPosition = new Vector3(-225f, -275f, 0f);
		this.NewMessage.transform.localEulerAngles = Vector3.zero;
		this.NewMessage.transform.localScale = new Vector3(1f, 1f, 1f);
		this.MessageText = this.Messages[ServiceID];
		if (ServiceID == 7 || ServiceID == 4)
		{
			this.MessageHeight = 11;
		}
		else if (ServiceID == 9)
		{
			this.MessageHeight = 6;
		}
		else
		{
			this.MessageHeight = 5;
		}
		this.NewMessage.GetComponent<UISprite>().height = 36 + 36 * this.MessageHeight;
		this.NewMessage.GetComponent<TextMessageScript>().Label.text = this.MessageText;
	}

	// Token: 0x04003ECF RID: 16079
	public PauseScreenScript PauseScreen;

	// Token: 0x04003ED0 RID: 16080
	public PromptBarScript PromptBar;

	// Token: 0x04003ED1 RID: 16081
	public GameObject ServicesMenu;

	// Token: 0x04003ED2 RID: 16082
	public string[] Messages;

	// Token: 0x04003ED3 RID: 16083
	private GameObject NewMessage;

	// Token: 0x04003ED4 RID: 16084
	public GameObject Message;

	// Token: 0x04003ED5 RID: 16085
	public int MessageHeight;

	// Token: 0x04003ED6 RID: 16086
	public string MessageText = string.Empty;
}
