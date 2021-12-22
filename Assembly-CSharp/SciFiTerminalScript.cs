using System;
using UnityEngine;

// Token: 0x02000412 RID: 1042
public class SciFiTerminalScript : MonoBehaviour
{
	// Token: 0x06001C46 RID: 7238 RVA: 0x00148A5E File Offset: 0x00146C5E
	private void Start()
	{
		if (this.Student.StudentID != 65)
		{
			base.enabled = false;
			return;
		}
		this.RobotArms = this.Student.StudentManager.RobotArms;
	}

	// Token: 0x06001C47 RID: 7239 RVA: 0x00148A90 File Offset: 0x00146C90
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

	// Token: 0x0400322D RID: 12845
	public StudentScript Student;

	// Token: 0x0400322E RID: 12846
	public RobotArmScript RobotArms;

	// Token: 0x0400322F RID: 12847
	public Transform OtherFinger;

	// Token: 0x04003230 RID: 12848
	public bool Updated;
}
