using System;
using UnityEngine;

// Token: 0x0200046E RID: 1134
public class TapePlayerScript : MonoBehaviour
{
	// Token: 0x06001EC1 RID: 7873 RVA: 0x001B288C File Offset: 0x001B0A8C
	private void Start()
	{
		this.Tape.SetActive(false);
	}

	// Token: 0x06001EC2 RID: 7874 RVA: 0x001B289C File Offset: 0x001B0A9C
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

	// Token: 0x04003FB3 RID: 16307
	public TapePlayerMenuScript TapePlayerMenu;

	// Token: 0x04003FB4 RID: 16308
	public PromptBarScript PromptBar;

	// Token: 0x04003FB5 RID: 16309
	public YandereScript Yandere;

	// Token: 0x04003FB6 RID: 16310
	public PromptScript Prompt;

	// Token: 0x04003FB7 RID: 16311
	public Transform RWButton;

	// Token: 0x04003FB8 RID: 16312
	public Transform FFButton;

	// Token: 0x04003FB9 RID: 16313
	public Camera TapePlayerCamera;

	// Token: 0x04003FBA RID: 16314
	public Transform[] Rolls;

	// Token: 0x04003FBB RID: 16315
	public GameObject NoteWindow;

	// Token: 0x04003FBC RID: 16316
	public GameObject Tape;

	// Token: 0x04003FBD RID: 16317
	public bool FastForward;

	// Token: 0x04003FBE RID: 16318
	public bool Rewind;

	// Token: 0x04003FBF RID: 16319
	public bool Spin;

	// Token: 0x04003FC0 RID: 16320
	public float SpinSpeed;
}
