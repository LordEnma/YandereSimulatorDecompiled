using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004B8 RID: 1208
public class WelcomeScript : MonoBehaviour
{
	// Token: 0x06001F9E RID: 8094 RVA: 0x001BD794 File Offset: 0x001BB994
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

	// Token: 0x06001F9F RID: 8095 RVA: 0x001BD99C File Offset: 0x001BBB9C
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

	// Token: 0x0400422A RID: 16938
	public JsonScript JSON;

	// Token: 0x0400422B RID: 16939
	public GameObject WelcomePanel;

	// Token: 0x0400422C RID: 16940
	public UILabel[] FlashingLabels;

	// Token: 0x0400422D RID: 16941
	public UILabel AltBeginLabel;

	// Token: 0x0400422E RID: 16942
	public UILabel BeginLabel;

	// Token: 0x0400422F RID: 16943
	public UILabel[] Labels;

	// Token: 0x04004230 RID: 16944
	public UISprite Darkness;

	// Token: 0x04004231 RID: 16945
	public bool Continue;

	// Token: 0x04004232 RID: 16946
	public bool FlashRed;

	// Token: 0x04004233 RID: 16947
	public float VersionNumber;

	// Token: 0x04004234 RID: 16948
	public float Timer;

	// Token: 0x04004235 RID: 16949
	public float Speed = 1f;

	// Token: 0x04004236 RID: 16950
	public string Text;

	// Token: 0x04004237 RID: 16951
	public int CurrentLabel = 1;

	// Token: 0x04004238 RID: 16952
	public int ID;
}
