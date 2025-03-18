using System;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	public class WaypointCircuit : MonoBehaviour
	{
		[Serializable]
		public class WaypointList
		{
			public WaypointCircuit circuit;

			public Transform[] items = new Transform[0];
		}

		public struct RoutePoint
		{
			public Vector3 position;

			public Vector3 direction;

			public RoutePoint(Vector3 position, Vector3 direction)
			{
				this.position = position;
				this.direction = direction;
			}
		}

		public WaypointList waypointList = new WaypointList();

		[SerializeField]
		private bool smoothRoute = true;

		private int numPoints;

		private Vector3[] points;

		private float[] distances;

		public float editorVisualisationSubsteps = 100f;

		private int p0n;

		private int p1n;

		private int p2n;

		private int p3n;

		private float i;

		private Vector3 P0;

		private Vector3 P1;

		private Vector3 P2;

		private Vector3 P3;

		public float Length { get; private set; }

		public Transform[] Waypoints => waypointList.items;

		private void Awake()
		{
			if (Waypoints.Length > 1)
			{
				CachePositionsAndDistances();
			}
			numPoints = Waypoints.Length;
		}

		public RoutePoint GetRoutePoint(float dist)
		{
			Vector3 routePosition = GetRoutePosition(dist);
			return new RoutePoint(routePosition, (GetRoutePosition(dist + 0.1f) - routePosition).normalized);
		}

		public Vector3 GetRoutePosition(float dist)
		{
			int i = 0;
			if (Length == 0f)
			{
				Length = distances[distances.Length - 1];
			}
			for (dist = Mathf.Repeat(dist, Length); distances[i] < dist; i++)
			{
			}
			p1n = (i - 1 + numPoints) % numPoints;
			p2n = i;
			this.i = Mathf.InverseLerp(distances[p1n], distances[p2n], dist);
			if (smoothRoute)
			{
				p0n = (i - 2 + numPoints) % numPoints;
				p3n = (i + 1) % numPoints;
				p2n %= numPoints;
				P0 = points[p0n];
				P1 = points[p1n];
				P2 = points[p2n];
				P3 = points[p3n];
				return CatmullRom(P0, P1, P2, P3, this.i);
			}
			p1n = (i - 1 + numPoints) % numPoints;
			p2n = i;
			return Vector3.Lerp(points[p1n], points[p2n], this.i);
		}

		private Vector3 CatmullRom(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float i)
		{
			return 0.5f * (2f * p1 + (-p0 + p2) * i + (2f * p0 - 5f * p1 + 4f * p2 - p3) * i * i + (-p0 + 3f * p1 - 3f * p2 + p3) * i * i * i);
		}

		private void CachePositionsAndDistances()
		{
			points = new Vector3[Waypoints.Length + 1];
			distances = new float[Waypoints.Length + 1];
			float num = 0f;
			for (int i = 0; i < points.Length; i++)
			{
				Transform transform = Waypoints[i % Waypoints.Length];
				Transform transform2 = Waypoints[(i + 1) % Waypoints.Length];
				if (transform != null && transform2 != null)
				{
					Vector3 position = transform.position;
					Vector3 position2 = transform2.position;
					points[i] = Waypoints[i % Waypoints.Length].position;
					distances[i] = num;
					num += (position - position2).magnitude;
				}
			}
		}

		private void OnDrawGizmos()
		{
			DrawGizmos(selected: false);
		}

		private void OnDrawGizmosSelected()
		{
			DrawGizmos(selected: true);
		}

		private void DrawGizmos(bool selected)
		{
			waypointList.circuit = this;
			if (Waypoints.Length <= 1)
			{
				return;
			}
			numPoints = Waypoints.Length;
			CachePositionsAndDistances();
			Length = distances[distances.Length - 1];
			Gizmos.color = (selected ? Color.yellow : new Color(1f, 1f, 0f, 0.5f));
			Vector3 from = Waypoints[0].position;
			if (smoothRoute)
			{
				for (float num = 0f; num < Length; num += Length / editorVisualisationSubsteps)
				{
					Vector3 routePosition = GetRoutePosition(num + 1f);
					Gizmos.DrawLine(from, routePosition);
					from = routePosition;
				}
				Gizmos.DrawLine(from, Waypoints[0].position);
			}
			else
			{
				for (int i = 0; i < Waypoints.Length; i++)
				{
					Vector3 position = Waypoints[(i + 1) % Waypoints.Length].position;
					Gizmos.DrawLine(from, position);
					from = position;
				}
			}
		}
	}
}
