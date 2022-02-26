using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200044B RID: 1099
public class StreetManagerScript : MonoBehaviour
{
	// Token: 0x06001D29 RID: 7465 RVA: 0x0015C6A8 File Offset: 0x0015A8A8
	private void Start()
	{
		this.MaidAnimation["f02_faceCouncilGrace_00"].layer = 1;
		this.MaidAnimation.Play("f02_faceCouncilGrace_00");
		this.MaidAnimation["f02_faceCouncilGrace_00"].weight = 1f;
		this.Gossip1["f02_socialSit_00"].layer = 1;
		this.Gossip1.Play("f02_socialSit_00");
		this.Gossip1["f02_socialSit_00"].weight = 1f;
		this.Gossip2["f02_socialSit_00"].layer = 1;
		this.Gossip2.Play("f02_socialSit_00");
		this.Gossip2["f02_socialSit_00"].weight = 1f;
		for (int i = 1; i < 6; i++)
		{
			this.Civilian[i]["f02_smile_00"].layer = 1;
			this.Civilian[i].Play("f02_smile_00");
			this.Civilian[i]["f02_smile_00"].weight = 1f;
		}
		this.Darkness.color = new Color(1f, 1f, 1f, 1f);
		this.CurrentlyActiveJukebox = this.JukeboxNight;
		this.Alpha = 1f;
		this.Sunlight.shadows = LightShadows.None;
		if (!HomeGlobals.Night)
		{
			this.Day = true;
			this.MaidLabel.SetActive(false);
			this.MaidPrompt.SetActive(false);
			this.Clock.HourLabel.text = "6:00 AM";
			this.Sunlight.shadows = LightShadows.Soft;
			this.Yakuza.transform.parent.gameObject.SetActive(false);
			if (DateGlobals.Weekday == DayOfWeek.Sunday)
			{
				this.MaidLabel.SetActive(true);
				this.MaidPrompt.SetActive(true);
			}
		}
		if (GameGlobals.Eighties)
		{
			this.BecomeEighties();
		}
		else
		{
			this.Yakuza.transform.parent.gameObject.SetActive(false);
			this.EightiesCivilians.SetActive(false);
			this.ModernCivilians.SetActive(true);
		}
		if (GameGlobals.YakuzaPhase > 0)
		{
			this.Threatened = true;
		}
	}

