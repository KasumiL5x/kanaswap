using UnityEngine;

public class KanaTooltipController : MonoBehaviour {
	public KanaTooltip Tooltip;

	void Start() {
		MouseHandler.addMouseDown(onMouseDown);
		MouseHandler.addMouseHold(onMouseHold);
		MouseHandler.addMouseUp(onMouseUp);
	}

	void onMouseDown( GameObject hit ) {
		var kana = hit.With(x => x.GetComponent<Kana>());
		if( null == kana ) {
			return;
		}

		Tooltip.Do(x => x.activate(kana.CurrentType.toRomaji(), kana.transform.position, kana.gameObject));
	}

	void onMouseHold( GameObject hit ) {
		var kana = hit.With(x => x.GetComponent<Kana>());
		if( null == kana ) {
			Tooltip.Do(x => x.deactivate());
		} else if( hit != Tooltip.ActiveKana ) {
			Tooltip.Do(x => x.activate(kana.CurrentType.toRomaji(), kana.transform.position, kana.gameObject));
		}
	}

	void onMouseUp( GameObject hit ) {
		Tooltip.Do(x => x.deactivate());
	}
}
