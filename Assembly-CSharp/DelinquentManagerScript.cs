using System;
using UnityEngine;

// Token: 0x02000278 RID: 632
public class DelinquentManagerScript : MonoBehaviour
{
	// Token: 0x0600136D RID: 4973 RVA: 0x000B1FA7 File Offset: 0x000B01A7
	private void Start()
	{
		this.Delinquents.SetActive(false);
		this.TimerMax = 15f;
		this.Timer = 15f;
		this.Phase++;
	}

	// Token: 0x0600136E RID: 4974 RVA: 0x000B1FDC File Offset: 0x000B01DC
	private void Update()
	{
		this.SpeechTimer = Mathf.MoveTowards(this.SpeechTimer, 0f, Time.deltaTime);
		if (this.Attacker != null && !this.Attacker.Attacking && this.Attacker.ExpressedSurprise && this.Attacker.Run && !this.Aggro)
		{
			AudioSource component = base.GetComponent<AudioSource>();
			component.clip = this.Attacker.AggroClips[UnityEngine.Random.Range(0, this.Attacker.AggroClips.Length)];
			component.Play();
			this.Aggro = true;
		}
		if (this.Panel.activeInHierarchy && this.Clock.HourTime > this.NextTime[this.Phase])
		{
			if (this.Phase == 3 && this.Clock.HourTime > 7.25f)
			{
				this.TimerMax = 75f;
				this.Timer = 75f;
				this.Phase++;
			}
			else if (this.Phase == 5 && this.Clock.HourTime > 8.5f)
			{
				this.TimerMax = 285f;
				this.Timer = 285f;
				this.Phase++;
			}
			else if (this.Phase == 7 && this.Clock.HourTime > 13.25f)
			{
				this.TimerMax = 15f;
				this.Timer = 15f;
				this.Phase++;
			}
			else if (this.Phase == 9 && this.Clock.HourTime > 13.5f)
			{
				this.TimerMax = 135f;
				this.Timer = 135f;
				this.Phase++;
			}
			if (this.Attacker == null)
			{
				this.Timer -= Time.deltaTime * (this.Clock.TimeSpeed / 60f);
			}
			this.Circle.fillAmount = 1f - this.Timer / this.TimerMax;
			if (this.Timer <= 0f)
			{
				this.Delinquents.SetActive(!this.Delinquents.activeInHierarchy);
				if (this.Phase < 8)
				{
					this.Phase++;
					return;
				}
				this.Delinquents.SetActive(false);
				this.Panel.SetActive(false);
			}
		}
	}

	// Token: 0x0600136F RID: 4975 RVA: 0x000B2254 File Offset: 0x000B0454
	public void CheckTime()
	{
		if (this.Clock.HourTime < 13f)
		{
			this.Delinquents.SetActive(false);
			this.TimerMax = 15f;
			this.Timer = 15f;
			this.Phase = 6;
			return;
		}
		if (this.Clock.HourTime < 15.5f)
		{
			this.Delinquents.SetActive(false);
			this.TimerMax = 15f;
			this.Timer = 15f;
			this.Phase = 8;
		}
	}

	// Token: 0x06001370 RID: 4976 RVA: 0x000B22D8 File Offset: 0x000B04D8
	public void EasterEgg()
	{
		this.RapBeat.SetActive(true);
		this.Mirror.Limit++;
	}

	// Token: 0x04001C66 RID: 7270
	public GameObject Delinquents;

	// Token: 0x04001C67 RID: 7271
	public GameObject RapBeat;

	// Token: 0x04001C68 RID: 7272
	public GameObject Panel;

	// Token: 0x04001C69 RID: 7273
	public float[] NextTime;

	// Token: 0x04001C6A RID: 7274
	public DelinquentScript Attacker;

	// Token: 0x04001C6B RID: 7275
	public MirrorScript Mirror;

	// Token: 0x04001C6C RID: 7276
	public UILabel TimeLabel;

	// Token: 0x04001C6D RID: 7277
	public ClockScript Clock;

	// Token: 0x04001C6E RID: 7278
	public UISprite Circle;

	// Token: 0x04001C6F RID: 7279
	public float SpeechTimer;

	// Token: 0x04001C70 RID: 7280
	public float TimerMax;

	// Token: 0x04001C71 RID: 7281
	public float Timer;

	// Token: 0x04001C72 RID: 7282
	public bool Aggro;

	// Token: 0x04001C73 RID: 7283
	public int Phase = 1;
}
