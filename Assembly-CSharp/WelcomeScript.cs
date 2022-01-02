using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004BA RID: 1210
public class WelcomeScript : MonoBehaviour
{
	// Token: 0x06001FB2 RID: 8114 RVA: 0x001BF4DC File Offset: 0x001BD6DC
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

	// Token: 0x06001FB3 RID: 8115 RVA: 0x001BF6E4 File Offset: 0x001BD8E4
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

	// Token: 0x04004272 RID: 17010
	public JsonScript JSON;

	// Token: 0x04004273 RID: 17011
	public GameObject WelcomePanel;

	// Token: 0x04004274 RID: 17012
	public UILabel[] FlashingLabels;

	// Token: 0x04004275 RID: 17013
	public UILabel AltBeginLabel;

	// Token: 0x04004276 RID: 17014
	public UILabel BeginLabel;

	// Token: 0x04004277 RID: 17015
	public UILabel[] Labels;

	// Token: 0x04004278 RID: 17016
	public UISprite Darkness;

	// Token: 0x04004279 RID: 17017
	public bool Continue;

	// Token: 0x0400427A RID: 17018
	public bool FlashRed;

	// Token: 0x0400427B RID: 17019
	public float VersionNumber;

	// Token: 0x0400427C RID: 17020
	public float Timer;

	// Token: 0x0400427D RID: 17021
	public float Speed = 1f;

	// Token: 0x0400427E RID: 17022
	public string Text;

	// Token: 0x0400427F RID: 17023
	public int CurrentLabel = 1;

	// Token: 0x04004280 RID: 17024
	public int ID;
}
