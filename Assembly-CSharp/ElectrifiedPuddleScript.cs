using System;
using UnityEngine;

// Token: 0x020002A0 RID: 672
public class ElectrifiedPuddleScript : MonoBehaviour
{
	// Token: 0x06001410 RID: 5136 RVA: 0x000BF2E8 File Offset: 0x000BD4E8
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null && !component.Electrified)
			{
				component.Yandere.GazerEyes.ElectrocuteStudent(component);
				base.gameObject.SetActive(false);
				this.PowerSwitch.On = false;
			}
		}
		if (other.gameObject.layer == 13)
		{
			YandereScript component2 = other.gameObject.GetComponent<YandereScript>();
			if (component2 != null)
			{
				component2.StudentManager.Headmaster.Taze();
				component2.StudentManager.Headmaster.Heartbroken.Headmaster = false;
			}
		}
	}

	// Token: 0x04001E1F RID: 7711
	public PowerSwitchScript PowerSwitch;
}
