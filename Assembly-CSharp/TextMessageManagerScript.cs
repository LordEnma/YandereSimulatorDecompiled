using System;
using UnityEngine;

// Token: 0x02000469 RID: 1129
public class TextMessageManagerScript : MonoBehaviour
{
	// Token: 0x06001E87 RID: 7815 RVA: 0x001ABE98 File Offset: 0x001AA098
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

	// Token: 0x06001E88 RID: 7816 RVA: 0x001ABF40 File Offset: 0x001AA140
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

	// Token: 0x04003F06 RID: 16134
	public PauseScreenScript PauseScreen;

	// Token: 0x04003F07 RID: 16135
	public PromptBarScript PromptBar;

	// Token: 0x04003F08 RID: 16136
	public GameObject ServicesMenu;

	// Token: 0x04003F09 RID: 16137
	public string[] Messages;

	// Token: 0x04003F0A RID: 16138
	private GameObject NewMessage;

	// Token: 0x04003F0B RID: 16139
	public GameObject Message;

	// Token: 0x04003F0C RID: 16140
	public int MessageHeight;

	// Token: 0x04003F0D RID: 16141
	public string MessageText = string.Empty;
}
