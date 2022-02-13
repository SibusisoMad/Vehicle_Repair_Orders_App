using NUnit.Framework;
using System.Collections;
using Vehicle_Repair_Orders_App.Enums;
using Vehicle_Repair_Orders_App.Interfaces;
using Vehicle_Repair_Orders_App.Models;

namespace Vehicle_Repair_Orders_UnitTest
{
    public class OrderProcessingTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestFixture]
        public class MultipleTestExecution
        {
            [TestCaseSource(typeof(OrdersDataClass), nameof(OrdersDataClass.TestCases))]
            public OrderStatus RegressionTest(bool isLargeOrder, bool isNewCustomer, bool isRushOrder, OrderType ? orderType)
            {
                ProcessOrder processOrder = new ProcessOrder();

                processOrder.IsLargeOrder(isLargeOrder);
                processOrder.IsRushOrder(isRushOrder);
                processOrder.OrderType(OrderType.Repair);
                processOrder.IsNewCustomer(isNewCustomer);

                return processOrder.OrderProcessing();
            }
        }

        public class OrdersDataClass
        {
            public static IEnumerable TestCases
            {
                get
                {
                    yield return new TestCaseData(true, true, true, OrderType.Repair).Returns(OrderStatus.Closed);
                    yield return new TestCaseData(true, true, true, OrderType.Hire).Returns(OrderStatus.Closed);
                    yield return new TestCaseData(true, false, false, OrderType.Repair).Returns(OrderStatus.AuthorisationRequired);
                    yield return new TestCaseData(false, true, true, null).Returns(OrderStatus.AuthorisationRequired);
                    yield return new TestCaseData(false, false, false, null).Returns(OrderStatus.Confirmed);
                }
            }
        }

        [Test]
        public void IsRepairLargeOrdersNewCustomerTest()
        {
            ProcessOrder processOrder = new ProcessOrder();

            processOrder.IsLargeOrder(true);
            processOrder.OrderType(OrderType.Repair);
            processOrder.IsNewCustomer(true);
            Assert.AreEqual(OrderStatus.Closed, processOrder.OrderProcessing());
        }

        [Test]
        public void IsLargeRushHireOrdersTest()
        {
            ProcessOrder processOrder = new ProcessOrder();

            processOrder.IsLargeOrder(true);
            processOrder.IsRushOrder(true);
            processOrder.OrderType(OrderType.Hire);
            Assert.AreEqual(OrderStatus.Closed, processOrder.OrderProcessing());
        }

        //[Test]
        //public void IsLargeOrderTest()
        //{
        //    ProcessOrder processOrder = new ProcessOrder();

        //    processOrder.IsLargeOrder(true);
        //    Assert.AreEqual("AuthorisationRequired",processOrder.OrderProcessing());
        //}

        [Test]
        public void IsLargeRepairOrdersTest()
        {
            ProcessOrder processOrder = new ProcessOrder();

            processOrder.IsLargeOrder(true);
            processOrder.OrderType(OrderType.Repair);
            Assert.AreEqual(OrderStatus.AuthorisationRequired, processOrder.OrderProcessing());
        }


        [Test]
        public void IsNewCustomerRushOrdersTest()
        {
            ProcessOrder processOrder = new ProcessOrder();

            processOrder.IsNewCustomer(true);
            processOrder.IsRushOrder(true);
            processOrder.IsLargeOrder(false);
            Assert.AreEqual(OrderStatus.AuthorisationRequired, processOrder.OrderProcessing());
        }

        [Test]
        public void AllOtherOrders()
        {
            ProcessOrder processOrder = new ProcessOrder();

            processOrder.OrderType(OrderType.Repair);
            processOrder.OrderType(OrderType.Hire);
            Assert.AreEqual(OrderStatus.Confirmed, processOrder.OrderProcessing());
        }

    }
}