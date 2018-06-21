using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Myth.Millionaire.Forms.WPF.Startup;
using Telerik.JustMock;
using Telerik.JustMock.AutoMock;

namespace Myth.Millionaire.Forms.WPF.Test {
    /// <summary>
    /// Summary description for JustMockTest
    /// </summary>
    [TestClass]
    public class JustMockTest {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod() {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            Assembly assembly = assemblies.First(s => s.FullName ==
                                  "Myth.Millionaire.Forms.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
            Mock.SetupStatic<Assembly>(Behavior.CallOriginal );
            Mock.Arrange(() => Assembly.GetEntryAssembly()).Returns(assembly);
            
            Assembly test = Assembly.GetEntryAssembly();
            App app = new App();
            app.InitializeComponent();
            app.Run();

            //
            // TODO: Add test logic here
            //
        }
    }
}
