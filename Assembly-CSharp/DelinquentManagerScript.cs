using System;
using UnityEngine;

// Token: 0x02000276 RID: 630
public class DelinquentManagerScript : MonoBehaviour
{
	// Token: 0x06001359 RID: 4953 RVA: 0x000B0827 File Offset: 0x000AEA27
	private void Start()
	{
		this.Delinquents.SetActive(false);
		this.TimerMax = 15f;
		this.Timer = 15f;
		this.Phase++;
	}

	// Token: 0x0600135A RID: 4954 RVA: 0x000B085C File Offset: 0x000AEA5C
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

	// Token: 0x0600135B RID: 4955 RVA: 0x000B0AD4 File Offset: 0x000AECD4
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

	// Token: 0x0600135C RID: 4956 RVA: 0x000B0B58 File Offset: 0x000AED58
	public void EasterEgg()
	{
		this.RapBeat.SetActive(true);
		this.Mirror.Limit++;
	}

	// Token: 0x04001C14 RID: 7188
	public GameObject Delinquents;

	// Token: 0x04001C15 RID: 7189
	public GameObject RapBeat;

	// Token: 0x04001C16 RID: 7190
	public GameObject Panel;

	// Token: 0x04001C17 RID: 7191
	public float[] NextTime;

	// Token: 0x04001C18 RID: 7192
	public DelinquentScript Attacker;

	// Token: 0x04001C19 RID: 7193
	public MirrorScript Mirror;

	// Token: 0x04001C1A RID: 7194
	public UILabel TimeLabel;

	// Token: 0x04001C1B RID: 7195
	public ClockScript Clock;

	// Token: 0x04001C1C RID: 7196
	public UISprite Circle;

	// Token: 0x04001C1D RID: 7197
	public float SpeechTimer;

	// Token: 0x04001C1E RID: 7198
	public float TimerMax;

	// Token: 0x04001C1F RID: 7199
	public float Timer;

	// Token: 0x04001C20 RID: 7200
	public bool Aggro;

	// Token: 0x04001C21 RID: 7201
	public int Phase = 1;
}
