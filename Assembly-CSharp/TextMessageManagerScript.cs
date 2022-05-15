using System;
using UnityEngine;

// Token: 0x02000476 RID: 1142
public class TextMessageManagerScript : MonoBehaviour
{
	// Token: 0x06001EE7 RID: 7911 RVA: 0x001B5708 File Offset: 0x001B3908
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

	// Token: 0x06001EE8 RID: 7912 RVA: 0x001B57B0 File Offset: 0x001B39B0
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

	// Token: 0x0400401F RID: 16415
	public PauseScreenScript PauseScreen;

	// Token: 0x04004020 RID: 16416
	public PromptBarScript PromptBar;

	// Token: 0x04004021 RID: 16417
	public GameObject ServicesMenu;

	// Token: 0x04004022 RID: 16418
	public string[] Messages;

	// Token: 0x04004023 RID: 16419
	private GameObject NewMessage;

	// Token: 0x04004024 RID: 16420
	public GameObject Message;

	// Token: 0x04004025 RID: 16421
	public int MessageHeight;

	// Token: 0x04004026 RID: 16422
	public string MessageText = string.Empty;
}
