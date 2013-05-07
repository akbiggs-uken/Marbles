#define DEBUG

using System;
using System.Diagnostics;

public static class DebugUtils
{
	[Conditional("DEBUG")]
	public static void Assert(bool condition) {
		Assert(condition, "");
	}
	
	[Conditional("DEBUG")]
	public static void Assert(bool condition, string failureMessage) {
		if (!condition)
			throw new Exception(failureMessage);
	}
}

