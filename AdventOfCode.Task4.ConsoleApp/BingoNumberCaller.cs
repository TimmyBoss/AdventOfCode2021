using System;
using System.Collections.Generic;
using System.Linq;

public class BingoNumberCaller
{
	private List<int> _callingNumbers = new List<int>();

	public BingoNumberCaller(string callingNumberString)
	{
		_callingNumbers = GetCallingNumbers(callingNumberString);
	}

	private List<int> GetCallingNumbers(string callingNumbersLine)
	{
		var callingNumbers = callingNumbersLine.Split(',');
		return callingNumbers.Select(int.Parse).ToList();
	}

	public List<int> Call()
	{
		return _callingNumbers;
	}
}
