using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004C9 RID: 1225
public class WelcomeScript : MonoBehaviour
{
	// Token: 0x06002007 RID: 8199 RVA: 0x001C6894 File Offset: 0x001C4A94
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

	// Token: 0x06002008 RID: 8200 RVA: 0x001C6A9C File Offset: 0x001C4C9C
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

	// Token: 0x04004363 RID: 17251
	public JsonScript JSON;

	// Token: 0x04004364 RID: 17252
	public GameObject WelcomePanel;

	// Token: 0x04004365 RID: 17253
	public UILabel[] FlashingLabels;

	// Token: 0x04004366 RID: 17254
	public UILabel AltBeginLabel;

	// Token: 0x04004367 RID: 17255
	public UILabel BeginLabel;

	// Token: 0x04004368 RID: 17256
	public UILabel[] Labels;

	// Token: 0x04004369 RID: 17257
	public UISprite Darkness;

	// Token: 0x0400436A RID: 17258
	public bool Continue;

	// Token: 0x0400436B RID: 17259
	public bool FlashRed;

	// Token: 0x0400436C RID: 17260
	public float VersionNumber;

	// Token: 0x0400436D RID: 17261
	public float Timer;

	// Token: 0x0400436E RID: 17262
	public float Speed = 1f;

	// Token: 0x0400436F RID: 17263
	public string Text;

	// Token: 0x04004370 RID: 17264
	public int CurrentLabel = 1;

	// Token: 0x04004371 RID: 17265
	public int ID;
}
