using UnityEngine;

public class CirnoIceAttackScript : MonoBehaviour
{
	public GameObject IceExplosion;

	private void Start()
	{
		Physics.IgnoreLayerCollision(18, 13, true);
		Physics.IgnoreLayerCollision(18, 18, true);
	}

	private void OnCollisionEnter(Collision collision)
	{
		Object.Instantiate(IceExplosion, base.transform.position, Quaternion.identity);
		if (collision.gameObject.layer == 9)
		{
			StudentScript component = collision.gameObject.GetComponent<StudentScript>();
			if (component != null && component.StudentID != 1)
			{
				component.SpawnAlarmDisc();
				component.BecomeRagdoll();
			}
		}
		Object.Destroy(base.gameObject);
	}
}
