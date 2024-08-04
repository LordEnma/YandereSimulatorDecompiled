using UnityEngine;

public class SciFiTerminalScript : MonoBehaviour
{
	public StudentScript Student;

	public RobotArmScript RobotArms;

	public Transform OtherFinger;

	public bool Updated;

	private void Start()
	{
		if (Student.StudentID != 65 || GameGlobals.RobotComplete || GameGlobals.RobotDestroyed)
		{
			base.enabled = false;
		}
		else
		{
			RobotArms = Student.StudentManager.RobotArms;
		}
	}

	private void Update()
	{
		if (!(RobotArms != null))
		{
			return;
		}
		if ((double)Vector3.Distance(RobotArms.TerminalTarget.position, base.transform.position) < 0.3 || (double)Vector3.Distance(RobotArms.TerminalTarget.position, OtherFinger.position) < 0.3)
		{
			if (!Updated)
			{
				Updated = true;
				if (!RobotArms.On[0])
				{
					RobotArms.ActivateArms();
				}
				else
				{
					RobotArms.ToggleWork();
				}
			}
		}
		else
		{
			Updated = false;
		}
	}
}
