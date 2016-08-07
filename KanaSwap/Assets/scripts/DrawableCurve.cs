using UnityEngine;
using System.Collections.Generic;

public class DrawableCurve : MonoBehaviour {
	public float CurveWidth = 0.25f;
	List<Vector3> trianglePoints_;

	public DrawableCurve() {
		trianglePoints_ = new List<Vector3>();
	}

	public List<Vector3> TrianglePoints {
		get{ return trianglePoints_; }
	}

	public void clearPoints() {
		trianglePoints_ = new List<Vector3>();
	}

	public void setPoints( List<BezierPointTangent> bezierPoints ) {
		if( bezierPoints.Count < 2 ) {
			return;
		}

		trianglePoints_.Clear();

		for( int i = 1; i < bezierPoints.Count; ++i ) {
			var p0 = bezierPoints[i-1].point;
			var p1 = bezierPoints[i].point;

			var p0Tan = bezierPoints[i-1].tangent; p0Tan.Normalize();
			var p1Tan = bezierPoints[i].tangent; p1Tan.Normalize();
			var p0Perp = Vector3.Cross(p0Tan, Vector3.forward); p0Perp.Normalize();
			var p1Perp = Vector3.Cross(p1Tan, Vector3.forward); p1Perp.Normalize();
			var BL = p0 - p0Perp * CurveWidth;
			var BR = p0 + p0Perp * CurveWidth;
			var TR = p1 + p1Perp * CurveWidth;
			var TL = p1 - p1Perp * CurveWidth;
			trianglePoints_.Add(BR);
			trianglePoints_.Add(BL);
			trianglePoints_.Add(TL);
			trianglePoints_.Add(TL);
			trianglePoints_.Add(TR);
			trianglePoints_.Add(BR);

			// Debug.DrawRay(p0, p0Tan, Color.red, 10.0f);
			// Debug.DrawRay(p0, p0Perp, Color.green, 10.0f);
		}
	}
}
