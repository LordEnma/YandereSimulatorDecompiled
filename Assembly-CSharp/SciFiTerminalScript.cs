using System;
using UnityEngine;

// Token: 0x02000416 RID: 1046
public class SciFiTerminalScript : MonoBehaviour
{
	// Token: 0x06001C5B RID: 7259 RVA: 0x0014B2B2 File Offset: 0x001494B2
	private void Start()
	{
		if (this.Student.StudentID != 65)
		{
			base.enabled = false;
			return;
		}
		this.RobotArms = this.Student.StudentManager.RobotArms;
	}

	// Token: 0x06001C5C RID: 7260 RVA: 0x0014B2E4 File Offset: 0x001494E4
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

	// Token: 0x0400324F RID: 12879
	public StudentScript Student;

	// Token: 0x04003250 RID: 12880
	public RobotArmScript RobotArms;

	// Token: 0x04003251 RID: 12881
	public Transform OtherFinger;

	// Token: 0x04003252 RID: 12882
	public bool Updated;
}
