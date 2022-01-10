using System;
using UnityEngine;

// Token: 0x0200046B RID: 1131
public class TextMessageManagerScript : MonoBehaviour
{
	// Token: 0x06001E92 RID: 7826 RVA: 0x001AC818 File Offset: 0x001AAA18
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

	// Token: 0x06001E93 RID: 7827 RVA: 0x001AC8C0 File Offset: 0x001AAAC0
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

	// Token: 0x04003F1A RID: 16154
	public PauseScreenScript PauseScreen;

	// Token: 0x04003F1B RID: 16155
	public PromptBarScript PromptBar;

	// Token: 0x04003F1C RID: 16156
	public GameObject ServicesMenu;

	// Token: 0x04003F1D RID: 16157
	public string[] Messages;

	// Token: 0x04003F1E RID: 16158
	private GameObject NewMessage;

	// Token: 0x04003F1F RID: 16159
	public GameObject Message;

	// Token: 0x04003F20 RID: 16160
	public int MessageHeight;

	// Token: 0x04003F21 RID: 16161
	public string MessageText = string.Empty;
}
