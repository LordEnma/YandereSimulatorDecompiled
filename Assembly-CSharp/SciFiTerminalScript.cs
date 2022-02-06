using System;
using UnityEngine;

// Token: 0x02000415 RID: 1045
public class SciFiTerminalScript : MonoBehaviour
{
	// Token: 0x06001C54 RID: 7252 RVA: 0x0014AFB2 File Offset: 0x001491B2
	private void Start()
	{
		if (this.Student.StudentID != 65)
		{
			base.enabled = false;
			return;
		}
		this.RobotArms = this.Student.StudentManager.RobotArms;
	}

	// Token: 0x06001C55 RID: 7253 RVA: 0x0014AFE4 File Offset: 0x001491E4
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

	// Token: 0x04003249 RID: 12873
	public StudentScript Student;

	// Token: 0x0400324A RID: 12874
	public RobotArmScript RobotArms;

	// Token: 0x0400324B RID: 12875
	public Transform OtherFinger;

	// Token: 0x0400324C RID: 12876
	public bool Updated;
}
