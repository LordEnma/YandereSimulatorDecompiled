using UnityEngine;

public class LowPolyStudentScript : MonoBehaviour
{
	public StudentScript Student;

	public Renderer TeacherMesh;

	public Renderer MyMesh;

	private void Start()
	{
		if (Student.StudentManager == null || Student.Cosmetic.Kidnapped || Student.Slave || Student.StudentID == 1)
		{
			base.enabled = false;
			if (Student.StudentID == 1)
			{
				Student.MyRenderer.enabled = true;
				MyMesh.enabled = false;
			}
		}
	}

	private void Update()
	{
		if (Student.StudentManager != null && (float)Student.StudentManager.LowDetailThreshold > 0f)
		{
			float num = 0f;
			num = ((!Student.Prompt.enabled) ? Vector3.Distance(Student.transform.position, Student.Yandere.transform.position) : Student.Prompt.DistanceSqr);
			if (num > (float)Student.StudentManager.LowDetailThreshold)
			{
				if (!MyMesh.enabled)
				{
					Student.MyRenderer.enabled = false;
					MyMesh.enabled = true;
				}
			}
			else if (MyMesh.enabled)
			{
				Student.MyRenderer.enabled = true;
				MyMesh.enabled = false;
			}
		}
		else if (MyMesh.enabled)
		{
			Student.MyRenderer.enabled = true;
			MyMesh.enabled = false;
		}
		if (Student.WearingBikini && Student.MyRenderer.enabled)
		{
			Debug.Log("Disabling Chigusa's MyRenderer from the LowPolyStudent script because WearingBikini is true and MyRenderer is enabled.");
			Student.MyRenderer.enabled = false;
			MyMesh.enabled = false;
		}
	}

	public void Deactivate()
	{
		Student.MyRenderer.enabled = true;
		MyMesh.enabled = false;
		base.enabled = false;
	}
}
