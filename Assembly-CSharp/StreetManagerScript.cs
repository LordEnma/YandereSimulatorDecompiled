using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000452 RID: 1106
public class StreetManagerScript : MonoBehaviour
{
	// Token: 0x06001D5C RID: 7516 RVA: 0x00160988 File Offset: 0x0015EB88
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

	// Token: 0x06001D5D RID: 7517 RVA: 0x00160BC4 File Offset: 0x0015EDC4
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

	// Token: 0x06001D5E RID: 7518 RVA: 0x00161122 File Offset: 0x0015F322
	private void LateUpdate()
	{
		this.Hips.LookAt(this.BinocularCamera.position);
	}

	// Token: 0x06001D5F RID: 7519 RVA: 0x0016113C File Offset: 0x0015F33C
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

	// Token: 0x06001D60 RID: 7520 RVA: 0x001611FC File Offset: 0x0015F3FC
	public void EightiesifyLabel(UILabel Label)
	{
		Label.trueTypeFont = this.VCR;
		Label.applyGradient = false;
		Label.color = new Color(1f, 1f, 1f, 1f);
		Label.effectStyle = UILabel.Effect.Outline8;
		Label.effectColor = new Color(0f, 0f, 0f, 1f);
	}

	// Token: 0x040035A7 RID: 13735
	public StreetShopInterfaceScript StreetShopInterface;

	// Token: 0x040035A8 RID: 13736
	public AudioSource CurrentlyActiveJukebox;

	// Token: 0x040035A9 RID: 13737
	public AudioSource JukeboxNight;

	// Token: 0x040035AA RID: 13738
	public AudioSource JukeboxDay;

	// Token: 0x040035AB RID: 13739
	public AudioSource Yakuza;

	// Token: 0x040035AC RID: 13740
	public Transform BinocularCamera;

	// Token: 0x040035AD RID: 13741
	public Transform Yandere;

	// Token: 0x040035AE RID: 13742
	public Transform Hips;

	// Token: 0x040035AF RID: 13743
	public Transform Sun;

	// Token: 0x040035B0 RID: 13744
	public Animation MaidAnimation;

	// Token: 0x040035B1 RID: 13745
	public Animation Gossip1;

	// Token: 0x040035B2 RID: 13746
	public Animation Gossip2;

	// Token: 0x040035B3 RID: 13747
	public GameObject MaidPrompt;

	// Token: 0x040035B4 RID: 13748
	public GameObject MaidLabel;

	// Token: 0x040035B5 RID: 13749
	public HomeClockScript Clock;

	// Token: 0x040035B6 RID: 13750
	public Animation[] Civilian;

	// Token: 0x040035B7 RID: 13751
	public GameObject Couple;

	// Token: 0x040035B8 RID: 13752
	public UISprite Darkness;

	// Token: 0x040035B9 RID: 13753
	public Renderer Stars;

	// Token: 0x040035BA RID: 13754
	public Light Sunlight;

	// Token: 0x040035BB RID: 13755
	public bool Threatened;

	// Token: 0x040035BC RID: 13756
	public bool GoToCafe;

	// Token: 0x040035BD RID: 13757
	public bool FadeOut;

	// Token: 0x040035BE RID: 13758
	public bool Mute;

	// Token: 0x040035BF RID: 13759
	public bool Day;

	// Token: 0x040035C0 RID: 13760
	public float Rotation;

	// Token: 0x040035C1 RID: 13761
	public float Timer;

	// Token: 0x040035C2 RID: 13762
	public float DesiredValue;

	// Token: 0x040035C3 RID: 13763
	public float StarAlpha;

	// Token: 0x040035C4 RID: 13764
	public float Alpha;

	// Token: 0x040035C5 RID: 13765
	public UILabel[] HUDLabels;

	// Token: 0x040035C6 RID: 13766
	public AudioClip DayStreet80s;

	// Token: 0x040035C7 RID: 13767
	public AudioClip NightStreet80s;

	// Token: 0x040035C8 RID: 13768
	public GameObject EightiesCivilians;

	// Token: 0x040035C9 RID: 13769
	public GameObject ModernCivilians;

	// Token: 0x040035CA RID: 13770
	public GameObject KenchoShip;

	// Token: 0x040035CB RID: 13771
	public Renderer Konbini;

	// Token: 0x040035CC RID: 13772
	public Texture EightiesKonbini;

	// Token: 0x040035CD RID: 13773
	public Font VCR;
}
