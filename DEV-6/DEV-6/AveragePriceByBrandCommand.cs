namespace DEV_6
{
    /// <summary>
    /// Сlass for counting average price for a specific brand.
    /// </summary>
    class AveragePriceByBrandCommand : ICommand
    {
        private CarsStock CarsStock { get; set; }
        private string Brand { get; set; }

        /// <summary>
        /// Constructor initializes fields.
        /// </summary>
        /// <param name="carsStock">Stock of cars</param>
        /// <param name="brand">Brand for counting</param>
        public AveragePriceByBrandCommand(CarsStock carsStock, string brand)
        {
            this.CarsStock = carsStock;
            Brand = brand;
        }

        /// <summary>
        /// Calls method for cars stock and displays average price of a specific brand cars.
        /// </summary>
        /// <returns></returns>
        public string Execute()
        {
            return CarsStock.GetAveragePriceByBrand(Brand).ToString();
        }
    }
}
