using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000445 RID: 1093
public class StreetManagerScript : MonoBehaviour
{
	// Token: 0x06001D00 RID: 7424 RVA: 0x0015848C File Offset: 0x0015668C
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

	// Token: 0x06001D01 RID: 7425 RVA: 0x001586C8 File Offset: 0x001568C8
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

	// Token: 0x06001D02 RID: 7426 RVA: 0x00158B78 File Offset: 0x00156D78
	private void LateUpdate()
	{
		this.Hips.LookAt(this.BinocularCamera.position);
	}

	// Token: 0x06001D03 RID: 7427 RVA: 0x00158B90 File Offset: 0x00156D90
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

	// Token: 0x06001D04 RID: 7428 RVA: 0x00158C50 File Offset: 0x00156E50
	public void EightiesifyLabel(UILabel Label)
	{
		Label.trueTypeFont = this.VCR;
		Label.applyGradient = false;
		Label.color = new Color(1f, 1f, 1f, 1f);
		Label.effectStyle = UILabel.Effect.Outline8;
		Label.effectColor = new Color(0f, 0f, 0f, 1f);
	}

	// Token: 0x04003492 RID: 13458
	public StreetShopInterfaceScript StreetShopInterface;

	// Token: 0x04003493 RID: 13459
	public AudioSource CurrentlyActiveJukebox;

	// Token: 0x04003494 RID: 13460
	public AudioSource JukeboxNight;

	// Token: 0x04003495 RID: 13461
	public AudioSource JukeboxDay;

	// Token: 0x04003496 RID: 13462
	public AudioSource Yakuza;

	// Token: 0x04003497 RID: 13463
	public Transform BinocularCamera;

	// Token: 0x04003498 RID: 13464
	public Transform Yandere;

	// Token: 0x04003499 RID: 13465
	public Transform Hips;

	// Token: 0x0400349A RID: 13466
	public Transform Sun;

	// Token: 0x0400349B RID: 13467
	public Animation MaidAnimation;

	// Token: 0x0400349C RID: 13468
	public Animation Gossip1;

	// Token: 0x0400349D RID: 13469
	public Animation Gossip2;

	// Token: 0x0400349E RID: 13470
	public GameObject MaidPrompt;

	// Token: 0x0400349F RID: 13471
	public GameObject MaidLabel;

	// Token: 0x040034A0 RID: 13472
	public HomeClockScript Clock;

	// Token: 0x040034A1 RID: 13473
	public Animation[] Civilian;

	// Token: 0x040034A2 RID: 13474
	public GameObject Couple;

	// Token: 0x040034A3 RID: 13475
	public UISprite Darkness;

	// Token: 0x040034A4 RID: 13476
	public Renderer Stars;

	// Token: 0x040034A5 RID: 13477
	public Light Sunlight;

	// Token: 0x040034A6 RID: 13478
	public bool Threatened;

	// Token: 0x040034A7 RID: 13479
	public bool GoToCafe;

	// Token: 0x040034A8 RID: 13480
	public bool FadeOut;

	// Token: 0x040034A9 RID: 13481
	public bool Day;

	// Token: 0x040034AA RID: 13482
	public float Rotation;

	// Token: 0x040034AB RID: 13483
	public float Timer;

	// Token: 0x040034AC RID: 13484
	public float DesiredValue;

	// Token: 0x040034AD RID: 13485
	public float StarAlpha;

	// Token: 0x040034AE RID: 13486
	public float Alpha;

	// Token: 0x040034AF RID: 13487
	public UILabel[] HUDLabels;

	// Token: 0x040034B0 RID: 13488
	public AudioClip DayStreet80s;

	// Token: 0x040034B1 RID: 13489
	public AudioClip NightStreet80s;

	// Token: 0x040034B2 RID: 13490
	public GameObject EightiesCivilians;

	// Token: 0x040034B3 RID: 13491
	public GameObject ModernCivilians;

	// Token: 0x040034B4 RID: 13492
	public GameObject KenchoShip;

	// Token: 0x040034B5 RID: 13493
	public Renderer Konbini;

	// Token: 0x040034B6 RID: 13494
	public Texture EightiesKonbini;

	// Token: 0x040034B7 RID: 13495
	public Font VCR;
}
