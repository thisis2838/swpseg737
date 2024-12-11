namespace HoaLacLaptopShop.Models
{
    public class TemporaryResource
    {
        public string ID { get; set; } = null!;
        public int UploaderID { get; set; }
        public string Bag { get; set; } = null!;
        public string Extension { get; set; } = null!;
        public long Length { get; set; }

        public string GetFileName()
        {
            return ID + Extension;
        }
    }
}
