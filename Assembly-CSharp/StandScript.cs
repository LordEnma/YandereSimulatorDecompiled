using System;
using UnityEngine;

// Token: 0x02000443 RID: 1091
public class StandScript : MonoBehaviour
{
	// Token: 0x06001D07 RID: 7431 RVA: 0x0015A355 File Offset: 0x00158555
	private void Start()
	{
		if (GameGlobals.LoveSick)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001D08 RID: 7432 RVA: 0x0015A368 File Offset: 0x00158568
	private void Update()
	{
		if (!this.Stand.activeInHierarchy)
		{
			if (this.Weapons == 8 && this.Yandere.transform.position.y > 11.9f && Input.GetButtonDown("RB") && !MissionModeGlobals.MissionMode && !this.Yandere.Laughing && this.Yandere.CanMove)
			{
				this.Yandere.Jojo();
				return;
			}
		}
		else if (this.Phase == 0)
		{
			if (this.Stand.GetComponent<Animation>()["StandSummon"].time >= 2f && this.Stand.GetComponent<Animation>()["StandSummon"].time <= 2.5f)
			{
				if (!this.SFX)
				{
					AudioSource.PlayClipAtPoint(this.SummonSFX, base.transform.position);
					this.SFX = true;
				}
				UnityEngine.Object.Instantiate<GameObject>(this.SummonEffect, this.SummonTransform.position, Quaternion.identity);
			}
			if (this.Stand.GetComponent<Animation>()["StandSummon"].time >= this.Stand.GetComponent<Animation>()["StandSummon"].length)
			{
				this.Stand.GetComponent<Animation>().CrossFade("StandIdle");
				this.Phase++;
				return;
			}
		}
		else
		{
			float axis = Input.GetAxis("Vertical");
			float axis2 = Input.GetAxis("Horizontal");
			if (this.Yandere.CanMove)
			{
				this.Return();
				if (axis == 0f && axis2 == 0f)
				{
					this.Stand.GetComponent<Animation>().CrossFade("StandIdle");
					return;
				}
				if (this.Yandere.Running)
				{
					this.Stand.GetComponent<Animation>().CrossFade("StandRun");
					return;
				}
				this.Stand.GetComponent<Animation>().CrossFade("StandWalk");
				return;
			}
			else if (this.Yandere.RPGCamera.enabled)
			{
				if (this.Yandere.Laughing)
				{
					if (Vector3.Distance(this.Stand.transform.localPosition, new Vector3(0f, 0.2f, -0.4f)) > 0.01f)
					{
						this.Stand.transform.localPosition = Vector3.Lerp(this.Stand.transform.localPosition, new Vector3(0f, 0.2f, 0.1f), Time.deltaTime * 10f);
						this.Stand.transform.localEulerAngles = new Vector3(Mathf.Lerp(this.Stand.transform.localEulerAngles.x, 22.5f, Time.deltaTime * 10f), this.Stand.transform.localEulerAngles.y, this.Stand.transform.localEulerAngles.z);
					}
					this.Stand.GetComponent<Animation>().CrossFade("StandAttack");
					this.StandPunch.MyCollider.enabled = true;
					this.ReadyForFinisher = true;
					return;
				}
				if (this.ReadyForFinisher)
				{
					if (this.Phase == 1)
					{
						base.GetComponent<AudioSource>().Play();
						this.Finisher = UnityEngine.Random.Range(1, 3);
						this.Stand.GetComponent<Animation>().CrossFade("StandFinisher" + this.Finisher.ToString());
						this.Phase++;
						return;
					}
					if (this.Phase == 2)
					{
						if (this.Stand.GetComponent<Animation>()["StandFinisher" + this.Finisher.ToString()].time >= 0.5f)
						{
							this.FalconPunch.MyCollider.enabled = true;
							this.StandPunch.MyCollider.enabled = false;
							this.Phase++;
							return;
						}
					}
					else if (this.Phase == 3 && (this.StandPunch.MyCollider.enabled || this.Stand.GetComponent<Animation>()["StandFinisher" + this.Finisher.ToString()].time >= this.Stand.GetComponent<Animation>()["StandFinisher" + this.Finisher.ToString()].length))
					{
						this.Stand.GetComponent<Animation>().CrossFade("StandIdle");
						this.FalconPunch.MyCollider.enabled = false;
						this.ReadyForFinisher = false;
						this.Yandere.CanMove = true;
						this.Phase = 1;
					}
				}
			}
		}
	}

	// Token: 0x06001D09 RID: 7433 RVA: 0x0015A81C File Offset: 0x00158A1C
	public void Spawn()
	{
		this.FalconPunch.MyCollider.enabled = false;
		this.StandPunch.MyCollider.enabled = false;
		this.StandCamera.SetActive(true);
		this.MotionBlur.enabled = true;
		this.Stand.SetActive(true);
	}

	// Token: 0x06001D0A RID: 7434 RVA: 0x0015A870 File Offset: 0x00158A70
	private void Return()
	{
		if (Vector3.Distance(this.Stand.transform.localPosition, new Vector3(0f, 0f, -0.5f)) > 0.01f)
		{
			this.Stand.transform.localPosition = Vector3.Lerp(this.Stand.transform.localPosition, new Vector3(0f, 0f, -0.5f), Time.deltaTime * 10f);
			this.Stand.transform.localEulerAngles = new Vector3(Mathf.Lerp(this.Stand.transform.localEulerAngles.x, 0f, Time.deltaTime * 10f), this.Stand.transform.localEulerAngles.y, this.Stand.transform.localEulerAngles.z);
		}
	}

	// Token: 0x040034BD RID: 13501
	public AmplifyMotionEffect MotionBlur;

	// Token: 0x040034BE RID: 13502
	public FalconPunchScript FalconPunch;

	// Token: 0x040034BF RID: 13503
	public StandPunchScript StandPunch;

	// Token: 0x040034C0 RID: 13504
	public Transform SummonTransform;

	// Token: 0x040034C1 RID: 13505
	public GameObject SummonEffect;

	// Token: 0x040034C2 RID: 13506
	public GameObject StandCamera;

	// Token: 0x040034C3 RID: 13507
	public YandereScript Yandere;

	// Token: 0x040034C4 RID: 13508
	public GameObject Stand;

	// Token: 0x040034C5 RID: 13509
	public Transform[] Hands;

	// Token: 0x040034C6 RID: 13510
	public int FinishPhase;

	// Token: 0x040034C7 RID: 13511
	public int Finisher;

	// Token: 0x040034C8 RID: 13512
	public int Weapons;

	// Token: 0x040034C9 RID: 13513
	public int Phase;

	// Token: 0x040034CA RID: 13514
	public AudioClip SummonSFX;

	// Token: 0x040034CB RID: 13515
	public bool ReadyForFinisher;

	// Token: 0x040034CC RID: 13516
	public bool SFX;
}
