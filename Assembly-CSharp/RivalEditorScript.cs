using System;
using UnityEngine;

// Token: 0x0200029A RID: 666
public class RivalEditorScript : MonoBehaviour
{
	// Token: 0x060013F8 RID: 5112 RVA: 0x000BD3DD File Offset: 0x000BB5DD
	private void Awake()
	{
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x060013F9 RID: 5113 RVA: 0x000BD3EC File Offset: 0x000BB5EC
	private void OnEnable()
	{
		this.promptBar.Label[0].text = string.Empty;
		this.promptBar.Label[1].text = "Back";
		this.promptBar.Label[4].text = string.Empty;
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013FA RID: 5114 RVA: 0x000BD449 File Offset: 0x000BB649
	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			this.mainPanel.gameObject.SetActive(true);
			this.rivalPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x060013FB RID: 5115 RVA: 0x000BD479 File Offset: 0x000BB679
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DBA RID: 7610
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DBB RID: 7611
	[SerializeField]
	private UIPanel rivalPanel;

	// Token: 0x04001DBC RID: 7612
	[SerializeField]
	private UILabel titleLabel;

	// Token: 0x04001DBD RID: 7613
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DBE RID: 7614
	private InputManagerScript inputManager;
}
