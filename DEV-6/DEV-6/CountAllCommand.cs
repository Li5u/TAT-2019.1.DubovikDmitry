namespace DEV_6
{
    /// <summary>
    /// Сlass for counting number of cars.
    /// </summary>
    class CountAllCommand : ICommand
    {
        private CarsStock CarsStock { get; set; }

        /// <summary>
        /// Constructor initializes fields.
        /// </summary>
        /// <param name="carsStock">Stock of cars</param>
        public CountAllCommand(CarsStock carsStock) => this.CarsStock = carsStock;

        /// <summary>
        /// Calls method for cars stock and displays number of cars.
        /// </summary>
        /// <returns>Number of cars</returns>
        public string Execute()
        {
            return CarsStock.CountCars().ToString();
        }
    }
}
