namespace DEV_6
{
    /// <summary>
    /// Сlass for counting average price.
    /// </summary>
    class AveragePriceCommand : ICommand
    {
        private CarsStock CarsStock { get; set; }

        /// <summary>
        /// Constructor initializes fields.
        /// </summary>
        /// <param name="carsStock">Stock of cars</param>
        public AveragePriceCommand(CarsStock carsStock) => this.CarsStock = carsStock;

        /// <summary>
        /// Calls method for cars stock and displays average price of all cars.
        /// </summary>
        /// <returns></returns>
        public string Execute()
        {
            return CarsStock.GetAveragePrice().ToString();
        }
    }
}
