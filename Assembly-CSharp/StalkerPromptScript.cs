using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000439 RID: 1081
public class StalkerPromptScript : MonoBehaviour
{
	// Token: 0x06001CD1 RID: 7377 RVA: 0x00154DC4 File Offset: 0x00152FC4
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

	// Token: 0x06001CD2 RID: 7378 RVA: 0x00154E40 File Offset: 0x00153040
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

	// Token: 0x06001CD3 RID: 7379 RVA: 0x00155668 File Offset: 0x00153868
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

	// Token: 0x06001CD4 RID: 7380 RVA: 0x00155740 File Offset: 0x00153940
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

	// Token: 0x040033E2 RID: 13282
	public StalkerPromptScript ExitPrompt;

	// Token: 0x040033E3 RID: 13283
	public FamilyVoiceScript FatherVoice;

	// Token: 0x040033E4 RID: 13284
	public StalkerYandereScript Yandere;

	// Token: 0x040033E5 RID: 13285
	public SmoothLookAtScript Cat;

	// Token: 0x040033E6 RID: 13286
	public StalkerScript Stalker;

	// Token: 0x040033E7 RID: 13287
	public GameObject DomesticDispute;

	// Token: 0x040033E8 RID: 13288
	public GameObject StairBlocker;

	// Token: 0x040033E9 RID: 13289
	public GameObject CatPrompt;

	// Token: 0x040033EA RID: 13290
	public GameObject FrontDoor;

	// Token: 0x040033EB RID: 13291
	public GameObject Button;

	// Token: 0x040033EC RID: 13292
	public GameObject Father;

	// Token: 0x040033ED RID: 13293
	public GameObject Mother;

	// Token: 0x040033EE RID: 13294
	public GameObject Lights;

	// Token: 0x040033EF RID: 13295
	public GameObject Fire;

	// Token: 0x040033F0 RID: 13296
	public UILabel BagsToBurnLabel;

	// Token: 0x040033F1 RID: 13297
	public UILabel Label;

	// Token: 0x040033F2 RID: 13298
	public Transform KitchenDoor;

	// Token: 0x040033F3 RID: 13299
	public Transform CatCage;

	// Token: 0x040033F4 RID: 13300
	public Transform Door;

	// Token: 0x040033F5 RID: 13301
	public AudioSource FireAudio;

	// Token: 0x040033F6 RID: 13302
	public AudioSource MyAudio;

	// Token: 0x040033F7 RID: 13303
	public AudioClip SwingOpen;

	// Token: 0x040033F8 RID: 13304
	public AudioClip PowerDown;

	// Token: 0x040033F9 RID: 13305
	public UISprite MySprite;

	// Token: 0x040033FA RID: 13306
	public Renderer Darkness;

	// Token: 0x040033FB RID: 13307
	public bool ServedPurpose;

	// Token: 0x040033FC RID: 13308
	public bool Eighties;

	// Token: 0x040033FD RID: 13309
	public bool OpenDoor;

	// Token: 0x040033FE RID: 13310
	public bool FadeOut;

	// Token: 0x040033FF RID: 13311
	public bool Open;

	// Token: 0x04003400 RID: 13312
	public float TargetRotation = 5.5f;

	// Token: 0x04003401 RID: 13313
	public float MinimumDistance = 2f;

	// Token: 0x04003402 RID: 13314
	public float Rotation;

	// Token: 0x04003403 RID: 13315
	public float Alpha;

	// Token: 0x04003404 RID: 13316
	public float Speed;

	// Token: 0x04003405 RID: 13317
	public int BagsToBurn;

	// Token: 0x04003406 RID: 13318
	public int BagID;

	// Token: 0x04003407 RID: 13319
	public int ID;
}
