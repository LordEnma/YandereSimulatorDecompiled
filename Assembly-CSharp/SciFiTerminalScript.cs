using System;
using UnityEngine;

// Token: 0x02000417 RID: 1047
public class SciFiTerminalScript : MonoBehaviour
{
	// Token: 0x06001C66 RID: 7270 RVA: 0x0014C266 File Offset: 0x0014A466
	private void Start()
	{
		if (this.Student.StudentID != 65)
		{
			base.enabled = false;
			return;
		}
		this.RobotArms = this.Student.StudentManager.RobotArms;
	}

	// Token: 0x06001C67 RID: 7271 RVA: 0x0014C298 File Offset: 0x0014A498
	private void Update()
	{
		if (this.RobotArms != null)
		{
			if ((double)Vector3.Distance(this.RobotArms.TerminalTarget.position, base.transform.position) < 0.3 || (double)Vector3.Distance(this.RobotArms.TerminalTarget.position, this.OtherFinger.position) < 0.3)
			{
				if (!this.Updated)
				{
					this.Updated = true;
					if (!this.RobotArms.On[0])
					{
						this.RobotArms.ActivateArms();
						return;
					}
					this.RobotArms.ToggleWork();
					return;
				}
			}
			else
			{
				this.Updated = false;
			}
		}
	}

	// Token: 0x04003275 RID: 12917
	public StudentScript Student;

	// Token: 0x04003276 RID: 12918
	public RobotArmScript RobotArms;

	// Token: 0x04003277 RID: 12919
	public Transform OtherFinger;

	// Token: 0x04003278 RID: 12920
	public bool Updated;
}
