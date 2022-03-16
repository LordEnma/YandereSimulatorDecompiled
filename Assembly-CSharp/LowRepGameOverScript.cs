using System;
using UnityEngine;

// Token: 0x0200035A RID: 858
public class LowRepGameOverScript : MonoBehaviour
{
	// Token: 0x06001989 RID: 6537 RVA: 0x00103674 File Offset: 0x00101874
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

	// Token: 0x0600198A RID: 6538 RVA: 0x00103868 File Offset: 0x00101A68
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

	// Token: 0x0600198B RID: 6539 RVA: 0x0010425C File Offset: 0x0010245C
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

	// Token: 0x040028D7 RID: 10455
	public StudentManagerScript StudentManager;

	// Token: 0x040028D8 RID: 10456
	public YandereScript Yandere;

	// Token: 0x040028D9 RID: 10457
	public StudentScript Senpai;

	// Token: 0x040028DA RID: 10458
	public Renderer Darkness;

	// Token: 0x040028DB RID: 10459
	public Transform SenpaiSpot;

	// Token: 0x040028DC RID: 10460
	public Transform MyCamera;

	// Token: 0x040028DD RID: 10461
	public Transform[] CameraPosition;

	// Token: 0x040028DE RID: 10462
	public GameObject[] GossipGroup;

	// Token: 0x040028DF RID: 10463
	public AudioClip[] Giggles;

	// Token: 0x040028E0 RID: 10464
	public float GiggleTimer;

	// Token: 0x040028E1 RID: 10465
	public float Timer;

	// Token: 0x040028E2 RID: 10466
	public int PreviousGiggle;

	// Token: 0x040028E3 RID: 10467
	public int GigglePhase;

	// Token: 0x040028E4 RID: 10468
	public int GiggleID;

	// Token: 0x040028E5 RID: 10469
	public int Phase;
}
