using UnityEngine;
using System.Collections.Generic;

public class KanaBezierPoints : MonoBehaviour {
	public Bezier BezierCurve {get; private set;}
	List<Vector3> finalPoints_;
	public bool DebugDraw = false;

	public KanaBezierPoints() {
		BezierCurve = new Bezier();
	}

	void Start() {
		processPoints();
	}

	public void processPoints() {
		// get all child objects' XY positions as bezier sample points
		List<Vector2> originalPoints = new List<Vector2>();
		foreach( Transform child in transform ) {
			originalPoints.Add(new Vector2(child.position.x, child.position.y));
		}

		// create handles that when combined with the above points create a bezier that
		// goes through all of the points directly
		List<Vector2> firstCPs = new List<Vector2>();
		List<Vector2> secondCPs = new List<Vector2>();
		BezierGenerator.getCurveControlPoints(originalPoints, ref firstCPs, ref secondCPs);

		// create all of the final points for the bezier curve
		finalPoints_ = new List<Vector3>();
		finalPoints_.Add(new Vector3(originalPoints[0].x, originalPoints[0].y, 0.0f));
		for( int i = 0; i < firstCPs.Count; ++i ) {
			finalPoints_.Add(new Vector3(firstCPs[i].x, firstCPs[i].y, 0.0f));
			finalPoints_.Add(new Vector3(secondCPs[i].x, secondCPs[i].y, 0.0f));
			finalPoints_.Add(new Vector3(originalPoints[i+1].x, originalPoints[i+1].y, 0.0f));
		}
		finalPoints_.Add(new Vector3(originalPoints[originalPoints.Count-1].x, originalPoints[originalPoints.Count-1].y, 0.0f));

		// update the bezier curve's control points
		BezierCurve.setControlPoints(finalPoints_);
	}

	void OnDrawGizmos() {
		if( !DebugDraw ) {
			return;
		}

		processPoints();

		Gizmos.color = Color.green;
		foreach( var pnt in finalPoints_ ) {
			Gizmos.DrawWireSphere(pnt, 0.25f);
		}
	}
}
