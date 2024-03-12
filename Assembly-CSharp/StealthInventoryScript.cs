using UnityEngine;

public class StealthInventoryScript : MonoBehaviour
{
	public NotificationManagerScript NotificationManager;

	public bool CardboardBox;

	public bool BakeryKey;

	public bool DoorKey;

	public bool GateKey;

	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			Debug.Log("Just filled out the inventory.");
			CardboardBox = true;
			BakeryKey = true;
			DoorKey = true;
			GateKey = true;
			if (NotificationManager != null)
			{
				NotificationManager.CustomText = "You must find the key.";
				NotificationManager.DisplayNotification(NotificationType.Custom);
			}
		}
	}
}
