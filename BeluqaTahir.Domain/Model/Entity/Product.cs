namespace BeluqaTahir.Domain.Model.Entity
{
    public class Product:BaseEntity
    {
   
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string FullName { get; set; }
        public string ShopDescription { get; set; }
       
        public string ImagePati { get; set; }

        public int ProductTypesId { get; set; }
        public virtual ProductTypes ProductTypes { get; set; }


    }
}
