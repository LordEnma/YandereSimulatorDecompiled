using System;
using UnityEngine;

// Token: 0x020003C0 RID: 960
public class RadioScript : MonoBehaviour
{
	// Token: 0x06001B19 RID: 6937 RVA: 0x0012DE9E File Offset: 0x0012C09E
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

	// Token: 0x06001B1A RID: 6938 RVA: 0x0012DED4 File Offset: 0x0012C0D4
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

	// Token: 0x06001B1B RID: 6939 RVA: 0x0012E234 File Offset: 0x0012C434
	public void TurnOn()
	{
		this.Prompt.Label[0].text = "     Turn Off";
		this.MyRenderer.material.mainTexture = this.OnTexture;
		this.RadioNotes.SetActive(true);
		this.MyAudio.Play();
		this.On = true;
	}

	// Token: 0x06001B1C RID: 6940 RVA: 0x0012E28C File Offset: 0x0012C48C
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

	// Token: 0x04002DE1 RID: 11745
	public StudentManagerScript StudentManager;

	// Token: 0x04002DE2 RID: 11746
	public JukeboxScript Jukebox;

	// Token: 0x04002DE3 RID: 11747
	public GameObject RadioNotes;

	// Token: 0x04002DE4 RID: 11748
	public GameObject AlarmDisc;

	// Token: 0x04002DE5 RID: 11749
	public AudioSource MyAudio;

	// Token: 0x04002DE6 RID: 11750
	public Renderer MyRenderer;

	// Token: 0x04002DE7 RID: 11751
	public Texture OffTexture;

	// Token: 0x04002DE8 RID: 11752
	public Texture OnTexture;

	// Token: 0x04002DE9 RID: 11753
	public StudentScript Victim;

	// Token: 0x04002DEA RID: 11754
	public PromptScript Prompt;

	// Token: 0x04002DEB RID: 11755
	public float CooldownTimer;

	// Token: 0x04002DEC RID: 11756
	public bool Delinquent;

	// Token: 0x04002DED RID: 11757
	public bool On;

	// Token: 0x04002DEE RID: 11758
	public int Proximity;

	// Token: 0x04002DEF RID: 11759
	public int ID;

	// Token: 0x04002DF0 RID: 11760
	public AudioClip EightiesMusic;
}
