using System;
using UnityEngine;

// Token: 0x02000418 RID: 1048
public class SciFiTerminalScript : MonoBehaviour
{
	// Token: 0x06001C73 RID: 7283 RVA: 0x0014D10A File Offset: 0x0014B30A
	private void Start()
	{
		if (this.Student.StudentID != 65)
		{
			base.enabled = false;
			return;
		}
		this.RobotArms = this.Student.StudentManager.RobotArms;
	}

	// Token: 0x06001C74 RID: 7284 RVA: 0x0014D13C File Offset: 0x0014B33C
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

	// Token: 0x040032A9 RID: 12969
	public StudentScript Student;

	// Token: 0x040032AA RID: 12970
	public RobotArmScript RobotArms;

	// Token: 0x040032AB RID: 12971
	public Transform OtherFinger;

	// Token: 0x040032AC RID: 12972
	public bool Updated;
}
