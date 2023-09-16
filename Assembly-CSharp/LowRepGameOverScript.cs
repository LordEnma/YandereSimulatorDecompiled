using UnityEngine;

public class LowRepGameOverScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public YandereScript Yandere;

	public StudentScript Senpai;

	public Renderer Darkness;

	public Transform SenpaiSpot;

	public Transform MyCamera;

	public Transform[] CameraPosition;

	public GameObject[] GossipGroup;

	public AudioClip[] Giggles;

	public float GiggleTimer;

	public float Timer;

	public int PreviousGiggle;

	public int GigglePhase;

	public int GiggleID;

	public int Phase;

	private void Start()
	{
		GossipGroup[1].SetActive(value: false);
		GossipGroup[2].SetActive(value: false);
		GossipGroup[3].SetActive(value: false);
		GossipGroup[4].SetActive(value: false);
		GossipGroup[5].SetActive(value: false);
		Senpai = StudentManager.Students[1];
		Yandere.transform.parent = base.transform;
		Yandere.transform.localPosition = new Vector3(0f, 0f, 0f);
		Yandere.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		Yandere.CharacterAnimation.Play("f02_LowRepGO_A");
		Yandere.LifeNotePen.SetActive(value: false);
		Yandere.LoseGentleEyes();
		MyCamera.eulerAngles = CameraPosition[0].eulerAngles;
		MyCamera.position = CameraPosition[0].position;
		Senpai.Chopsticks[0].SetActive(value: false);
		Senpai.Chopsticks[1].SetActive(value: false);
		Senpai.OccultBook.SetActive(value: false);
		Senpai.SmartPhone.SetActive(value: false);
		Senpai.Scrubber.SetActive(value: false);
		Senpai.Eraser.SetActive(value: false);
		Senpai.Bento.SetActive(value: false);
		Senpai.Pen.SetActive(value: false);
		Senpai.enabled = false;
		Senpai.CharacterAnimation.enabled = true;
		Senpai.MyController.enabled = false;
		Senpai.Pathfinding.enabled = false;
		Yandere.CameraEffects.UpdateDOF(1f);
		Time.timeScale = 1f;
	}

	private void Update()
	{
		Darkness.material.color = new Color(Darkness.material.color.r, Darkness.material.color.g, Darkness.material.color.b, Darkness.material.color.a - Time.deltaTime * 0.5f);
		if (Phase == 0)
		{
			if (Yandere.CharacterAnimation["f02_LowRepGO_A"].time >= 3f)
			{
				GigglePhase = 1;
			}
			if (Yandere.CharacterAnimation["f02_LowRepGO_A"].time >= Yandere.CharacterAnimation["f02_LowRepGO_A"].length || Input.GetButtonDown("A"))
			{
				MyCamera.eulerAngles = CameraPosition[1].eulerAngles;
				MyCamera.position = CameraPosition[1].position;
				GossipGroup[1].SetActive(value: true);
				GigglePhase = 1;
				Phase++;
			}
		}
		else if (Phase == 1)
		{
			MyCamera.position += MyCamera.forward * Time.deltaTime * -0.1f;
			Timer += Time.deltaTime;
			if (Timer > 2f || Input.GetButtonDown("A"))
			{
				MyCamera.eulerAngles = CameraPosition[2].eulerAngles;
				MyCamera.position = CameraPosition[2].position;
				Yandere.CharacterAnimation.Play("f02_LowRepGO_B");
				GossipGroup[1].SetActive(value: false);
				GigglePhase++;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 2)
		{
			MyCamera.position += MyCamera.forward * Time.deltaTime * 0.1f;
			if (Yandere.CharacterAnimation["f02_LowRepGO_B"].time >= Yandere.CharacterAnimation["f02_LowRepGO_B"].length || Input.GetButtonDown("A"))
			{
				MyCamera.eulerAngles = CameraPosition[3].eulerAngles;
				MyCamera.position = CameraPosition[3].position;
				GossipGroup[2].SetActive(value: true);
				Phase++;
			}
		}
		else if (Phase == 3)
		{
			MyCamera.position += MyCamera.forward * Time.deltaTime * -0.1f;
			Timer += Time.deltaTime;
			if (Timer > 2f || Input.GetButtonDown("A"))
			{
				MyCamera.eulerAngles = CameraPosition[4].eulerAngles;
				MyCamera.position = CameraPosition[4].position;
				Yandere.CharacterAnimation.Play("f02_LowRepGO_C");
				GossipGroup[2].SetActive(value: false);
				GigglePhase++;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 4)
		{
			MyCamera.position += MyCamera.forward * Time.deltaTime * 0.1f;
			if (Yandere.CharacterAnimation["f02_LowRepGO_C"].time >= Yandere.CharacterAnimation["f02_LowRepGO_C"].length || Input.GetButtonDown("A"))
			{
				MyCamera.eulerAngles = CameraPosition[5].eulerAngles;
				MyCamera.position = CameraPosition[5].position;
				GossipGroup[3].SetActive(value: true);
				Phase++;
			}
		}
		else if (Phase == 5)
		{
			MyCamera.position += MyCamera.forward * Time.deltaTime * -0.1f;
			Timer += Time.deltaTime;
			if (Timer > 2f || Input.GetButtonDown("A"))
			{
				MyCamera.eulerAngles = CameraPosition[6].eulerAngles;
				MyCamera.position = CameraPosition[6].position;
				Yandere.CharacterAnimation.Play("f02_LowRepGO_D");
				GossipGroup[3].SetActive(value: false);
				GossipGroup[4].SetActive(value: true);
				GigglePhase++;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 6)
		{
			MyCamera.position += MyCamera.forward * Time.deltaTime * 0.1f;
			if (Yandere.CharacterAnimation["f02_LowRepGO_D"].time >= Yandere.CharacterAnimation["f02_LowRepGO_D"].length || Input.GetButtonDown("A"))
			{
				MyCamera.eulerAngles = CameraPosition[7].eulerAngles;
				MyCamera.position = CameraPosition[7].position;
				Senpai.CharacterAnimation[Senpai.AngryFaceAnim].weight = 1f;
				Senpai.transform.eulerAngles = new Vector3(0f, 180f, 0f);
				Senpai.transform.position = SenpaiSpot.position;
				Senpai.CharacterAnimation.Play(Senpai.OriginalIdleAnim);
				Physics.SyncTransforms();
				GossipGroup[5].SetActive(value: true);
				GigglePhase++;
				Phase++;
			}
		}
		else if (Phase == 7)
		{
			MyCamera.position += MyCamera.forward * Time.deltaTime * 0.1f;
			Timer += Time.deltaTime;
			if (Timer > 2f || Input.GetButtonDown("A"))
			{
				Senpai.CharacterAnimation["refuse_01"].speed = 0.5f;
				Senpai.CharacterAnimation.Play("refuse_01");
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 8)
		{
			MyCamera.position += MyCamera.forward * Time.deltaTime * 0.1f;
			Timer += Time.deltaTime;
			if (Timer > 2.5f || Input.GetButtonDown("A"))
			{
				Yandere.CharacterAnimation.Play("f02_scaredIdle_00");
				Yandere.ShoulderCamera.GoingToCounselor = false;
				Yandere.ShoulderCamera.OverShoulder = false;
				Yandere.ShoulderCamera.enabled = true;
				Yandere.ShoulderCamera.Noticed = true;
				Yandere.ShoulderCamera.Skip = true;
				Yandere.StudentManager.Headmaster.Heartbroken.Exposed = true;
				GigglePhase++;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 9)
		{
			Timer += Time.deltaTime;
		}
		GiggleTimer += Time.deltaTime;
		if (GigglePhase == 1)
		{
			if (GiggleTimer > 2f)
			{
				Giggle();
				GiggleTimer = 0f;
			}
		}
		else if (GigglePhase == 2)
		{
			if (GiggleTimer > 1f)
			{
				Giggle();
				GiggleTimer = 0f;
			}
		}
		else if (GigglePhase == 3)
		{
			if (GiggleTimer > 0.5f)
			{
				Giggle();
				GiggleTimer = 0f;
			}
		}
		else if (GigglePhase == 4)
		{
			if (GiggleTimer > 0.25f)
			{
				Giggle();
				GiggleTimer = 0f;
			}
		}
		else if (GigglePhase > 4 && GiggleTimer > 0.125f)
		{
			Giggle();
			GiggleTimer = 0f;
		}
	}

	private void Giggle()
	{
		for (GiggleID = Random.Range(1, Giggles.Length); GiggleID == PreviousGiggle; GiggleID = Random.Range(1, Giggles.Length))
		{
		}
		PreviousGiggle = GiggleID;
		if (GigglePhase < 6)
		{
			AudioSource.PlayClipAtPoint(Giggles[GiggleID], MyCamera.transform.position);
		}
		else
		{
			AudioSource.PlayClipAtPoint(Giggles[GiggleID], MyCamera.transform.position + Vector3.up * Timer);
		}
	}
}
