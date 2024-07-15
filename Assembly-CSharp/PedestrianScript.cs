using UnityEngine;

public class PedestrianScript : MonoBehaviour
{
	public Animation MyAnim;

	public string[] WalkAnims;

	public float Speed;

	private void Start()
	{
		string animation = WalkAnims[Random.Range(0, WalkAnims.Length)];
		Speed = Random.Range(0.9f, 1.1f);
		MyAnim.Play(animation);
		MyAnim[animation].speed = Speed;
	}

	private void Update()
	{
		base.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
	}
}
