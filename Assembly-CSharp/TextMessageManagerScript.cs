using System;
using UnityEngine;

// Token: 0x0200046C RID: 1132
public class TextMessageManagerScript : MonoBehaviour
{
	// Token: 0x06001E97 RID: 7831 RVA: 0x001ADC88 File Offset: 0x001ABE88
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

	// Token: 0x06001E98 RID: 7832 RVA: 0x001ADD30 File Offset: 0x001ABF30
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

	// Token: 0x04003F2E RID: 16174
	public PauseScreenScript PauseScreen;

	// Token: 0x04003F2F RID: 16175
	public PromptBarScript PromptBar;

	// Token: 0x04003F30 RID: 16176
	public GameObject ServicesMenu;

	// Token: 0x04003F31 RID: 16177
	public string[] Messages;

	// Token: 0x04003F32 RID: 16178
	private GameObject NewMessage;

	// Token: 0x04003F33 RID: 16179
	public GameObject Message;

	// Token: 0x04003F34 RID: 16180
	public int MessageHeight;

	// Token: 0x04003F35 RID: 16181
	public string MessageText = string.Empty;
}
