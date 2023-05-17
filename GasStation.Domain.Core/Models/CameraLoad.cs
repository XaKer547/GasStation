namespace GasStation.Domain.Models
{
    public class CameraLoad
    {
        public int Id { get; set; }

        /// <summary>
        /// Дата съемки
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Распознан ли автомобиль
        /// </summary>
        public bool IsRecognized { get; set; }

        /// <summary>
        /// Номер машины
        /// </summary>
        public string? StateNumber { get; set; }

        /// <summary>
        /// Изображение с камеры
        /// </summary>

        //Image
        //
    }
}
