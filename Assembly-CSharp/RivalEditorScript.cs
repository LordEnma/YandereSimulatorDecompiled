using System;
using UnityEngine;

// Token: 0x02000299 RID: 665
public class RivalEditorScript : MonoBehaviour
{
	// Token: 0x060013F3 RID: 5107 RVA: 0x000BD19D File Offset: 0x000BB39D
	private void Awake()
	{
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x060013F4 RID: 5108 RVA: 0x000BD1AC File Offset: 0x000BB3AC
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.Label[4].text = string.Empty;
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013F5 RID: 5109 RVA: 0x000BD209 File Offset: 0x000BB409
	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			this.mainPanel.gameObject.SetActive(true);
			this.rivalPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x060013F6 RID: 5110 RVA: 0x000BD239 File Offset: 0x000BB439
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DAE RID: 7598
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DAF RID: 7599
	[SerializeField]
	private UIPanel rivalPanel;

	// Token: 0x04001DB0 RID: 7600
	[SerializeField]
	private UILabel titleLabel;

	// Token: 0x04001DB1 RID: 7601
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DB2 RID: 7602
	private InputManagerScript inputManager;
}
