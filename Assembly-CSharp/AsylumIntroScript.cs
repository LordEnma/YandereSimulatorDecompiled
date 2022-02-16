using System;
using UnityEngine;
using UnityEngine.PostProcessing;

// Token: 0x020000D7 RID: 215
public class AsylumIntroScript : MonoBehaviour
{
	// Token: 0x060009EF RID: 2543 RVA: 0x000539EC File Offset: 0x00051BEC
	private void Start()
	{
		this.Profile.colorGrading.enabled = true;
		RenderSettings.ambientIntensity = 8f;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		base.transform.position = new Vector3(-21.7985f, 1f, -29f);
		base.transform.eulerAngles = new Vector3(0f, 180f, 0f);
		this.Yandere.transform.position = new Vector3(-21.7985f, 0f, -31f);
		this.Yandere.transform.eulerAngles = new Vector3(0f, 0f, 0f);
		Physics.SyncTransforms();
		this.SetVignetteBlack();
		this.UpdateDOF(4f);
		this.DOF = 4f;
		this.Alpha = 1f;
		this.Yandere.Start();
		this.SkipPanel.alpha = 0f;
		for (int i = 10 - DateGlobals.Week; i > 0; i--)
		{
			this.Bags[i].SetActive(false);
		}
	}

	// Token: 0x060009F0 RID: 2544 RVA: 0x00053B10 File Offset: 0x00051D10
	private void Update()
	{
		if (this.SkipPanel.enabled)
		{
			this.UpdateSkipPanel();
		}
		if (this.Phase == 0)
		{
			if (this.Alpha < 1f)
			{
				this.Yandere.transform.position = new Vector3(-22.1f, -3.965f, -34f);
				this.Yandere.transform.eulerAngles = new Vector3(0f, 0f, 0f);
				Physics.SyncTransforms();
			}
			this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime * 0.5f);
			this.Darkness.material.color = new Color(0f, 0f, 0f, this.Alpha);
			if (this.Alpha == 0f)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 1f)
				{
					this.Timer = 0f;
					this.Phase++;
					return;
				}
			}
		}
		else if (this.Phase == 1)
		{
			if (this.Timer == 0f)
			{
				this.Yandere.MyAnimation["f02_climbTrellis_00"].time = 7f;
				this.Yandere.MyAnimation.Play();
			}
			this.Timer += Time.deltaTime;
			if (this.Yandere.MyAnimation["f02_climbTrellis_00"].time > 15f)
			{
				this.Yandere.MyAnimation.Play("f02_idleShort_00");
				this.Yandere.transform.position = new Vector3(-21.7985f, 0.03203398f, -29f);
				base.transform.position = new Vector3(-21.3985f, 1.3320339f, -28.4f);
				base.transform.eulerAngles = new Vector3(0f, -135f, 0f);
				Physics.SyncTransforms();
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
			if (this.Speed > -1f)
			{
				this.Yandere.MyAnimation.CrossFade("f02_stealthIdle_00");
				this.Yandere.transform.position = new Vector3(-21.7985f, 0.03203398f, -29f);
				Physics.SyncTransforms();
			}
			if (this.Speed > 0f)
			{
				base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(-21.7985f, 1.547184f, -30.92219f), Time.deltaTime * this.Speed);
				this.Rotation = Vector3.Lerp(this.Rotation, new Vector3(15f, 0f, 0f), Time.deltaTime * this.Speed * 2f);
				base.transform.eulerAngles = this.Rotation;
				this.DOF = Mathf.MoveTowards(this.DOF, 2f, Time.deltaTime * this.Speed);
				this.UpdateDOF(this.DOF);
				if (this.Speed > 4f)
				{
					this.Darkness.material.color = new Color(0f, 0f, 0f, 0f);
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

	// Token: 0x060009F1 RID: 2545 RVA: 0x00053F04 File Offset: 0x00052104
	private void UpdateDOF(float Value)
	{
		DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings;
		settings.focusDistance = Value;
		settings.aperture = 5.6f;
		this.Profile.depthOfField.settings = settings;
	}

	// Token: 0x060009F2 RID: 2546 RVA: 0x00053F48 File Offset: 0x00052148
	public void SetVignetteBlack()
	{
		VignetteModel.Settings settings = this.Profile.vignette.settings;
		settings.color = new Color(0f, 0f, 0f, 1f);
		settings.intensity = 0.45f;
		settings.smoothness = 0.2f;
		settings.roundness = 1f;
		this.Profile.vignette.settings = settings;
	}

	// Token: 0x060009F3 RID: 2547 RVA: 0x00053FBC File Offset: 0x000521BC
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

	// Token: 0x04000A8C RID: 2700
	public PostProcessingProfile Profile;

	// Token: 0x04000A8D RID: 2701
	public StalkerYandereScript Yandere;

	// Token: 0x04000A8E RID: 2702
	public RPG_Camera RPGCamera;

	// Token: 0x04000A8F RID: 2703
	public Renderer Darkness;

	// Token: 0x04000A90 RID: 2704
	public Vector3 Rotation;

	// Token: 0x04000A91 RID: 2705
	public float Alpha;

	// Token: 0x04000A92 RID: 2706
	public float Speed;

	// Token: 0x04000A93 RID: 2707
	public float Timer;

	// Token: 0x04000A94 RID: 2708
	public float DOF;

	// Token: 0x04000A95 RID: 2709
	public int Phase;

	// Token: 0x04000A96 RID: 2710
	public GameObject[] Bags;

	// Token: 0x04000A97 RID: 2711
	public UIPanel SkipPanel;

	// Token: 0x04000A98 RID: 2712
	public UISprite SkipCircle;

	// Token: 0x04000A99 RID: 2713
	private float SkipTimer;
}
