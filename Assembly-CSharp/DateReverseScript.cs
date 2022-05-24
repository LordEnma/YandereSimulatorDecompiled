using System;
using UnityEngine;

// Token: 0x02000271 RID: 625
public class DateReverseScript : MonoBehaviour
{
	// Token: 0x0600133F RID: 4927 RVA: 0x000AC34F File Offset: 0x000AA54F
	private void Start()
	{
		Time.timeScale = 1f;
		this.UpdateDate();
	}

	// Token: 0x06001340 RID: 4928 RVA: 0x000AC364 File Offset: 0x000AA564
	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.Rollback = true;
		}
		if (this.Rollback)
		{
			this.LifeTime += Time.deltaTime;
			this.Timer += Time.deltaTime;
			if (this.Timer > this.TimeLimit)
			{
				if ((this.Year == this.SlowYear && this.Month == this.SlowMonth && this.Day < this.SlowDay) || (this.Year == this.SlowYear && this.Month < this.SlowMonth))
				{
					this.TimeLimit *= 1.09f;
					if (this.Month == this.EndMonth && this.Day == this.EndDay + 1)
					{
						this.MyAudio.clip = this.Finish;
						this.Label.color = new Color(1f, 0f, 0f, 1f);
						base.enabled = false;
					}
				}
				else if (this.TimeLimit > 0.01f)
				{
					this.TimeLimit *= 0.9f;
				}
				else
				{
					this.Day += this.RollDirection * 19;
				}
				this.Timer = 0f;
				this.Day += this.RollDirection;
				this.UpdateDate();
				this.MyAudio.Play();
				if (!(this.MyAudio.clip != this.Finish))
				{
					this.MyAudio.pitch = 1f;
				}
			}
		}
	}

	// Token: 0x06001341 RID: 4929 RVA: 0x000AC50C File Offset: 0x000AA70C
	private void UpdateDate()
	{
		if (this.Day < 1)
		{
			this.Day = 31;
			this.Month--;
			if (this.Month < 1)
			{
				this.Month = 12;
				this.Year--;
			}
		}
		else if (this.Day > 31)
		{
			this.Day = 1;
			this.Month++;
			if (this.Month > 11)
			{
				this.Month = 1;
				this.Year++;
			}
		}
		if (this.Day == 1 || this.Day == 21 || this.Day == 31)
		{
			this.Prefix = "st";
		}
		else if (this.Day == 2 || this.Day == 22)
		{
			this.Prefix = "nd";
		}
		else if (this.Day == 3 || this.Day == 23)
		{
			this.Prefix = "rd";
		}
		else
		{
			this.Prefix = "th";
		}
		this.Label.text = string.Concat(new string[]
		{
			this.MonthName[this.Month],
			" ",
			this.Day.ToString(),
			this.Prefix,
			", ",
			this.Year.ToString()
		});
	}

	// Token: 0x04001BA7 RID: 7079
	public AudioSource MyAudio;

	// Token: 0x04001BA8 RID: 7080
	public string[] MonthName;

	// Token: 0x04001BA9 RID: 7081
	public string Prefix;

	// Token: 0x04001BAA RID: 7082
	public UILabel Label;

	// Token: 0x04001BAB RID: 7083
	public AudioClip Finish;

	// Token: 0x04001BAC RID: 7084
	public float TimeLimit;

	// Token: 0x04001BAD RID: 7085
	public float LifeTime;

	// Token: 0x04001BAE RID: 7086
	public float Timer;

	// Token: 0x04001BAF RID: 7087
	public int RollDirection;

	// Token: 0x04001BB0 RID: 7088
	public int Month;

	// Token: 0x04001BB1 RID: 7089
	public int Year;

	// Token: 0x04001BB2 RID: 7090
	public int Day;

	// Token: 0x04001BB3 RID: 7091
	public int SlowMonth;

	// Token: 0x04001BB4 RID: 7092
	public int SlowYear;

	// Token: 0x04001BB5 RID: 7093
	public int SlowDay;

	// Token: 0x04001BB6 RID: 7094
	public int EndMonth;

	// Token: 0x04001BB7 RID: 7095
	public int EndYear;

	// Token: 0x04001BB8 RID: 7096
	public int EndDay;

	// Token: 0x04001BB9 RID: 7097
	public bool Rollback;
}
