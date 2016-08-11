using UnityEngine;
using System.Collections.Generic;

public class CurveRenderer : MonoBehaviour {
	public Shader TheShader;
	static Material material_;
	List<Vector3> points;

	Dictionary<string, DrawableCurve> drawableCurves_;

	public CurveRenderer() {
		drawableCurves_ = new Dictionary<string, DrawableCurve>();
	}

	public void addCurve( string name, DrawableCurve curve ) {
		drawableCurves_[name] = curve;
	}

	public void removeCurve( string name ) {
		drawableCurves_.Remove(name);
	}

	public void removeAllCurves() {
		drawableCurves_.Clear();
	}

	void Start() {
		material_ = new Material(TheShader);
	}

	void OnPostRender() {
		material_.SetPass(0);

		GL.Begin(GL.TRIANGLES);
		// GL.wireframe = true;
		GL.Color(new Color(0.0f, 0.0f, 0.0f, 1.0f));
		foreach( var curve in drawableCurves_ ) {
			for( int i = 0; i < curve.Value.TrianglePoints.Count-2; i += 3 ) {
				var p0 = curve.Value.TrianglePoints[i+0];
				var p1 = curve.Value.TrianglePoints[i+1];
				var p2 = curve.Value.TrianglePoints[i+2];
				GL.Vertex3(p0.x, p0.y, p0.z);
				GL.Vertex3(p1.x, p1.y, p1.z);
				GL.Vertex3(p2.x, p2.y, p2.z);
			}
		}
		GL.End();
	}
}
