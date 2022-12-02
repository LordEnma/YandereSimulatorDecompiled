using UnityEngine;

public class YanvaniaTripleFireballScript : MonoBehaviour
{
	public Transform[] Fireballs;

	public Transform Dracula;

	public int Direction;

	public float Speed;

	public float Timer;

	private void Start()
	{
		Direction = ((!(Dracula.position.x > base.transform.position.x)) ? 1 : (-1));
	}

	private void Update()
	{
		Transform transform = Fireballs[1];
		Transform transform2 = Fireballs[2];
		Transform transform3 = Fireballs[3];
		if (transform != null)
		{
			transform.position = new Vector3(transform.position.x, Mathf.MoveTowards(transform.position.y, 7.5f, Time.deltaTime * Speed), transform.position.z);
		}
		if (transform2 != null)
		{
			transform2.position = new Vector3(transform2.position.x, Mathf.MoveTowards(transform2.position.y, 7.16666f, Time.deltaTime * Speed), transform2.position.z);
		}
		if (transform3 != null)
		{
			transform3.position = new Vector3(transform3.position.x, Mathf.MoveTowards(transform3.position.y, 6.83333f, Time.deltaTime * Speed), transform3.position.z);
		}
		for (int i = 1; i < 4; i++)
		{
			Transform transform4 = Fireballs[i];
			if (transform4 != null)
			{
				transform4.position = new Vector3(transform4.position.x + (float)Direction * Time.deltaTime * Speed, transform4.position.y, transform4.position.z);
			}
		}
		Timer += Time.deltaTime;
		if (Timer > 10f)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
