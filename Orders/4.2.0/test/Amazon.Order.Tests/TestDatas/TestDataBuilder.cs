using Amazon.Order.EntityFrameworkCore;

namespace Amazon.Order.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly OrderDbContext _context;

        public TestDataBuilder(OrderDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}