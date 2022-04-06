using System;
using UnityEngine;

// Token: 0x02000449 RID: 1097
public class StandScript : MonoBehaviour
{
	// Token: 0x06001D31 RID: 7473 RVA: 0x0015D3E9 File Offset: 0x0015B5E9
	private void Start()
	{
		if (GameGlobals.LoveSick)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001D32 RID: 7474 RVA: 0x0015D3FC File Offset: 0x0015B5FC
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

	// Token: 0x06001D33 RID: 7475 RVA: 0x0015D8B0 File Offset: 0x0015BAB0
	public void Spawn()
	{
		this.FalconPunch.MyCollider.enabled = false;
		this.StandPunch.MyCollider.enabled = false;
		this.StandCamera.SetActive(true);
		this.MotionBlur.enabled = true;
		this.Stand.SetActive(true);
	}

	// Token: 0x06001D34 RID: 7476 RVA: 0x0015D904 File Offset: 0x0015BB04
	private void Return()
	{
		if (Vector3.Distance(this.Stand.transform.localPosition, new Vector3(0f, 0f, -0.5f)) > 0.01f)
		{
			this.Stand.transform.localPosition = Vector3.Lerp(this.Stand.transform.localPosition, new Vector3(0f, 0f, -0.5f), Time.deltaTime * 10f);
			this.Stand.transform.localEulerAngles = new Vector3(Mathf.Lerp(this.Stand.transform.localEulerAngles.x, 0f, Time.deltaTime * 10f), this.Stand.transform.localEulerAngles.y, this.Stand.transform.localEulerAngles.z);
		}
	}

	// Token: 0x0400353E RID: 13630
	public AmplifyMotionEffect MotionBlur;

	// Token: 0x0400353F RID: 13631
	public FalconPunchScript FalconPunch;

	// Token: 0x04003540 RID: 13632
	public StandPunchScript StandPunch;

	// Token: 0x04003541 RID: 13633
	public Transform SummonTransform;

	// Token: 0x04003542 RID: 13634
	public GameObject SummonEffect;

	// Token: 0x04003543 RID: 13635
	public GameObject StandCamera;

	// Token: 0x04003544 RID: 13636
	public YandereScript Yandere;

	// Token: 0x04003545 RID: 13637
	public GameObject Stand;

	// Token: 0x04003546 RID: 13638
	public Transform[] Hands;

	// Token: 0x04003547 RID: 13639
	public int FinishPhase;

	// Token: 0x04003548 RID: 13640
	public int Finisher;

	// Token: 0x04003549 RID: 13641
	public int Weapons;

	// Token: 0x0400354A RID: 13642
	public int Phase;

	// Token: 0x0400354B RID: 13643
	public AudioClip SummonSFX;

	// Token: 0x0400354C RID: 13644
	public bool ReadyForFinisher;

	// Token: 0x0400354D RID: 13645
	public bool SFX;
}
