using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000466 RID: 1126
public class SuicideCutsceneScript : MonoBehaviour
{
	// Token: 0x06001E96 RID: 7830 RVA: 0x001A6C40 File Offset: 0x001A4E40
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

	// Token: 0x06001E97 RID: 7831 RVA: 0x001A6CC8 File Offset: 0x001A4EC8
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

	// Token: 0x04003EDF RID: 16095
	public AudioSource MyAudio;

	// Token: 0x04003EE0 RID: 16096
	public AudioClip EightiesMother;

	// Token: 0x04003EE1 RID: 16097
	public Light DirectionalLight;

	// Token: 0x04003EE2 RID: 16098
	public Light PointLight;

	// Token: 0x04003EE3 RID: 16099
	public Transform Door;

	// Token: 0x04003EE4 RID: 16100
	public Animation Mom;

	// Token: 0x04003EE5 RID: 16101
	public float Timer;

	// Token: 0x04003EE6 RID: 16102
	public float Rotation;

	// Token: 0x04003EE7 RID: 16103
	public float Speed;

	// Token: 0x04003EE8 RID: 16104
	public int ID;

	// Token: 0x04003EE9 RID: 16105
	public GameObject[] RivalHair;

	// Token: 0x04003EEA RID: 16106
	public GameObject[] EightiesHair;
}
