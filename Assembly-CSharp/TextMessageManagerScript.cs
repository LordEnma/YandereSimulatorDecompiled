using System;
using UnityEngine;

// Token: 0x02000473 RID: 1139
public class TextMessageManagerScript : MonoBehaviour
{
	// Token: 0x06001EC7 RID: 7879 RVA: 0x001B2244 File Offset: 0x001B0444
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

	// Token: 0x06001EC8 RID: 7880 RVA: 0x001B22EC File Offset: 0x001B04EC
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

	// Token: 0x04003FD8 RID: 16344
	public PauseScreenScript PauseScreen;

	// Token: 0x04003FD9 RID: 16345
	public PromptBarScript PromptBar;

	// Token: 0x04003FDA RID: 16346
	public GameObject ServicesMenu;

	// Token: 0x04003FDB RID: 16347
	public string[] Messages;

	// Token: 0x04003FDC RID: 16348
	private GameObject NewMessage;

	// Token: 0x04003FDD RID: 16349
	public GameObject Message;

	// Token: 0x04003FDE RID: 16350
	public int MessageHeight;

	// Token: 0x04003FDF RID: 16351
	public string MessageText = string.Empty;
}
