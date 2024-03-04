using NUnit.Framework;

namespace ConsoleApp3.Tests
{
	[SetUpFixture]
	public class Test
	{
		[SetUp]
		public void Setup()
		{
			Environment.SetEnvironmentVariable("ClientId", "TestClientId");
			Environment.SetEnvironmentVariable("ClientSecret", "TestClientSecret");
			Environment.SetEnvironmentVariable("ClientTenantId", "TestClientTenantId");
		}

		[TearDown]
		public void TearDown()
		{
			Environment.SetEnvironmentVariable("ClientId", null);
			Environment.SetEnvironmentVariable("ClientSecret", null);
			Environment.SetEnvironmentVariable("ClientTenantId", null);
		}

		[Test]
		public void Test1()
		{
			Assert.That(Environment.GetEnvironmentVariable("ClientId"), Is.Not.Null.Or.Empty);
		}
	}
}