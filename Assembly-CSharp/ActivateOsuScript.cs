using UnityEngine;

public class ActivateOsuScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public OsuScript[] OsuScripts;

	public StudentScript Student;

	public ClockScript Clock;

	public GameObject Music;

	public Transform Mouse;

	public GameObject Osu;

	public int PlayerID;

	public Vector3 OriginalMousePosition;

	public Vector3 OriginalMouseRotation;

	private void Start()
	{
		OsuScripts = Osu.GetComponents<OsuScript>();
		OriginalMouseRotation = Mouse.transform.eulerAngles;
		OriginalMousePosition = Mouse.transform.position;
	}

	private void Update()
	{
		if (Student == null)
		{
			Student = StudentManager.Students[PlayerID];
			return;
		}
		if (!Osu.activeInHierarchy)
		{
			if (Vector3.Distance(base.transform.position, Student.transform.position) < 0.1f && Student.Routine && Student.CurrentDestination == Student.Destinations[Student.Phase] && Student.Actions[Student.Phase] == StudentActionType.Gaming)
			{
				ActivateOsu();
			}
			return;
		}
		Mouse.transform.eulerAngles = OriginalMouseRotation;
		if (!Student.Routine || Student.CurrentDestination != Student.Destinations[Student.Phase] || Student.Actions[Student.Phase] != StudentActionType.Gaming)
		{
			DeactivateOsu();
		}
	}

	private void ActivateOsu()
	{
		Osu.transform.parent.gameObject.SetActive(true);
		Student.SmartPhone.SetActive(false);
		Music.SetActive(true);
		Mouse.parent = Student.RightHand;
		Mouse.transform.localPosition = Vector3.zero;
	}

	private void DeactivateOsu()
	{
		Osu.transform.parent.gameObject.SetActive(false);
		Music.SetActive(false);
		OsuScript[] osuScripts = OsuScripts;
		for (int i = 0; i < osuScripts.Length; i++)
		{
			osuScripts[i].Timer = 0f;
		}
		Mouse.parent = base.transform.parent;
		Mouse.transform.position = OriginalMousePosition;
	}
}
