using UnityEngine;

public class TrailScript : MonoBehaviour
{
	private void Start()
	{
		Physics.IgnoreCollision(GameObject.Find("YandereChan").GetComponent<Collider>(), GetComponent<Collider>());
		Physics.IgnoreLayerCollision(20, 8, ignore: false);
		Physics.IgnoreLayerCollision(8, 20, ignore: false);
		Physics.IgnoreLayerCollision(20, 15, ignore: true);
		Physics.IgnoreLayerCollision(15, 20, ignore: true);
		Object.Destroy(this);
	}
}
