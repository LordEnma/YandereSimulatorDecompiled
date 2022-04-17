using System;
using UnityEngine;

// Token: 0x0200041C RID: 1052
public class SciFiTerminalScript : MonoBehaviour
{
	// Token: 0x06001C87 RID: 7303 RVA: 0x0014E322 File Offset: 0x0014C522
	private void Start()
	{
		if (this.Student.StudentID != 65)
		{
			base.enabled = false;
			return;
		}
		this.RobotArms = this.Student.StudentManager.RobotArms;
	}

	// Token: 0x06001C88 RID: 7304 RVA: 0x0014E354 File Offset: 0x0014C554
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

	// Token: 0x040032D3 RID: 13011
	public StudentScript Student;

	// Token: 0x040032D4 RID: 13012
	public RobotArmScript RobotArms;

	// Token: 0x040032D5 RID: 13013
	public Transform OtherFinger;

	// Token: 0x040032D6 RID: 13014
	public bool Updated;
}
