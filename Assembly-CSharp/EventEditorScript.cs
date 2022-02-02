using System;
using UnityEngine;

// Token: 0x02000298 RID: 664
public class EventEditorScript : MonoBehaviour
{
	// Token: 0x060013EF RID: 5103 RVA: 0x000BD35B File Offset: 0x000BB55B
	private void Awake()
	{
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x060013F0 RID: 5104 RVA: 0x000BD368 File Offset: 0x000BB568
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.Label[4].text = string.Empty;
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013F1 RID: 5105 RVA: 0x000BD3C5 File Offset: 0x000BB5C5
	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			this.mainPanel.gameObject.SetActive(true);
			this.eventPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x060013F2 RID: 5106 RVA: 0x000BD3F5 File Offset: 0x000BB5F5
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DAF RID: 7599
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DB0 RID: 7600
	[SerializeField]
	private UIPanel eventPanel;

	// Token: 0x04001DB1 RID: 7601
	[SerializeField]
	private UILabel titleLabel;

	// Token: 0x04001DB2 RID: 7602
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DB3 RID: 7603
	private InputManagerScript inputManager;
}
