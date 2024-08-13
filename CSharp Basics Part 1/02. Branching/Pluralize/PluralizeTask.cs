namespace Pluralize;

public static class PluralizeTask
{
	public static string PluralizeRubles(int count)
	{
		int remain = count % 10;
		if (remain == 0 || remain > 4 || (count % 100 > 10 && count % 100 < 15)) return "рублей";
		if (remain == 1) return "рубль";
		return "рубля";
	}
}