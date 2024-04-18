using UnityEngine;

public class AlternateTimelineEndingScript : MonoBehaviour
{
	public Animation FunGirlAnim;

	private void Start()
	{
		FunGirlAnim["f02_funGirlHold_00"].speed = 0.2f;
	}

	private void Update()
	{
	}
}
