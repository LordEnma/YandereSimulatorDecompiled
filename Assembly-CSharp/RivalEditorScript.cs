using System;
using UnityEngine;

// Token: 0x0200029C RID: 668
public class RivalEditorScript : MonoBehaviour
{
	// Token: 0x0600140B RID: 5131 RVA: 0x000BE635 File Offset: 0x000BC835
	private void Awake()
	{
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x0600140C RID: 5132 RVA: 0x000BE644 File Offset: 0x000BC844
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.Label[4].text = string.Empty;
		this.promptBar.UpdateButtons();
	}

	// Token: 0x0600140D RID: 5133 RVA: 0x000BE6A1 File Offset: 0x000BC8A1
	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			this.mainPanel.gameObject.SetActive(true);
			this.rivalPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x0600140E RID: 5134 RVA: 0x000BE6D1 File Offset: 0x000BC8D1
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DE7 RID: 7655
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DE8 RID: 7656
	[SerializeField]
	private UIPanel rivalPanel;

	// Token: 0x04001DE9 RID: 7657
	[SerializeField]
	private UILabel titleLabel;

	// Token: 0x04001DEA RID: 7658
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DEB RID: 7659
	private InputManagerScript inputManager;
}
