using UnityEngine;

public class MapScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public InputDeviceScript InputDevice;

	public PauseScreenScript PauseScreen;

	public PromptBarScript PromptBar;

	public YandereScript Yandere;

	public GameObject Compass;

	public Transform YandereMapMarker;

	public Transform PortalMapMarker;

	public UILabel ElevationLabel;

	public UISprite Border;

	public Camera MyCamera;

	public float HorizontalLimit;

	public float VerticalLimit;

	public float X;

	public float Y;

	public float W;

	public float H;

	public bool Show;

	public Texture RyobaFace;

	public UILabel[] Labels;

	private void Start()
	{
		if (GameGlobals.Eighties)
		{
			YandereMapMarker.GetComponent<Renderer>().material.mainTexture = RyobaFace;
			Labels[0].text = "Newspaper Club";
			Labels[1].text = "Sociology Classroom";
			if (DateGlobals.Week > 10)
			{
				base.gameObject.SetActive(value: false);
			}
		}
		DisableCamera();
		X = 0.5f;
		Y = 0.5f;
	}

	private void Update()
	{
		if (Input.GetButtonDown(InputNames.Xbox_Back) && Yandere.CanMove && !Yandere.StudentManager.TutorialWindow.Show && Yandere.Police.Darkness.color.a <= 0f && !Yandere.StudentManager.KokonaTutorial)
		{
			if (!Show)
			{
				if (!PauseScreen.Show)
				{
					PauseScreen.Show = true;
					Yandere.RPGCamera.enabled = false;
					ElevationLabel.enabled = true;
					Yandere.Blur.enabled = true;
					MyCamera.enabled = true;
					Compass.SetActive(value: true);
					Time.timeScale = 0.001f;
					PromptBar.ClearButtons();
					PromptBar.Label[1].text = "Exit";
					PromptBar.Label[2].text = "Lower Floor";
					PromptBar.Label[3].text = "Higher Floor";
					PromptBar.UpdateButtons();
					PromptBar.Show = true;
					Show = true;
				}
			}
			else
			{
				Yandere.RPGCamera.enabled = true;
				ElevationLabel.enabled = false;
				Yandere.Blur.enabled = false;
				PauseScreen.Show = false;
				Compass.SetActive(value: false);
				Time.timeScale = 1f;
				PromptBar.ClearButtons();
				PromptBar.Show = false;
				Show = false;
			}
		}
		if (Show)
		{
			Border.transform.localScale = Vector3.Lerp(Border.transform.localScale, new Vector3(1.3f, 1.315f, 1.3f), Time.unscaledDeltaTime * 10f);
			X = Mathf.Lerp(X, 0.1f, Time.unscaledDeltaTime * 10f);
			Y = Mathf.Lerp(Y, 0.1f, Time.unscaledDeltaTime * 10f);
			W = Mathf.Lerp(W, 0.8f, Time.unscaledDeltaTime * 10f);
			H = Mathf.Lerp(H, 0.8f, Time.unscaledDeltaTime * 10f);
			MyCamera.rect = new Rect(X, Y, W, H);
			if (!(Border.transform.localScale.x > 1.2f))
			{
				return;
			}
			float num = 0f;
			float num2 = 0f;
			if (InputDevice.Type == InputDeviceType.MouseAndKeyboard)
			{
				num = Input.GetAxis("Mouse Y");
				num2 = Input.GetAxis("Mouse X");
				base.transform.position += new Vector3(num2 * Time.unscaledDeltaTime * 50f, 0f, num * Time.unscaledDeltaTime * 50f);
				MyCamera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * Time.unscaledDeltaTime * 1000f;
			}
			else
			{
				num = Input.GetAxis("Vertical");
				num2 = Input.GetAxis("Horizontal");
				base.transform.position += new Vector3(num2 * Time.unscaledDeltaTime * 100f, 0f, num * Time.unscaledDeltaTime * 100f);
				MyCamera.orthographicSize -= Input.GetAxis("Mouse Y") * Time.unscaledDeltaTime * 100f;
			}
			if (MyCamera.orthographicSize < 4f)
			{
				MyCamera.orthographicSize = 4f;
			}
			if (MyCamera.orthographicSize > 40.75f)
			{
				MyCamera.orthographicSize = 40.75f;
			}
			if (Input.GetButtonDown(InputNames.Xbox_X))
			{
				base.transform.position += new Vector3(0f, -4f, 0f);
				if (base.transform.position.y < 3f)
				{
					base.transform.position = new Vector3(base.transform.position.x, 3f, base.transform.position.z);
				}
			}
			if (Input.GetButtonDown(InputNames.Xbox_Y))
			{
				base.transform.position += new Vector3(0f, 4f, 0f);
				if (base.transform.position.y > 15f)
				{
					base.transform.position = new Vector3(base.transform.position.x, 15f, base.transform.position.z);
				}
			}
			if (base.transform.position.y == 3f)
			{
				ElevationLabel.text = "Floor 1";
			}
			else if (base.transform.position.y == 7f)
			{
				ElevationLabel.text = "Floor 2";
			}
			else if (base.transform.position.y == 11f)
			{
				ElevationLabel.text = "Floor 3";
			}
			else if (base.transform.position.y == 15f)
			{
				ElevationLabel.text = "The Rooftop";
			}
			HorizontalLimit = 70.72f - MyCamera.orthographicSize / 40.75f * 70.72f;
			if (base.transform.position.x > HorizontalLimit)
			{
				base.transform.position = new Vector3(HorizontalLimit, base.transform.position.y, base.transform.position.z);
			}
			if (base.transform.position.x < HorizontalLimit * -1f)
			{
				base.transform.position = new Vector3(HorizontalLimit * -1f, base.transform.position.y, base.transform.position.z);
			}
			VerticalLimit = 102f - MyCamera.orthographicSize / 40.75f;
			if (base.transform.position.z > VerticalLimit)
			{
				base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, VerticalLimit);
			}
			if (base.transform.position.z < VerticalLimit * -1f)
			{
				base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, VerticalLimit * -1f);
			}
			YandereMapMarker.localScale = new Vector3(MyCamera.orthographicSize / 40.75f * 10f, MyCamera.orthographicSize / 40.75f * 10f, MyCamera.orthographicSize / 40.75f * 10f);
			PortalMapMarker.localScale = new Vector3(MyCamera.orthographicSize / 40.75f * 10f, MyCamera.orthographicSize / 40.75f * 10f, MyCamera.orthographicSize / 40.75f * 10f);
			if (StudentManager.Students[1] != null)
			{
				StudentManager.Students[1].MapMarker.localScale = new Vector3(MyCamera.orthographicSize / 40.75f * 10f, MyCamera.orthographicSize / 40.75f * 10f, MyCamera.orthographicSize / 40.75f * 10f);
				StudentManager.Students[1].MapMarker.eulerAngles = new Vector3(90f, 0f, 0f);
			}
			if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				ElevationLabel.enabled = false;
				Compass.SetActive(value: false);
				PauseScreen.Show = false;
				Yandere.Blur.enabled = false;
				Time.timeScale = 1f;
				PromptBar.ClearButtons();
				PromptBar.Show = false;
				Yandere.RPGCamera.enabled = true;
				Show = false;
			}
		}
		else if (MyCamera.enabled)
		{
			Border.transform.localScale = Vector3.Lerp(Border.transform.localScale, new Vector3(0f, 0f, 0f), Time.unscaledDeltaTime * 10f);
			X = Mathf.Lerp(X, 0.5f, Time.unscaledDeltaTime * 10f);
			Y = Mathf.Lerp(Y, 0.5f, Time.unscaledDeltaTime * 10f);
			W = Mathf.Lerp(W, 0f, Time.unscaledDeltaTime * 10f);
			H = Mathf.Lerp(H, 0f, Time.unscaledDeltaTime * 10f);
			MyCamera.rect = new Rect(X, Y, W, H);
			if (W < 0.01f)
			{
				DisableCamera();
			}
		}
	}

	private void DisableCamera()
	{
		Border.transform.localScale = new Vector3(0f, 0f, 0f);
		MyCamera.rect = new Rect(0.5f, 0.5f, 0f, 0f);
		ElevationLabel.enabled = false;
		MyCamera.enabled = false;
	}
}
