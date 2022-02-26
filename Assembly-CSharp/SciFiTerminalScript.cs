using System;
using UnityEngine;

// Token: 0x02000417 RID: 1047
public class SciFiTerminalScript : MonoBehaviour
{
	// Token: 0x06001C64 RID: 7268 RVA: 0x0014BD2A File Offset: 0x00149F2A
	private void Start()
	{
		if (this.Student.StudentID != 65)
		{
			base.enabled = false;
			return;
		}
		this.RobotArms = this.Student.StudentManager.RobotArms;
	}

	// Token: 0x06001C65 RID: 7269 RVA: 0x0014BD5C File Offset: 0x00149F5C
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

	// Token: 0x0400325F RID: 12895
	public StudentScript Student;

	// Token: 0x04003260 RID: 12896
	public RobotArmScript RobotArms;

	// Token: 0x04003261 RID: 12897
	public Transform OtherFinger;

	// Token: 0x04003262 RID: 12898
	public bool Updated;
}
