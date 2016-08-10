using System;

public enum KanaType {
	Invalid,
	A,I,U,E,O,
	KA,KI,KU,KE,KO,
	SA,SHI,SU,SE,SO,
	TA,CHI,TSU,TE,TO,
	NA,NI,NU,NE,NO,
	HA,HI,FU,HE,HO,
	MA,MI,MU,ME,MO,
	YA,YU,YO,
	RA,RI,RU,RE,RO,
	WA,WO,
	N
}

public static class KanaTypeMethods {
	public static string toJapanese( this KanaType type ) {
		switch( type ) {
			case KanaType.Invalid: {
				return "!";
			}
			case KanaType.A: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "あ" : "ア";
			}
			case KanaType.I: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "い" : "イ";
			}
			case KanaType.U: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "う" : "ウ";
			}
			case KanaType.E: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "え" : "エ";
			}
			case KanaType.O: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "お" : "オ";
			}
			case KanaType.KA: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "か" : "カ";
			}
			case KanaType.KI: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "き" : "キ";
			}
			case KanaType.KU: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "く" : "ク";
			}
			case KanaType.KE: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "け" : "ケ";
			}
			case KanaType.KO: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "こ" : "コ";
			}
			case KanaType.SA: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "さ" : "サ";
			}
			case KanaType.SHI: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "し" : "シ";
			}
			case KanaType.SU: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "す" : "ス";
			}
			case KanaType.SE: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "せ" : "セ";
			}
			case KanaType.SO: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "そ" : "ソ";
			}
			case KanaType.TA: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "た" : "タ";
			}
			case KanaType.CHI: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "ち" : "チ";
			}
			case KanaType.TSU: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "つ" : "ツ";
			}
			case KanaType.TE: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "て" : "テ";
			}
			case KanaType.TO: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "と" : "ト";
			}
			case KanaType.NA: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "な" : "ナ";
			}
			case KanaType.NI: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "に" : "ニ";
			}
			case KanaType.NU: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "ぬ" : "ヌ";
			}
			case KanaType.NE: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "ね" : "ネ";
			}
			case KanaType.NO: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "の" : "ノ";
			}
			case KanaType.HA: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "は" : "ハ";
			}
			case KanaType.HI: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "ひ" : "ヒ";
			}
			case KanaType.FU: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "ふ" : "フ";
			}
			case KanaType.HE: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "へ" : "ヘ";
			}
			case KanaType.HO: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "ほ" : "ホ";
			}
			case KanaType.MA: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "ま" : "マ";
			}
			case KanaType.MI: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "み" : "ミ";
			}
			case KanaType.MU: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "む" : "ム";
			}
			case KanaType.ME: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "め" : "メ";
			}
			case KanaType.MO: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "も" : "モ";
			}
			case KanaType.YA: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "や" : "ヤ";
			}
			case KanaType.YU: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "ゆ" : "ユ";
			}
			case KanaType.YO: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "よ" : "ヨ";
			}
			case KanaType.RA: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "ら" : "ラ";
			}
			case KanaType.RI: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "り" : "リ";
			}
			case KanaType.RU: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "る" : "ル";
			}
			case KanaType.RE: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "れ" : "レ";
			}
			case KanaType.RO: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "ろ" : "ロ";
			}
			case KanaType.WA: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "わ" : "ワ";
			}
			case KanaType.WO: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "を" : "ヲ";
			}
			case KanaType.N: {
				return (KanaMode.Hiragana == Settings.KANA_MODE) ? "ん" : "ン";
			}
		}

		throw new ArgumentException ("type");
	}

	public static string toRomaji( this KanaType type ) {
		switch( type ) {
			case KanaType.Invalid: {
				return "!";
			}
			case KanaType.A: {
				return "a";
			}
			case KanaType.I: {
				return "i";
			}
			case KanaType.U: {
				return "u";
			}
			case KanaType.E: {
				return "e";
			}
			case KanaType.O: {
				return "o";
			}
			case KanaType.KA: {
				return "ka";
			}
			case KanaType.KI: {
				return "ki";
			}
			case KanaType.KU: {
				return "ku";
			}
			case KanaType.KE: {
				return "ke";
			}
			case KanaType.KO: {
				return "ko";
			}
			case KanaType.SA: {
				return "sa";
			}
			case KanaType.SHI: {
				return "shi";
			}
			case KanaType.SU: {
				return "su";
			}
			case KanaType.SE: {
				return "se";
			}
			case KanaType.SO: {
				return "so";
			}
			case KanaType.TA: {
				return "ta";
			}
			case KanaType.CHI: {
				return "chi";
			}
			case KanaType.TSU: {
				return "tsu";
			}
			case KanaType.TE: {
				return "te";
			}
			case KanaType.TO: {
				return "to";
			}
			case KanaType.NA: {
				return "na";
			}
			case KanaType.NI: {
				return "ni";
			}
			case KanaType.NU: {
				return "nu";
			}
			case KanaType.NE: {
				return "ne";
			}
			case KanaType.NO: {
				return "no";
			}
			case KanaType.HA: {
				return "ha";
			}
			case KanaType.HI: {
				return "hi";
			}
			case KanaType.FU: {
				return "fu";
			}
			case KanaType.HE: {
				return "he";
			}
			case KanaType.HO: {
				return "ho";
			}
			case KanaType.MA: {
				return "ma";
			}
			case KanaType.MI: {
				return "mi";
			}
			case KanaType.MU: {
				return "mu";
			}
			case KanaType.ME: {
				return "me";
			}
			case KanaType.MO: {
				return "mo";
			}
			case KanaType.YA: {
				return "ya";
			}
			case KanaType.YU: {
				return "yu";
			}
			case KanaType.YO: {
				return "yo";
			}
			case KanaType.RA: {
				return "ra";
			}
			case KanaType.RI: {
				return "ri";
			}
			case KanaType.RU: {
				return "ru";
			}
			case KanaType.RE: {
				return "re";
			}
			case KanaType.RO: {
				return "ro";
			}
			case KanaType.WA: {
				return "wa";
			}
			case KanaType.WO: {
				return "wo";
			}
			case KanaType.N: {
				return "n";
			}
		}

		throw new ArgumentException("type");
	}
}
