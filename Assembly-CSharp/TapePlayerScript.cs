using System;
using UnityEngine;

// Token: 0x02000466 RID: 1126
public class TapePlayerScript : MonoBehaviour
{
	// Token: 0x06001E84 RID: 7812 RVA: 0x001AC9C4 File Offset: 0x001AABC4
	private void Start()
	{
		this.Tape.SetActive(false);
	}

	// Token: 0x06001E85 RID: 7813 RVA: 0x001AC9D4 File Offset: 0x001AABD4
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

	// Token: 0x04003EEE RID: 16110
	public TapePlayerMenuScript TapePlayerMenu;

	// Token: 0x04003EEF RID: 16111
	public PromptBarScript PromptBar;

	// Token: 0x04003EF0 RID: 16112
	public YandereScript Yandere;

	// Token: 0x04003EF1 RID: 16113
	public PromptScript Prompt;

	// Token: 0x04003EF2 RID: 16114
	public Transform RWButton;

	// Token: 0x04003EF3 RID: 16115
	public Transform FFButton;

	// Token: 0x04003EF4 RID: 16116
	public Camera TapePlayerCamera;

	// Token: 0x04003EF5 RID: 16117
	public Transform[] Rolls;

	// Token: 0x04003EF6 RID: 16118
	public GameObject NoteWindow;

	// Token: 0x04003EF7 RID: 16119
	public GameObject Tape;

	// Token: 0x04003EF8 RID: 16120
	public bool FastForward;

	// Token: 0x04003EF9 RID: 16121
	public bool Rewind;

	// Token: 0x04003EFA RID: 16122
	public bool Spin;

	// Token: 0x04003EFB RID: 16123
	public float SpinSpeed;
}
