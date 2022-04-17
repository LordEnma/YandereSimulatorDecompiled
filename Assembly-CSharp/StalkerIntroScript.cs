using System;
using UnityEngine;
using UnityEngine.PostProcessing;

// Token: 0x02000443 RID: 1091
public class StalkerIntroScript : MonoBehaviour
{
	// Token: 0x06001D15 RID: 7445 RVA: 0x0015AAB0 File Offset: 0x00158CB0
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

	// Token: 0x06001D16 RID: 7446 RVA: 0x0015AB94 File Offset: 0x00158D94
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
					this.Yandere.VtuberCheck();
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

	// Token: 0x06001D17 RID: 7447 RVA: 0x0015AF64 File Offset: 0x00159164
	private void UpdateDOF(float Value)
	{
		DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings;
		settings.focusDistance = Value;
		settings.aperture = 5.6f;
		this.Profile.depthOfField.settings = settings;
	}

	// Token: 0x06001D18 RID: 7448 RVA: 0x0015AFA8 File Offset: 0x001591A8
	public void SetVignetteBlack()
	{
		VignetteModel.Settings settings = this.Profile.vignette.settings;
		settings.color = new Color(0f, 0f, 0f, 1f);
		settings.intensity = 0.45f;
		settings.smoothness = 0.2f;
		settings.roundness = 1f;
		this.Profile.vignette.settings = settings;
	}

	// Token: 0x06001D19 RID: 7449 RVA: 0x0015B01C File Offset: 0x0015921C
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

	// Token: 0x040034A5 RID: 13477
	public PostProcessingProfile Profile;

	// Token: 0x040034A6 RID: 13478
	public StalkerYandereScript Yandere;

	// Token: 0x040034A7 RID: 13479
	public RPG_Camera RPGCamera;

	// Token: 0x040034A8 RID: 13480
	public Transform CameraFocus;

	// Token: 0x040034A9 RID: 13481
	public Transform Moon;

	// Token: 0x040034AA RID: 13482
	public Renderer Darkness;

	// Token: 0x040034AB RID: 13483
	public float Alpha;

	// Token: 0x040034AC RID: 13484
	public float Speed;

	// Token: 0x040034AD RID: 13485
	public float Timer;

	// Token: 0x040034AE RID: 13486
	public float DOF;

	// Token: 0x040034AF RID: 13487
	public int Phase;

	// Token: 0x040034B0 RID: 13488
	public GameObject[] Neighborhood;

	// Token: 0x040034B1 RID: 13489
	public UIPanel SkipPanel;

	// Token: 0x040034B2 RID: 13490
	public UISprite SkipCircle;

	// Token: 0x040034B3 RID: 13491
	private float SkipTimer;
}
