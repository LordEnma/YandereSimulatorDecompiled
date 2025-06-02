using UnityEngine;

public class SciFiToolScript : MonoBehaviour
{
	public StudentScript Student;

	public ParticleSystem Sparks;

	public Transform Target;

	public Transform Tip;

	private void Start()
	{
		Target = Student.StudentManager.ToolTarget;
	}

	private void Update()
	{
		if (Student.MyRenderer.isVisible)
		{
			if ((double)Vector3.Distance(Tip.position, Target.position) < 0.1)
			{
				Sparks.Play();
			}
			else
			{
				Sparks.Stop();
			}
		}
	}
}
