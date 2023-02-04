using UnityEngine;

public class YanvaniaIntroScript : MonoBehaviour
{
	public YanvaniaZombieSpawnerScript ZombieSpawner;

	public YanvaniaYanmontScript Yanmont;

	public GameObject Jukebox;

	public Transform BlackRight;

	public Transform BlackLeft;

	public UILabel FinalStage;

	public UILabel Heartbreak;

	public UITexture Triangle;

	public float LeaveTime;

	public float Position;

	public float Timer;

	private void Start()
	{
		BlackRight.gameObject.SetActive(value: true);
		BlackLeft.gameObject.SetActive(value: true);
		FinalStage.gameObject.SetActive(value: true);
		Heartbreak.gameObject.SetActive(value: true);
		Triangle.gameObject.SetActive(value: true);
		Triangle.transform.localScale = Vector3.zero;
		Heartbreak.transform.localPosition = new Vector3(1300f, Heartbreak.transform.localPosition.y, Heartbreak.transform.localPosition.z);
		FinalStage.transform.localPosition = new Vector3(-1300f, FinalStage.transform.localPosition.y, FinalStage.transform.localPosition.z);
	}

	private void Update()
	{
		Timer += Time.deltaTime;
		if (Timer > 1f && Timer < 3f)
		{
			Yanmont.Character.transform.localScale = new Vector3(-1f, Yanmont.Character.transform.localScale.y, Yanmont.Character.transform.localScale.z);
			if (!Jukebox.activeInHierarchy)
			{
				Jukebox.SetActive(value: true);
			}
			Triangle.transform.localScale = Vector3.Lerp(Triangle.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			Heartbreak.transform.localPosition = new Vector3(Mathf.Lerp(Heartbreak.transform.localPosition.x, 0f, Time.deltaTime * 10f), Heartbreak.transform.localPosition.y, Heartbreak.transform.localPosition.z);
			FinalStage.transform.localPosition = new Vector3(Mathf.Lerp(FinalStage.transform.localPosition.x, 0f, Time.deltaTime * 10f), FinalStage.transform.localPosition.y, FinalStage.transform.localPosition.z);
		}
		else if (Timer > 3f)
		{
			if (!Jukebox.activeInHierarchy)
			{
				Jukebox.SetActive(value: true);
			}
			Triangle.transform.localEulerAngles = new Vector3(Triangle.transform.localEulerAngles.x, Triangle.transform.localEulerAngles.y, Triangle.transform.localEulerAngles.z + 36f * Time.deltaTime);
			Triangle.color = new Color(Triangle.color.r, Triangle.color.g, Triangle.color.b, Triangle.color.a - Time.deltaTime);
			Heartbreak.color = new Color(Heartbreak.color.r, Heartbreak.color.g, Heartbreak.color.b, Heartbreak.color.a - Time.deltaTime);
			FinalStage.color = new Color(FinalStage.color.r, FinalStage.color.g, FinalStage.color.b, FinalStage.color.a - Time.deltaTime);
		}
		if (Timer > 4f)
		{
			Finish();
		}
		if (Timer > LeaveTime)
		{
			Position += ((Position == 0f) ? Time.deltaTime : (Position * 0.1f));
			if (BlackLeft.localPosition.x > -2100f)
			{
				BlackRight.localPosition = new Vector3(BlackRight.localPosition.x + Position, BlackRight.localPosition.y, BlackRight.localPosition.z);
				BlackLeft.localPosition = new Vector3(BlackLeft.localPosition.x - Position, BlackLeft.localPosition.y, BlackLeft.localPosition.z);
			}
		}
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			Finish();
		}
	}

	private void Finish()
	{
		if (!Jukebox.activeInHierarchy)
		{
			Jukebox.SetActive(value: true);
		}
		ZombieSpawner.enabled = true;
		Yanmont.CanMove = true;
		Object.Destroy(base.gameObject);
	}
}
