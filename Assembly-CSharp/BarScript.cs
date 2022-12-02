using UnityEngine;

public class BarScript : MonoBehaviour
{
	public float Speed;

	public float Goal;

	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 1f, 1f);
	}

	private void Update()
	{
		if (Goal == 0f)
		{
			base.transform.localScale = new Vector3(base.transform.localScale.x + Speed * Time.deltaTime, 1f, 1f);
			if ((double)base.transform.localScale.x > 0.1)
			{
				base.transform.localScale = new Vector3(0f, 1f, 1f);
			}
		}
		else
		{
			Speed += Time.deltaTime;
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(Goal, 1f, 1f), Time.deltaTime * Speed);
		}
	}
}
