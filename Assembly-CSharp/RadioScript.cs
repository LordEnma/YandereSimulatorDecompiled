using System;
using UnityEngine;

// Token: 0x020003C5 RID: 965
public class RadioScript : MonoBehaviour
{
	// Token: 0x06001B3D RID: 6973 RVA: 0x0013044A File Offset: 0x0012E64A
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

	// Token: 0x06001B3E RID: 6974 RVA: 0x00130480 File Offset: 0x0012E680
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

	// Token: 0x06001B3F RID: 6975 RVA: 0x001307E0 File Offset: 0x0012E9E0
	public void TurnOn()
	{
		this.Prompt.Label[0].text = "     Turn Off";
		this.MyRenderer.material.mainTexture = this.OnTexture;
		this.RadioNotes.SetActive(true);
		this.MyAudio.Play();
		this.On = true;
	}

	// Token: 0x06001B40 RID: 6976 RVA: 0x00130838 File Offset: 0x0012EA38
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

	// Token: 0x04002E3A RID: 11834
	public StudentManagerScript StudentManager;

	// Token: 0x04002E3B RID: 11835
	public JukeboxScript Jukebox;

	// Token: 0x04002E3C RID: 11836
	public GameObject RadioNotes;

	// Token: 0x04002E3D RID: 11837
	public GameObject AlarmDisc;

	// Token: 0x04002E3E RID: 11838
	public AudioSource MyAudio;

	// Token: 0x04002E3F RID: 11839
	public Renderer MyRenderer;

	// Token: 0x04002E40 RID: 11840
	public Texture OffTexture;

	// Token: 0x04002E41 RID: 11841
	public Texture OnTexture;

	// Token: 0x04002E42 RID: 11842
	public StudentScript Victim;

	// Token: 0x04002E43 RID: 11843
	public PromptScript Prompt;

	// Token: 0x04002E44 RID: 11844
	public float CooldownTimer;

	// Token: 0x04002E45 RID: 11845
	public bool Delinquent;

	// Token: 0x04002E46 RID: 11846
	public bool On;

	// Token: 0x04002E47 RID: 11847
	public int Proximity;

	// Token: 0x04002E48 RID: 11848
	public int ID;

	// Token: 0x04002E49 RID: 11849
	public AudioClip EightiesMusic;
}
