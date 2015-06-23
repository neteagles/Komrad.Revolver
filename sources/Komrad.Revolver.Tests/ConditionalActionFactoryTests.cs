namespace Komrad.Revolver.Tests
{
    using Annotations.Actions;
    using NUnit.Framework;

    [TestFixture]
    public class ConditionalActionFactoryTests
    {
        private static ConditionalActionFactory _factory;

        [TestFixtureSetUp]
        public static void FixtureSetUp()
        {
            _factory = new ConditionalActionFactory();
        }

        [Test]
        [TestCase("[DatabaseType]=mysql")]
        public void ShouldCorrectlyParseReplaceAction(string input)
        {
            var action = _factory.Create(input);

            Assert.IsNotNull(action);
            Assert.IsInstanceOf<ReplaceAction>(action);
            Assert.AreEqual(input, action.Raw);

            var ra = (ReplaceAction) action;

            Assert.AreEqual("DatabaseType", ra.Placeholder);
            Assert.AreEqual("mysql", ra.Value);
        }

        [Test]
        [TestCase("[ DatabaseType]=mysql")]
        [TestCase("[DatabaseType ]=mysql")]
        [TestCase("[DatabaseType] =mysql")]
        [TestCase("[DatabaseType]= mysql")]
        [TestCase("[DatabaseType]=")]
        [TestCase("[]=mysql")]
        [TestCase("[]=")]
        public void ShouldNotParseMalformedInputString(string input)
        {
            var action = _factory.Create(input);

            Assert.IsNull(action);
        }
    }
}