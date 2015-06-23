namespace Komrad.Revolver.Tests
{
    using Annotations;
    using Annotations.Actions;
    using NUnit.Framework;

    [TestFixture]
    public class AnnotationFactoryTests
    {
        private static AnnotationFactory _factory;

        [TestFixtureSetUp]
        public static void FixtureSetUp()
        {
            _factory = new AnnotationFactory();
        }

        [Test]
        [TestCase("   //   @Komrad.Revolver    If:   sql   ")]
        [TestCase("// @Komrad.Revolver If: sql")]
        [TestCase("//@Komrad.Revolver If:sql")]
        public void ShouldCorrectlyParseSimpleConditionalAnnotation(string input)
        {
            var annotation = _factory.Create(input);

            Assert.NotNull(annotation);
            Assert.IsInstanceOf<ConditionalAnnotation>(annotation);

            var ca = (ConditionalAnnotation) annotation;

            Assert.AreEqual("sql", ca.Condition);
            Assert.IsNull(ca.Action);
        }

        [Test]
        [TestCase("//     @Komrad.Revolver    If:    sqlserver    Then:    [DatabaseType]=sqlserver")]
        [TestCase("// @Komrad.Revolver If: sqlserver Then: [DatabaseType]=sqlserver")]
        [TestCase("//@Komrad.Revolver If:sqlserver Then:[DatabaseType]=sqlserver")]
        public void ShouldCorrectlyParseFullConditionalAnnotation(string input)
        {
            var annotation = _factory.Create(input);

            Assert.NotNull(annotation);
            Assert.IsInstanceOf<ConditionalAnnotation>(annotation);

            var ca = (ConditionalAnnotation) annotation;

            Assert.AreEqual("sqlserver", ca.Condition);
            Assert.IsNotNull(ca.Action);
            Assert.IsInstanceOf<ReplaceAction>(ca.Action);
            Assert.AreEqual("[DatabaseType]=sqlserver", ca.Action.Raw);
        }
    }
}