using UnityEngine;

public class InfoChanWindowScript : MonoBehaviour
{
	public DropsScript DropMenu;

	public Transform DropPoint;

	public GameObject[] Drops;

	public int[] ItemsToDrop;

	public int Orders;

	public int ID;

	public float Rotation;

	public float Timer;

	public bool Dropped;

	public bool Drop;

	public bool Test;

	public bool Open = true;

	private void Update()
	{
		if (Drop)
		{
			Rotation = Mathf.Lerp(Rotation, Drop ? (-90f) : 0f, Time.deltaTime * 10f);
			base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, Rotation, base.transform.localEulerAngles.z);
			Timer += Time.deltaTime;
			if (Timer > 1f)
			{
				if ((float)Orders > 0f)
				{
					if (ItemsToDrop[Orders] < 15)
					{
						GameObject gameObject = Object.Instantiate(Drops[ItemsToDrop[Orders]], DropPoint.position, Quaternion.identity);
						gameObject.name = DropMenu.DropNames[ItemsToDrop[Orders]];
						if (gameObject.GetComponent<PickUpScript>() != null)
						{
							gameObject.GetComponent<PickUpScript>().InstantiatedObject = true;
						}
					}
					else
					{
						Debug.Log("Dropping Garrote!");
						Drops[ItemsToDrop[Orders]].transform.position = DropPoint.position;
						Drops[ItemsToDrop[Orders]].GetComponent<WeaponScript>().KinematicTimer = 0f;
						Drops[ItemsToDrop[Orders]].GetComponent<Rigidbody>().isKinematic = false;
						Drops[ItemsToDrop[Orders]].GetComponent<Rigidbody>().useGravity = true;
					}
					Timer = 0f;
					Orders--;
				}
				else
				{
					Open = false;
					if (Timer > 3f)
					{
						base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, 0f, base.transform.localEulerAngles.z);
						Drop = false;
					}
				}
			}
		}
		if (Test)
		{
			DropObject();
		}
	}

	public void DropObject()
	{
		Rotation = 0f;
		Timer = 0f;
		Dropped = false;
		Test = false;
		Drop = true;
		Open = true;
	}
}
