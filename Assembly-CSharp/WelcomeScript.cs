using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004BD RID: 1213
public class WelcomeScript : MonoBehaviour
{
	// Token: 0x06001FC1 RID: 8129 RVA: 0x001C1094 File Offset: 0x001BF294
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

	// Token: 0x06001FC2 RID: 8130 RVA: 0x001C129C File Offset: 0x001BF49C
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

	// Token: 0x04004295 RID: 17045
	public JsonScript JSON;

	// Token: 0x04004296 RID: 17046
	public GameObject WelcomePanel;

	// Token: 0x04004297 RID: 17047
	public UILabel[] FlashingLabels;

	// Token: 0x04004298 RID: 17048
	public UILabel AltBeginLabel;

	// Token: 0x04004299 RID: 17049
	public UILabel BeginLabel;

	// Token: 0x0400429A RID: 17050
	public UILabel[] Labels;

	// Token: 0x0400429B RID: 17051
	public UISprite Darkness;

	// Token: 0x0400429C RID: 17052
	public bool Continue;

	// Token: 0x0400429D RID: 17053
	public bool FlashRed;

	// Token: 0x0400429E RID: 17054
	public float VersionNumber;

	// Token: 0x0400429F RID: 17055
	public float Timer;

	// Token: 0x040042A0 RID: 17056
	public float Speed = 1f;

	// Token: 0x040042A1 RID: 17057
	public string Text;

	// Token: 0x040042A2 RID: 17058
	public int CurrentLabel = 1;

	// Token: 0x040042A3 RID: 17059
	public int ID;
}
