using UnityEngine;
using System;
using System.Collections.Generic;

public class KanaAnimatorGroup {
	public GameObject obj;
	public DrawableCurve curve;
	public KanaBezierPoints points;
	public float time;

	public KanaAnimatorGroup() {
	}
}

public class KanaAnimator : MonoBehaviour {
	public CurveRenderer curveRenderer;
	List<KanaAnimatorGroup> strokes_;
	bool isAnimating_ = false;     /**< If any animation is playing a all. */
	float animationTimer_ = 0.0f;  /**< Timer for the current animation (counts down). */
	int animationIndex_ = 0;       /**< Index of the current stroke (strokes_) being animated. */
	public float HoldDelay = 1.0f; /**< Delay after all animations are complete. */
	float holdTimer_ = 0.0f;       /**< Timer for hold delay. */
	bool isHolding_ = false;       /**< True if holding after animations complete. */
	public float PauseDelay = 0.25f; /**< Delay after a single stroke is complete before the next starts. */
	float pauseTimer_ = 0.0f;       /**< Timer for pause delay. */
	bool isPausing_ = false;        /**< True if pausing animations. */

	public KanaAnimator() {
		strokes_ = new List<KanaAnimatorGroup>();
		holdTimer_ = HoldDelay;
		pauseTimer_ = PauseDelay;
	}

	void Start() {
	}
	
	void Update () {
		if( !isAnimating_ ) {
			return;
		}

		if( isPausing_ ) {
			pauseTimer_ -= Time.deltaTime;
			if( pauseTimer_ <= 0.0f ) {
				isPausing_ = false;
				pauseTimer_ = PauseDelay;
			}
		} else if( isHolding_ ) {
			holdTimer_ -= Time.deltaTime;
			// reset holding
			if( holdTimer_ <= 0.0f ) {
				clearAllStrokes();
				isHolding_ = false;
				holdTimer_ = HoldDelay;
			}
		} else {
			// current animating stroke
			var currStroke = strokes_[animationIndex_];

			// timer and percentage through time
			animationTimer_ -= Time.deltaTime;
			float percent = 1.0f - (animationTimer_ / currStroke.time);

			// compute partial bezier and update curve
			var drawingPoints = currStroke.points.BezierCurve.samplePoints(10, percent);
			currStroke.curve.setPoints(drawingPoints);

			// terminate animation timer
			if( animationTimer_ <= 0.0f ) {
				animationIndex_ += 1; // move to next animation

				// reset animations and move to hold phase if complete
				if( strokes_.Count == animationIndex_ ) {
					animationIndex_ = 0;
					animationTimer_ = strokes_[0].time;
					isHolding_ = true;
					holdTimer_ = HoldDelay;
				} else {
					// set next animation time
					animationTimer_ = strokes_[animationIndex_].time;
					isPausing_ = true; // pause after each stroke
				}
			}
		}

	}

	public void activate() {
		if( 0 == strokes_.Count ) {
			processStrokes();
		}

		foreach( var stroke in strokes_ ) {
			curveRenderer.addCurve(Utils.getFullPath(stroke.obj), stroke.curve);
		}

		isAnimating_ = true;
		animationTimer_ = strokes_[0].time;
		animationIndex_ = 0;
		isHolding_ = false;
		holdTimer_ = HoldDelay;
	}

	void clearAllStrokes() {
		foreach( var stroke in strokes_ ) {
			stroke.curve.clearPoints();
		}
	}

	public void deactivate() {
		foreach( var grp in strokes_ ) {
			curveRenderer.removeCurve(Utils.getFullPath(grp.obj));
		}

		clearAllStrokes();

		isAnimating_ = false;
		animationTimer_ = 0.0f;
		animationIndex_ = 0;
		isHolding_ = false;
		holdTimer_ = HoldDelay;
	}

	void processStrokes() {
		for( int i = 0; i < transform.childCount; ++i ) {
			var child = transform.GetChild(i);
			if( "text" == child.name ) {
				continue;
			}

			var grp = new KanaAnimatorGroup();
			grp.obj = child.gameObject;
			grp.curve = grp.obj.GetComponent<DrawableCurve>();
			grp.points = grp.obj.GetComponent<KanaBezierPoints>();
			grp.time = grp.points.BezierCurve.length() / Settings.KANA_ANIMATION_SCALE;
			//Debug.Log (grp.obj.name + ": " + grp.time);
			if( null == grp.curve ) {
				Debug.Log("Stroke is missing a curve (" + Utils.getFullPath(grp.obj) + ")");
				continue;
			}
			if( null == grp.points ) {
				Debug.Log("Stroke is missing points (" + Utils.getFullPath(grp.obj) + ")");
				continue;
			}
			strokes_.Add(grp);
		}
	}
}
