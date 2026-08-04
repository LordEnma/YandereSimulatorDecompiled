using UnityEngine;

public class SciFiTabletScript : MonoBehaviour
{
	public StudentScript Student;

	public HologramScript Holograms;

	public Transform Finger;

	public bool Updated;

	private void Start()
	{
		if (Student == null)
		{
			base.enabled = false;
		}
		else if (Student.StudentID == 62)
		{
			Holograms = Student.StudentManager.Holograms;
		}
		else
		{
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (!Student.MyRenderer.isVisible)
		{
			return;
		}
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
