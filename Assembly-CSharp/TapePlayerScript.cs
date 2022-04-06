using System;
using UnityEngine;

// Token: 0x0200046D RID: 1133
public class TapePlayerScript : MonoBehaviour
{
	// Token: 0x06001EB2 RID: 7858 RVA: 0x001B0B44 File Offset: 0x001AED44
	private void Start()
	{
		this.Tape.SetActive(false);
	}

	// Token: 0x06001EB3 RID: 7859 RVA: 0x001B0B54 File Offset: 0x001AED54
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

	// Token: 0x04003F8D RID: 16269
	public TapePlayerMenuScript TapePlayerMenu;

	// Token: 0x04003F8E RID: 16270
	public PromptBarScript PromptBar;

	// Token: 0x04003F8F RID: 16271
	public YandereScript Yandere;

	// Token: 0x04003F90 RID: 16272
	public PromptScript Prompt;

	// Token: 0x04003F91 RID: 16273
	public Transform RWButton;

	// Token: 0x04003F92 RID: 16274
	public Transform FFButton;

	// Token: 0x04003F93 RID: 16275
	public Camera TapePlayerCamera;

	// Token: 0x04003F94 RID: 16276
	public Transform[] Rolls;

	// Token: 0x04003F95 RID: 16277
	public GameObject NoteWindow;

	// Token: 0x04003F96 RID: 16278
	public GameObject Tape;

	// Token: 0x04003F97 RID: 16279
	public bool FastForward;

	// Token: 0x04003F98 RID: 16280
	public bool Rewind;

	// Token: 0x04003F99 RID: 16281
	public bool Spin;

	// Token: 0x04003F9A RID: 16282
	public float SpinSpeed;
}
