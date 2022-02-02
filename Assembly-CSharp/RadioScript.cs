using System;
using UnityEngine;

// Token: 0x020003C3 RID: 963
public class RadioScript : MonoBehaviour
{
	// Token: 0x06001B2B RID: 6955 RVA: 0x0012F43E File Offset: 0x0012D63E
	private void Start()
	{
		if (this.Delinquent && StudentGlobals.GetStudentExpelled(76))
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		if (GameGlobals.Eighties)
		{
			this.MyAudio.clip = this.EightiesMusic;
		}
	}

	// Token: 0x06001B2C RID: 6956 RVA: 0x0012F474 File Offset: 0x0012D674
	private void Update()
	{
		if (base.transform.parent == null)
		{
			if (this.CooldownTimer > 0f)
			{
				this.CooldownTimer = Mathf.MoveTowards(this.CooldownTimer, 0f, Time.deltaTime);
				if (this.CooldownTimer == 0f)
				{
					this.Prompt.enabled = true;
				}
			}
			else
			{
				UISprite uisprite = this.Prompt.Circle[0];
				if (uisprite.fillAmount == 0f)
				{
					uisprite.fillAmount = 1f;
					if (!this.On)
					{
						this.TurnOn();
					}
					else
					{
						this.CooldownTimer = 1f;
						this.TurnOff();
					}
				}
			}
			if (this.On && this.Victim == null && this.AlarmDisc != null)
			{
				AlarmDiscScript component = UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, base.transform.position + Vector3.up, Quaternion.identity).GetComponent<AlarmDiscScript>();
				component.SourceRadio = this;
				component.NoScream = true;
				component.Radio = true;
			}
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.enabled = false;
			this.Prompt.Hide();
		}
		if (this.Delinquent)
		{
			this.Proximity = 0;
			this.ID = 1;
			while (this.ID < 6)
			{
				if (this.StudentManager.Students[75 + this.ID] != null && Vector3.Distance(base.transform.position, this.StudentManager.Students[75 + this.ID].transform.position) < 1.1f)
				{
					if (!this.StudentManager.Students[75 + this.ID].Alarmed && !this.StudentManager.Students[75 + this.ID].Threatened && this.StudentManager.Students[75 + this.ID].Alive)
					{
						this.Proximity++;
					}
					else
					{
						this.Proximity = -100;
						this.ID = 5;
						this.MyAudio.Stop();
						this.Jukebox.ClubDip = 0f;
					}
				}
				this.ID++;
			}
			if (this.Proximity > 0)
			{
				if (!this.MyAudio.isPlaying)
				{
					this.MyAudio.Play();
				}
				float num = Vector3.Distance(this.Prompt.Yandere.transform.position, base.transform.position);
				if (num < 11f)
				{
					this.Jukebox.ClubDip = Mathf.MoveTowards(this.Jukebox.ClubDip, (10f - num) * 0.2f * this.Jukebox.Volume, Time.deltaTime);
					if (this.Jukebox.ClubDip < 0f)
					{
						this.Jukebox.ClubDip = 0f;
					}
					if (this.Jukebox.ClubDip > this.Jukebox.Volume)
					{
						this.Jukebox.ClubDip = this.Jukebox.Volume;
						return;
					}
				}
			}
			else if (this.MyAudio.isPlaying)
			{
				this.MyAudio.Stop();
				this.Jukebox.ClubDip = 0f;
			}
		}
	}

	// Token: 0x06001B2D RID: 6957 RVA: 0x0012F7D4 File Offset: 0x0012D9D4
	public void TurnOn()
	{
		this.Prompt.Label[0].text = "     Turn Off";
		this.MyRenderer.material.mainTexture = this.OnTexture;
		this.RadioNotes.SetActive(true);
		this.MyAudio.Play();
		this.On = true;
	}

	// Token: 0x06001B2E RID: 6958 RVA: 0x0012F82C File Offset: 0x0012DA2C
	public void TurnOff()
	{
		this.Prompt.Label[0].text = "     Turn On";
		this.Prompt.enabled = false;
		this.Prompt.Hide();
		this.MyRenderer.material.mainTexture = this.OffTexture;
		this.RadioNotes.SetActive(false);
		this.CooldownTimer = 1f;
		this.MyAudio.Stop();
		this.Victim = null;
		this.On = false;
	}

	// Token: 0x04002E20 RID: 11808
	public StudentManagerScript StudentManager;

	// Token: 0x04002E21 RID: 11809
	public JukeboxScript Jukebox;

	// Token: 0x04002E22 RID: 11810
	public GameObject RadioNotes;

	// Token: 0x04002E23 RID: 11811
	public GameObject AlarmDisc;

	// Token: 0x04002E24 RID: 11812
	public AudioSource MyAudio;

	// Token: 0x04002E25 RID: 11813
	public Renderer MyRenderer;

	// Token: 0x04002E26 RID: 11814
	public Texture OffTexture;

	// Token: 0x04002E27 RID: 11815
	public Texture OnTexture;

	// Token: 0x04002E28 RID: 11816
	public StudentScript Victim;

	// Token: 0x04002E29 RID: 11817
	public PromptScript Prompt;

	// Token: 0x04002E2A RID: 11818
	public float CooldownTimer;

	// Token: 0x04002E2B RID: 11819
	public bool Delinquent;

	// Token: 0x04002E2C RID: 11820
	public bool On;

	// Token: 0x04002E2D RID: 11821
	public int Proximity;

	// Token: 0x04002E2E RID: 11822
	public int ID;

	// Token: 0x04002E2F RID: 11823
	public AudioClip EightiesMusic;
}
