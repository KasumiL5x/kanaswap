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

public static class KanaTypeTo {
	public static string romaji( KanaType type ) {
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

		return "";
	}
}
