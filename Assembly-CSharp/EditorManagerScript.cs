using System;
using System.Collections.Generic;
using System.IO;
using JsonFx.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000297 RID: 663
public class EditorManagerScript : MonoBehaviour
{
	// Token: 0x060013E7 RID: 5095 RVA: 0x000BCEFE File Offset: 0x000BB0FE
	private void Awake()
	{
		this.buttonIndex = 0;
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x060013E8 RID: 5096 RVA: 0x000BCF14 File Offset: 0x000BB114
	private void Start()
	{
		this.promptBar.Label[0].text = "Select";
		this.promptBar.Label[1].text = "Exit";
		this.promptBar.Label[4].text = "Choose";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013E9 RID: 5097 RVA: 0x000BCF74 File Offset: 0x000BB174
	private void OnEnable()
	{
		this.promptBar.Label[0].text = "Select";
		this.promptBar.Label[1].text = "Exit";
		this.promptBar.Label[4].text = "Choose";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013EA RID: 5098 RVA: 0x000BCFD1 File Offset: 0x000BB1D1
	public static Dictionary<string, object>[] DeserializeJson(string filename)
	{
		return JsonReader.Deserialize<Dictionary<string, object>[]>(File.ReadAllText(Path.Combine(Application.streamingAssetsPath, Path.Combine("JSON", filename))));
	}

	// Token: 0x060013EB RID: 5099 RVA: 0x000BCFF4 File Offset: 0x000BB1F4
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

	// Token: 0x060013EC RID: 5100 RVA: 0x000BD0E3 File Offset: 0x000BB2E3
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DA2 RID: 7586
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DA3 RID: 7587
	[SerializeField]
	private UIPanel[] editorPanels;

	// Token: 0x04001DA4 RID: 7588
	[SerializeField]
	private UILabel cursorLabel;

	// Token: 0x04001DA5 RID: 7589
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DA6 RID: 7590
	private int buttonIndex;

	// Token: 0x04001DA7 RID: 7591
	private const int ButtonCount = 3;

	// Token: 0x04001DA8 RID: 7592
	private InputManagerScript inputManager;
}
