using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000466 RID: 1126
public class SuicideCutsceneScript : MonoBehaviour
{
	// Token: 0x06001E9C RID: 7836 RVA: 0x001A7618 File Offset: 0x001A5818
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

	// Token: 0x06001E9D RID: 7837 RVA: 0x001A76A0 File Offset: 0x001A58A0
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

	// Token: 0x04003EEF RID: 16111
	public AudioSource MyAudio;

	// Token: 0x04003EF0 RID: 16112
	public AudioClip EightiesMother;

	// Token: 0x04003EF1 RID: 16113
	public Light DirectionalLight;

	// Token: 0x04003EF2 RID: 16114
	public Light PointLight;

	// Token: 0x04003EF3 RID: 16115
	public Transform Door;

	// Token: 0x04003EF4 RID: 16116
	public Animation Mom;

	// Token: 0x04003EF5 RID: 16117
	public float Timer;

	// Token: 0x04003EF6 RID: 16118
	public float Rotation;

	// Token: 0x04003EF7 RID: 16119
	public float Speed;

	// Token: 0x04003EF8 RID: 16120
	public int ID;

	// Token: 0x04003EF9 RID: 16121
	public GameObject[] RivalHair;

	// Token: 0x04003EFA RID: 16122
	public GameObject[] EightiesHair;
}
