using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200044B RID: 1099
public class StreetManagerScript : MonoBehaviour
{
	// Token: 0x06001D2B RID: 7467 RVA: 0x0015CC2C File Offset: 0x0015AE2C
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

	// Token: 0x06001D2C RID: 7468 RVA: 0x0015CE68 File Offset: 0x0015B068
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
				if (!this.StreetShopInterface.Show && !this.Mute)
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
			if (!this.StreetShopInterface.Show && !this.Mute)
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
		if (Input.GetKeyDown("m"))
		{
			this.Mute = !this.Mute;
			Debug.Log("Mute is: " + this.Mute.ToString());
			if (this.Mute)
			{
				this.JukeboxNight.volume = 0f;
				this.JukeboxDay.volume = 0f;
				if (this.StreetShopInterface != null)
				{
					this.StreetShopInterface.Jukebox.volume = 0f;
				}
			}
			else
			{
				this.CurrentlyActiveJukebox.Play();
			}
		}
		if (!this.Mute)
		{
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
		}
		this.Sun.transform.eulerAngles = new Vector3(this.Rotation, this.Rotation, 0f);
		this.Stars.material.SetColor("_TintColor", new Color(1f, 1f, 1f, this.StarAlpha));
	}

	// Token: 0x06001D2D RID: 7469 RVA: 0x0015D3C6 File Offset: 0x0015B5C6
	private void LateUpdate()
	{
		this.Hips.LookAt(this.BinocularCamera.position);
	}

	// Token: 0x06001D2E RID: 7470 RVA: 0x0015D3E0 File Offset: 0x0015B5E0
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

	// Token: 0x06001D2F RID: 7471 RVA: 0x0015D4A0 File Offset: 0x0015B6A0
	public void EightiesifyLabel(UILabel Label)
	{
		Label.trueTypeFont = this.VCR;
		Label.applyGradient = false;
		Label.color = new Color(1f, 1f, 1f, 1f);
		Label.effectStyle = UILabel.Effect.Outline8;
		Label.effectColor = new Color(0f, 0f, 0f, 1f);
	}

	// Token: 0x04003514 RID: 13588
	public StreetShopInterfaceScript StreetShopInterface;

	// Token: 0x04003515 RID: 13589
	public AudioSource CurrentlyActiveJukebox;

	// Token: 0x04003516 RID: 13590
	public AudioSource JukeboxNight;

	// Token: 0x04003517 RID: 13591
	public AudioSource JukeboxDay;

	// Token: 0x04003518 RID: 13592
	public AudioSource Yakuza;

	// Token: 0x04003519 RID: 13593
	public Transform BinocularCamera;

	// Token: 0x0400351A RID: 13594
	public Transform Yandere;

	// Token: 0x0400351B RID: 13595
	public Transform Hips;

	// Token: 0x0400351C RID: 13596
	public Transform Sun;

	// Token: 0x0400351D RID: 13597
	public Animation MaidAnimation;

	// Token: 0x0400351E RID: 13598
	public Animation Gossip1;

	// Token: 0x0400351F RID: 13599
	public Animation Gossip2;

	// Token: 0x04003520 RID: 13600
	public GameObject MaidPrompt;

	// Token: 0x04003521 RID: 13601
	public GameObject MaidLabel;

	// Token: 0x04003522 RID: 13602
	public HomeClockScript Clock;

	// Token: 0x04003523 RID: 13603
	public Animation[] Civilian;

	// Token: 0x04003524 RID: 13604
	public GameObject Couple;

	// Token: 0x04003525 RID: 13605
	public UISprite Darkness;

	// Token: 0x04003526 RID: 13606
	public Renderer Stars;

	// Token: 0x04003527 RID: 13607
	public Light Sunlight;

	// Token: 0x04003528 RID: 13608
	public bool Threatened;

	// Token: 0x04003529 RID: 13609
	public bool GoToCafe;

	// Token: 0x0400352A RID: 13610
	public bool FadeOut;

	// Token: 0x0400352B RID: 13611
	public bool Mute;

	// Token: 0x0400352C RID: 13612
	public bool Day;

	// Token: 0x0400352D RID: 13613
	public float Rotation;

	// Token: 0x0400352E RID: 13614
	public float Timer;

	// Token: 0x0400352F RID: 13615
	public float DesiredValue;

	// Token: 0x04003530 RID: 13616
	public float StarAlpha;

	// Token: 0x04003531 RID: 13617
	public float Alpha;

	// Token: 0x04003532 RID: 13618
	public UILabel[] HUDLabels;

	// Token: 0x04003533 RID: 13619
	public AudioClip DayStreet80s;

	// Token: 0x04003534 RID: 13620
	public AudioClip NightStreet80s;

	// Token: 0x04003535 RID: 13621
	public GameObject EightiesCivilians;

	// Token: 0x04003536 RID: 13622
	public GameObject ModernCivilians;

	// Token: 0x04003537 RID: 13623
	public GameObject KenchoShip;

	// Token: 0x04003538 RID: 13624
	public Renderer Konbini;

	// Token: 0x04003539 RID: 13625
	public Texture EightiesKonbini;

	// Token: 0x0400353A RID: 13626
	public Font VCR;
}
