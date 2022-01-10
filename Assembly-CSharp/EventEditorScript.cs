using System;
using UnityEngine;

// Token: 0x02000298 RID: 664
public class EventEditorScript : MonoBehaviour
{
	// Token: 0x060013EE RID: 5102 RVA: 0x000BD0F3 File Offset: 0x000BB2F3
	private void Awake()
	{
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x060013EF RID: 5103 RVA: 0x000BD100 File Offset: 0x000BB300
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.Label[4].text = string.Empty;
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013F0 RID: 5104 RVA: 0x000BD15D File Offset: 0x000BB35D
	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			this.mainPanel.gameObject.SetActive(true);
			this.eventPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x060013F1 RID: 5105 RVA: 0x000BD18D File Offset: 0x000BB38D
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DA9 RID: 7593
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DAA RID: 7594
	[SerializeField]
	private UIPanel eventPanel;

	// Token: 0x04001DAB RID: 7595
	[SerializeField]
	private UILabel titleLabel;

	// Token: 0x04001DAC RID: 7596
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DAD RID: 7597
	private InputManagerScript inputManager;
}
