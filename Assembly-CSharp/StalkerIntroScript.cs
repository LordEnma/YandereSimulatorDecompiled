using UnityEngine;
using UnityEngine.PostProcessing;

public class StalkerIntroScript : MonoBehaviour
{
	public PostProcessingProfile Profile;

	public StalkerYandereScript Yandere;

	public RPG_Camera RPGCamera;

	public Transform CameraFocus;

	public Transform Moon;

	public Renderer Darkness;

	public bool BurazaTown;

	public float RotationX;

	public float RotationY;

	public float Aperture;

	public float Alpha;

	public float Speed;

	public float Timer;

	public float DOF;

	public int Phase;

	public int Week;

	public GameObject[] Neighborhood;

	public Animation Baker;

	public UIPanel SkipPanel;

	public UISprite SkipCircle;

	private float SkipTimer;

	private void Start()
	{
		if (Baker != null)
		{
			GameGlobals.Eighties = false;
			DateGlobals.Week = 2;
		}
		Time.timeScale = 1f;
		if (Yandere.InstructionLabel != null)
		{
			Yandere.InstructionLabel.alpha = 0f;
		}
		Profile.colorGrading.enabled = true;
		RenderSettings.ambientIntensity = 8f;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		if (Week == 1)
		{
			base.transform.position = new Vector3(12.5f, 5f, 13f);
			base.transform.LookAt(Moon);
			CameraFocus.parent = base.transform;
			CameraFocus.localPosition = new Vector3(0f, 0f, 100f);
			CameraFocus.parent = null;
			DOF = 4f;
		}
		else if (Week == 2)
		{
			base.transform.position = new Vector3(-14.6f, 9.6f, 1.97f);
			base.transform.eulerAngles = new Vector3(0f, 90f, 0f);
			DOF = 1.5f;
		}
		SetVignetteBlack();
		UpdateDOF(DOF, 5.6f);
		Alpha = 1f;
		Darkness.material.color = new Color(0f, 0f, 0f, Alpha);
		Yandere.Start();
		SkipPanel.alpha = 0f;
	}

