using UnityEngine;

public class FunGirlScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public GameObject Jukebox;

	public Transform Yandere;

	public UIPanel HUD;

	public float Speed;

	private void Start()
	{
		ChaseYandereChan();
	}

	private void Update()
	{
		if (Speed < 5f)
		{
			Speed += Time.deltaTime * 0.1f;
		}
		else
		{
			Speed = 5f;
		}
		base.transform.position = Vector3.MoveTowards(base.transform.position, Yandere.position, Time.deltaTime * Speed);
		base.transform.LookAt(Yandere.position);
		if (Vector3.Distance(base.transform.position, Yandere.position) < 0.5f)
		{
			Application.Quit();
		}
	}

	private void ChaseYandereChan()
	{
		SchoolGlobals.SchoolAtmosphereSet = true;
		SchoolGlobals.SchoolAtmosphere = 0f;
		StudentManager.SetAtmosphere();
		StudentScript[] students = StudentManager.Students;
		foreach (StudentScript studentScript in students)
		{
			if (studentScript != null)
			{
				studentScript.gameObject.SetActive(value: false);
			}
		}
		StudentManager.Yandere.NoDebug = true;
		base.gameObject.SetActive(value: true);
		Jukebox.SetActive(value: false);
		HUD.enabled = false;
	}
}
