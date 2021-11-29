using System;
using UnityEngine;

// Token: 0x02000461 RID: 1121
public class TapePlayerScript : MonoBehaviour
{
	// Token: 0x06001E5E RID: 7774 RVA: 0x001A92BC File Offset: 0x001A74BC
	private void Start()
	{
		this.Tape.SetActive(false);
	}

	// Token: 0x06001E5F RID: 7775 RVA: 0x001A92CC File Offset: 0x001A74CC
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

	// Token: 0x04003E83 RID: 16003
	public TapePlayerMenuScript TapePlayerMenu;

	// Token: 0x04003E84 RID: 16004
	public PromptBarScript PromptBar;

	// Token: 0x04003E85 RID: 16005
	public YandereScript Yandere;

	// Token: 0x04003E86 RID: 16006
	public PromptScript Prompt;

	// Token: 0x04003E87 RID: 16007
	public Transform RWButton;

	// Token: 0x04003E88 RID: 16008
	public Transform FFButton;

	// Token: 0x04003E89 RID: 16009
	public Camera TapePlayerCamera;

	// Token: 0x04003E8A RID: 16010
	public Transform[] Rolls;

	// Token: 0x04003E8B RID: 16011
	public GameObject NoteWindow;

	// Token: 0x04003E8C RID: 16012
	public GameObject Tape;

	// Token: 0x04003E8D RID: 16013
	public bool FastForward;

	// Token: 0x04003E8E RID: 16014
	public bool Rewind;

	// Token: 0x04003E8F RID: 16015
	public bool Spin;

	// Token: 0x04003E90 RID: 16016
	public float SpinSpeed;
}
