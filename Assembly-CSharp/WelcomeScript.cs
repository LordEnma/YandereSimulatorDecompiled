using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004BE RID: 1214
public class WelcomeScript : MonoBehaviour
{
	// Token: 0x06001FCD RID: 8141 RVA: 0x001C1A18 File Offset: 0x001BFC18
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

	// Token: 0x06001FCE RID: 8142 RVA: 0x001C1C20 File Offset: 0x001BFE20
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

	// Token: 0x040042A7 RID: 17063
	public JsonScript JSON;

	// Token: 0x040042A8 RID: 17064
	public GameObject WelcomePanel;

	// Token: 0x040042A9 RID: 17065
	public UILabel[] FlashingLabels;

	// Token: 0x040042AA RID: 17066
	public UILabel AltBeginLabel;

	// Token: 0x040042AB RID: 17067
	public UILabel BeginLabel;

	// Token: 0x040042AC RID: 17068
	public UILabel[] Labels;

	// Token: 0x040042AD RID: 17069
	public UISprite Darkness;

	// Token: 0x040042AE RID: 17070
	public bool Continue;

	// Token: 0x040042AF RID: 17071
	public bool FlashRed;

	// Token: 0x040042B0 RID: 17072
	public float VersionNumber;

	// Token: 0x040042B1 RID: 17073
	public float Timer;

	// Token: 0x040042B2 RID: 17074
	public float Speed = 1f;

	// Token: 0x040042B3 RID: 17075
	public string Text;

	// Token: 0x040042B4 RID: 17076
	public int CurrentLabel = 1;

	// Token: 0x040042B5 RID: 17077
	public int ID;
}
