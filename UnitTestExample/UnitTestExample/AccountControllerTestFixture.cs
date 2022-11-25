using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnitTestExample.Controllers;

namespace UnitTestExample
{
    public class AccountControllerTestFixture
    {
     
        [Test,
        TestCase("abcd1234", false),
        TestCase("irf@uni-corvinus", false),
        TestCase("irf.uni-corvinus.hu", false),
        TestCase("irf@uni-corvinus.hu", true)
        ]
        public void TestValidateEmail(string email, bool ExprectedResult)
        {

        }
        var arrangeController = new AccountController();
        var actualResult = AccountController.ValidateEmail(email);
        Assert.AreEqual(expectedResult, actualResult);
    }
}
