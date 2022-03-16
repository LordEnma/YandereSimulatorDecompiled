using System;
using UnityEngine;

// Token: 0x020003C6 RID: 966
public class RadioScript : MonoBehaviour
{
	// Token: 0x06001B4B RID: 6987 RVA: 0x001316C2 File Offset: 0x0012F8C2
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

	// Token: 0x06001B4C RID: 6988 RVA: 0x001316F8 File Offset: 0x0012F8F8
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

	// Token: 0x06001B4D RID: 6989 RVA: 0x00131A58 File Offset: 0x0012FC58
	public void TurnOn()
	{
		this.Prompt.Label[0].text = "     Turn Off";
		this.MyRenderer.material.mainTexture = this.OnTexture;
		this.RadioNotes.SetActive(true);
		this.MyAudio.Play();
		this.On = true;
	}

	// Token: 0x06001B4E RID: 6990 RVA: 0x00131AB0 File Offset: 0x0012FCB0
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

	// Token: 0x04002E84 RID: 11908
	public StudentManagerScript StudentManager;

	// Token: 0x04002E85 RID: 11909
	public JukeboxScript Jukebox;

	// Token: 0x04002E86 RID: 11910
	public GameObject RadioNotes;

	// Token: 0x04002E87 RID: 11911
	public GameObject AlarmDisc;

	// Token: 0x04002E88 RID: 11912
	public AudioSource MyAudio;

	// Token: 0x04002E89 RID: 11913
	public Renderer MyRenderer;

	// Token: 0x04002E8A RID: 11914
	public Texture OffTexture;

	// Token: 0x04002E8B RID: 11915
	public Texture OnTexture;

	// Token: 0x04002E8C RID: 11916
	public StudentScript Victim;

	// Token: 0x04002E8D RID: 11917
	public PromptScript Prompt;

	// Token: 0x04002E8E RID: 11918
	public float CooldownTimer;

	// Token: 0x04002E8F RID: 11919
	public bool Delinquent;

	// Token: 0x04002E90 RID: 11920
	public bool On;

	// Token: 0x04002E91 RID: 11921
	public int Proximity;

	// Token: 0x04002E92 RID: 11922
	public int ID;

	// Token: 0x04002E93 RID: 11923
	public AudioClip EightiesMusic;
}
