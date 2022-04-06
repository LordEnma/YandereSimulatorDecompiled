using System;
using UnityEngine;

// Token: 0x0200041C RID: 1052
public class SciFiTerminalScript : MonoBehaviour
{
	// Token: 0x06001C83 RID: 7299 RVA: 0x0014DF12 File Offset: 0x0014C112
	private void Start()
	{
		if (this.Student.StudentID != 65)
		{
			base.enabled = false;
			return;
		}
		this.RobotArms = this.Student.StudentManager.RobotArms;
	}

	// Token: 0x06001C84 RID: 7300 RVA: 0x0014DF44 File Offset: 0x0014C144
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

	// Token: 0x040032C8 RID: 13000
	public StudentScript Student;

	// Token: 0x040032C9 RID: 13001
	public RobotArmScript RobotArms;

	// Token: 0x040032CA RID: 13002
	public Transform OtherFinger;

	// Token: 0x040032CB RID: 13003
	public bool Updated;
}
