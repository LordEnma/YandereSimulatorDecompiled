using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000446 RID: 1094
public class StalkerPromptScript : MonoBehaviour
{
	// Token: 0x06001D28 RID: 7464 RVA: 0x0015C5AC File Offset: 0x0015A7AC
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

	// Token: 0x06001D29 RID: 7465 RVA: 0x0015C630 File Offset: 0x0015A830
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

	// Token: 0x06001D2A RID: 7466 RVA: 0x0015D088 File Offset: 0x0015B288
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

	// Token: 0x06001D2B RID: 7467 RVA: 0x0015D160 File Offset: 0x0015B360
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

	// Token: 0x040034D8 RID: 13528
	public StalkerPromptScript ExitPrompt;

	// Token: 0x040034D9 RID: 13529
	public FamilyVoiceScript FatherVoice;

	// Token: 0x040034DA RID: 13530
	public StalkerYandereScript Yandere;

	// Token: 0x040034DB RID: 13531
	public SmoothLookAtScript Cat;

	// Token: 0x040034DC RID: 13532
	public StalkerScript Stalker;

	// Token: 0x040034DD RID: 13533
	public GameObject DomesticDispute;

	// Token: 0x040034DE RID: 13534
	public GameObject StairBlocker;

	// Token: 0x040034DF RID: 13535
	public GameObject CatPrompt;

	// Token: 0x040034E0 RID: 13536
	public GameObject FrontDoor;

	// Token: 0x040034E1 RID: 13537
	public GameObject Button;

	// Token: 0x040034E2 RID: 13538
	public GameObject Father;

	// Token: 0x040034E3 RID: 13539
	public GameObject Mother;

	// Token: 0x040034E4 RID: 13540
	public GameObject Lights;

	// Token: 0x040034E5 RID: 13541
	public GameObject Fire;

	// Token: 0x040034E6 RID: 13542
	public UILabel BagsToBurnLabel;

	// Token: 0x040034E7 RID: 13543
	public UILabel Label;

	// Token: 0x040034E8 RID: 13544
	public Transform KitchenDoor;

	// Token: 0x040034E9 RID: 13545
	public Transform CatCage;

	// Token: 0x040034EA RID: 13546
	public Transform Door;

	// Token: 0x040034EB RID: 13547
	public AudioSource FireAudio;

	// Token: 0x040034EC RID: 13548
	public AudioSource MyAudio;

	// Token: 0x040034ED RID: 13549
	public AudioClip SwingOpen;

	// Token: 0x040034EE RID: 13550
	public AudioClip PowerDown;

	// Token: 0x040034EF RID: 13551
	public UISprite MySprite;

	// Token: 0x040034F0 RID: 13552
	public Renderer Darkness;

	// Token: 0x040034F1 RID: 13553
	public bool ServedPurpose;

	// Token: 0x040034F2 RID: 13554
	public bool Eighties;

	// Token: 0x040034F3 RID: 13555
	public bool OpenDoor;

	// Token: 0x040034F4 RID: 13556
	public bool FadeOut;

	// Token: 0x040034F5 RID: 13557
	public bool Open;

	// Token: 0x040034F6 RID: 13558
	public float TargetRotation = 5.5f;

	// Token: 0x040034F7 RID: 13559
	public float MaximumDistance = 5f;

	// Token: 0x040034F8 RID: 13560
	public float MinimumDistance = 2f;

	// Token: 0x040034F9 RID: 13561
	public float Rotation;

	// Token: 0x040034FA RID: 13562
	public float Alpha;

	// Token: 0x040034FB RID: 13563
	public float Speed;

	// Token: 0x040034FC RID: 13564
	public int BagsToBurn;

	// Token: 0x040034FD RID: 13565
	public int BagID;

	// Token: 0x040034FE RID: 13566
	public int ID;
}
