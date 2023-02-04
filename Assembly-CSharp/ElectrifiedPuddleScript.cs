using UnityEngine;

public class ElectrifiedPuddleScript : MonoBehaviour
{
	public PowerSwitchScript PowerSwitch;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null)
			{
				Debug.Log(component.Name + " came into contact with an electrified puddle!");
				if (!component.Electrified && component.Yandere.Pursuer != component)
				{
					component.Yandere.GazerEyes.ElectrocuteStudent(component);
					base.gameObject.SetActive(value: false);
					if (PowerSwitch != null)
					{
						PowerSwitch.On = false;
					}
				}
			}
		}
		if (other.gameObject.layer != 13)
		{
			return;
		}
		YandereScript component2 = other.gameObject.GetComponent<YandereScript>();
		if (component2 != null && !component2.WearingRaincoat)
		{
			if (component2.TimeSkipping)
			{
				component2.StudentManager.Clock.EndTimeSkip();
				component2.CanMoveTimer = 0f;
			}
			component2.StudentManager.Headmaster.Taze();
			component2.StudentManager.Headmaster.Heartbroken.Headmaster = false;
		}
	}
}
