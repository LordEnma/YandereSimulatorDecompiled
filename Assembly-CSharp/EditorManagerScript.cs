using System;
using System.Collections.Generic;
using System.IO;
using JsonFx.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000299 RID: 665
public class EditorManagerScript : MonoBehaviour
{
	// Token: 0x060013F8 RID: 5112 RVA: 0x000BDFFE File Offset: 0x000BC1FE
	private void Awake()
	{
		this.buttonIndex = 0;
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x060013F9 RID: 5113 RVA: 0x000BE014 File Offset: 0x000BC214
	private void Start()
	{
		this.promptBar.Label[0].text = "Select";
		this.promptBar.Label[1].text = "Exit";
		this.promptBar.Label[4].text = "Choose";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013FA RID: 5114 RVA: 0x000BE074 File Offset: 0x000BC274
	private void OnEnable()
	{
		this.promptBar.Label[0].text = "Select";
		this.promptBar.Label[1].text = "Exit";
		this.promptBar.Label[4].text = "Choose";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013FB RID: 5115 RVA: 0x000BE0D1 File Offset: 0x000BC2D1
	public static Dictionary<string, object>[] DeserializeJson(string filename)
	{
		return JsonReader.Deserialize<Dictionary<string, object>[]>(File.ReadAllText(Path.Combine(Application.streamingAssetsPath, Path.Combine("JSON", filename))));
	}

	// Token: 0x060013FC RID: 5116 RVA: 0x000BE0F4 File Offset: 0x000BC2F4
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

	// Token: 0x060013FD RID: 5117 RVA: 0x000BE1E3 File Offset: 0x000BC3E3
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DD5 RID: 7637
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DD6 RID: 7638
	[SerializeField]
	private UIPanel[] editorPanels;

	// Token: 0x04001DD7 RID: 7639
	[SerializeField]
	private UILabel cursorLabel;

	// Token: 0x04001DD8 RID: 7640
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DD9 RID: 7641
	private int buttonIndex;

	// Token: 0x04001DDA RID: 7642
	private const int ButtonCount = 3;

	// Token: 0x04001DDB RID: 7643
	private InputManagerScript inputManager;
}
