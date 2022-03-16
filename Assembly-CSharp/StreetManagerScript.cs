using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200044C RID: 1100
public class StreetManagerScript : MonoBehaviour
{
	// Token: 0x06001D39 RID: 7481 RVA: 0x0015DDDC File Offset: 0x0015BFDC
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

	// Token: 0x06001D3A RID: 7482 RVA: 0x0015E018 File Offset: 0x0015C218
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

	// Token: 0x06001D3B RID: 7483 RVA: 0x0015E576 File Offset: 0x0015C776
	private void LateUpdate()
	{
		this.Hips.LookAt(this.BinocularCamera.position);
	}

	// Token: 0x06001D3C RID: 7484 RVA: 0x0015E590 File Offset: 0x0015C790
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

	// Token: 0x06001D3D RID: 7485 RVA: 0x0015E650 File Offset: 0x0015C850
	public void EightiesifyLabel(UILabel Label)
	{
		Label.trueTypeFont = this.VCR;
		Label.applyGradient = false;
		Label.color = new Color(1f, 1f, 1f, 1f);
		Label.effectStyle = UILabel.Effect.Outline8;
		Label.effectColor = new Color(0f, 0f, 0f, 1f);
	}

	// Token: 0x0400354F RID: 13647
	public StreetShopInterfaceScript StreetShopInterface;

	// Token: 0x04003550 RID: 13648
	public AudioSource CurrentlyActiveJukebox;

	// Token: 0x04003551 RID: 13649
	public AudioSource JukeboxNight;

	// Token: 0x04003552 RID: 13650
	public AudioSource JukeboxDay;

	// Token: 0x04003553 RID: 13651
	public AudioSource Yakuza;

	// Token: 0x04003554 RID: 13652
	public Transform BinocularCamera;

	// Token: 0x04003555 RID: 13653
	public Transform Yandere;

	// Token: 0x04003556 RID: 13654
	public Transform Hips;

	// Token: 0x04003557 RID: 13655
	public Transform Sun;

	// Token: 0x04003558 RID: 13656
	public Animation MaidAnimation;

	// Token: 0x04003559 RID: 13657
	public Animation Gossip1;

	// Token: 0x0400355A RID: 13658
	public Animation Gossip2;

	// Token: 0x0400355B RID: 13659
	public GameObject MaidPrompt;

	// Token: 0x0400355C RID: 13660
	public GameObject MaidLabel;

	// Token: 0x0400355D RID: 13661
	public HomeClockScript Clock;

	// Token: 0x0400355E RID: 13662
	public Animation[] Civilian;

	// Token: 0x0400355F RID: 13663
	public GameObject Couple;

	// Token: 0x04003560 RID: 13664
	public UISprite Darkness;

	// Token: 0x04003561 RID: 13665
	public Renderer Stars;

	// Token: 0x04003562 RID: 13666
	public Light Sunlight;

	// Token: 0x04003563 RID: 13667
	public bool Threatened;

	// Token: 0x04003564 RID: 13668
	public bool GoToCafe;

	// Token: 0x04003565 RID: 13669
	public bool FadeOut;

	// Token: 0x04003566 RID: 13670
	public bool Mute;

	// Token: 0x04003567 RID: 13671
	public bool Day;

	// Token: 0x04003568 RID: 13672
	public float Rotation;

	// Token: 0x04003569 RID: 13673
	public float Timer;

	// Token: 0x0400356A RID: 13674
	public float DesiredValue;

	// Token: 0x0400356B RID: 13675
	public float StarAlpha;

	// Token: 0x0400356C RID: 13676
	public float Alpha;

	// Token: 0x0400356D RID: 13677
	public UILabel[] HUDLabels;

	// Token: 0x0400356E RID: 13678
	public AudioClip DayStreet80s;

	// Token: 0x0400356F RID: 13679
	public AudioClip NightStreet80s;

	// Token: 0x04003570 RID: 13680
	public GameObject EightiesCivilians;

	// Token: 0x04003571 RID: 13681
	public GameObject ModernCivilians;

	// Token: 0x04003572 RID: 13682
	public GameObject KenchoShip;

	// Token: 0x04003573 RID: 13683
	public Renderer Konbini;

	// Token: 0x04003574 RID: 13684
	public Texture EightiesKonbini;

	// Token: 0x04003575 RID: 13685
	public Font VCR;
}
