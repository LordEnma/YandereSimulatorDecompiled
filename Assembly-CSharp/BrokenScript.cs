using System;
using UnityEngine;

// Token: 0x020000F8 RID: 248
public class BrokenScript : MonoBehaviour
{
	// Token: 0x06000A6A RID: 2666 RVA: 0x0005CD94 File Offset: 0x0005AF94
	private void Start()
	{
		this.HairPhysics[0].enabled = false;
		this.HairPhysics[1].enabled = false;
		this.PermanentAngleR = this.TwintailR.eulerAngles;
		this.PermanentAngleL = this.TwintailL.eulerAngles;
		this.Subtitle = GameObject.Find("EventSubtitle").GetComponent<UILabel>();
		this.Yandere = GameObject.Find("YandereChan");
	}

	// Token: 0x06000A6B RID: 2667 RVA: 0x0005CE04 File Offset: 0x0005B004
	private void Update()
	{
		if (!this.Done)
		{
			float num = Vector3.Distance(this.Yandere.transform.position, base.transform.root.position);
			if (num < 6f)
			{
				if (num < 5f)
				{
					if (!this.Hunting)
					{
						this.Timer += Time.deltaTime;
						if (this.VoiceClip == null)
						{
							this.Subtitle.text = "";
						}
						if (this.Timer > 5f)
						{
							this.Timer = 0f;
							this.Subtitle.text = this.MutterTexts[this.ID];
							AudioClipPlayer.PlayAttached(this.Mutters[this.ID], base.transform.position, base.transform, 1f, 5f, out this.VoiceClip, this.Yandere.transform.position.y);
							this.ID++;
							if (this.ID == this.Mutters.Length)
							{
								this.ID = 1;
							}
						}
					}
					else if (!this.Began)
					{
						if (this.VoiceClip != null)
						{
							UnityEngine.Object.Destroy(this.VoiceClip);
						}
						this.Subtitle.text = "Do it.";
						AudioClipPlayer.PlayAttached(this.DoIt, base.transform.position, base.transform, 1f, 5f, out this.VoiceClip, this.Yandere.transform.position.y);
						this.Began = true;
					}
					else if (this.VoiceClip == null)
					{
						this.Subtitle.text = "...kill...kill...kill...";
						AudioClipPlayer.PlayAttached(this.KillKillKill, base.transform.position, base.transform, 1f, 5f, out this.VoiceClip, this.Yandere.transform.position.y);
					}
					float num2 = Mathf.Abs((num - 5f) * 0.2f);
					num2 = ((num2 > 1f) ? 1f : num2);
					this.Subtitle.transform.localScale = new Vector3(num2, num2, num2);
				}
				else
				{
					this.Subtitle.transform.localScale = Vector3.zero;
				}
			}
		}
		Vector3 eulerAngles = this.TwintailR.eulerAngles;
		Vector3 eulerAngles2 = this.TwintailL.eulerAngles;
		eulerAngles.x = this.PermanentAngleR.x;
		eulerAngles.z = this.PermanentAngleR.z;
		eulerAngles2.x = this.PermanentAngleL.x;
		eulerAngles2.z = this.PermanentAngleL.z;
		this.TwintailR.eulerAngles = eulerAngles;
		this.TwintailL.eulerAngles = eulerAngles2;
	}

	// Token: 0x04000C2C RID: 3116
	public DynamicBone[] HairPhysics;

	// Token: 0x04000C2D RID: 3117
	public string[] MutterTexts;

	// Token: 0x04000C2E RID: 3118
	public AudioClip[] Mutters;

	// Token: 0x04000C2F RID: 3119
	public Vector3 PermanentAngleR;

	// Token: 0x04000C30 RID: 3120
	public Vector3 PermanentAngleL;

	// Token: 0x04000C31 RID: 3121
	public Transform TwintailR;

	// Token: 0x04000C32 RID: 3122
	public Transform TwintailL;

	// Token: 0x04000C33 RID: 3123
	public AudioClip KillKillKill;

	// Token: 0x04000C34 RID: 3124
	public AudioClip Stab;

	// Token: 0x04000C35 RID: 3125
	public AudioClip DoIt;

	// Token: 0x04000C36 RID: 3126
	public GameObject VoiceClip;

	// Token: 0x04000C37 RID: 3127
	public GameObject Yandere;

	// Token: 0x04000C38 RID: 3128
	public UILabel Subtitle;

	// Token: 0x04000C39 RID: 3129
	public AudioSource MyAudio;

	// Token: 0x04000C3A RID: 3130
	public bool Hunting;

	// Token: 0x04000C3B RID: 3131
	public bool Stabbed;

	// Token: 0x04000C3C RID: 3132
	public bool Began;

	// Token: 0x04000C3D RID: 3133
	public bool Done;

	// Token: 0x04000C3E RID: 3134
	public float SuicideTimer;

	// Token: 0x04000C3F RID: 3135
	public float Timer;

	// Token: 0x04000C40 RID: 3136
	public int ID = 1;
}
