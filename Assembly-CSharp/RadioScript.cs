using System;
using UnityEngine;

// Token: 0x020003CB RID: 971
public class RadioScript : MonoBehaviour
{
	// Token: 0x06001B6A RID: 7018 RVA: 0x001339DE File Offset: 0x00131BDE
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

	// Token: 0x06001B6B RID: 7019 RVA: 0x00133A14 File Offset: 0x00131C14
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

	// Token: 0x06001B6C RID: 7020 RVA: 0x00133D74 File Offset: 0x00131F74
	public void TurnOn()
	{
		this.Prompt.Label[0].text = "     Turn Off";
		this.MyRenderer.material.mainTexture = this.OnTexture;
		this.RadioNotes.SetActive(true);
		this.MyAudio.Play();
		this.On = true;
	}

	// Token: 0x06001B6D RID: 7021 RVA: 0x00133DCC File Offset: 0x00131FCC
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

	// Token: 0x04002ED1 RID: 11985
	public StudentManagerScript StudentManager;

	// Token: 0x04002ED2 RID: 11986
	public JukeboxScript Jukebox;

	// Token: 0x04002ED3 RID: 11987
	public GameObject RadioNotes;

	// Token: 0x04002ED4 RID: 11988
	public GameObject AlarmDisc;

	// Token: 0x04002ED5 RID: 11989
	public AudioSource MyAudio;

	// Token: 0x04002ED6 RID: 11990
	public Renderer MyRenderer;

	// Token: 0x04002ED7 RID: 11991
	public Texture OffTexture;

	// Token: 0x04002ED8 RID: 11992
	public Texture OnTexture;

	// Token: 0x04002ED9 RID: 11993
	public StudentScript Victim;

	// Token: 0x04002EDA RID: 11994
	public PromptScript Prompt;

	// Token: 0x04002EDB RID: 11995
	public float CooldownTimer;

	// Token: 0x04002EDC RID: 11996
	public bool Delinquent;

	// Token: 0x04002EDD RID: 11997
	public bool On;

	// Token: 0x04002EDE RID: 11998
	public int Proximity;

	// Token: 0x04002EDF RID: 11999
	public int ID;

	// Token: 0x04002EE0 RID: 12000
	public AudioClip EightiesMusic;
}