	// Token: 0x06001D2A RID: 7466 RVA: 0x0015C8E4 File Offset: 0x0015AAE4
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.5f)
		{
			if (this.Alpha == 1f)
			{
				this.JukeboxNight.volume = 0.5f;
				this.JukeboxNight.Play();
				this.JukeboxDay.volume = 0f;
				this.JukeboxDay.Play();
			}
			if (!this.FadeOut)
			{
				this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime);
				this.Darkness.color = new Color(1f, 1f, 1f, this.Alpha);
			}
			else
			{
				this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime);
				if (!this.StreetShopInterface.Show)
				{
					this.CurrentlyActiveJukebox.volume = (1f - this.Alpha) * 0.5f;
				}
				if (this.GoToCafe)
				{
					this.Darkness.color = new Color(1f, 1f, 1f, this.Alpha);
					if (this.Alpha == 1f)
					{
						SceneManager.LoadScene("MaidMenuScene");
					}
				}
				else
				{
					this.Darkness.color = new Color(0f, 0f, 0f, this.Alpha);
					if (this.Alpha == 1f)
					{
						Debug.Log("Going home, supposedly.");
						SceneManager.LoadScene("HomeScene");
					}
				}
			}
		}
		if (!this.FadeOut && !this.BinocularCamera.gameObject.activeInHierarchy)
		{
			if (this.Yandere.position.z > this.Yakuza.transform.position.z)
			{
				if (Vector3.Distance(this.Yandere.position, this.Yakuza.transform.position) > 5f)
				{
					this.DesiredValue = 0.5f;
				}
				else
				{
					this.DesiredValue = Vector3.Distance(this.Yandere.position, this.Yakuza.transform.position) * 0.1f;
				}
			}
			else
			{
				this.DesiredValue = 0f;
			}
			if (!this.StreetShopInterface.Show)
			{
				if (this.Day)
				{
					this.JukeboxDay.volume = Mathf.Lerp(this.JukeboxDay.volume, this.DesiredValue, Time.deltaTime * 10f);
					this.JukeboxNight.volume = Mathf.Lerp(this.JukeboxNight.volume, 0f, Time.deltaTime * 10f);
				}
				else
				{
					this.JukeboxDay.volume = Mathf.Lerp(this.JukeboxDay.volume, 0f, Time.deltaTime * 10f);
					this.JukeboxNight.volume = Mathf.Lerp(this.JukeboxNight.volume, this.DesiredValue, Time.deltaTime * 10f);
				}
			}
			if (Vector3.Distance(this.Yandere.position, this.Yakuza.transform.position) < 0.1f && !this.Threatened)
			{
				this.Threatened = true;
				this.Yakuza.Play();
			}
		}
		if (this.StreetShopInterface.Show)
		{
			this.JukeboxNight.volume = Mathf.Lerp(this.JukeboxNight.volume, 0f, Time.deltaTime * 10f);
			this.JukeboxDay.volume = Mathf.Lerp(this.JukeboxDay.volume, 0f, Time.deltaTime * 10f);
		}
		else if (this.Day)
		{
			this.CurrentlyActiveJukebox = this.JukeboxDay;
			this.Rotation = Mathf.Lerp(this.Rotation, 45f, Time.deltaTime * 10f);
			this.StarAlpha = Mathf.Lerp(this.StarAlpha, 0f, Time.deltaTime * 10f);
		}
		else
		{
			this.CurrentlyActiveJukebox = this.JukeboxNight;
			this.Rotation = Mathf.Lerp(this.Rotation, -45f, Time.deltaTime * 10f);
			this.StarAlpha = Mathf.Lerp(this.StarAlpha, 1f, Time.deltaTime * 10f);
		}
		this.Sun.transform.eulerAngles = new Vector3(this.Rotation, this.Rotation, 0f);
		this.Stars.material.SetColor("_TintColor", new Color(1f, 1f, 1f, this.StarAlpha));
	}

	// Token: 0x06001D2B RID: 7467 RVA: 0x0015CD94 File Offset: 0x0015AF94
	private void LateUpdate()
	{
		this.Hips.LookAt(this.BinocularCamera.position);
	}

	// Token: 0x06001D2C RID: 7468 RVA: 0x0015CDAC File Offset: 0x0015AFAC
	private void BecomeEighties()
	{
		for (int i = 1; i < this.HUDLabels.Length; i++)
		{
			this.EightiesifyLabel(this.HUDLabels[i]);
		}
		this.HUDLabels[1].transform.parent.localPosition -= new Vector3(25f, 25f, 0f);
		this.JukeboxDay.clip = this.DayStreet80s;
		this.JukeboxNight.clip = this.NightStreet80s;
		this.KenchoShip.SetActive(false);
		this.EightiesCivilians.SetActive(true);
		this.ModernCivilians.SetActive(false);
		this.Konbini.material.mainTexture = this.EightiesKonbini;
	}

	// Token: 0x06001D2D RID: 7469 RVA: 0x0015CE6C File Offset: 0x0015B06C
	public void EightiesifyLabel(UILabel Label)
	{
		Label.trueTypeFont = this.VCR;
		Label.applyGradient = false;
		Label.color = new Color(1f, 1f, 1f, 1f);
		Label.effectStyle = UILabel.Effect.Outline8;
		Label.effectColor = new Color(0f, 0f, 0f, 1f);
	}

	// Token: 0x040034FE RID: 13566
	public StreetShopInterfaceScript StreetShopInterface;

	// Token: 0x040034FF RID: 13567
	public AudioSource CurrentlyActiveJukebox;

	// Token: 0x04003500 RID: 13568
	public AudioSource JukeboxNight;

	// Token: 0x04003501 RID: 13569
	public AudioSource JukeboxDay;

	// Token: 0x04003502 RID: 13570
	public AudioSource Yakuza;

	// Token: 0x04003503 RID: 13571
	public Transform BinocularCamera;

	// Token: 0x04003504 RID: 13572
	public Transform Yandere;

	// Token: 0x04003505 RID: 13573
	public Transform Hips;

	// Token: 0x04003506 RID: 13574
	public Transform Sun;

	// Token: 0x04003507 RID: 13575
	public Animation MaidAnimation;

	// Token: 0x04003508 RID: 13576
	public Animation Gossip1;

	// Token: 0x04003509 RID: 13577
	public Animation Gossip2;

	// Token: 0x0400350A RID: 13578
	public GameObject MaidPrompt;

	// Token: 0x0400350B RID: 13579
	public GameObject MaidLabel;

	// Token: 0x0400350C RID: 13580
	public HomeClockScript Clock;

	// Token: 0x0400350D RID: 13581
	public Animation[] Civilian;

	// Token: 0x0400350E RID: 13582
	public GameObject Couple;

	// Token: 0x0400350F RID: 13583
	public UISprite Darkness;

	// Token: 0x04003510 RID: 13584
	public Renderer Stars;

	// Token: 0x04003511 RID: 13585
	public Light Sunlight;

	// Token: 0x04003512 RID: 13586
	public bool Threatened;

	// Token: 0x04003513 RID: 13587
	public bool GoToCafe;

	// Token: 0x04003514 RID: 13588
	public bool FadeOut;

	// Token: 0x04003515 RID: 13589
	public bool Day;

	// Token: 0x04003516 RID: 13590
	public float Rotation;

	// Token: 0x04003517 RID: 13591
	public float Timer;

	// Token: 0x04003518 RID: 13592
	public float DesiredValue;

	// Token: 0x04003519 RID: 13593
	public float StarAlpha;

	// Token: 0x0400351A RID: 13594
	public float Alpha;

	// Token: 0x0400351B RID: 13595
	public UILabel[] HUDLabels;

	// Token: 0x0400351C RID: 13596
	public AudioClip DayStreet80s;

	// Token: 0x0400351D RID: 13597
	public AudioClip NightStreet80s;

	// Token: 0x0400351E RID: 13598
	public GameObject EightiesCivilians;

	// Token: 0x0400351F RID: 13599
	public GameObject ModernCivilians;

	// Token: 0x04003520 RID: 13600
	public GameObject KenchoShip;

	// Token: 0x04003521 RID: 13601
	public Renderer Konbini;

	// Token: 0x04003522 RID: 13602
	public Texture EightiesKonbini;

	// Token: 0x04003523 RID: 13603
	public Font VCR;
}
