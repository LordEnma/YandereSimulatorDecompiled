using System;
using UnityEngine;

// Token: 0x02000411 RID: 1041
public class SciFiTerminalScript : MonoBehaviour
{
	// Token: 0x06001C3E RID: 7230 RVA: 0x00148182 File Offset: 0x00146382
	private void Start()
	{
		if (this.Student.StudentID != 65)
		{
			base.enabled = false;
			return;
		}
		this.RobotArms = this.Student.StudentManager.RobotArms;
	}

	// Token: 0x06001C3F RID: 7231 RVA: 0x001481B4 File Offset: 0x001463B4
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

	// Token: 0x04003202 RID: 12802
	public StudentScript Student;

	// Token: 0x04003203 RID: 12803
	public RobotArmScript RobotArms;

	// Token: 0x04003204 RID: 12804
	public Transform OtherFinger;

	// Token: 0x04003205 RID: 12805
	public bool Updated;
}
