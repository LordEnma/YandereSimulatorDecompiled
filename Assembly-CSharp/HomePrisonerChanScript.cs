using System;
using UnityEngine;

// Token: 0x02000323 RID: 803
public class HomePrisonerChanScript : MonoBehaviour
{
	// Token: 0x06001899 RID: 6297 RVA: 0x000F0CF0 File Offset: 0x000EEEF0
	private void Start()
	{
		if (SchoolGlobals.KidnapVictim > 0)
		{
			this.StudentID = SchoolGlobals.KidnapVictim;
			if (StudentGlobals.GetStudentSanity(this.StudentID) == 100f)
			{
				this.AnkleRopes.SetActive(false);
			}
			this.PermanentAngleR = this.TwintailR.eulerAngles;
			this.PermanentAngleL = this.TwintailL.eulerAngles;
			if (!StudentGlobals.GetStudentArrested(this.StudentID) && !StudentGlobals.GetStudentDead(this.StudentID))
			{
				this.Cosmetic.StudentID = this.StudentID;
				this.Cosmetic.enabled = true;
				this.BreastSize = this.JSON.Students[this.StudentID].BreastSize;
				this.RightEyeRotOrigin = this.RightEye.localEulerAngles;
				this.LeftEyeRotOrigin = this.LeftEye.localEulerAngles;
				this.RightEyeOrigin = this.RightEye.localPosition;
				this.LeftEyeOrigin = this.LeftEye.localPosition;
				this.UpdateSanity();
				this.TwintailR.transform.localEulerAngles = new Vector3(0f, 180f, -90f);
				this.TwintailL.transform.localEulerAngles = new Vector3(0f, 0f, -90f);
				this.Blindfold.SetActive(false);
				this.Tripod.SetActive(false);
				if (this.StudentID == 81 && !StudentGlobals.GetStudentBroken(81) && SchemeGlobals.HelpingKokona)
				{
					this.Blindfold.SetActive(true);
					this.Tripod.SetActive(true);
				}
			}
			else
			{
				SchoolGlobals.KidnapVictim = 0;
				base.gameObject.SetActive(false);
			}
		}
		else
		{
			base.gameObject.SetActive(false);
		}
		if (GameGlobals.Eighties)
		{
			if (this.Eighties)
			{
				for (int i = 0; i < this.Cosmetic.Student.Ragdoll.AllRigidbodies.Length; i++)
				{
					this.Cosmetic.Student.Ragdoll.AllRigidbodies[i].isKinematic = true;
					this.Cosmetic.Student.Ragdoll.AllColliders[i].enabled = false;
				}
				this.Cosmetic.Student.DisableFemaleProps();
				this.Cosmetic.Student.SetSplashes(false);
				this.Cosmetic.Student.DisableProps();
				this.Blindfold.SetActive(true);
				return;
			}
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x0600189A RID: 6298 RVA: 0x000F0F68 File Offset: 0x000EF168
	private void LateUpdate()
	{
		this.Skirt.transform.localPosition = new Vector3(0f, -0.135f, 0.01f);
		this.Skirt.transform.localScale = new Vector3(this.Skirt.transform.localScale.x, 1.2f, this.Skirt.transform.localScale.z);
		if (!this.Tortured)
		{
			if (this.Sanity > 0f)
			{
				if (this.LookAhead)
				{
					this.Neck.localEulerAngles = new Vector3(this.Neck.localEulerAngles.x - 45f, this.Neck.localEulerAngles.y, this.Neck.localEulerAngles.z);
				}
				else if (this.YandereDetector.YandereDetected && Vector3.Distance(base.transform.position, this.HomeYandere.position) < 2f)
				{
					Quaternion b;
					if (this.HomeCamera.Target == this.HomeCamera.Targets[10])
					{
						b = Quaternion.LookRotation(this.HomeCamera.transform.position + Vector3.down * (1.5f * ((100f - this.Sanity) / 100f)) - this.Neck.position);
						this.HairRotation = Mathf.Lerp(this.HairRotation, this.HairRot1, Time.deltaTime * 2f);
					}
					else
					{
						b = Quaternion.LookRotation(this.HomeYandere.position + Vector3.up * 1.5f - this.Neck.position);
						this.HairRotation = Mathf.Lerp(this.HairRotation, this.HairRot2, Time.deltaTime * 2f);
					}
					this.Neck.rotation = Quaternion.Slerp(this.LastRotation, b, Time.deltaTime * 2f);
					this.TwintailR.transform.localEulerAngles = new Vector3(this.HairRotation, 180f, -90f);
					this.TwintailL.transform.localEulerAngles = new Vector3(-this.HairRotation, 0f, -90f);
				}
				else
				{
					if (this.HomeCamera.Target == this.HomeCamera.Targets[10])
					{
						Quaternion b2 = Quaternion.LookRotation(this.HomeCamera.transform.position + Vector3.down * (1.5f * ((100f - this.Sanity) / 100f)) - this.Neck.position);
						this.HairRotation = Mathf.Lerp(this.HairRotation, this.HairRot3, Time.deltaTime * 2f);
					}
					else
					{
						Quaternion b2 = Quaternion.LookRotation(base.transform.position + base.transform.forward - this.Neck.position);
						this.Neck.rotation = Quaternion.Slerp(this.LastRotation, b2, Time.deltaTime * 2f);
					}
					this.HairRotation = Mathf.Lerp(this.HairRotation, this.HairRot4, Time.deltaTime * 2f);
					this.TwintailR.transform.localEulerAngles = new Vector3(this.HairRotation, 180f, -90f);
					this.TwintailL.transform.localEulerAngles = new Vector3(-this.HairRotation, 0f, -90f);
				}
			}
			else
			{
				this.Neck.localEulerAngles = new Vector3(this.Neck.localEulerAngles.x - 45f, this.Neck.localEulerAngles.y, this.Neck.localEulerAngles.z);
			}
		}
		this.LastRotation = this.Neck.rotation;
		if (!this.Tortured && this.Sanity < 100f && this.Sanity > 0f)
		{
			this.TwitchTimer += Time.deltaTime;
			if (this.TwitchTimer > this.NextTwitch)
			{
				this.Twitch = new Vector3((1f - this.Sanity / 100f) * UnityEngine.Random.Range(-10f, 10f), (1f - this.Sanity / 100f) * UnityEngine.Random.Range(-10f, 10f), (1f - this.Sanity / 100f) * UnityEngine.Random.Range(-10f, 10f));
				this.NextTwitch = UnityEngine.Random.Range(0f, 1f);
				this.TwitchTimer = 0f;
			}
			this.Twitch = Vector3.Lerp(this.Twitch, Vector3.zero, Time.deltaTime * 10f);
			this.Neck.localEulerAngles += this.Twitch;
		}
		if (this.Tortured)
		{
			this.HairRotation = Mathf.Lerp(this.HairRotation, this.HairRot5, Time.deltaTime * 2f);
			this.TwintailR.transform.localEulerAngles = new Vector3(this.HairRotation, 180f, -90f);
			this.TwintailL.transform.localEulerAngles = new Vector3(-this.HairRotation, 0f, -90f);
		}
	}

	// Token: 0x0600189B RID: 6299 RVA: 0x000F1518 File Offset: 0x000EF718
	public void UpdateSanity()
	{
		this.Sanity = StudentGlobals.GetStudentSanity(this.StudentID);
		bool active = this.Sanity == 0f;
		this.RightMindbrokenEye.SetActive(active);
		this.LeftMindbrokenEye.SetActive(active);
	}

	// Token: 0x04002521 RID: 9505
	public HomeYandereDetectorScript YandereDetector;

	// Token: 0x04002522 RID: 9506
	public HomeCameraScript HomeCamera;

	// Token: 0x04002523 RID: 9507
	public CosmeticScript Cosmetic;

	// Token: 0x04002524 RID: 9508
	public JsonScript JSON;

	// Token: 0x04002525 RID: 9509
	public Vector3 RightEyeRotOrigin;

	// Token: 0x04002526 RID: 9510
	public Vector3 LeftEyeRotOrigin;

	// Token: 0x04002527 RID: 9511
	public Vector3 PermanentAngleR;

	// Token: 0x04002528 RID: 9512
	public Vector3 PermanentAngleL;

	// Token: 0x04002529 RID: 9513
	public Vector3 RightEyeOrigin;

	// Token: 0x0400252A RID: 9514
	public Vector3 LeftEyeOrigin;

	// Token: 0x0400252B RID: 9515
	public Vector3 Twitch;

	// Token: 0x0400252C RID: 9516
	public Quaternion LastRotation;

	// Token: 0x0400252D RID: 9517
	public Transform HomeYandere;

	// Token: 0x0400252E RID: 9518
	public Transform RightBreast;

	// Token: 0x0400252F RID: 9519
	public Transform LeftBreast;

	// Token: 0x04002530 RID: 9520
	public Transform TwintailR;

	// Token: 0x04002531 RID: 9521
	public Transform TwintailL;

	// Token: 0x04002532 RID: 9522
	public Transform RightEye;

	// Token: 0x04002533 RID: 9523
	public Transform LeftEye;

	// Token: 0x04002534 RID: 9524
	public Transform Skirt;

	// Token: 0x04002535 RID: 9525
	public Transform Neck;

	// Token: 0x04002536 RID: 9526
	public GameObject RightMindbrokenEye;

	// Token: 0x04002537 RID: 9527
	public GameObject LeftMindbrokenEye;

	// Token: 0x04002538 RID: 9528
	public GameObject AnkleRopes;

	// Token: 0x04002539 RID: 9529
	public GameObject Blindfold;

	// Token: 0x0400253A RID: 9530
	public GameObject Character;

	// Token: 0x0400253B RID: 9531
	public GameObject Tripod;

	// Token: 0x0400253C RID: 9532
	public float HairRotation;

	// Token: 0x0400253D RID: 9533
	public float TwitchTimer;

	// Token: 0x0400253E RID: 9534
	public float NextTwitch;

	// Token: 0x0400253F RID: 9535
	public float BreastSize;

	// Token: 0x04002540 RID: 9536
	public float EyeShrink;

	// Token: 0x04002541 RID: 9537
	public float Sanity;

	// Token: 0x04002542 RID: 9538
	public float HairRot1;

	// Token: 0x04002543 RID: 9539
	public float HairRot2;

	// Token: 0x04002544 RID: 9540
	public float HairRot3;

	// Token: 0x04002545 RID: 9541
	public float HairRot4;

	// Token: 0x04002546 RID: 9542
	public float HairRot5;

	// Token: 0x04002547 RID: 9543
	public bool LookAhead;

	// Token: 0x04002548 RID: 9544
	public bool Tortured;

	// Token: 0x04002549 RID: 9545
	public bool Eighties;

	// Token: 0x0400254A RID: 9546
	public bool Male;

	// Token: 0x0400254B RID: 9547
	public int StudentID;
}
