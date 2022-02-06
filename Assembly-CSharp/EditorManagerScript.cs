using System;
using System.Collections.Generic;
using System.IO;
using JsonFx.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000297 RID: 663
public class EditorManagerScript : MonoBehaviour
{
	// Token: 0x060013E8 RID: 5096 RVA: 0x000BD1FA File Offset: 0x000BB3FA
	private void Awake()
	{
		this.buttonIndex = 0;
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x060013E9 RID: 5097 RVA: 0x000BD210 File Offset: 0x000BB410
	private void Start()
	{
		this.promptBar.Label[0].text = "Select";
		this.promptBar.Label[1].text = "Exit";
		this.promptBar.Label[4].text = "Choose";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013EA RID: 5098 RVA: 0x000BD270 File Offset: 0x000BB470
	private void OnEnable()
	{
		this.promptBar.Label[0].text = "Select";
		this.promptBar.Label[1].text = "Exit";
		this.promptBar.Label[4].text = "Choose";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013EB RID: 5099 RVA: 0x000BD2CD File Offset: 0x000BB4CD
	public static Dictionary<string, object>[] DeserializeJson(string filename)
	{
		return JsonReader.Deserialize<Dictionary<string, object>[]>(File.ReadAllText(Path.Combine(Application.streamingAssetsPath, Path.Combine("JSON", filename))));
	}

	// Token: 0x060013EC RID: 5100 RVA: 0x000BD2F0 File Offset: 0x000BB4F0
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

	// Token: 0x060013ED RID: 5101 RVA: 0x000BD3DF File Offset: 0x000BB5DF
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001DAB RID: 7595
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001DAC RID: 7596
	[SerializeField]
	private UIPanel[] editorPanels;

	// Token: 0x04001DAD RID: 7597
	[SerializeField]
	private UILabel cursorLabel;

	// Token: 0x04001DAE RID: 7598
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DAF RID: 7599
	private int buttonIndex;

	// Token: 0x04001DB0 RID: 7600
	private const int ButtonCount = 3;

	// Token: 0x04001DB1 RID: 7601
	private InputManagerScript inputManager;
}
