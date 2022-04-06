using System;
using UnityEngine;

// Token: 0x020003CA RID: 970
public class RadioScript : MonoBehaviour
{
	// Token: 0x06001B5B RID: 7003 RVA: 0x001321E2 File Offset: 0x001303E2
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

	// Token: 0x06001B5C RID: 7004 RVA: 0x00132218 File Offset: 0x00130418
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

	// Token: 0x06001B5D RID: 7005 RVA: 0x00132578 File Offset: 0x00130778
	public void TurnOn()
	{
		this.Prompt.Label[0].text = "     Turn Off";
		this.MyRenderer.material.mainTexture = this.OnTexture;
		this.RadioNotes.SetActive(true);
		this.MyAudio.Play();
		this.On = true;
	}

	// Token: 0x06001B5E RID: 7006 RVA: 0x001325D0 File Offset: 0x001307D0
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

	// Token: 0x04002EA0 RID: 11936
	public StudentManagerScript StudentManager;

	// Token: 0x04002EA1 RID: 11937
	public JukeboxScript Jukebox;

	// Token: 0x04002EA2 RID: 11938
	public GameObject RadioNotes;

	// Token: 0x04002EA3 RID: 11939
	public GameObject AlarmDisc;

	// Token: 0x04002EA4 RID: 11940
	public AudioSource MyAudio;

	// Token: 0x04002EA5 RID: 11941
	public Renderer MyRenderer;

	// Token: 0x04002EA6 RID: 11942
	public Texture OffTexture;

	// Token: 0x04002EA7 RID: 11943
	public Texture OnTexture;

	// Token: 0x04002EA8 RID: 11944
	public StudentScript Victim;

	// Token: 0x04002EA9 RID: 11945
	public PromptScript Prompt;

	// Token: 0x04002EAA RID: 11946
	public float CooldownTimer;

	// Token: 0x04002EAB RID: 11947
	public bool Delinquent;

	// Token: 0x04002EAC RID: 11948
	public bool On;

	// Token: 0x04002EAD RID: 11949
	public int Proximity;

	// Token: 0x04002EAE RID: 11950
	public int ID;

	// Token: 0x04002EAF RID: 11951
	public AudioClip EightiesMusic;
}
