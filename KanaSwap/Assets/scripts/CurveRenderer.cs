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
		// GL.PushMatrix();

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

		// tris
		// GL.Begin(GL.TRIANGLES);
		// GL.wireframe = true;
		// GL.Color(new Color(0.0f, 0.0f, 0.0f, 1.0f));
		// for( int i = 0; i < points.Count-3; i += 3 ) {
		// 	GL.Vertex3(points[i+0].x, points[i+0].y, points[i+0].z);
		// 	GL.Vertex3(points[i+1].x, points[i+1].y, points[i+1].z);
		// 	GL.Vertex3(points[i+2].x, points[i+2].y, points[i+2].z);
		// }
		// GL.End();

		// quads
		// GL.Begin(GL.QUADS);
		// GL.wireframe = true;
		// GL.Color(new Color(0.0f, 0.0f, 0.0f, 1.0f));
		// for( int i = 0; i < points.Count-3; i += 3 ) {
		// 	GL.Vertex3(points[i+0].x, points[i+0].y, points[i+0].z);
		// 	GL.Vertex3(points[i+1].x, points[i+1].y, points[i+1].z);
		// 	GL.Vertex3(points[i+2].x, points[i+2].y, points[i+2].z);
		// 	GL.Vertex3(points[i+3].x, points[i+3].y, points[i+3].z);
		// }
		// GL.End();

		// lines
		// GL.Begin(GL.LINES);
		// GL.Color(new Color(0.0f, 0.0f, 0.0f, 1.0f));
		// for( int i = 0; i < points.Count; ++i ) {
		// 	GL.Vertex3(points[i].x, points[i].y, points[i].z);
		// }
		// GL.End();
		// GL.PopMatrix();
	}
}
