using UnityEngine;

public class GlobalKnifeArrayScript : MonoBehaviour
{
	public TimeStopKnifeScript[] Knives;

	public int ID;

	public void ActivateKnives()
	{
		TimeStopKnifeScript[] knives = Knives;
		foreach (TimeStopKnifeScript timeStopKnifeScript in knives)
		{
			if (timeStopKnifeScript != null)
			{
				timeStopKnifeScript.Unfreeze = true;
			}
		}
		ID = 0;
	}
}
