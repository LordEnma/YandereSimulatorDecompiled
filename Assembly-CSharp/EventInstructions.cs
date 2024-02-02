using System;
using UnityEngine;

[Serializable]
public struct EventInstructions
{
	public InstructionType Type;

	public Transform[] Destination;

	public string[] Anim;

	public string Dialogue;

	public AudioClip Audio;

	public NextCriteriaType NextCritera;

	public float TimeLimit;

	public int SpecialCase;

	public bool Rush;
}
