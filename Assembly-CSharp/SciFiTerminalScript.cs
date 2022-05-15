using System;
using UnityEngine;

// Token: 0x0200041E RID: 1054
public class SciFiTerminalScript : MonoBehaviour
{
	// Token: 0x06001C94 RID: 7316 RVA: 0x0014F7DE File Offset: 0x0014D9DE
	private void Start()
	{
		if (this.Student.StudentID != 65)
		{
			base.enabled = false;
			return;
		}
		this.RobotArms = this.Student.StudentManager.RobotArms;
	}

	// Token: 0x06001C95 RID: 7317 RVA: 0x0014F810 File Offset: 0x0014DA10
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

	// Token: 0x040032F7 RID: 13047
	public StudentScript Student;

	// Token: 0x040032F8 RID: 13048
	public RobotArmScript RobotArms;

	// Token: 0x040032F9 RID: 13049
	public Transform OtherFinger;

	// Token: 0x040032FA RID: 13050
	public bool Updated;
}
