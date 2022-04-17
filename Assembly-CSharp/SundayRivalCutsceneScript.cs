using System;
using UnityEngine;

// Token: 0x02000468 RID: 1128
public class SundayRivalCutsceneScript : MonoBehaviour
{
	// Token: 0x06001EA2 RID: 7842 RVA: 0x001A8320 File Offset: 0x001A6520
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

	// Token: 0x06001EA3 RID: 7843 RVA: 0x001A85E4 File Offset: 0x001A67E4
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

	// Token: 0x04003F12 RID: 16146
	public HomeSenpaiShrineScript HomeSenpaiShrine;

	// Token: 0x04003F13 RID: 16147
	public HomeDarknessScript HomeDarkness;

	// Token: 0x04003F14 RID: 16148
	public HomeYandereScript HomeYandere;

	// Token: 0x04003F15 RID: 16149
	public PhoneScript Phone;

	// Token: 0x04003F16 RID: 16150
	public GameObject InfoTextConvo;

	// Token: 0x04003F17 RID: 16151
	public GameObject InfoTextPanel;

	// Token: 0x04003F18 RID: 16152
	public AudioClip YoureSafeNow;

	// Token: 0x04003F19 RID: 16153
	public AudioSource Vibration;

	// Token: 0x04003F1A RID: 16154
	public GameObject GrabbyHand;

	// Token: 0x04003F1B RID: 16155
	public GameObject HomeClock;

	// Token: 0x04003F1C RID: 16156
	public UISprite SkipCircle;

	// Token: 0x04003F1D RID: 16157
	public UIPanel SkipPanel;

	// Token: 0x04003F1E RID: 16158
	public float Alpha = 1f;

	// Token: 0x04003F1F RID: 16159
	public float Speed;

	// Token: 0x04003F20 RID: 16160
	public float Timer;

	// Token: 0x04003F21 RID: 16161
	public float X;

	// Token: 0x04003F22 RID: 16162
	public float Y;

	// Token: 0x04003F23 RID: 16163
	public float Z;

	// Token: 0x04003F24 RID: 16164
	public int Phase;

	// Token: 0x04003F25 RID: 16165
	public bool RestoreDOF;
}
