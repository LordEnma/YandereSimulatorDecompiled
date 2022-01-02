using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000446 RID: 1094
public class StreetManagerScript : MonoBehaviour
{
	// Token: 0x06001D0A RID: 7434 RVA: 0x001591F4 File Offset: 0x001573F4
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

	// Token: 0x06001D0B RID: 7435 RVA: 0x00159430 File Offset: 0x00157630
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

	// Token: 0x06001D0C RID: 7436 RVA: 0x001598E0 File Offset: 0x00157AE0
	private void LateUpdate()
	{
		this.Hips.LookAt(this.BinocularCamera.position);
	}

	// Token: 0x06001D0D RID: 7437 RVA: 0x001598F8 File Offset: 0x00157AF8
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

	// Token: 0x06001D0E RID: 7438 RVA: 0x001599B8 File Offset: 0x00157BB8
	public void EightiesifyLabel(UILabel Label)
	{
		Label.trueTypeFont = this.VCR;
		Label.applyGradient = false;
		Label.color = new Color(1f, 1f, 1f, 1f);
		Label.effectStyle = UILabel.Effect.Outline8;
		Label.effectColor = new Color(0f, 0f, 0f, 1f);
	}

	// Token: 0x040034C4 RID: 13508
	public StreetShopInterfaceScript StreetShopInterface;

	// Token: 0x040034C5 RID: 13509
	public AudioSource CurrentlyActiveJukebox;

	// Token: 0x040034C6 RID: 13510
	public AudioSource JukeboxNight;

	// Token: 0x040034C7 RID: 13511
	public AudioSource JukeboxDay;

	// Token: 0x040034C8 RID: 13512
	public AudioSource Yakuza;

	// Token: 0x040034C9 RID: 13513
	public Transform BinocularCamera;

	// Token: 0x040034CA RID: 13514
	public Transform Yandere;

	// Token: 0x040034CB RID: 13515
	public Transform Hips;

	// Token: 0x040034CC RID: 13516
	public Transform Sun;

	// Token: 0x040034CD RID: 13517
	public Animation MaidAnimation;

	// Token: 0x040034CE RID: 13518
	public Animation Gossip1;

	// Token: 0x040034CF RID: 13519
	public Animation Gossip2;

	// Token: 0x040034D0 RID: 13520
	public GameObject MaidPrompt;

	// Token: 0x040034D1 RID: 13521
	public GameObject MaidLabel;

	// Token: 0x040034D2 RID: 13522
	public HomeClockScript Clock;

	// Token: 0x040034D3 RID: 13523
	public Animation[] Civilian;

	// Token: 0x040034D4 RID: 13524
	public GameObject Couple;

	// Token: 0x040034D5 RID: 13525
	public UISprite Darkness;

	// Token: 0x040034D6 RID: 13526
	public Renderer Stars;

	// Token: 0x040034D7 RID: 13527
	public Light Sunlight;

	// Token: 0x040034D8 RID: 13528
	public bool Threatened;

	// Token: 0x040034D9 RID: 13529
	public bool GoToCafe;

	// Token: 0x040034DA RID: 13530
	public bool FadeOut;

	// Token: 0x040034DB RID: 13531
	public bool Day;

	// Token: 0x040034DC RID: 13532
	public float Rotation;

	// Token: 0x040034DD RID: 13533
	public float Timer;

	// Token: 0x040034DE RID: 13534
	public float DesiredValue;

	// Token: 0x040034DF RID: 13535
	public float StarAlpha;

	// Token: 0x040034E0 RID: 13536
	public float Alpha;

	// Token: 0x040034E1 RID: 13537
	public UILabel[] HUDLabels;

	// Token: 0x040034E2 RID: 13538
	public AudioClip DayStreet80s;

	// Token: 0x040034E3 RID: 13539
	public AudioClip NightStreet80s;

	// Token: 0x040034E4 RID: 13540
	public GameObject EightiesCivilians;

	// Token: 0x040034E5 RID: 13541
	public GameObject ModernCivilians;

	// Token: 0x040034E6 RID: 13542
	public GameObject KenchoShip;

	// Token: 0x040034E7 RID: 13543
	public Renderer Konbini;

	// Token: 0x040034E8 RID: 13544
	public Texture EightiesKonbini;

	// Token: 0x040034E9 RID: 13545
	public Font VCR;
}
