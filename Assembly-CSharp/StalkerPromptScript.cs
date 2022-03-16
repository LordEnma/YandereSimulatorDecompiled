using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000440 RID: 1088
public class StalkerPromptScript : MonoBehaviour
{
	// Token: 0x06001D06 RID: 7430 RVA: 0x00159E64 File Offset: 0x00158064
	private void Start()
	{
		this.Eighties = GameGlobals.Eighties;
		if (this.Eighties)
		{
			if (this.ID == 1)
			{
				if (this.BagID > DateGlobals.Week)
				{
					base.gameObject.SetActive(false);
					return;
				}
			}
			else if (this.ID == 5)
			{
				this.BagsToBurn = DateGlobals.Week;
				this.BagsToBurnLabel.text = "BAGS TO BURN: " + this.BagsToBurn.ToString();
				base.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06001D07 RID: 7431 RVA: 0x00159EE8 File Offset: 0x001580E8
	private void Update()
	{
		base.transform.LookAt(this.Yandere.MainCamera.transform);
		if (Vector3.Distance(base.transform.position, this.Yandere.transform.position) < this.MaximumDistance)
		{
			if (!this.ServedPurpose)
			{
				if (Vector3.Distance(base.transform.position, this.Yandere.transform.position) < this.MinimumDistance)
				{
					this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime);
				}
				else
				{
					this.Alpha = Mathf.MoveTowards(this.Alpha, 0.5f, Time.deltaTime);
				}
			}
			else
			{
				this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime);
			}
			if (Vector3.Distance(base.transform.position, this.Yandere.transform.position) < this.MinimumDistance && !this.ServedPurpose && Input.GetButtonDown("A"))
			{
				if (!this.Eighties)
				{
					if (this.ID == 1)
					{
						this.Yandere.MyAnimation.CrossFade("f02_climbTrellis_00");
						this.CatPrompt.SetActive(true);
						this.Yandere.Climbing = true;
						this.Yandere.CanMove = false;
						UnityEngine.Object.Destroy(base.gameObject);
						UnityEngine.Object.Destroy(this.MySprite);
					}
					else if (this.ID == 2)
					{
						this.CatPrompt.SetActive(true);
						this.Stalker.enabled = true;
						this.ServedPurpose = true;
						this.OpenDoor = true;
						this.MyAudio.Play();
					}
					else if (this.ID == 3)
					{
						this.BeginCarryingCat();
						this.Door.transform.localEulerAngles = Vector3.zero;
						this.KitchenDoor.localEulerAngles = new Vector3(0f, 180f, 0f);
						this.Father.SetActive(false);
						this.Mother.SetActive(false);
						this.DomesticDispute.SetActive(true);
						this.StairBlocker.SetActive(true);
						this.FrontDoor.SetActive(true);
						this.Cat.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
						this.Cat.enabled = false;
						this.MyAudio.Play();
						base.gameObject.SetActive(false);
						UnityEngine.Object.Destroy(this.MySprite);
						this.Stalker.Limit = 10;
					}
					else if (this.ID == 4)
					{
						this.CatCage.gameObject.SetActive(true);
						this.ServedPurpose = true;
						this.OpenDoor = true;
						this.MyAudio.Play();
					}
					else if (this.ID == 5)
					{
						this.Yandere.MyAnimation.CrossFade(this.Yandere.IdleAnim);
						this.Yandere.CanMove = false;
						this.ServedPurpose = true;
						this.OpenDoor = true;
						this.MyAudio.Play();
					}
					else if (this.ID == 6)
					{
						if (!this.Open)
						{
							this.MyAudio.clip = this.SwingOpen;
							this.MyAudio.Play();
							this.Label.text = "Sabotage";
							this.Open = true;
						}
						else
						{
							this.FatherVoice.MyAnimation.CrossFade("walkConfident_00");
							this.FatherVoice.Investigating = true;
							AudioSource.PlayClipAtPoint(this.PowerDown, Camera.main.transform.position);
							this.Lights.SetActive(false);
							this.ServedPurpose = true;
						}
					}
				}
				else if (this.ID == 1)
				{
					this.ExitPrompt.CountBags();
					this.Fire.SetActive(true);
					this.ServedPurpose = true;
					this.MyAudio.Play();
				}
				else if (this.ID == 2)
				{
					this.Yandere.Pebbles = 10;
					this.Yandere.UpdatePebbles();
					this.MyAudio.Play();
				}
				else if (this.ID == 3)
				{
					if (this.Yandere.CanMove)
					{
						this.Door.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
						this.Yandere.transform.localScale = new Vector3(0f, 1f, 0f);
						this.Yandere.Invisible = true;
						this.Yandere.CanMove = false;
						this.Label.text = "Exit";
						this.MyAudio.clip = this.PowerDown;
					}
					else
					{
						this.Door.transform.localEulerAngles = new Vector3(0f, 135f, 0f);
						this.Yandere.transform.localScale = new Vector3(1f, 1f, 1f);
						this.Yandere.Invisible = false;
						this.Yandere.CanMove = true;
						this.Label.text = "Hide";
						this.MyAudio.clip = this.SwingOpen;
					}
					this.MyAudio.Play();
				}
				else if (this.ID == 4)
				{
					AudioSource.PlayClipAtPoint(this.PowerDown, Camera.main.transform.position);
					if (this.BagID == 1)
					{
						this.Yandere.LethalPoison = true;
					}
					else if (this.BagID == 2)
					{
						this.Yandere.Sedative = true;
					}
					else if (this.BagID == 3)
					{
						this.Yandere.Cigs = true;
					}
					base.transform.parent.parent.gameObject.SetActive(false);
				}
				else if (this.ID == 5)
				{
					this.Yandere.MyAnimation.CrossFade(this.Yandere.IdleAnim);
					this.BagsToBurnLabel.gameObject.SetActive(false);
					this.Yandere.CanMove = false;
					this.ServedPurpose = true;
					this.FadeOut = true;
					this.MyAudio.Play();
				}
			}
		}
		else
		{
			if (!this.Eighties && (this.ID == 1 || this.ID == 6) && this.Yandere.transform.position.x > -11f && this.Yandere.transform.position.x < 11f && this.Yandere.transform.position.z > -11f && this.Yandere.transform.position.z < 11f)
			{
				if (this.ID == 1)
				{
					this.CatPrompt.SetActive(true);
				}
				this.ServedPurpose = true;
			}
			this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime);
		}
		if (this.Label != null && this.Door != null && !this.Eighties)
		{
			if (this.Open)
			{
				this.Door.transform.localEulerAngles = Vector3.Lerp(this.Door.transform.localEulerAngles, new Vector3(this.Door.transform.localEulerAngles.x, 180f, this.Door.transform.localEulerAngles.z), Time.deltaTime * 10f);
			}
			else
			{
				this.Door.transform.localEulerAngles = Vector3.Lerp(this.Door.transform.localEulerAngles, new Vector3(this.Door.transform.localEulerAngles.x, 0f, this.Door.transform.localEulerAngles.z), Time.deltaTime * 10f);
			}
		}
		if (this.OpenDoor)
		{
			this.Speed += Time.deltaTime * 0.1f;
			this.Rotation = Mathf.Lerp(this.Rotation, this.TargetRotation, Time.deltaTime * this.Speed);
			this.Door.transform.localEulerAngles = new Vector3(this.Door.transform.localEulerAngles.x, this.Rotation, this.Door.transform.localEulerAngles.z);
			if (this.ID == 5)
			{
				this.Darkness.material.color = new Color(0f, 0f, 0f, this.Darkness.material.color.a + Time.deltaTime * 0.33333f);
				if (this.Darkness.material.color.a >= 1f)
				{
					EventGlobals.OsanaConversation = true;
					SceneManager.LoadScene("PhoneScene");
				}
			}
		}
		if (this.FadeOut)
		{
			this.Darkness.material.color = new Color(0f, 0f, 0f, this.Darkness.material.color.a + Time.deltaTime * 0.33333f);
			this.MyAudio.volume -= Time.deltaTime;
			if (this.Darkness.material.color.a >= 1f)
			{
				if (this.Yandere.LethalPoison)
				{
					PlayerGlobals.BoughtPoison = true;
				}
				if (this.Yandere.Sedative)
				{
					PlayerGlobals.BoughtSedative = true;
				}
				if (this.Yandere.Cigs)
				{
					PlayerGlobals.SetCannotBringItem(6, false);
				}
				SceneManager.LoadScene("LivingRoomScene");
			}
		}
		if (this.FireAudio != null)
		{
			if (this.Yandere.transform.position.y < 1f)
			{
				this.FireAudio.volume = 0f;
			}
			else
			{
				this.FireAudio.volume = 1f;
			}
		}
		this.MySprite.color = new Color(1f, 1f, 1f, this.Alpha);
	}

