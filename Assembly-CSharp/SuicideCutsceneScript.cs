using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000460 RID: 1120
public class SuicideCutsceneScript : MonoBehaviour
{
	// Token: 0x06001E74 RID: 7796 RVA: 0x001A3D24 File Offset: 0x001A1F24
	private void Start()
	{
		this.PointLight.color = new Color(0.1f, 0.1f, 0.1f, 1f);
		this.Door.eulerAngles = new Vector3(0f, 0f, 0f);
		if (GameGlobals.Eighties)
		{
			this.MyAudio.clip = this.EightiesMother;
			this.RivalHair[1].SetActive(false);
			this.EightiesHair[DateGlobals.Week].SetActive(true);
		}
	}

	// Token: 0x06001E75 RID: 7797 RVA: 0x001A3DAC File Offset: 0x001A1FAC
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.ID == 0)
		{
			if (this.Timer > 1f)
			{
				this.MyAudio.Play();
				this.ID++;
				return;
			}
		}
		else if (this.ID == 1)
		{
			if (this.Timer > 6f)
			{
				this.Speed += Time.deltaTime * 0.66666f;
				this.Rotation = Mathf.Lerp(this.Rotation, -45f, Time.deltaTime * this.Speed);
				this.PointLight.color = new Color(0.1f + this.Rotation / -45f * 0.9f, 0.1f + this.Rotation / -45f * 0.9f, 0.1f + this.Rotation / -45f * 0.9f, 1f);
				this.Door.eulerAngles = new Vector3(0f, this.Rotation, 0f);
			}
			if (this.Timer > 8.5f)
			{
				this.Mom.CrossFade("f02_shock_00");
			}
			if (this.Timer > 9.5f)
			{
				this.DirectionalLight.color = new Color(0f, 0f, 0f);
				this.PointLight.color = new Color(0f, 0f, 0f);
			}
			if (this.Timer > 11f)
			{
				GameGlobals.SpecificEliminationID = 19;
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Suicide", 1);
				}
				SchoolGlobals.SchoolAtmosphere -= 0.1f;
				GameGlobals.SenpaiMourning = true;
				SceneManager.LoadScene("HomeScene");
			}
		}
	}

	// Token: 0x04003E67 RID: 15975
	public AudioSource MyAudio;

	// Token: 0x04003E68 RID: 15976
	public AudioClip EightiesMother;

	// Token: 0x04003E69 RID: 15977
	public Light DirectionalLight;

	// Token: 0x04003E6A RID: 15978
	public Light PointLight;

	// Token: 0x04003E6B RID: 15979
	public Transform Door;

	// Token: 0x04003E6C RID: 15980
	public Animation Mom;

	// Token: 0x04003E6D RID: 15981
	public float Timer;

	// Token: 0x04003E6E RID: 15982
	public float Rotation;

	// Token: 0x04003E6F RID: 15983
	public float Speed;

	// Token: 0x04003E70 RID: 15984
	public int ID;

	// Token: 0x04003E71 RID: 15985
	public GameObject[] RivalHair;

	// Token: 0x04003E72 RID: 15986
	public GameObject[] EightiesHair;
}
