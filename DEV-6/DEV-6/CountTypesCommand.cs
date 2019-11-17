namespace DEV_6
{
    /// <summary>
    /// Сlass for counting number of brands.
    /// </summary>
    class CountTypesCommand : ICommand
    {
        private CarsStock CarsStock { get; set; }

        /// <summary>
        /// Constructor initializes fields.
        /// </summary>
        /// <param name="carsStock">Stock of cars</param>
        public CountTypesCommand(CarsStock carsStock) => this.CarsStock = carsStock;

        /// <summary>
        /// Calls method for cars stock and displays number of brands.
        /// </summary>
        /// <returns>Number of cars</returns>
        public string Execute()
        {
            return CarsStock.CountBrands().ToString();
        }
    }
}
