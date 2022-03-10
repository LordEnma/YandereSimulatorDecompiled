using System;
using UnityEngine;

// Token: 0x020003C5 RID: 965
public class RadioScript : MonoBehaviour
{
	// Token: 0x06001B3E RID: 6974 RVA: 0x00130822 File Offset: 0x0012EA22
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

	// Token: 0x06001B3F RID: 6975 RVA: 0x00130858 File Offset: 0x0012EA58
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

	// Token: 0x06001B40 RID: 6976 RVA: 0x00130BB8 File Offset: 0x0012EDB8
	public void TurnOn()
	{
		this.Prompt.Label[0].text = "     Turn Off";
		this.MyRenderer.material.mainTexture = this.OnTexture;
		this.RadioNotes.SetActive(true);
		this.MyAudio.Play();
		this.On = true;
	}

	// Token: 0x06001B41 RID: 6977 RVA: 0x00130C10 File Offset: 0x0012EE10
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

	// Token: 0x04002E50 RID: 11856
	public StudentManagerScript StudentManager;

	// Token: 0x04002E51 RID: 11857
	public JukeboxScript Jukebox;

	// Token: 0x04002E52 RID: 11858
	public GameObject RadioNotes;

	// Token: 0x04002E53 RID: 11859
	public GameObject AlarmDisc;

	// Token: 0x04002E54 RID: 11860
	public AudioSource MyAudio;

	// Token: 0x04002E55 RID: 11861
	public Renderer MyRenderer;

	// Token: 0x04002E56 RID: 11862
	public Texture OffTexture;

	// Token: 0x04002E57 RID: 11863
	public Texture OnTexture;

	// Token: 0x04002E58 RID: 11864
	public StudentScript Victim;

	// Token: 0x04002E59 RID: 11865
	public PromptScript Prompt;

	// Token: 0x04002E5A RID: 11866
	public float CooldownTimer;

	// Token: 0x04002E5B RID: 11867
	public bool Delinquent;

	// Token: 0x04002E5C RID: 11868
	public bool On;

	// Token: 0x04002E5D RID: 11869
	public int Proximity;

	// Token: 0x04002E5E RID: 11870
	public int ID;

	// Token: 0x04002E5F RID: 11871
	public AudioClip EightiesMusic;
}
