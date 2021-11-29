using System;
using UnityEngine;

// Token: 0x0200031F RID: 799
public class HomePrisonerChanScript : MonoBehaviour
{
	// Token: 0x06001879 RID: 6265 RVA: 0x000EEADC File Offset: 0x000ECCDC
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

	// Token: 0x0600187A RID: 6266 RVA: 0x000EED54 File Offset: 0x000ECF54
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

	// Token: 0x0600187B RID: 6267 RVA: 0x000EF304 File Offset: 0x000ED504
	public void UpdateSanity()
	{
		this.Sanity = StudentGlobals.GetStudentSanity(this.StudentID);
		bool active = this.Sanity == 0f;
		this.RightMindbrokenEye.SetActive(active);
		this.LeftMindbrokenEye.SetActive(active);
	}

	// Token: 0x040024C4 RID: 9412
	public HomeYandereDetectorScript YandereDetector;

	// Token: 0x040024C5 RID: 9413
	public HomeCameraScript HomeCamera;

	// Token: 0x040024C6 RID: 9414
	public CosmeticScript Cosmetic;

	// Token: 0x040024C7 RID: 9415
	public JsonScript JSON;

	// Token: 0x040024C8 RID: 9416
	public Vector3 RightEyeRotOrigin;

	// Token: 0x040024C9 RID: 9417
	public Vector3 LeftEyeRotOrigin;

	// Token: 0x040024CA RID: 9418
	public Vector3 PermanentAngleR;

	// Token: 0x040024CB RID: 9419
	public Vector3 PermanentAngleL;

	// Token: 0x040024CC RID: 9420
	public Vector3 RightEyeOrigin;

	// Token: 0x040024CD RID: 9421
	public Vector3 LeftEyeOrigin;

	// Token: 0x040024CE RID: 9422
	public Vector3 Twitch;

	// Token: 0x040024CF RID: 9423
	public Quaternion LastRotation;

	// Token: 0x040024D0 RID: 9424
	public Transform HomeYandere;

	// Token: 0x040024D1 RID: 9425
	public Transform RightBreast;

	// Token: 0x040024D2 RID: 9426
	public Transform LeftBreast;

	// Token: 0x040024D3 RID: 9427
	public Transform TwintailR;

	// Token: 0x040024D4 RID: 9428
	public Transform TwintailL;

	// Token: 0x040024D5 RID: 9429
	public Transform RightEye;

	// Token: 0x040024D6 RID: 9430
	public Transform LeftEye;

	// Token: 0x040024D7 RID: 9431
	public Transform Skirt;

	// Token: 0x040024D8 RID: 9432
	public Transform Neck;

	// Token: 0x040024D9 RID: 9433
	public GameObject RightMindbrokenEye;

	// Token: 0x040024DA RID: 9434
	public GameObject LeftMindbrokenEye;

	// Token: 0x040024DB RID: 9435
	public GameObject AnkleRopes;

	// Token: 0x040024DC RID: 9436
	public GameObject Blindfold;

	// Token: 0x040024DD RID: 9437
	public GameObject Character;

	// Token: 0x040024DE RID: 9438
	public GameObject Tripod;

	// Token: 0x040024DF RID: 9439
	public float HairRotation;

	// Token: 0x040024E0 RID: 9440
	public float TwitchTimer;

	// Token: 0x040024E1 RID: 9441
	public float NextTwitch;

	// Token: 0x040024E2 RID: 9442
	public float BreastSize;

	// Token: 0x040024E3 RID: 9443
	public float EyeShrink;

	// Token: 0x040024E4 RID: 9444
	public float Sanity;

	// Token: 0x040024E5 RID: 9445
	public float HairRot1;

	// Token: 0x040024E6 RID: 9446
	public float HairRot2;

	// Token: 0x040024E7 RID: 9447
	public float HairRot3;

	// Token: 0x040024E8 RID: 9448
	public float HairRot4;

	// Token: 0x040024E9 RID: 9449
	public float HairRot5;

	// Token: 0x040024EA RID: 9450
	public bool LookAhead;

	// Token: 0x040024EB RID: 9451
	public bool Tortured;

	// Token: 0x040024EC RID: 9452
	public bool Eighties;

	// Token: 0x040024ED RID: 9453
	public bool Male;

	// Token: 0x040024EE RID: 9454
	public int StudentID;
}
