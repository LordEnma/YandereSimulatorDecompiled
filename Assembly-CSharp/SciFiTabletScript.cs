using UnityEngine;

public class SciFiTabletScript : MonoBehaviour
{
	public StudentScript Student;

	public HologramScript Holograms;

	public Transform Finger;

	public bool Updated;

	private void Start()
	{
		Holograms = Student.StudentManager.Holograms;
	}

	private void Update()
	{
		if ((double)Vector3.Distance(Finger.position, base.transform.position) < 0.1)
		{
			if (!Updated)
			{
				Holograms.UpdateHolograms();
				Updated = true;
			}
		}
		else
		{
			Updated = false;
		}
	}
}
