using UnityEngine;

public class ListScript : MonoBehaviour
{
	public Transform[] List;

	public bool AutoFill;

	public void Start()
	{
		if (AutoFill)
		{
			int num = 1;
			for (num = 1; num < List.Length; num++)
			{
				List[num] = base.transform.GetChild(num - 1);
			}
		}
	}
}
