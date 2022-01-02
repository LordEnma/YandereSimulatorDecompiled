using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200043A RID: 1082
public class StalkerPromptScript : MonoBehaviour
{
	// Token: 0x06001CDB RID: 7387 RVA: 0x00155B2C File Offset: 0x00153D2C
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
			else
			{
				this.BagsToBurn = DateGlobals.Week;
				this.BagsToBurnLabel.text = "BAGS TO BURN: " + this.BagsToBurn.ToString();
				base.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06001CDC RID: 7388 RVA: 0x00155BA8 File Offset: 0x00153DA8
	private void Update()
	{
		base.transform.LookAt(this.Yandere.MainCamera.transform);
		if (Vector3.Distance(base.transform.position, this.Yandere.transform.position) < 5f)
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
		if (this.Label != null && this.Door != null)
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

	// Token: 0x06001CDD RID: 7389 RVA: 0x001563D0 File Offset: 0x001545D0
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

	// Token: 0x06001CDE RID: 7390 RVA: 0x001564A8 File Offset: 0x001546A8
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

	// Token: 0x04003414 RID: 13332
	public StalkerPromptScript ExitPrompt;

	// Token: 0x04003415 RID: 13333
	public FamilyVoiceScript FatherVoice;

	// Token: 0x04003416 RID: 13334
	public StalkerYandereScript Yandere;

	// Token: 0x04003417 RID: 13335
	public SmoothLookAtScript Cat;

	// Token: 0x04003418 RID: 13336
	public StalkerScript Stalker;

	// Token: 0x04003419 RID: 13337
	public GameObject DomesticDispute;

	// Token: 0x0400341A RID: 13338
	public GameObject StairBlocker;

	// Token: 0x0400341B RID: 13339
	public GameObject CatPrompt;

	// Token: 0x0400341C RID: 13340
	public GameObject FrontDoor;

	// Token: 0x0400341D RID: 13341
	public GameObject Button;

	// Token: 0x0400341E RID: 13342
	public GameObject Father;

	// Token: 0x0400341F RID: 13343
	public GameObject Mother;

	// Token: 0x04003420 RID: 13344
	public GameObject Lights;

	// Token: 0x04003421 RID: 13345
	public GameObject Fire;

	// Token: 0x04003422 RID: 13346
	public UILabel BagsToBurnLabel;

	// Token: 0x04003423 RID: 13347
	public UILabel Label;

	// Token: 0x04003424 RID: 13348
	public Transform KitchenDoor;

	// Token: 0x04003425 RID: 13349
	public Transform CatCage;

	// Token: 0x04003426 RID: 13350
	public Transform Door;

	// Token: 0x04003427 RID: 13351
	public AudioSource FireAudio;

	// Token: 0x04003428 RID: 13352
	public AudioSource MyAudio;

	// Token: 0x04003429 RID: 13353
	public AudioClip SwingOpen;

	// Token: 0x0400342A RID: 13354
	public AudioClip PowerDown;

	// Token: 0x0400342B RID: 13355
	public UISprite MySprite;

	// Token: 0x0400342C RID: 13356
	public Renderer Darkness;

	// Token: 0x0400342D RID: 13357
	public bool ServedPurpose;

	// Token: 0x0400342E RID: 13358
	public bool Eighties;

	// Token: 0x0400342F RID: 13359
	public bool OpenDoor;

	// Token: 0x04003430 RID: 13360
	public bool FadeOut;

	// Token: 0x04003431 RID: 13361
	public bool Open;

	// Token: 0x04003432 RID: 13362
	public float TargetRotation = 5.5f;

	// Token: 0x04003433 RID: 13363
	public float MinimumDistance = 2f;

	// Token: 0x04003434 RID: 13364
	public float Rotation;

	// Token: 0x04003435 RID: 13365
	public float Alpha;

	// Token: 0x04003436 RID: 13366
	public float Speed;

	// Token: 0x04003437 RID: 13367
	public int BagsToBurn;

	// Token: 0x04003438 RID: 13368
	public int BagID;

	// Token: 0x04003439 RID: 13369
	public int ID;
}
