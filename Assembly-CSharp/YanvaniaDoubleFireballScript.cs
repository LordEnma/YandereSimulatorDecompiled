using UnityEngine;

public class YanvaniaDoubleFireballScript : MonoBehaviour
{
	public GameObject Lavaball;

	public GameObject FirstLavaball;

	public GameObject SecondLavaball;

	public GameObject LightningEffect;

	public Transform Dracula;

	public bool SpawnedFirst;

	public bool SpawnedSecond;

	public float FirstPosition;

	public float SecondPosition;

	public int Direction;

	public float Timer;

	public float Speed;

	private void Start()
	{
		Object.Instantiate(LightningEffect, new Vector3(base.transform.position.x, 8f, 0f), Quaternion.identity);
		Direction = ((!(Dracula.position.x > base.transform.position.x)) ? 1 : (-1));
	}

	private void Update()
	{
		if (Timer > 1f && !SpawnedFirst)
		{
			Object.Instantiate(LightningEffect, new Vector3(base.transform.position.x, 7f, 0f), Quaternion.identity);
			FirstLavaball = Object.Instantiate(Lavaball, new Vector3(base.transform.position.x, 8f, 0f), Quaternion.identity);
			FirstLavaball.transform.localScale = Vector3.zero;
			SpawnedFirst = true;
		}
		if (FirstLavaball != null)
		{
			FirstLavaball.transform.localScale = Vector3.Lerp(FirstLavaball.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			FirstPosition += ((FirstPosition == 0f) ? Time.deltaTime : (FirstPosition * Speed));
			FirstLavaball.transform.position = new Vector3(FirstLavaball.transform.position.x + FirstPosition * (float)Direction, FirstLavaball.transform.position.y, FirstLavaball.transform.position.z);
			FirstLavaball.transform.eulerAngles = new Vector3(FirstLavaball.transform.eulerAngles.x, FirstLavaball.transform.eulerAngles.y, FirstLavaball.transform.eulerAngles.z - FirstPosition * (float)Direction * 36f);
		}
		if (Timer > 2f && !SpawnedSecond)
		{
			SecondLavaball = Object.Instantiate(Lavaball, new Vector3(base.transform.position.x, 7f, 0f), Quaternion.identity);
			SecondLavaball.transform.localScale = Vector3.zero;
			SpawnedSecond = true;
		}
		if (SecondLavaball != null)
		{
			SecondLavaball.transform.localScale = Vector3.Lerp(SecondLavaball.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			if (SecondPosition == 0f)
			{
				SecondPosition += Time.deltaTime;
			}
			else
			{
				SecondPosition += SecondPosition * Speed;
			}
			SecondLavaball.transform.position = new Vector3(SecondLavaball.transform.position.x + SecondPosition * (float)Direction, SecondLavaball.transform.position.y, SecondLavaball.transform.position.z);
			SecondLavaball.transform.eulerAngles = new Vector3(SecondLavaball.transform.eulerAngles.x, SecondLavaball.transform.eulerAngles.y, SecondLavaball.transform.eulerAngles.z - SecondPosition * (float)Direction * 36f);
		}
		Timer += Time.deltaTime;
		if (Timer > 10f)
		{
			if (FirstLavaball != null)
			{
				Object.Destroy(FirstLavaball);
			}
			if (SecondLavaball != null)
			{
				Object.Destroy(SecondLavaball);
			}
			Object.Destroy(base.gameObject);
		}
	}
}
