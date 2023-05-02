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

	public float Alpha;

	public float Speed;

	public float Timer;

	public float DOF;

	public int Phase;

	public GameObject[] Neighborhood;

	public UIPanel SkipPanel;

	public UISprite SkipCircle;

	private float SkipTimer;

	private void Start()
	{
		if (Yandere.InstructionLabel != null)
		{
			Yandere.InstructionLabel.alpha = 0f;
		}
		Profile.colorGrading.enabled = true;
		RenderSettings.ambientIntensity = 8f;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		base.transform.position = new Vector3(12.5f, 5f, 13f);
		base.transform.LookAt(Moon);
		CameraFocus.parent = base.transform;
		CameraFocus.localPosition = new Vector3(0f, 0f, 100f);
		CameraFocus.parent = null;
		SetVignetteBlack();
		UpdateDOF(4f);
		DOF = 4f;
		Alpha = 1f;
		Yandere.Start();
		SkipPanel.alpha = 0f;
	}

	private void Update()
	{
		if (SkipPanel.enabled)
		{
			UpdateSkipPanel();
		}
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
			UpdateDOF(DOF);
			base.transform.LookAt(CameraFocus);
			if (Yandere.MyAnimation["f02_jumpOverWall_00"].time > 13f)
			{
				Yandere.transform.position = new Vector3(13.15f, 0f, 13f);
				base.transform.position = new Vector3(12.75f, 1.3f, 12.4f);
				base.transform.eulerAngles = new Vector3(0f, 45f, 0f);
				DOF = 0.5f;
				UpdateDOF(DOF);
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
				UpdateDOF(DOF);
				if (Speed > 4f)
				{
					DOF = 2f;
					UpdateDOF(DOF);
					SkipPanel.enabled = false;
					RPGCamera.enabled = true;
					Yandere.enabled = true;
					Phase++;
				}
			}
		}
	}

	private void UpdateDOF(float Value)
	{
		DepthOfFieldModel.Settings settings = Profile.depthOfField.settings;
		settings.focusDistance = Value;
		settings.aperture = 5.6f;
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
				Phase = 2;
				Speed = 100f;
				Yandere.MyAnimation.Play("f02_stealthIdle_00");
			}
		}
		else
		{
			SkipCircle.fillAmount = 1f;
		}
	}
}
