using System;

namespace Tymakov
{
    class Building
    {
        private static uint lastId;
        public readonly uint id;
        public readonly double height;
        public readonly uint apartmentCount;
        public readonly uint floorsCount;
        public readonly uint entrancesCount;

        /// <summary>
        /// Averages the apartments count per floor.
        /// </summary>
        /// <returns>The apartments count per floor.</returns>
        public double AverageApartmentsCountPerFloor()
        {
            return (double)apartmentCount / floorsCount;
        }

        /// <summary>
        /// Averages the apartments count per entrance.
        /// </summary>
        /// <returns>The apartments count per entrance.</returns>
        public double AverageApartmentsCountPerEntrance()
        {
            return (double)apartmentCount / entrancesCount;
        }

        /// <summary>
        /// Averags the floors count per entrance.
        /// </summary>
        /// <returns>The floors count per entrance.</returns>
        public double AveragFloorsCountPerEntrance()
        {
            return (double)floorsCount / entrancesCount;
        }

        /// <summary>
        /// Heights the of the floor.
        /// </summary>
        /// <returns>The of the floor or -1 if parameter bigger then count of the floors</returns>
        /// <param name="number">Number.</param>
        public double HeightOfTheFloor(uint number)
        {
            if (number > floorsCount)
            {
                return -1;
            }

            return height * number / AveragFloorsCountPerEntrance();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Tymakov.Building"/> class.
        /// </summary>
        /// <param name="height">Height.</param>
        /// <param name="apartmentCount">Apartment count.</param>
        /// <param name="entrancesCount">Entrances count.</param>
        /// <param name="floorsCount">Floors count.</param>
        public Building(double height, uint apartmentCount, uint floorsCount, uint entrancesCount)
        {
            if (entrancesCount > floorsCount || floorsCount > apartmentCount || entrancesCount > apartmentCount)
            {
                throw new ArgumentException("Incorrect count of enrances, floors or apartments");
            }

            if (apartmentCount / floorsCount < 2)
            {
                throw new ArgumentException("Impossible height");
            }

            this.height = height;
            this.apartmentCount = apartmentCount;
            this.entrancesCount = entrancesCount;
            this.floorsCount = floorsCount;
            id = lastId++;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Tymakov.Building"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Tymakov.Building"/>.</returns>
        public override string ToString()
        {
            return $"Building №{id}:\n\tHeight: {height} meters\n\tApartments: {apartmentCount}" +
            $"\n\tFloors:{floorsCount}\n\tEntrances: {entrancesCount}";
        }
    }
}
