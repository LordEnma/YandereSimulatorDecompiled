using UnityEngine;
using UnityEngine.PostProcessing;

public class SwordCutsceneScript : MonoBehaviour
{
	public PostProcessingProfile Profile;

	public Animation YandereAnimation;

	public Animation SwordAnimation;

	public AudioClip CinematicBoom;

	public Transform[] CameraAngle;

	public Transform[] Segments;

	public AudioClip[] VoiceClips;

	public Transform HeartSegment;

	public Transform YandereHead;

	public AudioSource Jukebox;

	public AudioSource MyAudio;

	public UISprite Darkness;

	public string[] Dialogue;

	public UILabel Subtitle;

	public float CutsceneTimer;

	public float Timer;

	public int Phase;

	public int ID;

	public float Intensity;

	private void Start()
	{
		Segments = HeartSegment.gameObject.GetComponentsInChildren<Transform>();
		base.transform.position = CameraAngle[1].position;
		base.transform.eulerAngles = CameraAngle[1].eulerAngles;
		SwordAnimation.Stop("Sword_Pull");
		Subtitle.text = "";
		UpdateDOF(1f);
	}

	private void Update()
	{
		if (Phase < 8 && Input.GetKeyDown("space"))
		{
			Darkness.alpha = 0f;
			Timer = 10f;
		}
		if (Phase > 0)
		{
			CutsceneTimer += Time.deltaTime;
		}
		if (Phase == 3 || Phase == 4 || Phase == 5)
		{
			UpdateDOF(Vector3.Distance(base.transform.position, HeartSegment.position));
		}
		else if (Phase < 8)
		{
			UpdateDOF(Vector3.Distance(base.transform.position, YandereHead.position));
		}
		if (Phase == 0)
		{
			Timer = Mathf.MoveTowards(Timer, 1f, Time.deltaTime);
			if (Timer >= 1f)
			{
				YandereAnimation.transform.position = new Vector3(1.5f, 0.1f, 10f);
				YandereAnimation["f02_paranoidWalk_00"].speed = 1f;
				YandereAnimation.Play("f02_paranoidWalk_00");
				Jukebox.Play();
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 1)
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime * 0.2f);
			YandereAnimation.transform.position -= new Vector3(0f, 0f, Time.deltaTime);
			Timer = Mathf.MoveTowards(Timer, 10f, Time.deltaTime);
			if (Timer >= 10f)
			{
				base.transform.position = CameraAngle[2].position;
				base.transform.eulerAngles = CameraAngle[2].eulerAngles;
				YandereAnimation.transform.position = new Vector3(0f, 0f, 3f);
				YandereAnimation["f02_girlWalk_LookLeft_00"].time = 1.5f;
				YandereAnimation.Play("f02_girlWalk_LookLeft_00");
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 2)
		{
			Timer = Mathf.MoveTowards(Timer, 5f, Time.deltaTime);
			if (Timer >= 5f)
			{
				base.transform.position = CameraAngle[3].position;
				base.transform.eulerAngles = CameraAngle[3].eulerAngles;
				YandereAnimation.transform.position = new Vector3(0f, 100f, 0f);
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 3)
		{
			base.transform.position -= new Vector3(0f, 0f, Time.deltaTime * 0.1f);
			Timer = Mathf.MoveTowards(Timer, 5f, Time.deltaTime);
			if (Timer >= 5f)
			{
				base.transform.position = CameraAngle[4].position;
				base.transform.eulerAngles = CameraAngle[4].eulerAngles;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 4)
		{
			base.transform.position -= new Vector3(0f, 0f, Time.deltaTime * 0.1f);
			Timer = Mathf.MoveTowards(Timer, 5f, Time.deltaTime);
			if (Timer >= 5f)
			{
				base.transform.position = CameraAngle[5].position;
				base.transform.eulerAngles = CameraAngle[5].eulerAngles;
				AudioSource.PlayClipAtPoint(CinematicBoom, base.transform.position);
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 5)
		{
			base.transform.Translate(base.transform.forward * Time.deltaTime * 0.01f, Space.World);
			Timer = Mathf.MoveTowards(Timer, 5f, Time.deltaTime);
			if (Timer >= 5f)
			{
				base.transform.position = CameraAngle[6].position;
				base.transform.eulerAngles = CameraAngle[6].eulerAngles;
				YandereAnimation.transform.position = new Vector3(0f, 0f, 3f);
				YandereAnimation.Stop();
				YandereAnimation["f02_girlWalk_LookLeft_00"].speed = 0.5f;
				YandereAnimation["f02_girlWalk_LookLeft_00"].time = 12.25f;
				YandereAnimation.Play("f02_girlWalk_LookLeft_00");
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 6)
		{
			Timer = Mathf.MoveTowards(Timer, 5f, Time.deltaTime);
			if (Timer >= 5f)
			{
				base.transform.position = CameraAngle[7].position;
				base.transform.eulerAngles = CameraAngle[7].eulerAngles;
				YandereAnimation.transform.position = new Vector3(0f, 0f, -1f);
				YandereAnimation.Stop();
				YandereAnimation["f02_girlWalk_LookLeft_00"].speed = 1f;
				YandereAnimation["f02_girlWalk_LookLeft_00"].time = 1.5f;
				YandereAnimation.Play("f02_girlWalk_LookLeft_00");
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 7)
		{
			Timer = Mathf.MoveTowards(Timer, 5f, Time.deltaTime);
			if (Timer >= 5f)
			{
				base.transform.position = CameraAngle[8].position;
				base.transform.eulerAngles = CameraAngle[8].eulerAngles;
				YandereAnimation.transform.position = new Vector3(0f, 0f, -1f);
				SwordAnimation.transform.parent = YandereAnimation.transform;
				SwordAnimation.transform.localPosition = Vector3.zero;
				YandereAnimation.Stop();
				SwordAnimation.Stop();
				YandereAnimation["f02_girlWalk_LookLeft_00"].time = 0f;
				SwordAnimation["Sword_Pull"].time = 0f;
				YandereAnimation.Play("f02_swordPull_00");
				SwordAnimation.Play("Sword_Pull");
				UpdateDOF(1f);
				Timer = 0f;
				Phase++;
			}
		}
		else
		{
			if (Phase != 8)
			{
				return;
			}
			if (Input.GetKeyDown("space"))
			{
				if (YandereAnimation["f02_swordPull_00"].time < 15f)
				{
					YandereAnimation["f02_swordPull_00"].time = 15f;
					SwordAnimation["Sword_Pull"].time = 15f;
				}
				else
				{
					YandereAnimation["f02_swordPull_00"].time = 25f;
					SwordAnimation["Sword_Pull"].time = 25f;
				}
			}
			if (YandereAnimation["f02_swordPull_00"].time > 28.5f)
			{
				if (base.transform.position.x != 0f)
				{
					base.transform.position = CameraAngle[10].position;
					base.transform.eulerAngles = CameraAngle[10].eulerAngles;
					SwordAnimation["Sword_Pull"].speed = 0.4f;
					YandereAnimation["f02_swordPull_00"].speed = 0.4f;
					return;
				}
				UpdateDOF(Vector3.Distance(base.transform.position, YandereAnimation.transform.position));
				base.transform.position += new Vector3(0f, 0f, Time.deltaTime * 0.033333f);
				Timer += Time.deltaTime;
				if (Timer >= 1f && ID < VoiceClips.Length && !MyAudio.isPlaying)
				{
					Timer += Time.deltaTime;
					ID++;
					Timer = 0f;
					MyAudio.clip = VoiceClips[ID];
					MyAudio.Play();
					Subtitle.text = Dialogue[ID];
				}
			}
			else if (YandereAnimation["f02_swordPull_00"].time > 15.5f)
			{
				base.transform.position = CameraAngle[8].position;
				base.transform.eulerAngles = CameraAngle[8].eulerAngles;
			}
			else if (YandereAnimation["f02_swordPull_00"].time > 10.5f)
			{
				base.transform.position = CameraAngle[9].position;
				base.transform.eulerAngles = CameraAngle[9].eulerAngles;
			}
		}
	}

	private void LateUpdate()
	{
		if (YandereAnimation["f02_swordPull_00"].time > 16.5f && YandereAnimation["f02_swordPull_00"].time < 22.5f)
		{
			Intensity += Time.deltaTime;
			Transform[] segments = Segments;
			for (int i = 0; i < segments.Length; i++)
			{
				segments[i].transform.position += new Vector3(Random.Range(-0.001f * Intensity, 0.001f * Intensity), Random.Range(-0.001f * Intensity, 0.001f * Intensity), Random.Range(-0.001f * Intensity, 0.001f * Intensity));
			}
		}
	}

	public void UpdateDOF(float Focus)
	{
		DepthOfFieldModel.Settings settings = Profile.depthOfField.settings;
		settings.focusDistance = Focus;
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
}
