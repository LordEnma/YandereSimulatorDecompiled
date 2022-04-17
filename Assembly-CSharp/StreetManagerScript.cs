using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000450 RID: 1104
public class StreetManagerScript : MonoBehaviour
{
	// Token: 0x06001D4E RID: 7502 RVA: 0x0015F1BC File Offset: 0x0015D3BC
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

	// Token: 0x06001D4F RID: 7503 RVA: 0x0015F3F8 File Offset: 0x0015D5F8
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

	// Token: 0x06001D50 RID: 7504 RVA: 0x0015F956 File Offset: 0x0015DB56
	private void LateUpdate()
	{
		this.Hips.LookAt(this.BinocularCamera.position);
	}

	// Token: 0x06001D51 RID: 7505 RVA: 0x0015F970 File Offset: 0x0015DB70
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

	// Token: 0x06001D52 RID: 7506 RVA: 0x0015FA30 File Offset: 0x0015DC30
	public void EightiesifyLabel(UILabel Label)
	{
		Label.trueTypeFont = this.VCR;
		Label.applyGradient = false;
		Label.color = new Color(1f, 1f, 1f, 1f);
		Label.effectStyle = UILabel.Effect.Outline8;
		Label.effectColor = new Color(0f, 0f, 0f, 1f);
	}

	// Token: 0x0400357B RID: 13691
	public StreetShopInterfaceScript StreetShopInterface;

	// Token: 0x0400357C RID: 13692
	public AudioSource CurrentlyActiveJukebox;

	// Token: 0x0400357D RID: 13693
	public AudioSource JukeboxNight;

	// Token: 0x0400357E RID: 13694
	public AudioSource JukeboxDay;

	// Token: 0x0400357F RID: 13695
	public AudioSource Yakuza;

	// Token: 0x04003580 RID: 13696
	public Transform BinocularCamera;

	// Token: 0x04003581 RID: 13697
	public Transform Yandere;

	// Token: 0x04003582 RID: 13698
	public Transform Hips;

	// Token: 0x04003583 RID: 13699
	public Transform Sun;

	// Token: 0x04003584 RID: 13700
	public Animation MaidAnimation;

	// Token: 0x04003585 RID: 13701
	public Animation Gossip1;

	// Token: 0x04003586 RID: 13702
	public Animation Gossip2;

	// Token: 0x04003587 RID: 13703
	public GameObject MaidPrompt;

	// Token: 0x04003588 RID: 13704
	public GameObject MaidLabel;

	// Token: 0x04003589 RID: 13705
	public HomeClockScript Clock;

	// Token: 0x0400358A RID: 13706
	public Animation[] Civilian;

	// Token: 0x0400358B RID: 13707
	public GameObject Couple;

	// Token: 0x0400358C RID: 13708
	public UISprite Darkness;

	// Token: 0x0400358D RID: 13709
	public Renderer Stars;

	// Token: 0x0400358E RID: 13710
	public Light Sunlight;

	// Token: 0x0400358F RID: 13711
	public bool Threatened;

	// Token: 0x04003590 RID: 13712
	public bool GoToCafe;

	// Token: 0x04003591 RID: 13713
	public bool FadeOut;

	// Token: 0x04003592 RID: 13714
	public bool Mute;

	// Token: 0x04003593 RID: 13715
	public bool Day;

	// Token: 0x04003594 RID: 13716
	public float Rotation;

	// Token: 0x04003595 RID: 13717
	public float Timer;

	// Token: 0x04003596 RID: 13718
	public float DesiredValue;

	// Token: 0x04003597 RID: 13719
	public float StarAlpha;

	// Token: 0x04003598 RID: 13720
	public float Alpha;

	// Token: 0x04003599 RID: 13721
	public UILabel[] HUDLabels;

	// Token: 0x0400359A RID: 13722
	public AudioClip DayStreet80s;

	// Token: 0x0400359B RID: 13723
	public AudioClip NightStreet80s;

	// Token: 0x0400359C RID: 13724
	public GameObject EightiesCivilians;

	// Token: 0x0400359D RID: 13725
	public GameObject ModernCivilians;

	// Token: 0x0400359E RID: 13726
	public GameObject KenchoShip;

	// Token: 0x0400359F RID: 13727
	public Renderer Konbini;

	// Token: 0x040035A0 RID: 13728
	public Texture EightiesKonbini;

	// Token: 0x040035A1 RID: 13729
	public Font VCR;
}
