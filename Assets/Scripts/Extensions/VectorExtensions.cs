using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public static class VectorExtensions
	{
		public static Vector2 ScalarMultiply(this Vector2 vector, float scalar) {
			return new Vector2(vector.x * scalar, vector.y * scalar);
		}
		
		public static Vector3 ScalarMultiply(this Vector3 vector, float scalar) {
			return new Vector3(vector.x * scalar, vector.y * scalar, vector.z * scalar);
		}
		
		public static Vector4 ScalarMultiply(this Vector4 vector, float scalar) {
			return new Vector4(vector.x * scalar, vector.y * scalar, 
				vector.z * scalar, vector.w * scalar);
		}
	}
}

