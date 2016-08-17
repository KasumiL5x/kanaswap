using UnityEngine;

public class KanaTooltipController : MonoBehaviour {
	public KanaTooltip Tooltip;
	public float TimeToActivate = 0.1f;
	float activateTimer_ = 0.0f;
	bool isMouseDown_ = false;
	bool isTooltipActive_ = false;
	GameObject hitObject_;

	void Start() {
		activateTimer_ = TimeToActivate;

		MouseHandler.addMouseHold(onMouseHold);
		MouseHandler.addMouseUp(onMouseUp);
	}

	void Update() {
		if( isMouseDown_ && !isTooltipActive_ ) {
			activateTimer_ -= Time.deltaTime;
			if( activateTimer_ < 0.0f ) {
				activateTimer_ = TimeToActivate;
				isTooltipActive_ = true;

				setupWith(hitObject_);
			}
		} else if( isMouseDown_ && isTooltipActive_ && hitObject_ != Tooltip.ActiveKana ) {
			setupWith(hitObject_);
		}
	}

	void setupWith( GameObject obj ) {
		var kana = obj.With(x => x.GetComponent<Kana>());
		if( null != kana ) {
			Tooltip.Do(x => x.activate(kana.CurrentType.toRomaji(), kana.transform.position, kana.gameObject));
		} else {
			Tooltip.Do(x => x.deactivate());
		}
	}

	void onMouseHold( GameObject hit ) {
		isMouseDown_ = true;
		hitObject_ = hit;
	}

	void onMouseUp( GameObject hit ) {
		isMouseDown_ = false;
		isTooltipActive_ = false;
		activateTimer_ = TimeToActivate;
		Tooltip.Do(x => x.deactivate());
	}
}
