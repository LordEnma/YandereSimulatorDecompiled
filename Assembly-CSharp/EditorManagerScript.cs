using System;
using System.Collections.Generic;
using System.IO;
using JsonFx.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000299 RID: 665
public class EditorManagerScript : MonoBehaviour
{
	// Token: 0x060013F9 RID: 5113 RVA: 0x000BE10A File Offset: 0x000BC30A
	private void Awake()
	{
		this.buttonIndex = 0;
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x060013FA RID: 5114 RVA: 0x000BE120 File Offset: 0x000BC320
	private void Start()
	{
		this.promptBar.Label[0].text = "Select";
		this.promptBar.Label[1].text = "Exit";
		this.promptBar.Label[4].text = "Choose";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013FB RID: 5115 RVA: 0x000BE180 File Offset: 0x000BC380
	private void OnEnable()
	{
		this.promptBar.Label[0].text = "Select";
		this.promptBar.Label[1].text = "Exit";
		this.promptBar.Label[4].text = "Choose";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013FC RID: 5116 RVA: 0x000BE1DD File Offset: 0x000BC3DD
	public static Dictionary<string, object>[] DeserializeJson(string filename)
	{
		return JsonReader.Deserialize<Dictionary<string, object>[]>(File.ReadAllText(Path.Combine(Application.streamingAssetsPath, Path.Combine("JSON", filename))));
	}

	// Token: 0x060013FD RID: 5117 RVA: 0x000BE200 File Offset: 0x000BC400
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

	// Token: 0x060013FE RID: 5118 RVA: 0x000BE2EF File Offset: 0x000BC4EF
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DD8 RID: 7640
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DD9 RID: 7641
	[SerializeField]
	private UIPanel[] editorPanels;

	// Token: 0x04001DDA RID: 7642
	[SerializeField]
	private UILabel cursorLabel;

	// Token: 0x04001DDB RID: 7643
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DDC RID: 7644
	private int buttonIndex;

	// Token: 0x04001DDD RID: 7645
	private const int ButtonCount = 3;

	// Token: 0x04001DDE RID: 7646
	private InputManagerScript inputManager;
}
