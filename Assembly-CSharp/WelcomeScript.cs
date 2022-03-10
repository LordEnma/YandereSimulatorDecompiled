using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004C0 RID: 1216
public class WelcomeScript : MonoBehaviour
{
	// Token: 0x06001FDC RID: 8156 RVA: 0x001C2EA0 File Offset: 0x001C10A0
	private void Start()
	{
		Time.timeScale = 1f;
		this.ID = 0;
		while (this.ID < this.Labels.Length)
		{
			this.Labels[this.ID].color = new Color(this.Labels[this.ID].color.r, this.Labels[this.ID].color.g, this.Labels[this.ID].color.b, 0f);
			this.ID++;
		}
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		if (ApplicationGlobals.VersionNumber != this.VersionNumber)
		{
			ApplicationGlobals.VersionNumber = this.VersionNumber;
		}
		if (!Application.CanStreamedLevelBeLoaded("FunScene"))
		{
			Application.Quit();
		}
		if (File.Exists(Application.streamingAssetsPath + "/Fun.txt"))
		{
			this.Text = File.ReadAllText(Application.streamingAssetsPath + "/Fun.txt");
		}
		if (this.Text == "0" || this.Text == "1" || this.Text == "2" || this.Text == "3" || this.Text == "4" || this.Text == "5" || this.Text == "6" || this.Text == "7" || this.Text == "8" || this.Text == "9" || this.Text == "10" || this.Text == "69" || this.Text == "666")
		{
			SceneManager.LoadScene("VeryFunScene");
		}
	}

	// Token: 0x06001FDD RID: 8157 RVA: 0x001C30A8 File Offset: 0x001C12A8
	private void Update()
	{
		Input.GetKeyDown(KeyCode.S);
		Input.GetKeyDown(KeyCode.Y);
		if (!this.Continue)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a - Time.deltaTime);
			if (this.Darkness.color.a <= 0f)
			{
				Input.GetKeyDown(KeyCode.W);
				if (Input.anyKeyDown)
				{
					this.Speed += 1f;
				}
				if (this.CurrentLabel < this.Labels.Length)
				{
					this.Labels[this.CurrentLabel].color = new Color(this.Labels[this.CurrentLabel].color.r, this.Labels[this.CurrentLabel].color.g, this.Labels[this.CurrentLabel].color.b, this.Labels[this.CurrentLabel].color.a + Time.deltaTime * this.Speed);
					if (this.Labels[this.CurrentLabel].color.a >= 1f)
					{
						this.CurrentLabel++;
						return;
					}
				}
				else if (Input.anyKeyDown)
				{
					this.Darkness.color = new Color(1f, 1f, 1f, 0f);
					this.Continue = true;
					return;
				}
			}
		}
		else
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime);
			if (this.Darkness.color.a >= 1f)
			{
				SceneManager.LoadScene("SponsorScene");
			}
		}
	}

	// Token: 0x040042D3 RID: 17107
	public JsonScript JSON;

	// Token: 0x040042D4 RID: 17108
	public GameObject WelcomePanel;

	// Token: 0x040042D5 RID: 17109
	public UILabel[] FlashingLabels;

	// Token: 0x040042D6 RID: 17110
	public UILabel AltBeginLabel;

	// Token: 0x040042D7 RID: 17111
	public UILabel BeginLabel;

	// Token: 0x040042D8 RID: 17112
	public UILabel[] Labels;

	// Token: 0x040042D9 RID: 17113
	public UISprite Darkness;

	// Token: 0x040042DA RID: 17114
	public bool Continue;

	// Token: 0x040042DB RID: 17115
	public bool FlashRed;

	// Token: 0x040042DC RID: 17116
	public float VersionNumber;

	// Token: 0x040042DD RID: 17117
	public float Timer;

	// Token: 0x040042DE RID: 17118
	public float Speed = 1f;

	// Token: 0x040042DF RID: 17119
	public string Text;

	// Token: 0x040042E0 RID: 17120
	public int CurrentLabel = 1;

	// Token: 0x040042E1 RID: 17121
	public int ID;
}
