using System;
using UnityEngine;

// Token: 0x0200035A RID: 858
public class LowRepGameOverScript : MonoBehaviour
{
	// Token: 0x06001981 RID: 6529 RVA: 0x00102CFC File Offset: 0x00100EFC
	private void Start()
	{
		this.GossipGroup[1].SetActive(false);
		this.GossipGroup[2].SetActive(false);
		this.GossipGroup[3].SetActive(false);
		this.GossipGroup[4].SetActive(false);
		this.GossipGroup[5].SetActive(false);
		this.Senpai = this.StudentManager.Students[1];
		this.Yandere.transform.parent = base.transform;
		this.Yandere.transform.localPosition = new Vector3(0f, 0f, 0f);
		this.Yandere.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		this.Yandere.CharacterAnimation.Play("f02_LowRepGO_A");
		this.MyCamera.eulerAngles = this.CameraPosition[0].eulerAngles;
		this.MyCamera.position = this.CameraPosition[0].position;
		this.Senpai.Chopsticks[0].SetActive(false);
		this.Senpai.Chopsticks[1].SetActive(false);
		this.Senpai.OccultBook.SetActive(false);
		this.Senpai.SmartPhone.SetActive(false);
		this.Senpai.Scrubber.SetActive(false);
		this.Senpai.Eraser.SetActive(false);
		this.Senpai.Bento.SetActive(false);
		this.Senpai.Pen.SetActive(false);
		this.Senpai.enabled = false;
		this.Senpai.CharacterAnimation.enabled = true;
		this.Senpai.MyController.enabled = false;
		this.Senpai.Pathfinding.enabled = false;
		this.Yandere.CameraEffects.UpdateDOF(1f);
		Time.timeScale = 1f;
	}