	private void Update()
	{
		if (SkipPanel.enabled)
		{
			UpdateSkipPanel();
		}
		if (BurazaTown)
		{
			DOF = 2f;
			UpdateDOF(DOF, 5.6f);
			Darkness.material.color = new Color(0f, 0f, 0f, 0f);
			SkipPanel.enabled = false;
			RPGCamera.enabled = true;
			Yandere.enabled = true;
			base.enabled = false;
		}
		else if (Week == 1)
		{
			Moon.LookAt(base.transform);
			if (Phase == 0)
			{
				Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime * 0.5f);
				Darkness.material.color = new Color(0f, 0f, 0f, Alpha);
				if (Alpha == 0f)
				{
					Timer += Time.deltaTime;
					if (Timer > 2f)
					{
						Yandere.VtuberCheck();
						Phase++;
					}
				}
			}
			else if (Phase == 1)
			{
				if (Speed == 0f)
				{
					Yandere.MyAnimation.Play();
				}
				Speed += Time.deltaTime;
				base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(11.5f, 1f, 13f), Time.deltaTime * Speed);
				CameraFocus.position = Vector3.Lerp(CameraFocus.position, new Vector3(13.62132f, 1f, 15.12132f), Time.deltaTime * Speed);
				DOF = Mathf.MoveTowards(DOF, 1.4f, Time.deltaTime * Speed);
				UpdateDOF(DOF, 5.6f);
				base.transform.LookAt(CameraFocus);
				if (Yandere.MyAnimation["f02_jumpOverWall_00"].time > 13f)
				{
					Yandere.transform.position = new Vector3(13.15f, 0f, 13f);
					base.transform.position = new Vector3(12.75f, 1.3f, 12.4f);
					base.transform.eulerAngles = new Vector3(0f, 45f, 0f);
					DOF = 0.5f;
					UpdateDOF(DOF, 5.6f);
					Speed = -1f;
					Phase++;
				}
			}
			else
			{
				if (Phase != 2)
				{
					return;
				}
				Speed += Time.deltaTime;
				if (Speed > 0f)
				{
					Yandere.transform.position = new Vector3(13.15f, 0f, 13f);
					base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(13.15f, 1.51515f, 14.92272f), Time.deltaTime * Speed);
					base.transform.eulerAngles = Vector3.Lerp(base.transform.eulerAngles, new Vector3(15f, 180f, 0f), Time.deltaTime * Speed * 2f);
					DOF = Mathf.MoveTowards(DOF, 2f, Time.deltaTime * Speed);
					UpdateDOF(DOF, 5.6f);
					if (Speed > 4f)
					{
						DOF = 2f;
						UpdateDOF(DOF, 5.6f);
						SkipPanel.enabled = false;
						RPGCamera.enabled = true;
						Yandere.enabled = true;
						Phase++;
					}
				}
			}
		}
		else
		{
			if (Week != 2)
			{
				return;
			}
			if (Phase == 0)
			{
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
				Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime * 0.5f);
				Darkness.material.color = new Color(0f, 0f, 0f, Alpha);
				if (Alpha == 0f)
				{
					Timer += Time.deltaTime;
					if (Timer > 2f)
					{
						Yandere.MyAnimation.Play("f02_girlWalk_LookLeft_00");
						Yandere.MyAnimation.transform.localScale = new Vector3(-1f, 1f, 1f);
						Yandere.VtuberCheck();
						Phase++;
					}
				}
				base.transform.position -= new Vector3(Time.deltaTime * 0.1f, 0f, 0f);
			}
			else if (Phase == 1)
			{
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
				Speed += Time.deltaTime * 0.1f;
				CameraFocus.position = Vector3.Lerp(CameraFocus.position, Yandere.Hips.position, Time.deltaTime * Speed);
				DOF = Mathf.MoveTowards(DOF, 2f, Time.deltaTime * Speed);
				UpdateDOF(DOF, 5.6f);
				base.transform.LookAt(CameraFocus);
				if (Yandere.MyAnimation["f02_girlWalk_LookLeft_00"].time > 5f)
				{
					Yandere.transform.position = new Vector3(-19f, 0f, -35f);
					base.transform.position = new Vector3(-18.5f, 1.3f, -34.5f);
					base.transform.eulerAngles = new Vector3(0f, -135f, 0f);
					RotationX = 0f;
					RotationY = -135f;
					DOF = 0.6f;
					Aperture = 16f;
					UpdateDOF(DOF, Aperture);
					Speed = -8f;
					Phase++;
				}
			}
			else
			{
				if (Phase != 2)
				{
					return;
				}
				Speed += Time.deltaTime;
				if (Speed > 0f)
				{
					Yandere.MyAnimation.CrossFade("f02_stealthIdle_00", 2f);
					RotationX = Mathf.Lerp(RotationX, 15f, Time.deltaTime * Speed);
					RotationY = Mathf.Lerp(RotationY, 0f, Time.deltaTime * Speed);
					base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(-19f, 1.51715f, -36.92219f), Time.deltaTime * Speed);
					base.transform.eulerAngles = new Vector3(RotationX, RotationY, 0f);
					DOF = Mathf.MoveTowards(DOF, 2f, Time.deltaTime * Speed);
					Aperture = Mathf.MoveTowards(Aperture, 5.6f, Time.deltaTime * Speed);
					UpdateDOF(DOF, Aperture);
					if (Speed > 5f)
					{
						DOF = 2f;
						UpdateDOF(DOF, 5.6f);
						SkipPanel.enabled = false;
						RPGCamera.enabled = true;
						Yandere.enabled = true;
						Phase++;
					}
				}
			}
		}
	}

	private void UpdateDOF(float Value, float Aperture)
	{
		DepthOfFieldModel.Settings settings = Profile.depthOfField.settings;
		settings.focusDistance = Value;
		Profile.depthOfField.settings = settings;
		UpdateAperture(Aperture);
	}

	public void UpdateAperture(float Aperture)
	{
		DepthOfFieldModel.Settings settings = Profile.depthOfField.settings;
		float num = (float)Screen.width / 1280f;
		settings.aperture = Aperture * num;
		settings.focalLength = 50f;
		Profile.depthOfField.settings = settings;
	}

	public void SetVignetteBlack()
	{
		VignetteModel.Settings settings = Profile.vignette.settings;
		settings.color = new Color(0f, 0f, 0f, 1f);
		settings.intensity = 0.45f;
		settings.smoothness = 0.2f;
		settings.roundness = 1f;
		Profile.vignette.settings = settings;
	}

	private void UpdateSkipPanel()
	{
		SkipTimer += Time.deltaTime;
		if (SkipTimer > 1f)
		{
			SkipPanel.alpha += Time.deltaTime;
		}
		if (Input.GetButton(InputNames.Xbox_X))
		{
			SkipPanel.alpha = 1f;
			SkipTimer = 0f;
			SkipCircle.fillAmount -= Time.deltaTime;
			if (SkipCircle.fillAmount == 0f)
			{
				Alpha = 0f;
				Phase = 2;
				Speed = 100f;
				Darkness.material.color = new Color(0f, 0f, 0f, Alpha);
				Yandere.MyAnimation.Play("f02_stealthIdle_00");
				_ = Week;
				_ = 2;
			}
		}
		else
		{
			SkipCircle.fillAmount = 1f;
		}
	}
}
