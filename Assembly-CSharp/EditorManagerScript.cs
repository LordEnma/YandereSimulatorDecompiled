using System;
using System.Collections.Generic;
using System.IO;
using JsonFx.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000298 RID: 664
public class EditorManagerScript : MonoBehaviour
{
	// Token: 0x060013EC RID: 5100 RVA: 0x000BD13E File Offset: 0x000BB33E
	private void Awake()
	{
		this.buttonIndex = 0;
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x060013ED RID: 5101 RVA: 0x000BD154 File Offset: 0x000BB354
	private void Start()
	{
		this.promptBar.Label[0].text = "Select";
		this.promptBar.Label[1].text = "Exit";
		this.promptBar.Label[4].text = "Choose";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013EE RID: 5102 RVA: 0x000BD1B4 File Offset: 0x000BB3B4
	private void OnEnable()
	{
		this.promptBar.Label[0].text = "Select";
		this.promptBar.Label[1].text = "Exit";
		this.promptBar.Label[4].text = "Choose";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013EF RID: 5103 RVA: 0x000BD211 File Offset: 0x000BB411
	public static Dictionary<string, object>[] DeserializeJson(string filename)
	{
		return JsonReader.Deserialize<Dictionary<string, object>[]>(File.ReadAllText(Path.Combine(Application.streamingAssetsPath, Path.Combine("JSON", filename))));
	}

	// Token: 0x060013F0 RID: 5104 RVA: 0x000BD234 File Offset: 0x000BB434
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

	// Token: 0x060013F1 RID: 5105 RVA: 0x000BD323 File Offset: 0x000BB523
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DAE RID: 7598
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DAF RID: 7599
	[SerializeField]
	private UIPanel[] editorPanels;

	// Token: 0x04001DB0 RID: 7600
	[SerializeField]
	private UILabel cursorLabel;

	// Token: 0x04001DB1 RID: 7601
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DB2 RID: 7602
	private int buttonIndex;

	// Token: 0x04001DB3 RID: 7603
	private const int ButtonCount = 3;

	// Token: 0x04001DB4 RID: 7604
	private InputManagerScript inputManager;
}
