using UnityEngine;

public class SuckScript : MonoBehaviour
{
	public StudentScript Student;

	public float Strength;

	private void Update()
	{
		Strength += Time.deltaTime;
		base.transform.position = Vector3.MoveTowards(base.transform.position, Student.Yandere.Hips.position + base.transform.up * 0.25f, Time.deltaTime * Strength);
		if (Vector3.Distance(base.transform.position, Student.Yandere.Hips.position + base.transform.up * 0.25f) < 1f)
		{
			base.transform.localScale = Vector3.MoveTowards(base.transform.localScale, Vector3.zero, Time.deltaTime);
			if (base.transform.localScale == Vector3.zero)
			{
				base.transform.parent.parent.parent.gameObject.SetActive(false);
			}
		}
	}
}
