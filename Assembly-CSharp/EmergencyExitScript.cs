using UnityEngine;

public class EmergencyExitScript : MonoBehaviour
{
	public StudentScript Student;

	public Transform Yandere;

	public Transform Pivot;

	public float Timer;

	public bool Open;

	private void Update()
	{
		if (Vector3.Distance(Yandere.position, base.transform.position) < 2f)
		{
			Open = true;
		}
		else if (Timer == 0f)
		{
			Student = null;
			Open = false;
		}
		if (!Open)
		{
			Pivot.localEulerAngles = new Vector3(Pivot.localEulerAngles.x, Mathf.Lerp(Pivot.localEulerAngles.y, 0f, Time.deltaTime * 10f), Pivot.localEulerAngles.z);
			return;
		}
		Pivot.localEulerAngles = new Vector3(Pivot.localEulerAngles.x, Mathf.Lerp(Pivot.localEulerAngles.y, 90f, Time.deltaTime * 10f), Pivot.localEulerAngles.z);
		Timer = Mathf.MoveTowards(Timer, 0f, Time.deltaTime);
	}

	private void OnTriggerStay(Collider other)
	{
		Student = other.gameObject.GetComponent<StudentScript>();
		if (Student != null)
		{
			Timer = 1f;
			Open = true;
		}
	}
}