	// Token: 0x06001D08 RID: 7432 RVA: 0x0015A940 File Offset: 0x00158B40
	public void BeginCarryingCat()
	{
		this.Yandere.MyAnimation["f02_grip_00"].layer = 1;
		this.Yandere.MyAnimation.Play("f02_grip_00");
		this.Yandere.Object = this.CatCage;
		this.CatCage.parent = this.Yandere.RightHand;
		this.CatCage.localEulerAngles = new Vector3(0f, 0f, 0f);
		this.CatCage.localPosition = new Vector3(0.075f, -0.025f, 0.0125f);
		this.CatCage.GetComponent<Rigidbody>().isKinematic = true;
		this.CatCage.GetComponent<Rigidbody>().useGravity = false;
		this.CatCage.GetComponent<Collider>().isTrigger = true;
	}

	// Token: 0x06001D09 RID: 7433 RVA: 0x0015AA18 File Offset: 0x00158C18
	public void CountBags()
	{
		this.BagsToBurn--;
		if (this.BagsToBurn == 0)
		{
			this.BagsToBurnLabel.text = "EXIT THE BUILDING FROM THE WINDOW YOU CAME IN FROM!";
			base.gameObject.SetActive(true);
			return;
		}
		this.BagsToBurnLabel.text = "BAGS TO BURN: " + this.BagsToBurn.ToString();
	}

