using System;
using UnityEngine;

// Token: 0x0200034F RID: 847
public class LaptopScript : MonoBehaviour
{
	// Token: 0x0600196A RID: 6506 RVA: 0x000FF13C File Offset: 0x000FD33C
	private void Start()
	{
		if (SchoolGlobals.SCP || GameGlobals.AlphabetMode)
		{
			this.LaptopScreen.localScale = Vector3.zero;
			this.LaptopCamera.enabled = false;
			this.SCP.SetActive(false);
			base.enabled = false;
			return;
		}
		this.SCPRenderer.sharedMesh = this.Uniforms[StudentGlobals.FemaleUniform];
		Animation component = this.SCP.GetComponent<Animation>();
		component["f02_scp_00"].speed = 0f;
		component["f02_scp_00"].time = 0f;
		this.MyAudio = base.GetComponent<AudioSource>();
	}

	// Token: 0x0600196B RID: 6507 RVA: 0x000FF1E0 File Offset: 0x000FD3E0
	private void Update()
	{
		if (this.FirstFrame == 2)
		{
			this.LaptopCamera.enabled = false;
		}
		this.FirstFrame++;
		if (!this.Off)
		{
			Animation component = this.SCP.GetComponent<Animation>();
			if (!this.React)
			{
				if (this.Yandere.transform.position.x > base.transform.position.x + 1f && Vector3.Distance(this.Yandere.transform.position, new Vector3(base.transform.position.x, 4f, base.transform.position.z)) < 2f && this.Yandere.Followers == 0)
				{
					this.EventSubtitle.transform.localScale = new Vector3(1f, 1f, 1f);
					component["f02_scp_00"].time = 0f;
					this.LaptopCamera.enabled = true;
					component.Play();
					this.Hair.enabled = true;
					this.Jukebox.Dip = 0.5f;
					this.MyAudio.Play();
					this.React = true;
				}
			}
			else
			{
				this.MyAudio.pitch = Time.timeScale;
				this.MyAudio.volume = 1f;
				if (this.Yandere.transform.position.y > base.transform.position.y + 3f || this.Yandere.transform.position.y < base.transform.position.y - 3f)
				{
					this.MyAudio.volume = 0f;
				}
				for (int i = 0; i < this.Cues.Length; i++)
				{
					if (this.MyAudio.time > this.Cues[i])
					{
						this.EventSubtitle.text = this.Subs[i];
					}
				}
				if (this.MyAudio.time >= this.MyAudio.clip.length - 1f || this.MyAudio.time == 0f)
				{
					component["f02_scp_00"].speed = 1f;
					this.Timer += Time.deltaTime;
				}
				else
				{
					component["f02_scp_00"].time = this.MyAudio.time;
				}
				if (this.Timer > 1f || Vector3.Distance(this.Yandere.transform.position, new Vector3(base.transform.position.x, 4f, base.transform.position.z)) > 5f)
				{
					this.TurnOff();
				}
			}
			if (this.Yandere.StudentManager.Clock.HourTime > 16f || this.Yandere.Police.FadeOut)
			{
				this.TurnOff();
				return;
			}
		}
		else
		{
			if (this.LaptopScreen.localScale.x > 0.1f)
			{
				this.LaptopScreen.localScale = Vector3.Lerp(this.LaptopScreen.localScale, Vector3.zero, Time.deltaTime * 10f);
				return;
			}
			if (base.enabled)
			{
				this.LaptopScreen.localScale = Vector3.zero;
				this.Hair.enabled = false;
				base.enabled = false;
			}
		}
	}

	// Token: 0x0600196C RID: 6508 RVA: 0x000FF574 File Offset: 0x000FD774
	private void TurnOff()
	{
		this.MyAudio.clip = this.ShutDown;
		this.MyAudio.Play();
		this.EventSubtitle.text = string.Empty;
		SchoolGlobals.SCP = true;
		this.LaptopCamera.enabled = false;
		this.Jukebox.Dip = 1f;
		this.React = false;
		this.Off = true;
	}

	// Token: 0x04002836 RID: 10294
	public SkinnedMeshRenderer SCPRenderer;

	// Token: 0x04002837 RID: 10295
	public Camera LaptopCamera;

	// Token: 0x04002838 RID: 10296
	public JukeboxScript Jukebox;

	// Token: 0x04002839 RID: 10297
	public YandereScript Yandere;

	// Token: 0x0400283A RID: 10298
	public AudioSource MyAudio;

	// Token: 0x0400283B RID: 10299
	public DynamicBone Hair;

	// Token: 0x0400283C RID: 10300
	public Transform LaptopScreen;

	// Token: 0x0400283D RID: 10301
	public AudioClip ShutDown;

	// Token: 0x0400283E RID: 10302
	public GameObject SCP;

	// Token: 0x0400283F RID: 10303
	public bool React;

	// Token: 0x04002840 RID: 10304
	public bool Off;

	// Token: 0x04002841 RID: 10305
	public float[] Cues;

	// Token: 0x04002842 RID: 10306
	public string[] Subs;

	// Token: 0x04002843 RID: 10307
	public Mesh[] Uniforms;

	// Token: 0x04002844 RID: 10308
	public int FirstFrame;

	// Token: 0x04002845 RID: 10309
	public float Timer;

	// Token: 0x04002846 RID: 10310
	public UILabel EventSubtitle;
}
