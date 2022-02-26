using System;
using UnityEngine;

// Token: 0x0200029A RID: 666
public class EventEditorScript : MonoBehaviour
{
	// Token: 0x060013FC RID: 5116 RVA: 0x000BDC73 File Offset: 0x000BBE73
	private void Awake()
	{
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x060013FD RID: 5117 RVA: 0x000BDC80 File Offset: 0x000BBE80
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.Label[4].text = string.Empty;
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013FE RID: 5118 RVA: 0x000BDCDD File Offset: 0x000BBEDD
	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			this.mainPanel.gameObject.SetActive(true);
			this.eventPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x060013FF RID: 5119 RVA: 0x000BDD0D File Offset: 0x000BBF0D
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DC4 RID: 7620
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DC5 RID: 7621
	[SerializeField]
	private UIPanel eventPanel;

	// Token: 0x04001DC6 RID: 7622
	[SerializeField]
	private UILabel titleLabel;

	// Token: 0x04001DC7 RID: 7623
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DC8 RID: 7624
	private InputManagerScript inputManager;
}
