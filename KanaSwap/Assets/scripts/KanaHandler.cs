﻿using UnityEngine;
using System.Collections.Generic;

public class KanaHandler : MonoBehaviour {
	public void swap( Kana a, Kana b ) {
		var tmp = a.CurrentType;
		a.CurrentType = b.CurrentType;
		b.CurrentType = tmp;

		a.forceUpdateText();
		b.forceUpdateText();

		a.updateColor();
		b.updateColor();

		// don't bother trying to validate if a or b are wrong
		if( a.CurrentType != a.ActualType || b.CurrentType != b.ActualType ) {
			return;
		}
		if( isCorrect() ) {
			// todo: something when they are correct (tick pops up? anything?)
		}
	}

	public void reset() {
		foreach( Transform xform in transform ) {
			var kana = xform.gameObject.GetComponent<Kana>();
			if( null == kana ) {
				Debug.Log(Utils.getFullPath(xform.gameObject) + " is missing a Kana.");
				continue;
			}

			kana.reset();
		}

		updateAllText();
	}
	
	public void shuffle() {
		int childCount = transform.childCount;

		// populate ordered array from 0..childCount
		int[] candidates = new int[childCount];
		for( int i = 0; i < childCount; ++i ) {
			candidates[i] = i+1; // zero = invalid, so skip it
		}

		// shuffle the array (fisher-yates)
		System.Random rand = new System.Random();
		int len = candidates.Length;
		while( len > 1 ) {
			int idx = rand.Next(len--);
			int tmp = candidates[len];
			candidates[len] = candidates[idx];
			candidates[idx] = tmp;
		}

		// assign kana randomly based on array
		for( int i = 0; i < transform.childCount; ++i ) {
			var kana = transform.GetChild(i).With(x => x.GetComponent<Kana>());
			if( null == kana ) {
				Debug.Log(Utils.getFullPath(transform.GetChild(i).gameObject) + " is missing a Kana.");
				continue;
			}

			kana.CurrentType = (KanaType)candidates[i];
			kana.updateColor();
		}

		updateAllText();
	}

	public bool isCorrect() {
		foreach( Transform xform in transform ) {
			var kana = xform.gameObject.GetComponent<Kana>();
			if( null == kana ) {
				Debug.Log(Utils.getFullPath(xform.gameObject) + " is missing a Kana.");
				return false;
			}

			if( !kana.isCorrect() ) {
				return false;
			}
		}
		return true;
	}

	public void updateAllText() {
		foreach( Transform xform in transform ) {
			xform.gameObject.GetComponent<Kana>().Do(x => x.forceUpdateText());
		}
	}
}
