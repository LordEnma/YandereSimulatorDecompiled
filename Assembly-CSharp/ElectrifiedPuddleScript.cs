using System;
using UnityEngine;

// Token: 0x020002A3 RID: 675
public class ElectrifiedPuddleScript : MonoBehaviour
{
	// Token: 0x06001429 RID: 5161 RVA: 0x000C0C24 File Offset: 0x000BEE24
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null && !component.Electrified && component.Yandere.Pursuer != component)
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

	// Token: 0x04001E5C RID: 7772
	public PowerSwitchScript PowerSwitch;
}
