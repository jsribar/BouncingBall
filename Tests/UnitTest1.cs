using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			Assert.IsTrue(true);
		}

		[TestMethod]
		public void TestMethod2()
		{
			Assert.IsTrue(false);
		}
	}
}
