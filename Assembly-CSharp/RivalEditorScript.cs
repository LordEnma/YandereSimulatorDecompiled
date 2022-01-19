using System;
using UnityEngine;

// Token: 0x02000299 RID: 665
public class RivalEditorScript : MonoBehaviour
{
	// Token: 0x060013F3 RID: 5107 RVA: 0x000BD201 File Offset: 0x000BB401
	private void Awake()
	{
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x060013F4 RID: 5108 RVA: 0x000BD210 File Offset: 0x000BB410
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.Label[4].text = string.Empty;
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013F5 RID: 5109 RVA: 0x000BD26D File Offset: 0x000BB46D
	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			this.mainPanel.gameObject.SetActive(true);
			this.rivalPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x060013F6 RID: 5110 RVA: 0x000BD29D File Offset: 0x000BB49D
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DB0 RID: 7600
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DB1 RID: 7601
	[SerializeField]
	private UIPanel rivalPanel;

	// Token: 0x04001DB2 RID: 7602
	[SerializeField]
	private UILabel titleLabel;

	// Token: 0x04001DB3 RID: 7603
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DB4 RID: 7604
	private InputManagerScript inputManager;
}
