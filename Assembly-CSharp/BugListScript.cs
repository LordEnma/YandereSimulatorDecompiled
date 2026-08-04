using UnityEngine;

public class BugListScript : MonoBehaviour
{
	public BugScript[] Bugs;

	public int Week;

	public void Start()
	{
		if (DateGlobals.Week != Week)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	public void SaveBugsPlaced()
	{
		BugScript[] bugs = Bugs;
		foreach (BugScript bugScript in bugs)
		{
			if (bugScript != null)
			{
				bugScript.RememberIfPlaced();
			}
		}
	}
}
