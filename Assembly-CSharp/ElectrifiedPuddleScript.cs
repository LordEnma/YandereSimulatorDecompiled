using System;
using UnityEngine;

// Token: 0x0200029E RID: 670
public class ElectrifiedPuddleScript : MonoBehaviour
{
	// Token: 0x06001408 RID: 5128 RVA: 0x000BEFD4 File Offset: 0x000BD1D4
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

	// Token: 0x04001E12 RID: 7698
	public PowerSwitchScript PowerSwitch;
}
