using System;
using UnityEngine;

// Token: 0x020003CA RID: 970
public class RadioScript : MonoBehaviour
{
	// Token: 0x06001B63 RID: 7011 RVA: 0x00132C3E File Offset: 0x00130E3E
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

	// Token: 0x06001B64 RID: 7012 RVA: 0x00132C74 File Offset: 0x00130E74
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

	// Token: 0x06001B65 RID: 7013 RVA: 0x00132FD4 File Offset: 0x001311D4
	public void TurnOn()
	{
		this.Prompt.Label[0].text = "     Turn Off";
		this.MyRenderer.material.mainTexture = this.OnTexture;
		this.RadioNotes.SetActive(true);
		this.MyAudio.Play();
		this.On = true;
	}

	// Token: 0x06001B66 RID: 7014 RVA: 0x0013302C File Offset: 0x0013122C
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

	// Token: 0x04002EB4 RID: 11956
	public StudentManagerScript StudentManager;

	// Token: 0x04002EB5 RID: 11957
	public JukeboxScript Jukebox;

	// Token: 0x04002EB6 RID: 11958
	public GameObject RadioNotes;

	// Token: 0x04002EB7 RID: 11959
	public GameObject AlarmDisc;

	// Token: 0x04002EB8 RID: 11960
	public AudioSource MyAudio;

	// Token: 0x04002EB9 RID: 11961
	public Renderer MyRenderer;

	// Token: 0x04002EBA RID: 11962
	public Texture OffTexture;

	// Token: 0x04002EBB RID: 11963
	public Texture OnTexture;

	// Token: 0x04002EBC RID: 11964
	public StudentScript Victim;

	// Token: 0x04002EBD RID: 11965
	public PromptScript Prompt;

	// Token: 0x04002EBE RID: 11966
	public float CooldownTimer;

	// Token: 0x04002EBF RID: 11967
	public bool Delinquent;

	// Token: 0x04002EC0 RID: 11968
	public bool On;

	// Token: 0x04002EC1 RID: 11969
	public int Proximity;

	// Token: 0x04002EC2 RID: 11970
	public int ID;

	// Token: 0x04002EC3 RID: 11971
	public AudioClip EightiesMusic;
}
