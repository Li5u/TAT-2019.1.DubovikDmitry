using System;

namespace DEV_5
{
    /// <summary>
    /// Interface for flying objects.
    /// </summary>
    public interface IFlyable
    {
        /// <summary>
        /// This method changes current point of the object.
        /// </summary>
        /// <param name="newPoint">New point</param>
        void FlyTo(Point newPoint);

        /// <summary>
        /// This method returns type to the current object.
        /// </summary>
        /// <returns>Type to the current object</returns>
        IFlyable WhoAmI();

        /// <summary>
        /// THis method calculates time that took the object to fly.
        /// </summary>
        /// <returns>Time of the flight</returns>
        double GetFlyTime();
    }
}