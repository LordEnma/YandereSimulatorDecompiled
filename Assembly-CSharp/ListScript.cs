using UnityEngine;

public class ListScript : MonoBehaviour
{
	public Transform[] List;

	public Transform[] Week2List;

	public bool PrintDebug;

	public bool AutoFill;

	public bool Patrols;

	public void Start()
	{
		if (Patrols && DateGlobals.Week == 2)
		{
			List[88] = Week2List[88];
		}
		if (!AutoFill)
		{
			return;
		}
		int num = 1;
		for (num = 1; num < List.Length; num++)
		{
			if (base.transform.childCount > 0)
			{
				List[num] = base.transform.GetChild(num - 1);
			}
		}
	}
}
