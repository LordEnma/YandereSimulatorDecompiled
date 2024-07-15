using UnityEngine;
using UnityEngine.PostProcessing;

public class AsylumIntroScript : MonoBehaviour
{
	public PostProcessingProfile Profile;

	public StalkerYandereScript Yandere;

	public RPG_Camera RPGCamera;

	public Renderer Darkness;

	public Vector3 Rotation;

	public float Alpha;

	public float Speed;

	public float Timer;

	public float DOF;

	public int Phase;

	public GameObject[] Bags;

	public UIPanel SkipPanel;

	public UISprite SkipCircle;

	private float SkipTimer;

	private void Start()
	{
		Profile.colorGrading.enabled = true;
		RenderSettings.ambientIntensity = 8f;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		base.transform.position = new Vector3(-21.7985f, 1f, -29f);
		base.transform.eulerAngles = new Vector3(0f, 180f, 0f);
		Yandere.transform.position = new Vector3(-21.7985f, 0f, -31f);
		Yandere.transform.eulerAngles = new Vector3(0f, 0f, 0f);
		Physics.SyncTransforms();
		SetVignetteBlack();
		UpdateDOF(4f);
		DOF = 4f;
		Alpha = 1f;
		Yandere.Start();
		SkipPanel.alpha = 0f;
		for (int num = 10 - DateGlobals.Week; num > 0; num--)
		{
			Bags[num].SetActive(value: false);
		}
	}

	private void Update()
	{
		if (SkipPanel.enabled)
		{
			UpdateSkipPanel();
		}
		if (Phase == 0)
		{
			if (Alpha < 1f)
			{
				Yandere.transform.position = new Vector3(-22.1f, -3.965f, -34f);
				Yandere.transform.eulerAngles = new Vector3(0f, 0f, 0f);
				Physics.SyncTransforms();
			}
			Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime * 0.5f);
			Darkness.material.color = new Color(0f, 0f, 0f, Alpha);
			if (Alpha == 0f)
			{
				Timer += Time.deltaTime;
				if (Timer > 1f)
				{
					Yandere.VtuberCheck();
					Timer = 0f;
					Phase++;
				}
			}
		}
		else if (Phase == 1)
		{
			if (Timer == 0f)
			{
				Yandere.MyAnimation["f02_climbTrellis_00"].time = 7f;
				Yandere.MyAnimation.Play();
			}
			Timer += Time.deltaTime;
			if (Yandere.MyAnimation["f02_climbTrellis_00"].time > 15f)
			{
				Yandere.MyAnimation.Play("f02_idleShort_00");
				Yandere.transform.position = new Vector3(-21.7985f, 0.03203398f, -29f);
				base.transform.position = new Vector3(-21.3985f, 1.3320339f, -28.4f);
				base.transform.eulerAngles = new Vector3(0f, -135f, 0f);
				Physics.SyncTransforms();
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
			if (Speed > -1f)
			{
				Yandere.MyAnimation.CrossFade("f02_stealthIdle_00");
				Yandere.transform.position = new Vector3(-21.7985f, 0.03203398f, -29f);
				Physics.SyncTransforms();
			}
			if (Speed > 0f)
			{
				base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(-21.7985f, 1.547184f, -30.92219f), Time.deltaTime * Speed);
				Rotation = Vector3.Lerp(Rotation, new Vector3(15f, 0f, 0f), Time.deltaTime * Speed * 2f);
				base.transform.eulerAngles = Rotation;
				DOF = Mathf.MoveTowards(DOF, 2f, Time.deltaTime * Speed);
				UpdateDOF(DOF);
				if (Speed > 4f)
				{
					Darkness.material.color = new Color(0f, 0f, 0f, 0f);
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
		UpdateAperture(5.6f);
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
