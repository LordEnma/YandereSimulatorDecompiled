using System;
using UnityEngine;

// Token: 0x0200029C RID: 668
public class EventEditorScript : MonoBehaviour
{
	// Token: 0x0600140C RID: 5132 RVA: 0x000BEC6F File Offset: 0x000BCE6F
	private void Awake()
	{
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x0600140D RID: 5133 RVA: 0x000BEC7C File Offset: 0x000BCE7C
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.Label[4].text = string.Empty;
		this.promptBar.UpdateButtons();
	}

	// Token: 0x0600140E RID: 5134 RVA: 0x000BECD9 File Offset: 0x000BCED9
	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			this.mainPanel.gameObject.SetActive(true);
			this.eventPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x0600140F RID: 5135 RVA: 0x000BED09 File Offset: 0x000BCF09
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DF2 RID: 7666
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DF3 RID: 7667
	[SerializeField]
	private UIPanel eventPanel;

	// Token: 0x04001DF4 RID: 7668
	[SerializeField]
	private UILabel titleLabel;

	// Token: 0x04001DF5 RID: 7669
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DF6 RID: 7670
	private InputManagerScript inputManager;
}
