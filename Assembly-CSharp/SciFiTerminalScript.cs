using System;
using UnityEngine;

// Token: 0x0200041D RID: 1053
public class SciFiTerminalScript : MonoBehaviour
{
	// Token: 0x06001C8E RID: 7310 RVA: 0x0014EB2A File Offset: 0x0014CD2A
	private void Start()
	{
		if (this.Student.StudentID != 65)
		{
			base.enabled = false;
			return;
		}
		this.RobotArms = this.Student.StudentManager.RobotArms;
	}

	// Token: 0x06001C8F RID: 7311 RVA: 0x0014EB5C File Offset: 0x0014CD5C
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

	// Token: 0x040032E2 RID: 13026
	public StudentScript Student;

	// Token: 0x040032E3 RID: 13027
	public RobotArmScript RobotArms;

	// Token: 0x040032E4 RID: 13028
	public Transform OtherFinger;

	// Token: 0x040032E5 RID: 13029
	public bool Updated;
}
