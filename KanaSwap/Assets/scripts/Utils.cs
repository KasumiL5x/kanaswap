using UnityEngine;

public static class Utils {
	// http://answers.unity3d.com/answers/8502/view.html
	public static string getFullPath( GameObject obj ) {
		string path = "/" + obj.name;
		while( obj.transform.parent != null ) {
			obj = obj.transform.parent.gameObject;
			path = "/" + obj.name + path;
		}
		return path;
	}
}
