using Xunit;

namespace Assignment
{
    public class AssurantAssignmentTest
    {
        [Fact]
        public void PassingGucciDiscountTaxPostTest()
        {
            Assert.Equal(144.97m, AssurantAssignment.gucciDiscountTaxPost(15,480.00M,110.00M,1090.00M,460.00M,"GA",7));
        }

        [Fact]
        public void FailingGucciDiscountTaxPostTest()
        {
            Assert.NotEqual(69, AssurantAssignment.gucciDiscountTaxPost(15,480.00M,110.00M,1090.00M,460.00M,"GA",7));
        }

        [Fact]
        public void PassingGucciDiscountTaxPreTest()
        {
            Assert.Equal(124.26m, AssurantAssignment.gucciDiscountTaxPost(15,480.00M,110.00M,1090.00M,460.00M,"FL",6));
        }

        [Fact]
        public void FailingGucciDiscountTaxPreTest()
        {
            Assert.NotEqual(111.22m, AssurantAssignment.gucciDiscountTaxPost(15,480.00M,110.00M,1090.00M,460.00M,"GA",7));
        }

        [Fact]
        public void PassingVetPromotionTaxPostTest()
        {
            Assert.Equal(134.82m, AssurantAssignment.vetPromotionTaxPost(10,480.00M,110.00M,1090.00M,460.00M,"GA",7));
        }

        [Fact]
        public void FailingVetPromotionTaxPostTest()
        {
            Assert.NotEqual(144.82m, AssurantAssignment.vetPromotionTaxPost(10,480.00M,110.00M,1090.00M,460.00M,"GA",7));
        }

        [Fact]
        public void PassingVetPromotionTaxPreTest()
        {
            Assert.Equal(128.40m, AssurantAssignment.vetPromotionTaxPre(10,480.00M,110.00M,1090.00M,460.00M,"FL",6));
        }

        [Fact]
        public void FailingVetPromotionTaxPreTest()
        {
            Assert.NotEqual(128.41m, AssurantAssignment.vetPromotionTaxPre(10,480.00M,110.00M,1090.00M,460.00M,"FL",6));
        }

        [Fact]
        public void PassingNoDiscountTest()
        {
            Assert.Equal(149.80m, AssurantAssignment.noDiscount(480.00M,110.00M,1090.00M,460.00M,"GA",7));
        }

        [Fact]
        public void FailingNoDiscountTest()
        {
            Assert.NotEqual(134.82m, AssurantAssignment.noDiscount(480.00M,110.00M,1090.00M,460.00M,"GA",7));
        }
    }
}