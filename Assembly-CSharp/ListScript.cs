using UnityEngine;

public class ListScript : MonoBehaviour
{
	public Transform[] List;

	public bool PrintDebug;

	public bool AutoFill;

	public void Start()
	{
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
