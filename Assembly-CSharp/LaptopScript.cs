using System;
using UnityEngine;

// Token: 0x0200034D RID: 845
public class LaptopScript : MonoBehaviour
{
	// Token: 0x06001953 RID: 6483 RVA: 0x000FDF60 File Offset: 0x000FC160
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

	// Token: 0x06001954 RID: 6484 RVA: 0x000FE004 File Offset: 0x000FC204
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

	// Token: 0x06001955 RID: 6485 RVA: 0x000FE398 File Offset: 0x000FC598
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

	// Token: 0x040027FB RID: 10235
	public SkinnedMeshRenderer SCPRenderer;

	// Token: 0x040027FC RID: 10236
	public Camera LaptopCamera;

	// Token: 0x040027FD RID: 10237
	public JukeboxScript Jukebox;

	// Token: 0x040027FE RID: 10238
	public YandereScript Yandere;

	// Token: 0x040027FF RID: 10239
	public AudioSource MyAudio;

	// Token: 0x04002800 RID: 10240
	public DynamicBone Hair;

	// Token: 0x04002801 RID: 10241
	public Transform LaptopScreen;

	// Token: 0x04002802 RID: 10242
	public AudioClip ShutDown;

	// Token: 0x04002803 RID: 10243
	public GameObject SCP;

	// Token: 0x04002804 RID: 10244
	public bool React;

	// Token: 0x04002805 RID: 10245
	public bool Off;

	// Token: 0x04002806 RID: 10246
	public float[] Cues;

	// Token: 0x04002807 RID: 10247
	public string[] Subs;

	// Token: 0x04002808 RID: 10248
	public Mesh[] Uniforms;

	// Token: 0x04002809 RID: 10249
	public int FirstFrame;

	// Token: 0x0400280A RID: 10250
	public float Timer;

	// Token: 0x0400280B RID: 10251
	public UILabel EventSubtitle;
}
