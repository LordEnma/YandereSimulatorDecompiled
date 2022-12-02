using UnityEngine;

public class RuntimeAnimRetarget : MonoBehaviour
{
	public GameObject Source;

	public GameObject Target;

	private Component[] SourceSkelNodes;

	private Component[] TargetSkelNodes;

	private void Start()
	{
		Debug.Log(Source.name);
		SourceSkelNodes = Source.GetComponentsInChildren<Component>();
		TargetSkelNodes = Target.GetComponentsInChildren<Component>();
	}

	private void LateUpdate()
	{
		TargetSkelNodes[1].transform.localPosition = SourceSkelNodes[1].transform.localPosition;
		for (int i = 0; i < 154; i++)
		{
			TargetSkelNodes[i].transform.localRotation = SourceSkelNodes[i].transform.localRotation;
		}
	}
}
