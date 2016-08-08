using System;

public enum KanaMode {
	Hiragana,
	Katakana
}

public static class KanaModeMethods {
	public static string toRomaji( this KanaMode mode ) {
		switch( mode ) {
			case KanaMode.Hiragana: {
				return "hiragana";
			}
			case KanaMode.Katakana: {
				return "katakana";
			}
		}

		throw new ArgumentException ("mode");
	}
}