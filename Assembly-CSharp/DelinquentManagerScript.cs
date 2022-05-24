using System;
using UnityEngine;

// Token: 0x02000279 RID: 633
public class DelinquentManagerScript : MonoBehaviour
{
	// Token: 0x0600136F RID: 4975 RVA: 0x000B2287 File Offset: 0x000B0487
	private void Start()
	{
		this.Delinquents.SetActive(false);
		this.TimerMax = 15f;
		this.Timer = 15f;
		this.Phase++;
	}

	// Token: 0x06001370 RID: 4976 RVA: 0x000B22BC File Offset: 0x000B04BC
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

	// Token: 0x06001371 RID: 4977 RVA: 0x000B2534 File Offset: 0x000B0734
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

	// Token: 0x06001372 RID: 4978 RVA: 0x000B25B8 File Offset: 0x000B07B8
	public void EasterEgg()
	{
		this.RapBeat.SetActive(true);
		this.Mirror.Limit++;
	}

	// Token: 0x04001C6D RID: 7277
	public GameObject Delinquents;

	// Token: 0x04001C6E RID: 7278
	public GameObject RapBeat;

	// Token: 0x04001C6F RID: 7279
	public GameObject Panel;

	// Token: 0x04001C70 RID: 7280
	public float[] NextTime;

	// Token: 0x04001C71 RID: 7281
	public DelinquentScript Attacker;

	// Token: 0x04001C72 RID: 7282
	public MirrorScript Mirror;

	// Token: 0x04001C73 RID: 7283
	public UILabel TimeLabel;

	// Token: 0x04001C74 RID: 7284
	public ClockScript Clock;

	// Token: 0x04001C75 RID: 7285
	public UISprite Circle;

	// Token: 0x04001C76 RID: 7286
	public float SpeechTimer;

	// Token: 0x04001C77 RID: 7287
	public float TimerMax;

	// Token: 0x04001C78 RID: 7288
	public float Timer;

	// Token: 0x04001C79 RID: 7289
	public bool Aggro;

	// Token: 0x04001C7A RID: 7290
	public int Phase = 1;
}
