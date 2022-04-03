using System;
using UnityEngine;

// Token: 0x020000DB RID: 219
public class AudioSoftwareScript : MonoBehaviour
{
	// Token: 0x06000A09 RID: 2569 RVA: 0x00056921 File Offset: 0x00054B21
	private void Start()
	{
		this.Screen.SetActive(false);
	}

	// Token: 0x06000A0A RID: 2570 RVA: 0x00056930 File Offset: 0x00054B30
	private void Update()
	{
		if (this.ConversationRecorded && this.Yandere.Inventory.RivalPhone)
		{
			if (!this.Prompt.enabled)
			{
				this.Prompt.enabled = true;
			}
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.enabled = false;
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Yandere.CharacterAnimation.CrossFade("f02_onComputer_00");
			this.Yandere.MyController.radius = 0.1f;
			this.Yandere.CanMove = false;
			base.GetComponent<AudioSource>().Play();
			this.ChairCollider.enabled = false;
			this.Screen.SetActive(true);
			this.Editing = true;
		}
		if (this.Editing)
		{
			this.Yandere.CharacterAnimation.CrossFade("f02_onComputer_00");
			this.targetRotation = Quaternion.LookRotation(new Vector3(this.Screen.transform.position.x, this.Yandere.transform.position.y, this.Screen.transform.position.z) - this.Yandere.transform.position);
			this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
			this.Yandere.MoveTowardsTarget(this.SitSpot.position);
			this.Timer += Time.deltaTime;
			if (this.Timer > 1f)
			{
				this.EventSubtitle.text = "Okay, how 'bout that boy from class 3-2? What do you think of him?";
			}
			if (this.Timer > 7f)
			{
				this.EventSubtitle.text = "He's just my childhood friend.";
			}
			if (this.Timer > 9f)
			{
				this.EventSubtitle.text = "Is he your boyfriend?";
			}
			if (this.Timer > 11f)
			{
				this.EventSubtitle.text = "What? HIM? Ugh, no way! That guy's a total creep! I wouldn't date him if he was the last man alive on earth! He can go jump off a cliff for all I care!";
			}
			if (this.Timer > 22f)
			{
				this.Yandere.MyController.radius = 0.2f;
				this.Yandere.CanMove = true;
				this.ChairCollider.enabled = true;
				this.EventSubtitle.text = "";
				this.Screen.SetActive(false);
				this.AudioDoctored = true;
				this.Editing = false;
				this.Prompt.enabled = false;
				this.Prompt.Hide();
				base.enabled = false;
			}
		}
	}

	// Token: 0x04000AC7 RID: 2759
	public YandereScript Yandere;

	// Token: 0x04000AC8 RID: 2760
	public PromptScript Prompt;

	// Token: 0x04000AC9 RID: 2761
	public Quaternion targetRotation;

	// Token: 0x04000ACA RID: 2762
	public Collider ChairCollider;

	// Token: 0x04000ACB RID: 2763
	public UILabel EventSubtitle;

	// Token: 0x04000ACC RID: 2764
	public GameObject Screen;

	// Token: 0x04000ACD RID: 2765
	public Transform SitSpot;

	// Token: 0x04000ACE RID: 2766
	public bool ConversationRecorded;

	// Token: 0x04000ACF RID: 2767
	public bool AudioDoctored;

	// Token: 0x04000AD0 RID: 2768
	public bool Editing;

	// Token: 0x04000AD1 RID: 2769
	public float Timer;
}
