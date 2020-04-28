using Amazon.Items.EntityFrameworkCore;

namespace Amazon.Items.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly ItemsDbContext _context;

        public TestDataBuilder(ItemsDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}