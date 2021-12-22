using System;
using UnityEngine;

// Token: 0x02000469 RID: 1129
public class TextMessageManagerScript : MonoBehaviour
{
	// Token: 0x06001E85 RID: 7813 RVA: 0x001AB9E4 File Offset: 0x001A9BE4
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

	// Token: 0x06001E86 RID: 7814 RVA: 0x001ABA8C File Offset: 0x001A9C8C
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

	// Token: 0x04003EFF RID: 16127
	public PauseScreenScript PauseScreen;

	// Token: 0x04003F00 RID: 16128
	public PromptBarScript PromptBar;

	// Token: 0x04003F01 RID: 16129
	public GameObject ServicesMenu;

	// Token: 0x04003F02 RID: 16130
	public string[] Messages;

	// Token: 0x04003F03 RID: 16131
	private GameObject NewMessage;

	// Token: 0x04003F04 RID: 16132
	public GameObject Message;

	// Token: 0x04003F05 RID: 16133
	public int MessageHeight;

	// Token: 0x04003F06 RID: 16134
	public string MessageText = string.Empty;
}
