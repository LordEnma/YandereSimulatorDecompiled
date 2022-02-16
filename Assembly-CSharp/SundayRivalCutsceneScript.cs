using System;
using UnityEngine;

// Token: 0x02000461 RID: 1121
public class SundayRivalCutsceneScript : MonoBehaviour
{
	// Token: 0x06001E6E RID: 7790 RVA: 0x001A382C File Offset: 0x001A1A2C
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

	// Token: 0x06001E6F RID: 7791 RVA: 0x001A3AF0 File Offset: 0x001A1CF0
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

	// Token: 0x04003E63 RID: 15971
	public HomeSenpaiShrineScript HomeSenpaiShrine;

	// Token: 0x04003E64 RID: 15972
	public HomeDarknessScript HomeDarkness;

	// Token: 0x04003E65 RID: 15973
	public HomeYandereScript HomeYandere;

	// Token: 0x04003E66 RID: 15974
	public PhoneScript Phone;

	// Token: 0x04003E67 RID: 15975
	public GameObject InfoTextConvo;

	// Token: 0x04003E68 RID: 15976
	public GameObject InfoTextPanel;

	// Token: 0x04003E69 RID: 15977
	public AudioClip YoureSafeNow;

	// Token: 0x04003E6A RID: 15978
	public AudioSource Vibration;

	// Token: 0x04003E6B RID: 15979
	public GameObject GrabbyHand;

	// Token: 0x04003E6C RID: 15980
	public GameObject HomeClock;

	// Token: 0x04003E6D RID: 15981
	public UISprite SkipCircle;

	// Token: 0x04003E6E RID: 15982
	public UIPanel SkipPanel;

	// Token: 0x04003E6F RID: 15983
	public float Alpha = 1f;

	// Token: 0x04003E70 RID: 15984
	public float Speed;

	// Token: 0x04003E71 RID: 15985
	public float Timer;

	// Token: 0x04003E72 RID: 15986
	public float X;

	// Token: 0x04003E73 RID: 15987
	public float Y;

	// Token: 0x04003E74 RID: 15988
	public float Z;

	// Token: 0x04003E75 RID: 15989
	public int Phase;

	// Token: 0x04003E76 RID: 15990
	public bool RestoreDOF;
}
