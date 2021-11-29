using System;
using UnityEngine;

// Token: 0x02000296 RID: 662
public class EventEditorScript : MonoBehaviour
{
	// Token: 0x060013E4 RID: 5092 RVA: 0x000BC86B File Offset: 0x000BAA6B
	private void Awake()
	{
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x060013E5 RID: 5093 RVA: 0x000BC878 File Offset: 0x000BAA78
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.Label[4].text = string.Empty;
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013E6 RID: 5094 RVA: 0x000BC8D5 File Offset: 0x000BAAD5
	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			this.mainPanel.gameObject.SetActive(true);
			this.eventPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x060013E7 RID: 5095 RVA: 0x000BC905 File Offset: 0x000BAB05
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001D85 RID: 7557
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001D86 RID: 7558
	[SerializeField]
	private UIPanel eventPanel;

	// Token: 0x04001D87 RID: 7559
	[SerializeField]
	private UILabel titleLabel;

	// Token: 0x04001D88 RID: 7560
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001D89 RID: 7561
	private InputManagerScript inputManager;
}