	// Token: 0x06001982 RID: 6530 RVA: 0x00102EF0 File Offset: 0x001010F0
	private void Update()
	{
		this.Darkness.material.color = new Color(this.Darkness.material.color.r, this.Darkness.material.color.g, this.Darkness.material.color.b, this.Darkness.material.color.a - Time.deltaTime * 0.5f);
		if (this.Phase == 0)
		{
			if (this.Yandere.CharacterAnimation["f02_LowRepGO_A"].time >= 3f)
			{
				this.GigglePhase = 1;
			}
			if (this.Yandere.CharacterAnimation["f02_LowRepGO_A"].time >= this.Yandere.CharacterAnimation["f02_LowRepGO_A"].length || Input.GetButtonDown("A"))
			{
				this.MyCamera.eulerAngles = this.CameraPosition[1].eulerAngles;
				this.MyCamera.position = this.CameraPosition[1].position;
				this.GossipGroup[1].SetActive(true);
				this.GigglePhase = 1;
				this.Phase++;
			}
		}
		else if (this.Phase == 1)
		{
			this.MyCamera.position += this.MyCamera.forward * Time.deltaTime * -0.1f;
			this.Timer += Time.deltaTime;
			if (this.Timer > 2f || Input.GetButtonDown("A"))
			{
				this.MyCamera.eulerAngles = this.CameraPosition[2].eulerAngles;
				this.MyCamera.position = this.CameraPosition[2].position;
				this.Yandere.CharacterAnimation.Play("f02_LowRepGO_B");
				this.GossipGroup[1].SetActive(false);
				this.GigglePhase++;
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 2)
		{
			this.MyCamera.position += this.MyCamera.forward * Time.deltaTime * 0.1f;
			if (this.Yandere.CharacterAnimation["f02_LowRepGO_B"].time >= this.Yandere.CharacterAnimation["f02_LowRepGO_B"].length || Input.GetButtonDown("A"))
			{
				this.MyCamera.eulerAngles = this.CameraPosition[3].eulerAngles;
				this.MyCamera.position = this.CameraPosition[3].position;
				this.GossipGroup[2].SetActive(true);
				this.Phase++;
			}
		}
		else if (this.Phase == 3)
		{
			this.MyCamera.position += this.MyCamera.forward * Time.deltaTime * -0.1f;
			this.Timer += Time.deltaTime;
			if (this.Timer > 2f || Input.GetButtonDown("A"))
			{
				this.MyCamera.eulerAngles = this.CameraPosition[4].eulerAngles;
				this.MyCamera.position = this.CameraPosition[4].position;
				this.Yandere.CharacterAnimation.Play("f02_LowRepGO_C");
				this.GossipGroup[2].SetActive(false);
				this.GigglePhase++;
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 4)
		{
			this.MyCamera.position += this.MyCamera.forward * Time.deltaTime * 0.1f;
			if (this.Yandere.CharacterAnimation["f02_LowRepGO_C"].time >= this.Yandere.CharacterAnimation["f02_LowRepGO_C"].length || Input.GetButtonDown("A"))
			{
				this.MyCamera.eulerAngles = this.CameraPosition[5].eulerAngles;
				this.MyCamera.position = this.CameraPosition[5].position;
				this.GossipGroup[3].SetActive(true);
				this.Phase++;
			}
		}
		else if (this.Phase == 5)
		{
			this.MyCamera.position += this.MyCamera.forward * Time.deltaTime * -0.1f;
			this.Timer += Time.deltaTime;
			if (this.Timer > 2f || Input.GetButtonDown("A"))
			{
				this.MyCamera.eulerAngles = this.CameraPosition[6].eulerAngles;
				this.MyCamera.position = this.CameraPosition[6].position;
				this.Yandere.CharacterAnimation.Play("f02_LowRepGO_D");
				this.GossipGroup[3].SetActive(false);
				this.GossipGroup[4].SetActive(true);
				this.GigglePhase++;
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 6)
		{
			this.MyCamera.position += this.MyCamera.forward * Time.deltaTime * 0.1f;
			if (this.Yandere.CharacterAnimation["f02_LowRepGO_D"].time >= this.Yandere.CharacterAnimation["f02_LowRepGO_D"].length || Input.GetButtonDown("A"))
			{
				this.MyCamera.eulerAngles = this.CameraPosition[7].eulerAngles;
				this.MyCamera.position = this.CameraPosition[7].position;
				this.Senpai.CharacterAnimation[this.Senpai.AngryFaceAnim].weight = 1f;
				this.Senpai.transform.eulerAngles = new Vector3(0f, 180f, 0f);
				this.Senpai.transform.position = this.SenpaiSpot.position;
				this.Senpai.CharacterAnimation.Play(this.Senpai.OriginalIdleAnim);
				Physics.SyncTransforms();
				this.GossipGroup[5].SetActive(true);
				this.GigglePhase++;
				this.Phase++;
			}
		}
		else if (this.Phase == 7)
		{
			this.MyCamera.position += this.MyCamera.forward * Time.deltaTime * 0.1f;
			this.Timer += Time.deltaTime;
			if (this.Timer > 2f || Input.GetButtonDown("A"))
			{
				this.Senpai.CharacterAnimation["refuse_01"].speed = 0.5f;
				this.Senpai.CharacterAnimation.Play("refuse_01");
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 8)
		{
			this.MyCamera.position += this.MyCamera.forward * Time.deltaTime * 0.1f;
			this.Timer += Time.deltaTime;
			if (this.Timer > 2.5f || Input.GetButtonDown("A"))
			{
				this.Yandere.CharacterAnimation.Play("f02_scaredIdle_00");
				this.Yandere.ShoulderCamera.GoingToCounselor = false;
				this.Yandere.ShoulderCamera.enabled = true;
				this.Yandere.ShoulderCamera.Noticed = true;
				this.Yandere.ShoulderCamera.Skip = true;
				this.GigglePhase++;
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 9)
		{
			this.Timer += Time.deltaTime;
		}
		this.GiggleTimer += Time.deltaTime;
		if (this.GigglePhase == 1)
		{
			if (this.GiggleTimer > 2f)
			{
				this.Giggle();
				this.GiggleTimer = 0f;
				return;
			}
		}
		else if (this.GigglePhase == 2)
		{
			if (this.GiggleTimer > 1f)
			{
				this.Giggle();
				this.GiggleTimer = 0f;
				return;
			}
		}
		else if (this.GigglePhase == 3)
		{
			if (this.GiggleTimer > 0.5f)
			{
				this.Giggle();
				this.GiggleTimer = 0f;
				return;
			}
		}
		else if (this.GigglePhase == 4)
		{
			if (this.GiggleTimer > 0.25f)
			{
				this.Giggle();
				this.GiggleTimer = 0f;
				return;
			}
		}
		else if (this.GigglePhase > 4 && this.GiggleTimer > 0.125f)
		{
			this.Giggle();
			this.GiggleTimer = 0f;
		}
	}

	// Token: 0x06001983 RID: 6531 RVA: 0x001038E4 File Offset: 0x00101AE4
	private void Giggle()
	{
		this.GiggleID = UnityEngine.Random.Range(1, this.Giggles.Length);
		while (this.GiggleID == this.PreviousGiggle)
		{
			this.GiggleID = UnityEngine.Random.Range(1, this.Giggles.Length);
		}
		this.PreviousGiggle = this.GiggleID;
		if (this.GigglePhase < 6)
		{
			AudioSource.PlayClipAtPoint(this.Giggles[this.GiggleID], this.MyCamera.transform.position);
			return;
		}
		AudioSource.PlayClipAtPoint(this.Giggles[this.GiggleID], this.MyCamera.transform.position + Vector3.up * this.Timer);
	}

	// Token: 0x040028B5 RID: 10421
	public StudentManagerScript StudentManager;

	// Token: 0x040028B6 RID: 10422
	public YandereScript Yandere;

	// Token: 0x040028B7 RID: 10423
	public StudentScript Senpai;

	// Token: 0x040028B8 RID: 10424
	public Renderer Darkness;

	// Token: 0x040028B9 RID: 10425
	public Transform SenpaiSpot;

	// Token: 0x040028BA RID: 10426
	public Transform MyCamera;

	// Token: 0x040028BB RID: 10427
	public Transform[] CameraPosition;

	// Token: 0x040028BC RID: 10428
	public GameObject[] GossipGroup;

	// Token: 0x040028BD RID: 10429
	public AudioClip[] Giggles;

	// Token: 0x040028BE RID: 10430
	public float GiggleTimer;

	// Token: 0x040028BF RID: 10431
	public float Timer;

	// Token: 0x040028C0 RID: 10432
	public int PreviousGiggle;

	// Token: 0x040028C1 RID: 10433
	public int GigglePhase;

	// Token: 0x040028C2 RID: 10434
	public int GiggleID;

	// Token: 0x040028C3 RID: 10435
	public int Phase;
}
