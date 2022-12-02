using UnityEngine;

public class MatchTriggerScript : MonoBehaviour
{
	public StudentScript Student;

	public bool Fireball;

	public bool Candle;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer != 9)
		{
			return;
		}
		Student = other.gameObject.transform.root.gameObject.GetComponent<StudentScript>();
		if (Student != null && Student.StudentID > 1 && (Student.Gas || Fireball))
		{
			if (Student.Yandere.PickUp != null && Student.Yandere.PickUp.OpenFlame)
			{
				Student.Yandere.Sanity -= ((PlayerGlobals.PantiesEquipped == 10) ? 10f : 20f) * Student.Yandere.Numbness;
			}
			Student.Combust();
			if (!Candle)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}
}
