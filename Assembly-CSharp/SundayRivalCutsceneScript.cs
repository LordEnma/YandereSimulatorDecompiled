using System;
using UnityEngine;

// Token: 0x0200045D RID: 1117
public class SundayRivalCutsceneScript : MonoBehaviour
{
	// Token: 0x06001E52 RID: 7762 RVA: 0x001A0F60 File Offset: 0x0019F160
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

	// Token: 0x06001E53 RID: 7763 RVA: 0x001A1224 File Offset: 0x0019F424
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

	// Token: 0x04003E28 RID: 15912
	public HomeSenpaiShrineScript HomeSenpaiShrine;

	// Token: 0x04003E29 RID: 15913
	public HomeDarknessScript HomeDarkness;

	// Token: 0x04003E2A RID: 15914
	public HomeYandereScript HomeYandere;

	// Token: 0x04003E2B RID: 15915
	public PhoneScript Phone;

	// Token: 0x04003E2C RID: 15916
	public GameObject InfoTextConvo;

	// Token: 0x04003E2D RID: 15917
	public GameObject InfoTextPanel;

	// Token: 0x04003E2E RID: 15918
	public AudioClip YoureSafeNow;

	// Token: 0x04003E2F RID: 15919
	public AudioSource Vibration;

	// Token: 0x04003E30 RID: 15920
	public GameObject GrabbyHand;

	// Token: 0x04003E31 RID: 15921
	public GameObject HomeClock;

	// Token: 0x04003E32 RID: 15922
	public UISprite SkipCircle;

	// Token: 0x04003E33 RID: 15923
	public UIPanel SkipPanel;

	// Token: 0x04003E34 RID: 15924
	public float Alpha = 1f;

	// Token: 0x04003E35 RID: 15925
	public float Speed;

	// Token: 0x04003E36 RID: 15926
	public float Timer;

	// Token: 0x04003E37 RID: 15927
	public float X;

	// Token: 0x04003E38 RID: 15928
	public float Y;

	// Token: 0x04003E39 RID: 15929
	public float Z;

	// Token: 0x04003E3A RID: 15930
	public int Phase;

	// Token: 0x04003E3B RID: 15931
	public bool RestoreDOF;
}
