using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class DreamYandereScript : MonoBehaviour
{
	public CharacterController MyController;

	public PostProcessingProfile Profile;

	public InputDeviceScript InputDevice;

	public Transform Environment;

	public Transform ShardParent;

	public Transform MainCamera;

	public GameObject AyanoHair;

	public GameObject RyobaHair;

	public UISprite Darkness;

	public Animation MyAnim;

	public AudioSource BGM;

	public UISprite Circle;

	public string IdleAnim;

	public string WalkAnim;

	public string RunAnim;

	public float Timer;

	public bool WakeUp;

	public bool Skip;

	public int DreamID;

	public Animation[] AnimNPC;

	public bool invertAxisY;

	public float sensitivity;

	public float mouseSpeed = 8f;

	public float rotation;

	public Transform OniHead;

	public float X;

	public float Y;

	public float Z;

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		if (!GameGlobals.Eighties)
		{
			RyobaHair.SetActive(value: false);
		}
		else
		{
			AyanoHair.SetActive(value: false);
		}
		Darkness.alpha = 1f;
		Time.timeScale = 1f;
		BGM.volume = 0f;
		if (Environment != null && !Environment.gameObject.activeInHierarchy)
		{
			Environment.gameObject.SetActive(value: true);
		}
		if (DreamID == 2)
		{
			AnimNPC[0]["BegForLife"].speed = 0.1f;
			AnimNPC[1]["walkConfident_00"].speed = 0.95f;
			AnimNPC[12]["walkConfident_00"].speed = 0.95f;
			for (int i = 2; i < 12; i++)
			{
				AnimNPC[i]["f02_suspicious_00"].speed = Random.Range(0.9f, 1.1f);
			}
			for (int i = 13; i < 23; i++)
			{
				AnimNPC[i]["f02_walkCouncilGrace_00"].speed = Random.Range(0.9f, 1.1f);
			}
		}
		if (Skip)
		{
			Timer = 1f;
			Darkness.alpha = 0f;
		}
		invertAxisY = OptionGlobals.InvertAxisY;
		sensitivity = OptionGlobals.Sensitivity;
		UpdateDOF(2f, 5.6f);
	}

	private void Update()
	{
		if (!WakeUp)
		{
			Timer += Time.deltaTime;
			if (Timer > 1f)
			{
				Environment.position = new Vector3(base.transform.position.x, 0f, base.transform.position.z);
				Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime * 0.1f);
				UpdateMovement();
				if (Input.GetButton(InputNames.Xbox_X))
				{
					Circle.fillAmount += Time.deltaTime;
					if (Circle.fillAmount == 1f)
					{
						WakeUp = true;
					}
				}
				else
				{
					Circle.fillAmount = 0f;
				}
				if (Input.GetKeyDown("-"))
				{
					Time.timeScale -= 1f;
					if (Time.timeScale == 0f)
					{
						Time.timeScale = 1f;
					}
				}
				if (Input.GetKeyDown("="))
				{
					Time.timeScale += 1f;
				}
			}
		}
		else
		{
			MyAnim.CrossFade(IdleAnim);
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 1f, Time.deltaTime * 0.5f);
			if (Darkness.alpha > 0.999f)
			{
				SceneManager.LoadScene("CalendarScene");
			}
		}
		BGM.volume = 1f - Darkness.alpha;
		string axisName = "Mouse Y";
		if (InputDevice.Type == InputDeviceType.Gamepad)
		{
			axisName = InputNames.Xbox_JoyY;
		}
		float num = 0f;
		num = ((Input.GetAxis(axisName) < 0f) ? (invertAxisY ? (num + Input.GetAxis(axisName) * mouseSpeed * (Time.deltaTime / Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * sensitivity * 10f) : (num - Input.GetAxis(axisName) * mouseSpeed * (Time.deltaTime / Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * sensitivity * 10f)) : (invertAxisY ? (num + Input.GetAxis(axisName) * mouseSpeed * (Time.deltaTime / Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * sensitivity * 10f) : (num - Input.GetAxis(axisName) * mouseSpeed * (Time.deltaTime / Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * sensitivity * 10f)));
		rotation += num;
		if (rotation > 30f)
		{
			rotation = 30f;
		}
		else if (rotation < -15f)
		{
			rotation = -15f;
		}
		MainCamera.localEulerAngles = new Vector3(rotation, 0f, 0f);
	}

	private void LateUpdate()
	{
		if (DreamID == 2)
		{
			OniHead.LookAt(AnimNPC[0].transform.position);
			OniHead.eulerAngles += new Vector3(X, Y, Z);
		}
	}

	private void UpdateMovement()
	{
		MyController.Move(Physics.gravity * Time.deltaTime);
		float axis = Input.GetAxis("Vertical");
		float axis2 = Input.GetAxis("Horizontal");
		Vector3 vector = base.transform.TransformDirection(Vector3.forward);
		vector.y = 0f;
		vector = vector.normalized;
		Vector3 vector2 = new Vector3(vector.z, 0f, 0f - vector.x);
		Vector3 vector3 = axis2 * vector2 + axis * vector;
		if (Mathf.Abs(axis) > 0.5f || Mathf.Abs(axis2) > 0.5f)
		{
			MyAnim[WalkAnim].speed = Mathf.Abs(axis) + Mathf.Abs(axis2);
			if (MyAnim[WalkAnim].speed > 1f)
			{
				MyAnim[WalkAnim].speed = 1f;
			}
			if (Input.GetButton(InputNames.Xbox_LB))
			{
				MyController.Move(vector3 * Time.deltaTime * 5f);
				MyAnim.CrossFade(RunAnim);
			}
			else
			{
				MyController.Move(vector3 * Time.deltaTime);
				MyAnim.CrossFade(WalkAnim);
			}
		}
		else
		{
			MyAnim.CrossFade(IdleAnim);
		}
		string axisName = "Mouse X";
		if (InputDevice.Type == InputDeviceType.Gamepad)
		{
			axisName = InputNames.Xbox_JoyX;
		}
		float num = Input.GetAxis(axisName) * (float)OptionGlobals.Sensitivity;
		if (OptionGlobals.InvertAxisX)
		{
			num *= -1f;
		}
		if (num != 0f)
		{
			base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, base.transform.eulerAngles.y + num * 36f * Time.deltaTime, base.transform.eulerAngles.z);
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
}
