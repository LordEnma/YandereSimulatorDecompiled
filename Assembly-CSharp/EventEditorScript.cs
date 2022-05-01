using System;
using UnityEngine;

// Token: 0x0200029B RID: 667
public class EventEditorScript : MonoBehaviour
{
	// Token: 0x0600140A RID: 5130 RVA: 0x000BEA2F File Offset: 0x000BCC2F
	private void Awake()
	{
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x0600140B RID: 5131 RVA: 0x000BEA3C File Offset: 0x000BCC3C
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.Label[4].text = string.Empty;
		this.promptBar.UpdateButtons();
	}

	// Token: 0x0600140C RID: 5132 RVA: 0x000BEA99 File Offset: 0x000BCC99
	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			this.mainPanel.gameObject.SetActive(true);
			this.eventPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x0600140D RID: 5133 RVA: 0x000BEAC9 File Offset: 0x000BCCC9
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DEB RID: 7659
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DEC RID: 7660
	[SerializeField]
	private UIPanel eventPanel;

	// Token: 0x04001DED RID: 7661
	[SerializeField]
	private UILabel titleLabel;

	// Token: 0x04001DEE RID: 7662
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DEF RID: 7663
	private InputManagerScript inputManager;
}
