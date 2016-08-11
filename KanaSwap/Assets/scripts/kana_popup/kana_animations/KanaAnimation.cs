using UnityEngine;
using System.Collections.Generic;

public class KanaAnimation : MonoBehaviour {
	public Material lineMaterial;
	KanaAnimator lastAnimation_;
	GameObject lastKanaObject_;

	KanaAnimation() {
		lastAnimation_ = null;
		lastKanaObject_ = null;
	}

	void Start () {
	}

	public void clear() {
		// remove last active animation
		if( lastAnimation_ != null && lastKanaObject_ != null ) {
			lastAnimation_.deactivate();
			lastKanaObject_.SetActive(false);
		}
	}

	public void configure( string kanaType, string kana ) {
		// get kana type object
		var kanaTypeObject = transform.Find(kanaType);
		if( null == kanaTypeObject ) {
			Debug.Log("Could not find kana type object: " + kanaType);
			return;
		}

		// find specific kana
		var kanaObject = kanaTypeObject.Find(kana);
		if( null == kanaObject ) {
			Debug.Log("Could not find kana object: " + kana);
			return;
		}

		// get kana animator
		var animator = kanaObject.gameObject.GetComponent<KanaAnimator>();
		if( null == animator ) {
			Debug.Log("Found kana object but it was missing a KanaAnimator: " + kana);
			return;
		}

		// remove last active animation
		if( lastAnimation_ != null && lastKanaObject_ != null ) {
			lastAnimation_.deactivate();
			lastKanaObject_.SetActive(false);
		}

		// start current animation
		lastAnimation_ = animator;
		lastKanaObject_ = kanaObject.gameObject;
		kanaObject.gameObject.SetActive(true);
		animator.activate();
	}
}
