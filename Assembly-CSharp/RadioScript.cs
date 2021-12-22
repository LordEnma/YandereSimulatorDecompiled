using System;
using UnityEngine;

// Token: 0x020003C1 RID: 961
public class RadioScript : MonoBehaviour
{
	// Token: 0x06001B21 RID: 6945 RVA: 0x0012E712 File Offset: 0x0012C912
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

	// Token: 0x06001B22 RID: 6946 RVA: 0x0012E748 File Offset: 0x0012C948
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

	// Token: 0x06001B23 RID: 6947 RVA: 0x0012EAA8 File Offset: 0x0012CCA8
	public void TurnOn()
	{
		this.Prompt.Label[0].text = "     Turn Off";
		this.MyRenderer.material.mainTexture = this.OnTexture;
		this.RadioNotes.SetActive(true);
		this.MyAudio.Play();
		this.On = true;
	}

	// Token: 0x06001B24 RID: 6948 RVA: 0x0012EB00 File Offset: 0x0012CD00
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

	// Token: 0x04002E0B RID: 11787
	public StudentManagerScript StudentManager;

	// Token: 0x04002E0C RID: 11788
	public JukeboxScript Jukebox;

	// Token: 0x04002E0D RID: 11789
	public GameObject RadioNotes;

	// Token: 0x04002E0E RID: 11790
	public GameObject AlarmDisc;

	// Token: 0x04002E0F RID: 11791
	public AudioSource MyAudio;

	// Token: 0x04002E10 RID: 11792
	public Renderer MyRenderer;

	// Token: 0x04002E11 RID: 11793
	public Texture OffTexture;

	// Token: 0x04002E12 RID: 11794
	public Texture OnTexture;

	// Token: 0x04002E13 RID: 11795
	public StudentScript Victim;

	// Token: 0x04002E14 RID: 11796
	public PromptScript Prompt;

	// Token: 0x04002E15 RID: 11797
	public float CooldownTimer;

	// Token: 0x04002E16 RID: 11798
	public bool Delinquent;

	// Token: 0x04002E17 RID: 11799
	public bool On;

	// Token: 0x04002E18 RID: 11800
	public int Proximity;

	// Token: 0x04002E19 RID: 11801
	public int ID;

	// Token: 0x04002E1A RID: 11802
	public AudioClip EightiesMusic;
}
