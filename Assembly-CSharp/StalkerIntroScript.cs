using System;
using UnityEngine;
using UnityEngine.PostProcessing;

// Token: 0x0200043C RID: 1084
public class StalkerIntroScript : MonoBehaviour
{
	// Token: 0x06001CDF RID: 7391 RVA: 0x00157448 File Offset: 0x00155648
	private void Start()
	{
		this.Profile.colorGrading.enabled = true;
		RenderSettings.ambientIntensity = 8f;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		base.transform.position = new Vector3(12.5f, 5f, 13f);
		base.transform.LookAt(this.Moon);
		this.CameraFocus.parent = base.transform;
		this.CameraFocus.localPosition = new Vector3(0f, 0f, 100f);
		this.CameraFocus.parent = null;
		this.SetVignetteBlack();
		this.UpdateDOF(4f);
		this.DOF = 4f;
		this.Alpha = 1f;
		this.Yandere.Start();
		this.SkipPanel.alpha = 0f;
	}

	// Token: 0x06001CE0 RID: 7392 RVA: 0x0015752C File Offset: 0x0015572C
	private void Update()
	{
		if (this.SkipPanel.enabled)
		{
			this.UpdateSkipPanel();
		}
		this.Moon.LookAt(base.transform);
		if (this.Phase == 0)
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime * 0.5f);
			this.Darkness.material.color = new Color(0f, 0f, 0f, this.Alpha);
			if (this.Alpha == 0f)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 2f)
				{
					this.Phase++;
					return;
				}
			}
		}
		else if (this.Phase == 1)
		{
			if (this.Speed == 0f)
			{
				this.Yandere.MyAnimation.Play();
			}
			this.Speed += Time.deltaTime;
			base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(11.5f, 1f, 13f), Time.deltaTime * this.Speed);
			this.CameraFocus.position = Vector3.Lerp(this.CameraFocus.position, new Vector3(13.62132f, 1f, 15.12132f), Time.deltaTime * this.Speed);
			this.DOF = Mathf.MoveTowards(this.DOF, 1.4f, Time.deltaTime * this.Speed);
			this.UpdateDOF(this.DOF);
			base.transform.LookAt(this.CameraFocus);
			if (this.Yandere.MyAnimation["f02_jumpOverWall_00"].time > 13f)
			{
				this.Yandere.transform.position = new Vector3(13.15f, 0f, 13f);
				base.transform.position = new Vector3(12.75f, 1.3f, 12.4f);
				base.transform.eulerAngles = new Vector3(0f, 45f, 0f);
				this.DOF = 0.5f;
				this.UpdateDOF(this.DOF);
				this.Speed = -1f;
				this.Phase++;
				return;
			}
		}
		else if (this.Phase == 2)
		{
			this.Speed += Time.deltaTime;
			if (this.Speed > 0f)
			{
				this.Yandere.transform.position = new Vector3(13.15f, 0f, 13f);
				base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(13.15f, 1.51515f, 14.92272f), Time.deltaTime * this.Speed);
				base.transform.eulerAngles = Vector3.Lerp(base.transform.eulerAngles, new Vector3(15f, 180f, 0f), Time.deltaTime * this.Speed * 2f);
				this.DOF = Mathf.MoveTowards(this.DOF, 2f, Time.deltaTime * this.Speed);
				this.UpdateDOF(this.DOF);
				if (this.Speed > 4f)
				{
					this.DOF = 2f;
					this.UpdateDOF(this.DOF);
					this.SkipPanel.enabled = false;
					this.RPGCamera.enabled = true;
					this.Yandere.enabled = true;
					this.Phase++;
				}
			}
		}
	}

	// Token: 0x06001CE1 RID: 7393 RVA: 0x001578F0 File Offset: 0x00155AF0
	private void UpdateDOF(float Value)
	{
		DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings;
		settings.focusDistance = Value;
		settings.aperture = 5.6f;
		this.Profile.depthOfField.settings = settings;
	}

	// Token: 0x06001CE2 RID: 7394 RVA: 0x00157934 File Offset: 0x00155B34
	public void SetVignetteBlack()
	{
		VignetteModel.Settings settings = this.Profile.vignette.settings;
		settings.color = new Color(0f, 0f, 0f, 1f);
		settings.intensity = 0.45f;
		settings.smoothness = 0.2f;
		settings.roundness = 1f;
		this.Profile.vignette.settings = settings;
	}

	// Token: 0x06001CE3 RID: 7395 RVA: 0x001579A8 File Offset: 0x00155BA8
	private void UpdateSkipPanel()
	{
		this.SkipTimer += Time.deltaTime;
		if (this.SkipTimer > 1f)
		{
			this.SkipPanel.alpha += Time.deltaTime;
		}
		if (Input.GetButton("X"))
		{
			this.SkipPanel.alpha = 1f;
			this.SkipTimer = 0f;
			this.SkipCircle.fillAmount -= Time.deltaTime;
			if (this.SkipCircle.fillAmount == 0f)
			{
				this.Phase = 2;
				this.Speed = 100f;
				this.Yandere.MyAnimation.Play("f02_stealthIdle_00");
				return;
			}
		}
		else
		{
			this.SkipCircle.fillAmount = 1f;
		}
	}

	// Token: 0x04003417 RID: 13335
	public PostProcessingProfile Profile;

	// Token: 0x04003418 RID: 13336
	public StalkerYandereScript Yandere;

	// Token: 0x04003419 RID: 13337
	public RPG_Camera RPGCamera;

	// Token: 0x0400341A RID: 13338
	public Transform CameraFocus;

	// Token: 0x0400341B RID: 13339
	public Transform Moon;

	// Token: 0x0400341C RID: 13340
	public Renderer Darkness;

	// Token: 0x0400341D RID: 13341
	public float Alpha;

	// Token: 0x0400341E RID: 13342
	public float Speed;

	// Token: 0x0400341F RID: 13343
	public float Timer;

	// Token: 0x04003420 RID: 13344
	public float DOF;

	// Token: 0x04003421 RID: 13345
	public int Phase;

	// Token: 0x04003422 RID: 13346
	public GameObject[] Neighborhood;

	// Token: 0x04003423 RID: 13347
	public UIPanel SkipPanel;

	// Token: 0x04003424 RID: 13348
	public UISprite SkipCircle;

	// Token: 0x04003425 RID: 13349
	private float SkipTimer;
}
