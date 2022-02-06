using System;
using UnityEngine;

// Token: 0x0200029F RID: 671
public class ElectrifiedPuddleScript : MonoBehaviour
{
	// Token: 0x0600140C RID: 5132 RVA: 0x000BF390 File Offset: 0x000BD590
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

	// Token: 0x04001E1C RID: 7708
	public PowerSwitchScript PowerSwitch;
}
