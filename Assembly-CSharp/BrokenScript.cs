using System;
using UnityEngine;

// Token: 0x020000F8 RID: 248
public class BrokenScript : MonoBehaviour
{
	// Token: 0x06000A68 RID: 2664 RVA: 0x0005C97C File Offset: 0x0005AB7C
	private void Start()
	{
		this.HairPhysics[0].enabled = false;
		this.HairPhysics[1].enabled = false;
		this.PermanentAngleR = this.TwintailR.eulerAngles;
		this.PermanentAngleL = this.TwintailL.eulerAngles;
		this.Subtitle = GameObject.Find("EventSubtitle").GetComponent<UILabel>();
		this.Yandere = GameObject.Find("YandereChan");
	}

	// Token: 0x06000A69 RID: 2665 RVA: 0x0005C9EC File Offset: 0x0005ABEC
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

	// Token: 0x04000C1B RID: 3099
	public DynamicBone[] HairPhysics;

	// Token: 0x04000C1C RID: 3100
	public string[] MutterTexts;

	// Token: 0x04000C1D RID: 3101
	public AudioClip[] Mutters;

	// Token: 0x04000C1E RID: 3102
	public Vector3 PermanentAngleR;

	// Token: 0x04000C1F RID: 3103
	public Vector3 PermanentAngleL;

	// Token: 0x04000C20 RID: 3104
	public Transform TwintailR;

	// Token: 0x04000C21 RID: 3105
	public Transform TwintailL;

	// Token: 0x04000C22 RID: 3106
	public AudioClip KillKillKill;

	// Token: 0x04000C23 RID: 3107
	public AudioClip Stab;

	// Token: 0x04000C24 RID: 3108
	public AudioClip DoIt;

	// Token: 0x04000C25 RID: 3109
	public GameObject VoiceClip;

	// Token: 0x04000C26 RID: 3110
	public GameObject Yandere;

	// Token: 0x04000C27 RID: 3111
	public UILabel Subtitle;

	// Token: 0x04000C28 RID: 3112
	public AudioSource MyAudio;

	// Token: 0x04000C29 RID: 3113
	public bool Hunting;

	// Token: 0x04000C2A RID: 3114
	public bool Stabbed;

	// Token: 0x04000C2B RID: 3115
	public bool Began;

	// Token: 0x04000C2C RID: 3116
	public bool Done;

	// Token: 0x04000C2D RID: 3117
	public float SuicideTimer;

	// Token: 0x04000C2E RID: 3118
	public float Timer;

	// Token: 0x04000C2F RID: 3119
	public int ID = 1;
}
