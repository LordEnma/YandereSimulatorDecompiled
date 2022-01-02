using System;
using UnityEngine;

// Token: 0x02000462 RID: 1122
public class TapePlayerScript : MonoBehaviour
{
	// Token: 0x06001E6A RID: 7786 RVA: 0x001AA4FC File Offset: 0x001A86FC
	private void Start()
	{
		this.Tape.SetActive(false);
	}

	// Token: 0x06001E6B RID: 7787 RVA: 0x001AA50C File Offset: 0x001A870C
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

	// Token: 0x04003EBA RID: 16058
	public TapePlayerMenuScript TapePlayerMenu;

	// Token: 0x04003EBB RID: 16059
	public PromptBarScript PromptBar;

	// Token: 0x04003EBC RID: 16060
	public YandereScript Yandere;

	// Token: 0x04003EBD RID: 16061
	public PromptScript Prompt;

	// Token: 0x04003EBE RID: 16062
	public Transform RWButton;

	// Token: 0x04003EBF RID: 16063
	public Transform FFButton;

	// Token: 0x04003EC0 RID: 16064
	public Camera TapePlayerCamera;

	// Token: 0x04003EC1 RID: 16065
	public Transform[] Rolls;

	// Token: 0x04003EC2 RID: 16066
	public GameObject NoteWindow;

	// Token: 0x04003EC3 RID: 16067
	public GameObject Tape;

	// Token: 0x04003EC4 RID: 16068
	public bool FastForward;

	// Token: 0x04003EC5 RID: 16069
	public bool Rewind;

	// Token: 0x04003EC6 RID: 16070
	public bool Spin;

	// Token: 0x04003EC7 RID: 16071
	public float SpinSpeed;
}
