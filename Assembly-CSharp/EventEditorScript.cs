using System;
using UnityEngine;

// Token: 0x02000297 RID: 663
public class EventEditorScript : MonoBehaviour
{
	// Token: 0x060013EB RID: 5099 RVA: 0x000BCE07 File Offset: 0x000BB007
	private void Awake()
	{
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x060013EC RID: 5100 RVA: 0x000BCE14 File Offset: 0x000BB014
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.Label[4].text = string.Empty;
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013ED RID: 5101 RVA: 0x000BCE71 File Offset: 0x000BB071
	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			this.mainPanel.gameObject.SetActive(true);
			this.eventPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x060013EE RID: 5102 RVA: 0x000BCEA1 File Offset: 0x000BB0A1
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DA5 RID: 7589
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DA6 RID: 7590
	[SerializeField]
	private UIPanel eventPanel;

	// Token: 0x04001DA7 RID: 7591
	[SerializeField]
	private UILabel titleLabel;

	// Token: 0x04001DA8 RID: 7592
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DA9 RID: 7593
	private InputManagerScript inputManager;
}
