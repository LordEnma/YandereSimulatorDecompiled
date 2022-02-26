using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200043F RID: 1087
public class StalkerPromptScript : MonoBehaviour
{
	// Token: 0x06001CF7 RID: 7415 RVA: 0x001589C8 File Offset: 0x00156BC8
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

	// Token: 0x06001CF8 RID: 7416 RVA: 0x00158A4C File Offset: 0x00156C4C
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

	// Token: 0x06001CF9 RID: 7417 RVA: 0x001594A4 File Offset: 0x001576A4
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

	// Token: 0x06001CFA RID: 7418 RVA: 0x0015957C File Offset: 0x0015777C
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

	// Token: 0x0400343F RID: 13375
	public StalkerPromptScript ExitPrompt;

	// Token: 0x04003440 RID: 13376
	public FamilyVoiceScript FatherVoice;

	// Token: 0x04003441 RID: 13377
	public StalkerYandereScript Yandere;

	// Token: 0x04003442 RID: 13378
	public SmoothLookAtScript Cat;

	// Token: 0x04003443 RID: 13379
	public StalkerScript Stalker;

	// Token: 0x04003444 RID: 13380
	public GameObject DomesticDispute;

	// Token: 0x04003445 RID: 13381
	public GameObject StairBlocker;

	// Token: 0x04003446 RID: 13382
	public GameObject CatPrompt;

	// Token: 0x04003447 RID: 13383
	public GameObject FrontDoor;

	// Token: 0x04003448 RID: 13384
	public GameObject Button;

	// Token: 0x04003449 RID: 13385
	public GameObject Father;

	// Token: 0x0400344A RID: 13386
	public GameObject Mother;

	// Token: 0x0400344B RID: 13387
	public GameObject Lights;

	// Token: 0x0400344C RID: 13388
	public GameObject Fire;

	// Token: 0x0400344D RID: 13389
	public UILabel BagsToBurnLabel;

	// Token: 0x0400344E RID: 13390
	public UILabel Label;

	// Token: 0x0400344F RID: 13391
	public Transform KitchenDoor;

	// Token: 0x04003450 RID: 13392
	public Transform CatCage;

	// Token: 0x04003451 RID: 13393
	public Transform Door;

	// Token: 0x04003452 RID: 13394
	public AudioSource FireAudio;

	// Token: 0x04003453 RID: 13395
	public AudioSource MyAudio;

	// Token: 0x04003454 RID: 13396
	public AudioClip SwingOpen;

	// Token: 0x04003455 RID: 13397
	public AudioClip PowerDown;

	// Token: 0x04003456 RID: 13398
	public UISprite MySprite;

	// Token: 0x04003457 RID: 13399
	public Renderer Darkness;

	// Token: 0x04003458 RID: 13400
	public bool ServedPurpose;

	// Token: 0x04003459 RID: 13401
	public bool Eighties;

	// Token: 0x0400345A RID: 13402
	public bool OpenDoor;

	// Token: 0x0400345B RID: 13403
	public bool FadeOut;

	// Token: 0x0400345C RID: 13404
	public bool Open;

	// Token: 0x0400345D RID: 13405
	public float TargetRotation = 5.5f;

	// Token: 0x0400345E RID: 13406
	public float MaximumDistance = 5f;

	// Token: 0x0400345F RID: 13407
	public float MinimumDistance = 2f;

	// Token: 0x04003460 RID: 13408
	public float Rotation;

	// Token: 0x04003461 RID: 13409
	public float Alpha;

	// Token: 0x04003462 RID: 13410
	public float Speed;

	// Token: 0x04003463 RID: 13411
	public int BagsToBurn;

	// Token: 0x04003464 RID: 13412
	public int BagID;

	// Token: 0x04003465 RID: 13413
	public int ID;
}
