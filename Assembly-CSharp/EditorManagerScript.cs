using System;
using System.Collections.Generic;
using System.IO;
using JsonFx.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000299 RID: 665
public class EditorManagerScript : MonoBehaviour
{
	// Token: 0x060013F5 RID: 5109 RVA: 0x000BDA7E File Offset: 0x000BBC7E
	private void Awake()
	{
		this.buttonIndex = 0;
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x060013F6 RID: 5110 RVA: 0x000BDA94 File Offset: 0x000BBC94
	private void Start()
	{
		this.promptBar.Label[0].text = "Select";
		this.promptBar.Label[1].text = "Exit";
		this.promptBar.Label[4].text = "Choose";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013F7 RID: 5111 RVA: 0x000BDAF4 File Offset: 0x000BBCF4
	private void OnEnable()
	{
		this.promptBar.Label[0].text = "Select";
		this.promptBar.Label[1].text = "Exit";
		this.promptBar.Label[4].text = "Choose";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013F8 RID: 5112 RVA: 0x000BDB51 File Offset: 0x000BBD51
	public static Dictionary<string, object>[] DeserializeJson(string filename)
	{
		return JsonReader.Deserialize<Dictionary<string, object>[]>(File.ReadAllText(Path.Combine(Application.streamingAssetsPath, Path.Combine("JSON", filename))));
	}

	// Token: 0x060013F9 RID: 5113 RVA: 0x000BDB74 File Offset: 0x000BBD74
	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			SceneManager.LoadScene("NewTitleScene");
		}
		bool tappedUp = this.inputManager.TappedUp;
		bool tappedDown = this.inputManager.TappedDown;
		if (tappedUp)
		{
			this.buttonIndex = ((this.buttonIndex > 0) ? (this.buttonIndex - 1) : 2);
		}
		else if (tappedDown)
		{
			this.buttonIndex = ((this.buttonIndex < 2) ? (this.buttonIndex + 1) : 0);
		}
		if (tappedUp || tappedDown)
		{
			Transform transform = this.cursorLabel.transform;
			transform.localPosition = new Vector3(transform.localPosition.x, 100f - (float)this.buttonIndex * 100f, transform.localPosition.z);
		}
		if (Input.GetButtonDown("A"))
		{
			this.editorPanels[this.buttonIndex].gameObject.SetActive(true);
			this.mainPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x060013FA RID: 5114 RVA: 0x000BDC63 File Offset: 0x000BBE63
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DBD RID: 7613
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DBE RID: 7614
	[SerializeField]
	private UIPanel[] editorPanels;

	// Token: 0x04001DBF RID: 7615
	[SerializeField]
	private UILabel cursorLabel;

	// Token: 0x04001DC0 RID: 7616
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DC1 RID: 7617
	private int buttonIndex;

	// Token: 0x04001DC2 RID: 7618
	private const int ButtonCount = 3;

	// Token: 0x04001DC3 RID: 7619
	private InputManagerScript inputManager;
}
