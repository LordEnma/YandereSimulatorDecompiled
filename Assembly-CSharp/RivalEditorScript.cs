using System;
using UnityEngine;

// Token: 0x02000297 RID: 663
public class RivalEditorScript : MonoBehaviour
{
	// Token: 0x060013E9 RID: 5097 RVA: 0x000BC915 File Offset: 0x000BAB15
	private void Awake()
	{
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x060013EA RID: 5098 RVA: 0x000BC924 File Offset: 0x000BAB24
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.Label[4].text = string.Empty;
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013EB RID: 5099 RVA: 0x000BC981 File Offset: 0x000BAB81
	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			this.mainPanel.gameObject.SetActive(true);
			this.rivalPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x060013EC RID: 5100 RVA: 0x000BC9B1 File Offset: 0x000BABB1
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001D8A RID: 7562
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001D8B RID: 7563
	[SerializeField]
	private UIPanel rivalPanel;

	// Token: 0x04001D8C RID: 7564
	[SerializeField]
	private UILabel titleLabel;

	// Token: 0x04001D8D RID: 7565
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001D8E RID: 7566
	private InputManagerScript inputManager;
}
