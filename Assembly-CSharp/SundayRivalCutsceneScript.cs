using System;
using UnityEngine;

// Token: 0x02000462 RID: 1122
public class SundayRivalCutsceneScript : MonoBehaviour
{
	// Token: 0x06001E77 RID: 7799 RVA: 0x001A4368 File Offset: 0x001A2568
	private void Start()
	{
		if (!GameGlobals.Eighties && DateGlobals.Weekday == DayOfWeek.Sunday)
		{
			this.HomeSenpaiShrine.Start();
			this.HomeYandere.HomeDarkness.color = new Color(0f, 0f, 0f, 1f);
			this.HomeDarkness.enabled = false;
			this.Alpha = 1f;
			this.InfoTextConvo.gameObject.SetActive(true);
			this.Vibration.gameObject.SetActive(true);
			this.HomeYandere.Start();
			this.HomeYandere.HomeCamera.Start();
			this.HomeClock.SetActive(false);
			this.HomeYandere.enabled = false;
			this.HomeYandere.HomeCamera.enabled = false;
			this.HomeYandere.HomeCamera.RoomJukebox.enabled = false;
			this.HomeYandere.HomeCamera.HomeSenpaiShrine.enabled = false;
			UnityEngine.Object.Destroy(this.HomeYandere.HomeCamera.PauseScreen.gameObject);
			this.HomeYandere.HomeCamera.HomeSenpaiShrine.RightDoor.localEulerAngles = new Vector3(this.HomeYandere.HomeCamera.HomeSenpaiShrine.RightDoor.localEulerAngles.x, 135f, this.HomeYandere.HomeCamera.HomeSenpaiShrine.RightDoor.localEulerAngles.z);
			this.HomeYandere.HomeCamera.HomeSenpaiShrine.LeftDoor.localEulerAngles = new Vector3(this.HomeYandere.HomeCamera.HomeSenpaiShrine.LeftDoor.localEulerAngles.x, -135f, this.HomeYandere.HomeCamera.HomeSenpaiShrine.LeftDoor.localEulerAngles.z);
			this.HomeYandere.transform.position = new Vector3(-1.655f, 0f, 1.93f);
			this.HomeYandere.transform.eulerAngles = new Vector3(0f, -45f, 0f);
			this.HomeYandere.HomeCamera.transform.position = new Vector3(-1.905f, 1.48f, 2.15f);
			this.HomeYandere.HomeCamera.transform.eulerAngles = new Vector3(0f, -22.5f, 0f);
			if (this.HomeYandere.HomeCamera.Profile.depthOfField.enabled)
			{
				this.RestoreDOF = true;
			}
			this.HomeYandere.HomeCamera.Profile.depthOfField.enabled = false;
			return;
		}
		base.gameObject.SetActive(false);
	}

