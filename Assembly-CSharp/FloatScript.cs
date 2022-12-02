using UnityEngine;

public class FloatScript : MonoBehaviour
{
	public bool Down;

	public float Float;

	public float Speed;

	public float Limit;

	public float DownLimit;

	public float UpLimit;

	private void Update()
	{
		if (!Down)
		{
			Float += Time.deltaTime * Speed;
			if (Float > Limit)
			{
				Down = true;
			}
		}
		else
		{
			Float -= Time.deltaTime * Speed;
			if (Float < -1f * Limit)
			{
				Down = false;
			}
		}
		base.transform.localPosition += new Vector3(0f, Float * Time.deltaTime, 0f);
		if (base.transform.localPosition.y > UpLimit)
		{
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, UpLimit, base.transform.localPosition.z);
		}
		if (base.transform.localPosition.y < DownLimit)
		{
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, DownLimit, base.transform.localPosition.z);
		}
	}
}
