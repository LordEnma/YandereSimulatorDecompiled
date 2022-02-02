using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000449 RID: 1097
public class StreetManagerScript : MonoBehaviour
{
	// Token: 0x06001D17 RID: 7447 RVA: 0x0015B658 File Offset: 0x00159858
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

	// Token: 0x06001D18 RID: 7448 RVA: 0x0015B894 File Offset: 0x00159A94
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

	// Token: 0x06001D19 RID: 7449 RVA: 0x0015BD44 File Offset: 0x00159F44
	private void LateUpdate()
	{
		this.Hips.LookAt(this.BinocularCamera.position);
	}

	// Token: 0x06001D1A RID: 7450 RVA: 0x0015BD5C File Offset: 0x00159F5C
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

	// Token: 0x06001D1B RID: 7451 RVA: 0x0015BE1C File Offset: 0x0015A01C
	public void EightiesifyLabel(UILabel Label)
	{
		Label.trueTypeFont = this.VCR;
		Label.applyGradient = false;
		Label.color = new Color(1f, 1f, 1f, 1f);
		Label.effectStyle = UILabel.Effect.Outline8;
		Label.effectColor = new Color(0f, 0f, 0f, 1f);
	}

	// Token: 0x040034E4 RID: 13540
	public StreetShopInterfaceScript StreetShopInterface;

	// Token: 0x040034E5 RID: 13541
	public AudioSource CurrentlyActiveJukebox;

	// Token: 0x040034E6 RID: 13542
	public AudioSource JukeboxNight;

	// Token: 0x040034E7 RID: 13543
	public AudioSource JukeboxDay;

	// Token: 0x040034E8 RID: 13544
	public AudioSource Yakuza;

	// Token: 0x040034E9 RID: 13545
	public Transform BinocularCamera;

	// Token: 0x040034EA RID: 13546
	public Transform Yandere;

	// Token: 0x040034EB RID: 13547
	public Transform Hips;

	// Token: 0x040034EC RID: 13548
	public Transform Sun;

	// Token: 0x040034ED RID: 13549
	public Animation MaidAnimation;

	// Token: 0x040034EE RID: 13550
	public Animation Gossip1;

	// Token: 0x040034EF RID: 13551
	public Animation Gossip2;

	// Token: 0x040034F0 RID: 13552
	public GameObject MaidPrompt;

	// Token: 0x040034F1 RID: 13553
	public GameObject MaidLabel;

	// Token: 0x040034F2 RID: 13554
	public HomeClockScript Clock;

	// Token: 0x040034F3 RID: 13555
	public Animation[] Civilian;

	// Token: 0x040034F4 RID: 13556
	public GameObject Couple;

	// Token: 0x040034F5 RID: 13557
	public UISprite Darkness;

	// Token: 0x040034F6 RID: 13558
	public Renderer Stars;

	// Token: 0x040034F7 RID: 13559
	public Light Sunlight;

	// Token: 0x040034F8 RID: 13560
	public bool Threatened;

	// Token: 0x040034F9 RID: 13561
	public bool GoToCafe;

	// Token: 0x040034FA RID: 13562
	public bool FadeOut;

	// Token: 0x040034FB RID: 13563
	public bool Day;

	// Token: 0x040034FC RID: 13564
	public float Rotation;

	// Token: 0x040034FD RID: 13565
	public float Timer;

	// Token: 0x040034FE RID: 13566
	public float DesiredValue;

	// Token: 0x040034FF RID: 13567
	public float StarAlpha;

	// Token: 0x04003500 RID: 13568
	public float Alpha;

	// Token: 0x04003501 RID: 13569
	public UILabel[] HUDLabels;

	// Token: 0x04003502 RID: 13570
	public AudioClip DayStreet80s;

	// Token: 0x04003503 RID: 13571
	public AudioClip NightStreet80s;

	// Token: 0x04003504 RID: 13572
	public GameObject EightiesCivilians;

	// Token: 0x04003505 RID: 13573
	public GameObject ModernCivilians;

	// Token: 0x04003506 RID: 13574
	public GameObject KenchoShip;

	// Token: 0x04003507 RID: 13575
	public Renderer Konbini;

	// Token: 0x04003508 RID: 13576
	public Texture EightiesKonbini;

	// Token: 0x04003509 RID: 13577
	public Font VCR;
}