	// Token: 0x06001E78 RID: 7800 RVA: 0x001A462C File Offset: 0x001A282C
	private void Update()
	{
		if (Input.GetKeyDown("="))
		{
			Time.timeScale += 1f;
		}
		if (this.SkipCircle.transform.parent.gameObject.activeInHierarchy)
		{
			if (Input.GetButton("X"))
			{
				this.SkipCircle.fillAmount -= Time.deltaTime;
				if (this.SkipCircle.fillAmount == 0f)
				{
					this.HomeYandere.HomeDarkness.color = new Color(0f, 0f, 0f, 0f);
					this.SkipCircle.transform.parent.gameObject.SetActive(false);
					this.Phase = 5;
					this.Timer = 0f;
				}
			}
			else
			{
				this.SkipCircle.fillAmount = 1f;
			}
		}
		if (this.Phase < 4)
		{
			this.HomeYandere.HomeCamera.transform.Translate(Vector3.forward * Time.deltaTime * -0.01f, Space.Self);
		}
		if (this.Phase == 0)
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime * 0.25f);
			this.HomeYandere.HomeDarkness.color = new Color(0f, 0f, 0f, this.Alpha);
			if (this.Alpha == 0f)
			{
				this.Phase++;
				return;
			}
		}
		else if (this.Phase == 1)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 1f)
			{
				this.HomeYandere.Character.GetComponent<Animation>().Play("f02_caressPhoto_00");
				this.Timer = 0f;
				this.Phase++;
				return;
			}
		}
		else if (this.Phase == 2)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 2.5f)
			{
				this.Vibration.PlayOneShot(this.YoureSafeNow);
				this.Timer = 0f;
				this.Phase++;
				return;
			}
		}
		else if (this.Phase == 3)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 3f && !this.Vibration.isPlaying)
			{
				this.Vibration.Play();
			}
			if (this.Timer > 4f)
			{
				this.X = 0f;
				this.Y = -22.5f;
				this.Z = 0f;
				this.Timer = 0f;
				this.Phase++;
				return;
			}
		}
		else if (this.Phase == 4)
		{
			this.Timer += Time.deltaTime;
			this.Speed += Time.deltaTime;
			this.HomeYandere.HomeCamera.transform.position = Vector3.Lerp(this.HomeYandere.HomeCamera.transform.position, new Vector3(-1.966666f, 1.07f, 1.9433333f), Time.deltaTime * this.Speed);
			this.X = Mathf.Lerp(this.X, 67.5f, Time.deltaTime * this.Speed);
			this.Y = Mathf.Lerp(this.Y, -22.5f, Time.deltaTime * this.Speed);
			this.Z = Mathf.Lerp(this.Z, 0f, Time.deltaTime * this.Speed);
			this.HomeYandere.HomeCamera.transform.eulerAngles = new Vector3(this.X, this.Y, this.Z);
			if (this.Timer > 2.5f)
			{
				this.GrabbyHand.SetActive(true);
			}
			if (this.Timer > 4.5f)
			{
				this.HomeYandere.HomeCamera.transform.position = new Vector3(-1.638197f, 1.4925f, 2f);
				this.HomeYandere.HomeCamera.transform.eulerAngles = new Vector3(0f, -45f, 0f);
				this.HomeYandere.gameObject.SetActive(false);
				this.GrabbyHand.SetActive(false);
				this.InfoTextConvo.SetActive(true);
				this.Timer = 0f;
				this.Phase++;
				return;
			}
		}
		else if (this.Phase == 5)
		{
			this.Timer += Time.deltaTime;
			this.InfoTextPanel.transform.localPosition = Vector3.Lerp(this.InfoTextPanel.transform.localPosition, new Vector3(0f, 0f, 1f), Time.deltaTime * 10f);
			if (this.Timer > 1f)
			{
				this.SkipPanel.alpha = 0f;
				if (this.RestoreDOF)
				{
					this.HomeYandere.HomeCamera.Profile.depthOfField.enabled = true;
				}
				this.Phone.enabled = true;
				Time.timeScale = 1f;
				this.Phase++;
			}
		}
	}

	// Token: 0x04003E73 RID: 15987
	public HomeSenpaiShrineScript HomeSenpaiShrine;

	// Token: 0x04003E74 RID: 15988
	public HomeDarknessScript HomeDarkness;

	// Token: 0x04003E75 RID: 15989
	public HomeYandereScript HomeYandere;

	// Token: 0x04003E76 RID: 15990
	public PhoneScript Phone;

	// Token: 0x04003E77 RID: 15991
	public GameObject InfoTextConvo;

	// Token: 0x04003E78 RID: 15992
	public GameObject InfoTextPanel;

	// Token: 0x04003E79 RID: 15993
	public AudioClip YoureSafeNow;

	// Token: 0x04003E7A RID: 15994
	public AudioSource Vibration;

	// Token: 0x04003E7B RID: 15995
	public GameObject GrabbyHand;

	// Token: 0x04003E7C RID: 15996
	public GameObject HomeClock;

	// Token: 0x04003E7D RID: 15997
	public UISprite SkipCircle;

	// Token: 0x04003E7E RID: 15998
	public UIPanel SkipPanel;

	// Token: 0x04003E7F RID: 15999
	public float Alpha = 1f;

	// Token: 0x04003E80 RID: 16000
	public float Speed;

	// Token: 0x04003E81 RID: 16001
	public float Timer;

	// Token: 0x04003E82 RID: 16002
	public float X;

	// Token: 0x04003E83 RID: 16003
	public float Y;

	// Token: 0x04003E84 RID: 16004
	public float Z;

	// Token: 0x04003E85 RID: 16005
	public int Phase;

	// Token: 0x04003E86 RID: 16006
	public bool RestoreDOF;
}