	// Token: 0x0400348A RID: 13450
	public StalkerPromptScript ExitPrompt;

	// Token: 0x0400348B RID: 13451
	public FamilyVoiceScript FatherVoice;

	// Token: 0x0400348C RID: 13452
	public StalkerYandereScript Yandere;

	// Token: 0x0400348D RID: 13453
	public SmoothLookAtScript Cat;

	// Token: 0x0400348E RID: 13454
	public StalkerScript Stalker;

	// Token: 0x0400348F RID: 13455
	public GameObject DomesticDispute;

	// Token: 0x04003490 RID: 13456
	public GameObject StairBlocker;

	// Token: 0x04003491 RID: 13457
	public GameObject CatPrompt;

	// Token: 0x04003492 RID: 13458
	public GameObject FrontDoor;

	// Token: 0x04003493 RID: 13459
	public GameObject Button;

	// Token: 0x04003494 RID: 13460
	public GameObject Father;

	// Token: 0x04003495 RID: 13461
	public GameObject Mother;

	// Token: 0x04003496 RID: 13462
	public GameObject Lights;

	// Token: 0x04003497 RID: 13463
	public GameObject Fire;

	// Token: 0x04003498 RID: 13464
	public UILabel BagsToBurnLabel;

	// Token: 0x04003499 RID: 13465
	public UILabel Label;

	// Token: 0x0400349A RID: 13466
	public Transform KitchenDoor;

	// Token: 0x0400349B RID: 13467
	public Transform CatCage;

	// Token: 0x0400349C RID: 13468
	public Transform Door;

	// Token: 0x0400349D RID: 13469
	public AudioSource FireAudio;

	// Token: 0x0400349E RID: 13470
	public AudioSource MyAudio;

	// Token: 0x0400349F RID: 13471
	public AudioClip SwingOpen;

	// Token: 0x040034A0 RID: 13472
	public AudioClip PowerDown;

	// Token: 0x040034A1 RID: 13473
	public UISprite MySprite;

	// Token: 0x040034A2 RID: 13474
	public Renderer Darkness;

	// Token: 0x040034A3 RID: 13475
	public bool ServedPurpose;

	// Token: 0x040034A4 RID: 13476
	public bool Eighties;

	// Token: 0x040034A5 RID: 13477
	public bool OpenDoor;

	// Token: 0x040034A6 RID: 13478
	public bool FadeOut;

	// Token: 0x040034A7 RID: 13479
	public bool Open;

	// Token: 0x040034A8 RID: 13480
	public float TargetRotation = 5.5f;

	// Token: 0x040034A9 RID: 13481
	public float MaximumDistance = 5f;

	// Token: 0x040034AA RID: 13482
	public float MinimumDistance = 2f;

	// Token: 0x040034AB RID: 13483
	public float Rotation;

	// Token: 0x040034AC RID: 13484
	public float Alpha;

	// Token: 0x040034AD RID: 13485
	public float Speed;

	// Token: 0x040034AE RID: 13486
	public int BagsToBurn;

	// Token: 0x040034AF RID: 13487
	public int BagID;

	// Token: 0x040034B0 RID: 13488
	public int ID;
}
