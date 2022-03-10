using System;
using UnityEngine;

// Token: 0x02000467 RID: 1127
public class TapePlayerScript : MonoBehaviour
{
	// Token: 0x06001E90 RID: 7824 RVA: 0x001ADC28 File Offset: 0x001ABE28
	private void Start()
	{
		this.Tape.SetActive(false);
	}

	// Token: 0x06001E91 RID: 7825 RVA: 0x001ADC38 File Offset: 0x001ABE38
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

	// Token: 0x04003F15 RID: 16149
	public TapePlayerMenuScript TapePlayerMenu;

	// Token: 0x04003F16 RID: 16150
	public PromptBarScript PromptBar;

	// Token: 0x04003F17 RID: 16151
	public YandereScript Yandere;

	// Token: 0x04003F18 RID: 16152
	public PromptScript Prompt;

	// Token: 0x04003F19 RID: 16153
	public Transform RWButton;

	// Token: 0x04003F1A RID: 16154
	public Transform FFButton;

	// Token: 0x04003F1B RID: 16155
	public Camera TapePlayerCamera;

	// Token: 0x04003F1C RID: 16156
	public Transform[] Rolls;

	// Token: 0x04003F1D RID: 16157
	public GameObject NoteWindow;

	// Token: 0x04003F1E RID: 16158
	public GameObject Tape;

	// Token: 0x04003F1F RID: 16159
	public bool FastForward;

	// Token: 0x04003F20 RID: 16160
	public bool Rewind;

	// Token: 0x04003F21 RID: 16161
	public bool Spin;

	// Token: 0x04003F22 RID: 16162
	public float SpinSpeed;
}
