using System.Text;

namespace FlowStockManager.Domain.Entities
{
    public abstract class EntityBase
    {
        public string Id { get; protected set; } = string.Empty;

        protected EntityBase(string id)
        {
            Id = id;
        }

        public static string GenerateId()
        {
            var guid = Guid.NewGuid();
            byte[] bytes = guid.ToByteArray();
            int integerValue = BitConverter.ToInt32(bytes, 0);
            var split = guid.ToString().Split('-');
            var guidString = string.Join("", split);
            var sb = new StringBuilder();
            sb.Append(guidString);
            sb.Append(integerValue);
            return sb.ToString();
        }
    }
}
