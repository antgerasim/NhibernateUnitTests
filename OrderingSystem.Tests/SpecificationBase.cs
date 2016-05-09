using NUnit.Framework;

namespace OrderingSystem.Tests
{
    public abstract class SpecificationBase
    {
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            BeforeAllTests();
        }

        [SetUp]
        public void SetUp()
        {
            Given();
            When();
        }

        [TearDown]
        public void TearDown()
        {
            CleanUp();
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            AfterAllTests();
        }

        protected virtual void BeforeAllTests(){ }
        protected virtual void Given(){ }
        protected virtual void When(){ }
        protected virtual void CleanUp(){ }
        protected virtual void AfterAllTests(){ }
    }
}