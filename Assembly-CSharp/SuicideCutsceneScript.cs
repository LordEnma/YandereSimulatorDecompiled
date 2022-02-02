using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200045E RID: 1118
public class SuicideCutsceneScript : MonoBehaviour
{
	// Token: 0x06001E5C RID: 7772 RVA: 0x001A21D8 File Offset: 0x001A03D8
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

	// Token: 0x06001E5D RID: 7773 RVA: 0x001A2260 File Offset: 0x001A0460
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

	// Token: 0x04003E2E RID: 15918
	public AudioSource MyAudio;

	// Token: 0x04003E2F RID: 15919
	public AudioClip EightiesMother;

	// Token: 0x04003E30 RID: 15920
	public Light DirectionalLight;

	// Token: 0x04003E31 RID: 15921
	public Light PointLight;

	// Token: 0x04003E32 RID: 15922
	public Transform Door;

	// Token: 0x04003E33 RID: 15923
	public Animation Mom;

	// Token: 0x04003E34 RID: 15924
	public float Timer;

	// Token: 0x04003E35 RID: 15925
	public float Rotation;

	// Token: 0x04003E36 RID: 15926
	public float Speed;

	// Token: 0x04003E37 RID: 15927
	public int ID;

	// Token: 0x04003E38 RID: 15928
	public GameObject[] RivalHair;

	// Token: 0x04003E39 RID: 15929
	public GameObject[] EightiesHair;
}
