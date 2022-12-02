using System;
using UnityEngine;

internal class ToiletFlushScript : MonoBehaviour
{
	[Header("=== Toilet Related ===")]
	public GameObject Toilet;

	private GameObject toilet;

	private static System.Random random = new System.Random();

	private StudentManagerScript StudentManager;
}
