using UnityEngine;

public class EmptyHuskScript : MonoBehaviour
{
	public StudentScript TargetStudent;

	public Animation MyAnimation;

	public GameObject DarkAura;

	public Transform Mouth;

	public float[] BloodTimes;

	public int EatPhase;

	private void Update()
	{
		if (EatPhase < BloodTimes.Length && MyAnimation["f02_sixEat_00"].time > BloodTimes[EatPhase])
		{
			Object.Instantiate(TargetStudent.StabBloodEffect, Mouth.position, Quaternion.identity).GetComponent<RandomStabScript>().Biting = true;
			EatPhase++;
		}
		if (MyAnimation["f02_sixEat_00"].time >= MyAnimation["f02_sixEat_00"].length)
		{
			if (DarkAura != null)
			{
				Object.Instantiate(DarkAura, base.transform.position + Vector3.up * 0.81f, Quaternion.identity);
			}
			Object.Destroy(base.gameObject);
		}
	}
}
