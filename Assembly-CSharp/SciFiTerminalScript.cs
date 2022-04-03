using System;
using UnityEngine;

// Token: 0x0200041B RID: 1051
public class SciFiTerminalScript : MonoBehaviour
{
	// Token: 0x06001C7D RID: 7293 RVA: 0x0014DC2E File Offset: 0x0014BE2E
	private void Start()
	{
		if (this.Student.StudentID != 65)
		{
			base.enabled = false;
			return;
		}
		this.RobotArms = this.Student.StudentManager.RobotArms;
	}

	// Token: 0x06001C7E RID: 7294 RVA: 0x0014DC60 File Offset: 0x0014BE60
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

	// Token: 0x040032C5 RID: 12997
	public StudentScript Student;

	// Token: 0x040032C6 RID: 12998
	public RobotArmScript RobotArms;

	// Token: 0x040032C7 RID: 12999
	public Transform OtherFinger;

	// Token: 0x040032C8 RID: 13000
	public bool Updated;
}
