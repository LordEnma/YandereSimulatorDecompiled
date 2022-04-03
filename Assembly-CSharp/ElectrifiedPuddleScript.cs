using System;
using UnityEngine;

// Token: 0x020002A1 RID: 673
public class ElectrifiedPuddleScript : MonoBehaviour
{
	// Token: 0x0600141D RID: 5149 RVA: 0x000C02B4 File Offset: 0x000BE4B4
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null && !component.Electrified)
			{
				component.Yandere.GazerEyes.ElectrocuteStudent(component);
				base.gameObject.SetActive(false);
				if (this.PowerSwitch != null)
				{
					this.PowerSwitch.On = false;
				}
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

	// Token: 0x04001E49 RID: 7753
	public PowerSwitchScript PowerSwitch;
}
