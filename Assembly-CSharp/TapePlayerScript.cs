using System;
using UnityEngine;

// Token: 0x02000464 RID: 1124
public class TapePlayerScript : MonoBehaviour
{
	// Token: 0x06001E75 RID: 7797 RVA: 0x001AAE7C File Offset: 0x001A907C
	private void Start()
	{
		this.Tape.SetActive(false);
	}

	// Token: 0x06001E76 RID: 7798 RVA: 0x001AAE8C File Offset: 0x001A908C
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Yandere.HeartCamera.enabled = false;
			this.Yandere.RPGCamera.enabled = false;
			this.TapePlayerMenu.TimeBar.gameObject.SetActive(true);
			this.TapePlayerMenu.List.gameObject.SetActive(true);
			this.TapePlayerCamera.enabled = true;
			this.TapePlayerMenu.UpdateLabels();
			this.TapePlayerMenu.Show = true;
			this.NoteWindow.SetActive(false);
			this.Yandere.CanMove = false;
			this.Yandere.HUD.alpha = 0f;
			Time.timeScale = 0.0001f;
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[1].text = "EXIT";
			this.PromptBar.Label[4].text = "CHOOSE";
			this.PromptBar.Label[5].text = "CATEGORY";
			this.TapePlayerMenu.CheckSelection();
			this.PromptBar.Show = true;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		if (this.Spin)
		{
			Transform transform = this.Rolls[0];
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + 0.016666668f * (360f * this.SpinSpeed), transform.localEulerAngles.z);
			Transform transform2 = this.Rolls[1];
			transform2.localEulerAngles = new Vector3(transform2.localEulerAngles.x, transform2.localEulerAngles.y + 0.016666668f * (360f * this.SpinSpeed), transform2.localEulerAngles.z);
		}
		if (this.FastForward)
		{
			this.FFButton.localEulerAngles = new Vector3(Mathf.MoveTowards(this.FFButton.localEulerAngles.x, 6.25f, 1.6666666f), this.FFButton.localEulerAngles.y, this.FFButton.localEulerAngles.z);
			this.SpinSpeed = 2f;
		}
		else
		{
			this.FFButton.localEulerAngles = new Vector3(Mathf.MoveTowards(this.FFButton.localEulerAngles.x, 0f, 1.6666666f), this.FFButton.localEulerAngles.y, this.FFButton.localEulerAngles.z);
			this.SpinSpeed = 1f;
		}
		if (this.Rewind)
		{
			this.RWButton.localEulerAngles = new Vector3(Mathf.MoveTowards(this.RWButton.localEulerAngles.x, 6.25f, 1.6666666f), this.RWButton.localEulerAngles.y, this.RWButton.localEulerAngles.z);
			this.SpinSpeed = -2f;
			return;
		}
		this.RWButton.localEulerAngles = new Vector3(Mathf.MoveTowards(this.RWButton.localEulerAngles.x, 0f, 1.6666666f), this.RWButton.localEulerAngles.y, this.RWButton.localEulerAngles.z);
	}

	// Token: 0x04003ECE RID: 16078
	public TapePlayerMenuScript TapePlayerMenu;

	// Token: 0x04003ECF RID: 16079
	public PromptBarScript PromptBar;

	// Token: 0x04003ED0 RID: 16080
	public YandereScript Yandere;

	// Token: 0x04003ED1 RID: 16081
	public PromptScript Prompt;

	// Token: 0x04003ED2 RID: 16082
	public Transform RWButton;

	// Token: 0x04003ED3 RID: 16083
	public Transform FFButton;

	// Token: 0x04003ED4 RID: 16084
	public Camera TapePlayerCamera;

	// Token: 0x04003ED5 RID: 16085
	public Transform[] Rolls;

	// Token: 0x04003ED6 RID: 16086
	public GameObject NoteWindow;

	// Token: 0x04003ED7 RID: 16087
	public GameObject Tape;

	// Token: 0x04003ED8 RID: 16088
	public bool FastForward;

	// Token: 0x04003ED9 RID: 16089
	public bool Rewind;

	// Token: 0x04003EDA RID: 16090
	public bool Spin;

	// Token: 0x04003EDB RID: 16091
	public float SpinSpeed;
}
